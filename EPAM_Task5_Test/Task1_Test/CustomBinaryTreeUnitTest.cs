using EPAM_Task5.Task1;
using EPAM_Task5.Task1.CustomBinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EPAM_Task5_Test.Task1_Test
{
    public class CustomBinaryTreeUnitTest
    {
        private List<Student> _studentTests;
        private CustomBinaryTree<Student> _binaryTree;

        [SetUp]
        public void Setup()
        {
            _studentTests = new List<Student>
            {
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 87 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 45 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 13 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 92 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 33 },
            };

            _binaryTree = new CustomBinaryTree<Student>(_studentTests);
        }

        [Test]
        public void Test_CustomBinaryTree()
        {
            var result = new CustomBinaryTree<Student>(_studentTests);

            Assert.AreEqual(result, _binaryTree);
        }

        [Test]
        public void Test_Add()
        {
            var studentTest = new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 56 };
            _binaryTree.Add(studentTest);

            var actualResult = new CustomBinaryTree<Student>(_studentTests);
            actualResult.Add(studentTest);

            Assert.AreEqual(_binaryTree, actualResult);
        }

        [Test]
        public void Test_Add_ThrowArgumentException()
        {
            var studentTest = new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 87 };
            Assert.That(() => _binaryTree.Add(studentTest), Throws.ArgumentException);
        }

        [Test]
        public void Test_TreeBalancing()
        {
            var studentTests = new List<Student>
            {
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 45 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 87 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 13 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 92 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 33 },
            };

            var actualResult = new CustomBinaryTree<Student>(studentTests);

            _binaryTree.TreeBalancing();

            Assert.AreEqual(_binaryTree, actualResult);
        }

        [Test]
        public void Test_ConvertTreeToStudentTestsList()
        {
            var actualResult = new List<Student>
            {
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 87 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 45 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 13 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 33 },
                new Student { StudentName = "fsdffs", TestName = "mkgkfng", Date = new DateTime(2012, 10, 23), Result = 92 },
            };

            var result = new List<Student>();
            _binaryTree.ConvertTreeToStudentTestsList(_binaryTree.Root, result);

            Assert.AreEqual(result, actualResult);
        }
    }
}