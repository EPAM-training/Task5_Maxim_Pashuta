using EPAM_Task5.Task1.CustomBinaryTree;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EPAM_Task5.Task1.FileWork
{
    /// <summary>
    /// Class for writing and reading the binary tree.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// The method reads the binary tree from xml file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="binaryTree"></param>
        public static void SerializeBinaryTree(string filePath, CustomBinaryTree<Student> binaryTree)
        {
            var studentTests = new List<Student>();
            binaryTree.ConvertTreeToStudentTestsList(binaryTree.Root, studentTests);

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(studentTests.GetType());
                xmlSerializer.Serialize(stream, studentTests);
            }
        }

        /// <summary>
        /// The method writes the binary tree to xml file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static CustomBinaryTree<Student> DeserializeBinaryTree(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                var studentTests = (List<Student>)xmlSerializer.Deserialize(stream);
                return new CustomBinaryTree<Student>(studentTests);
            }
        }
    }
}
