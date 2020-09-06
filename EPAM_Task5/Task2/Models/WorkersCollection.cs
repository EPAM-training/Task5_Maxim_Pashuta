using EPAM_Task5.Task2.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EPAM_Task5.Task2.Models
{
    /// <summary>
    /// Class for working workers collection.
    /// </summary>
    /// <typeparam name="T">Worker</typeparam>
    [Serializable]
    [DataContract]
    public class WorkersCollection<T> : ICollection<T>, ISerialize where T : Worker
    {
        [DataMember]
        private List<T> _workers;

        /// <summary>
        /// Constructor to initialise workers collection.
        /// </summary>
        /// <param name="workersCollection"></param>
        public WorkersCollection(IEnumerable<T> workersCollection)
        {
            _workers = workersCollection.ToList();
        }

        /// <summary>
        /// Indexator for interacting with the workers collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Worker</returns>
        public T this[int index]
        {
            get => _workers[index];
            set => _workers[index] = value;
        }

        public int Count => _workers.Count;

        public bool IsReadOnly => false;

        /// <summary>
        /// The method adds worker to the workers collection.
        /// </summary>
        /// <param name="item">worker</param>
        public void Add(T item)
        {
            _workers.Add(item);
        }

        /// <summary>
        /// The method clears the workers collection.
        /// </summary>
        public void Clear()
        {
            _workers.Clear();
        }

        /// <summary>
        /// The method checks if the worker is contained in the workers collection.
        /// </summary>
        /// <param name="item">Worker</param>
        /// <returns>True or False</returns>
        public bool Contains(T item)
        {
            return _workers.Contains(item);
        }

        /// <summary>
        /// The method copys the workers collection into array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _workers.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The method gets enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _workers.GetEnumerator();
        }

        /// <summary>
        /// The method removes the worker from the workers collection.
        /// </summary>
        /// <param name="item">Worker</param>
        /// <returns>True or False</returns>
        public bool Remove(T item)
        {
            return _workers.Remove(item);
        }

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

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return _workers.Select(obj => obj.GetHashCode() >> 32).Sum();
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
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
