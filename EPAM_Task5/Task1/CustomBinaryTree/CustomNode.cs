namespace EPAM_Task5.Task1.CustomBinaryTree
{
    public class CustomNode<T>
    {
        public CustomNode(T data)
        {
            LeftNode = null;
            RightNode = null;
            Data = data;
        }

        public CustomNode<T> LeftNode { get; set; }

        public CustomNode<T> RightNode { get; set; }

        public T Data { get; set; }
    }
}
