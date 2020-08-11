using EPAM_Task5.Task2.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task5_Test.Task2_Test
{
    /// <summary>
    /// Class for testing class WorkersCollection.
    /// </summary>
    public class WorkersCollectionUnitTest
    {
        private WorkersCollection<Worker> _workersCollection;
        private Worker[] _workersArray;

        /// <summary>
        /// Initializes WorkersCollectionUnitTest test objects.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _workersCollection = new WorkersCollection<Worker>(new List<Worker>
            {
                new Worker() { FullName = "fsfsdf", Vacancy = "sgsgsfg", Workplace = "sgsgs", Salary = 1456.29m },
                new Worker() { FullName = "ldmbslk", Vacancy = "sghhgdgs", Workplace = "htyhfbg", Salary = 1856.29m },
                new Worker() { FullName = "gwpgjwn", Vacancy = "pvww", Workplace = "vnxcmvbsdl", Salary = 1996.09m }
            });

            _workersArray = new Worker[]
            {
                new Worker() { FullName = "ldmbslk", Vacancy = "sghhgdgs", Workplace = "htyhfbg", Salary = 1856.29m },
                new Worker() { FullName = "gwpgjwn", Vacancy = "pvww", Workplace = "vnxcmvbsdl", Salary = 1996.09m },
                new Worker(),
            };
        }

        /// <summary>
        /// The method tests method Add.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="vacancy"></param>
        /// <param name="workplace"></param>
        /// <param name="salary"></param>
        [TestCase("Ivan", "Manager", "OOO Vector", 1526.39)]
        [TestCase("Ilya", "Director", "OOO Vector", 2620.99)]
        public void Test_Add(string fullName, string vacancy, string workplace, decimal salary)
        {
            var worker = new Worker { FullName = fullName, Vacancy = vacancy, Workplace = workplace, Salary = salary };
            _workersCollection.Add(worker);
            Assert.AreEqual(_workersCollection[_workersCollection.Count - 1], worker);
        }

        /// <summary>
        /// The method tests method Clear.
        /// </summary>
        [Test]
        public void Test_Clear()
        {
            _workersCollection.Clear();
            var actualResult = 0;
            Assert.AreEqual(_workersCollection.Count, actualResult);
        }

        /// <summary>
        /// The method tests method Contains.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="vacancy"></param>
        /// <param name="workplace"></param>
        /// <param name="salary"></param>
        /// <param name="actualResult">Is contain</param>
        [TestCase("fsfsdf", "sgsgsfg", "sgsgs", 1456.29, true)]
        [TestCase("Ivan", "Manager", "OOO Vector", 1526.39, false)]
        public void Test_Contains(string fullName, string vacancy, string workplace, decimal salary, bool actualResult)
        {
            var worker = new Worker { FullName = fullName, Vacancy = vacancy, Workplace = workplace, Salary = salary };
            bool result = _workersCollection.Contains(worker);
            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method CopyTo.
        /// </summary>
        [Test]
        public void Test_CopyTo()
        {
            var resultArray = new Worker[]
            {
                new Worker() { FullName = "fsfsdf", Vacancy = "sgsgsfg", Workplace = "sgsgs", Salary = 1456.29m },
                new Worker() { FullName = "ldmbslk", Vacancy = "sghhgdgs", Workplace = "htyhfbg", Salary = 1856.29m },
                new Worker() { FullName = "gwpgjwn", Vacancy = "pvww", Workplace = "vnxcmvbsdl", Salary = 1996.09m }
            };

            _workersCollection.CopyTo(_workersArray, 0);
            CollectionAssert.AreEqual(resultArray, _workersArray);
        }

        /// <summary>
        /// The method tests method Remove.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="vacancy"></param>
        /// <param name="workplace"></param>
        /// <param name="salary"></param>
        /// <param name="actualResult">Is removed</param>
        [TestCase("fsfsdf", "sgsgsfg", "sgsgs", 1456.29, true)]
        [TestCase("Ivan", "Manager", "OOO Vector", 1526.39, false)]
        public void Test_Remove(string fullName, string vacancy, string workplace, decimal salary, bool actualResult)
        {
            var worker = new Worker { FullName = fullName, Vacancy = vacancy, Workplace = workplace, Salary = salary };
            bool result = _workersCollection.Remove(worker);
            Assert.AreEqual(result, actualResult);
        }
    }
}
