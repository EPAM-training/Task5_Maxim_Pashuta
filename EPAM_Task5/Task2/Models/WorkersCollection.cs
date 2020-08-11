using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EPAM_Task5.Task2.Models
{
    [Serializable]
    [DataContract]
    public class WorkersCollection<T> : ICollection<T> where T : Worker
    {
        [DataMember]
        private List<T> _workers;

        public WorkersCollection(IEnumerable<T> workers)
        {
            _workers = workers.ToList();
        }

        public T this[int index]
        {
            get => _workers[index];
            set => _workers[index] = value;
        }

        public int Count => _workers.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _workers.Add(item);
        }

        public void Clear()
        {
            _workers.Clear();
        }

        public bool Contains(T item)
        {
            return _workers.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _workers.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _workers.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _workers.Remove(item);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            var workersCollection = (WorkersCollection<Worker>)obj;

            if (Count != workersCollection.Count)
            {
                return false;
            }

            for (var i = 0; i < Count; i++)
            {
                if (!_workers[i].Equals(workersCollection._workers[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return _workers.Select(obj => obj.GetHashCode() >> 32).Sum();
        }

        public override string ToString()
        {
            var workersString = "Workers:\n\n";

            foreach (Worker worker in _workers)
            {
                workersString += worker.ToString() + "\n\n";
            }

            return workersString;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
