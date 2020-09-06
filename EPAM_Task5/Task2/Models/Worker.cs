using EPAM_Task5.Task2.Interfaces;
using System;
using System.Runtime.Serialization;

namespace EPAM_Task5.Task2.Models
{
    /// <summary>
    /// Class describes worker.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Worker : ISerialize
    {
        public Worker()
        {
        }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Workplace { get; set; }

        [DataMember]
        public string Vacancy { get; set; }

        [DataMember(Order = 2)]
        public decimal Salary { get; set; }

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

            var worker = (Worker)obj;

            return ((worker.FullName == this.FullName) && (worker.Workplace == this.Workplace) &&
                    (worker.Vacancy == this.Vacancy) && (worker.Salary == this.Salary));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (FullName.GetHashCode() ^ Workplace.GetHashCode() ^ Vacancy.GetHashCode() ^ Salary.GetHashCode());
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"FullName: {this.FullName}\n" +
                                 $"Workplace: {this.Workplace}\n" +
                                 $"Vacancy: {this.Vacancy}\n" +
                                 $"Salary: {this.Salary,6:f2}");
        }

        /// <summary>
        /// The method sets a value to Salary if Salary is null.
        /// </summary>
        /// <param name="context"></param>
        [OnDeserializing]
        private void SetSalaryDefault(StreamingContext context)
        {
            Salary = 15.23m;
        }
    }
}
