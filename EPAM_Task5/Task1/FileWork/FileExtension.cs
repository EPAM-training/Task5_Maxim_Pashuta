using EPAM_Task5.Task1.CustomBinaryTree;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EPAM_Task5.Task1.FileWork
{
    public static class FileExtension
    {
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
