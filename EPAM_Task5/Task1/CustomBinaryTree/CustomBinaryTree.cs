using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPAM_Task5.Task1.CustomBinaryTree
{
    /// <summary>
    /// Class that implements a binary tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomBinaryTree<T> where T : Student
    {
        /// <summary>
        /// Constrictor for initialization binary tree.
        /// </summary>
        /// <param name="studentTestsCollection"></param>
        public CustomBinaryTree(IEnumerable<T> studentTestsCollection)
        {
            foreach (T studentTest in studentTestsCollection)
            {
                this.Add(studentTest);
            }
        }

        /// <summary>
        /// Binary tree root.
        /// </summary>
        public CustomNode<T> Root { get; set; }

        /// <summary>
        /// The method adds a value to the binary tree.
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// The method balances the tree.
        /// </summary>
        public void TreeBalancing()
        {
            List<CustomNode<T>> nodes = new List<CustomNode<T>>();
            ConvertTreeToNodesList(this.Root, nodes);

            int nodesCount = nodes.Count;
            this.Root = ConvertTreeToBalancedTree(nodes, 0, nodesCount - 1);
        }

        /// <summary>
        /// The method converts the tree to the student tests list.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="studentTestsCollection"></param>
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

        /// <summary>
        /// The method converts the tree to the balanced tree.
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Tree root</returns>
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

        /// <summary>
        /// The method converts the tree to the nodes list.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nodes"></param>
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

        /// <summary>
        /// Method for equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
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

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            List<T> thisStudentTests = new List<T>();
            this.ConvertTreeToStudentTestsList(this.Root, thisStudentTests);

            return thisStudentTests.Select(obj => obj.GetHashCode() >> 32).Sum();
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
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
