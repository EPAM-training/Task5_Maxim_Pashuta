using System;
using System.Diagnostics.CodeAnalysis;

namespace EPAM_Task5.Task1
{
    /// <summary>
    /// Class for working a student.
    /// </summary>
    public class Student : IComparable<Student>
    {
        /// <summary>
        /// Test result.
        /// </summary>
        private int _result;

        /// <summary>
        /// Student name.
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Test name.
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Test date.
        /// </summary>
        public DateTime Date { get; set; }

        public int Result
        {
            get => _result;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("The test result must be between 0 and 100.");
                }

                _result = value;
            }
        }

        /// <summary>
        /// The method for sort list.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] Student other)
        {
            return Result.CompareTo(other.Result);
        }

        /// <summary>
        /// Method for equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            var studentTest = (Student)obj;

            return ((studentTest.StudentName == StudentName) &&
                    (studentTest.TestName == TestName) &&
                    (studentTest.Date == Date) &&
                    (studentTest.Result == Result));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (StudentName.GetHashCode() ^ TestName.GetHashCode() ^ Date.GetHashCode() ^ Result.GetHashCode());
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"Student Name: {StudentName}\n" +
                                 $"Test Name: {TestName}\n" +
                                 $"Date: {Date:dd.MM.yyyy}\n" +
                                 $"Result Test: {Result}");
        }
    }
}
