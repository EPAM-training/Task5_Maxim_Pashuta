using System;
using System.Runtime.Serialization;

namespace EPAM_Task5.Task2.Models
{
    [Serializable]
    [DataContract]
    public class Worker
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

        public override int GetHashCode()
        {
            return (FullName.GetHashCode() ^ Workplace.GetHashCode() ^ Vacancy.GetHashCode() ^ Salary.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format($"FullName: {this.FullName}\n" +
                                 $"Workplace: {this.Workplace}\n" +
                                 $"Vacancy: {this.Vacancy}\n" +
                                 $"Salary: {this.Salary,6:f2}");
        }

        [OnDeserializing]
        private void OnDeserialized(StreamingContext context)
        {
            Salary = 15.23m;
        }
    }
}
