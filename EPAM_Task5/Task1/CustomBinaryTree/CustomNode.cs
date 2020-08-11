namespace EPAM_Task5.Task1.CustomBinaryTree
{
    /// <summary>
    /// Class that implements a node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomNode<T>
    {
        /// <summary>
        /// Constructor for initialization the node.
        /// </summary>
        /// <param name="data"></param>
        public CustomNode(T data)
        {
            LeftNode = null;
            RightNode = null;
            Data = data;
        }

        /// <summary>
        /// Left node.
        /// </summary>
        public CustomNode<T> LeftNode { get; set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public CustomNode<T> RightNode { get; set; }

        /// <summary>
        /// Node value.
        /// </summary>
        public T Data { get; set; }
    }
}
