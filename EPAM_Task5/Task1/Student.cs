using System;
using System.Diagnostics.CodeAnalysis;

namespace EPAM_Task5.Task1
{
    [Serializable]
    public class Student : IComparable<Student>
    {
        private int _result;

        public string StudentName { get; set; }

        public string TestName { get; set; }

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

        public int CompareTo([AllowNull] Student other)
        {
            return Result.CompareTo(other.Result);
        }

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

        public override int GetHashCode()
        {
            return (StudentName.GetHashCode() ^ TestName.GetHashCode() ^ Date.GetHashCode() ^ Result.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format($"Student Name: {StudentName}\n" +
                                 $"Test Name: {TestName}\n" +
                                 $"Date: {Date:dd.MM.yyyy}\n" +
                                 $"Result Test: {Result}");
        }
    }
}
