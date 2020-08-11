using EPAM_Task5.Task1;
using EPAM_Task5.Task1.CustomBinaryTree;
using EPAM_Task5.Task1.FileWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace EPAM_Task5_Test.Task1_Test
{
    /// <summary>
    /// Class for testing class FileExtension.
    /// </summary>
    public class FileExtensionUnitTest
    {
        private string _filePath;
        private string _xmlFileContent;
        private CustomBinaryTree<Student> _binaryTree;

        /// <summary>
        /// Initializes FileExtensionUnitTest test objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _filePath = @"..\..\..\..\EPAM_Task5\Task1\Resources\BinaryTree.xml";

            var studentTests = new List<Student>
            {
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 87 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 45 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 13 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 92 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 33 },
            };

            _binaryTree = new CustomBinaryTree<Student>(studentTests);

            _xmlFileContent = "<?xml version=\"1.0\"?>\r\n" +
                              "<ArrayOfStudent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>fsdffs</StudentName>\r\n" +
                              "    <TestName>mkgkfng</TestName>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Result>87</Result>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>fsdffs</StudentName>\r\n" +
                              "    <TestName>mkgkfng</TestName>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Result>45</Result>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>fsdffs</StudentName>\r\n" +
                              "    <TestName>mkgkfng</TestName>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Result>13</Result>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>fsdffs</StudentName>\r\n" +
                              "    <TestName>mkgkfng</TestName>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Result>33</Result>\r\n" +
                              "  </Student>\r\n" +
                              "  <Student>\r\n" +
                              "    <StudentName>fsdffs</StudentName>\r\n" +
                              "    <TestName>mkgkfng</TestName>\r\n" +
                              "    <Date>2012-10-23T00:00:00</Date>\r\n" +
                              "    <Result>92</Result>\r\n" +
                              "  </Student>\r\n" +
                              "</ArrayOfStudent>";
        }

        /// <summary>
        /// The method tests method SerializeBinaryTree.
        /// </summary>
        [Test]
        public void Test_SerializeBinaryTree()
        {
            FileExtension.SerializeBinaryTree(_filePath, _binaryTree);

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(_filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = _xmlFileContent;
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method DeserializeBinaryTree.
        /// </summary>
        [Test]
        public void Test_DeserializeBinaryTree()
        {
            CustomBinaryTree<Student> newBinaryTree = FileExtension.DeserializeBinaryTree(_filePath);
            Assert.AreEqual(newBinaryTree, _binaryTree);
        }
    }
}
