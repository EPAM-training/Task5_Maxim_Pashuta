using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPAM_Task5.Task1.CustomBinaryTree
{
    public class CustomBinaryTree<T> where T : Student
    {
        public CustomBinaryTree(IEnumerable<T> studentTestsCollection)
        {
            foreach (T studentTest in studentTestsCollection)
            {
                this.Add(studentTest);
            }
        }

        public CustomNode<T> Root { get; set; }

        public void Add(T value)
        {
            CustomNode<T> nextNode = this.Root;
            CustomNode<T> prevNode = null;

            while (nextNode != null)
            {
                prevNode = nextNode;

                if (nextNode.Data.CompareTo(value) == -1)
                {
                    nextNode = nextNode.RightNode;
                }
                else if (nextNode.Data.CompareTo(value) == 1)
                {
                    nextNode = nextNode.LeftNode;
                }
                else
                {
                    throw new ArgumentException("This element already exists in the binary tree.");
                }
            }

            CustomNode<T> newNode = new CustomNode<T>(value);

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (prevNode.Data.CompareTo(value) == -1)
                {
                    prevNode.RightNode = newNode;
                }
                else
                {
                    prevNode.LeftNode = newNode;
                }
            }
        }

        public void TreeBalancing()
        {
            List<CustomNode<T>> nodes = new List<CustomNode<T>>();
            ConvertTreeToNodesList(this.Root, nodes);

            int nodesCount = nodes.Count;
            this.Root = ConvertTreeToBalancedTree(nodes, 0, nodesCount - 1);
        }

        public void ConvertTreeToStudentTestsList(CustomNode<T> node, IList<T> studentTestsCollection)
        {
            if (node == null)
            {
                return;
            }

            studentTestsCollection.Add(node.Data);
            ConvertTreeToStudentTestsList(node.LeftNode, studentTestsCollection);
            ConvertTreeToStudentTestsList(node.RightNode, studentTestsCollection);
        }

        private CustomNode<T> ConvertTreeToBalancedTree(List<CustomNode<T>> nodes, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;
            CustomNode<T> node = nodes[middle];

            node.LeftNode = ConvertTreeToBalancedTree(nodes, start, middle - 1);
            node.RightNode = ConvertTreeToBalancedTree(nodes, middle + 1, end);

            return node;
        }

        private void ConvertTreeToNodesList(CustomNode<T> root, List<CustomNode<T>> nodes)
        {
            if (root == null)
            {
                return;
            }

            ConvertTreeToNodesList(root.LeftNode, nodes);
            nodes.Add(root);
            ConvertTreeToNodesList(root.RightNode, nodes);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            CustomBinaryTree<Student> binaryTree = (CustomBinaryTree<Student>)obj;

            List<Student> newStudentTests = new List<Student>();
            List<T> thisStudentTests = new List<T>();
            binaryTree.ConvertTreeToStudentTestsList(binaryTree.Root, newStudentTests);
            this.ConvertTreeToStudentTestsList(this.Root, thisStudentTests);

            if (thisStudentTests.Count != newStudentTests.Count)
            {
                return false;
            }

            for (var i = 0; i < newStudentTests.Count; i++)
            {
                if (!newStudentTests[i].Equals(thisStudentTests[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            List<T> thisStudentTests = new List<T>();
            this.ConvertTreeToStudentTestsList(this.Root, thisStudentTests);

            return thisStudentTests.Select(obj => obj.GetHashCode() >> 32).Sum();
        }

        public override string ToString()
        {
            List<T> thisStudentTests = new List<T>();
            this.ConvertTreeToStudentTestsList(this.Root, thisStudentTests);

            var stringBuilder = new StringBuilder();

            foreach (T studentTest in thisStudentTests)
            {
                stringBuilder.Append(studentTest);
                stringBuilder.Append("\n\n");
            }

            return stringBuilder.ToString();
        }
    }
}
