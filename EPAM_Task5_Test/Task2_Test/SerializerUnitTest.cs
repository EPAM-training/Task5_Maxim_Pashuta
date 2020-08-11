using EPAM_Task5.Task2;
using EPAM_Task5.Task2.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace EPAM_Task5_Test.Task2_Test
{
    /// <summary>
    /// Class for testing class Serializer.
    /// </summary>
    public class SerializerUnitTest
    {
        private string _xmlFilePath;
        private string _binaryFilePath;
        private string _jsonFilePath;
        private string _xmlFileCollectionPath;
        private string _binaryFileCollectionPath;
        private string _jsonFileCollectionPath;
        private Worker _worker;
        private WorkersCollection<Worker> _workersCollection;

        /// <summary>
        /// Initializes SerializerUnitTest test objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _binaryFilePath = @"..\..\..\..\EPAM_Task5\Task2\Resources\BinaryFile.dat";
            _xmlFilePath = @"..\..\..\..\EPAM_Task5\Task2\Resources\XmlFile.xml";
            _jsonFilePath = @"..\..\..\..\EPAM_Task5\Task2\Resources\JsonFile.json";

            _binaryFileCollectionPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\BinaryFileCollection.dat";
            _xmlFileCollectionPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\XmlFileCollection.xml";
            _jsonFileCollectionPath = @"..\..\..\..\EPAM_Task5\Task2\Resources\JsonFileCollection.json";

            _worker = new Worker() { FullName = "Ivan", Vacancy = "gsfgaaaaa", Workplace = "OOO" };

            _workersCollection = new WorkersCollection<Worker>(new List<Worker>
            {
                new Worker() { FullName = "fsfsdf", Vacancy = "sgsgsfg", Workplace = "sgsgs" },
                new Worker() { FullName = "ldmbslk", Vacancy = "sghhgdgs", Workplace = "htyhfbg" },
                new Worker() { FullName = "gwpgjwn", Vacancy = "pvww", Workplace = "vnxcmvbsdl" }
            });
        }

        /// <summary>
        /// The method tests method SerializeToBinary with WorkersCollection and Worker.
        /// </summary>
        [Test]
        public void Test_SerializeCollectionAndObjectToBinaryFile()
        {
            Serializer<WorkersCollection<Worker>>.SerializeToBinary(_binaryFileCollectionPath, _workersCollection);
            Serializer<Worker>.SerializeToBinary(_binaryFilePath, _worker);
            var fileInfoCollection = new FileInfo(_binaryFileCollectionPath);
            var fileInfoObject = new FileInfo(_binaryFilePath);
            Assert.IsTrue(fileInfoCollection.Length > 0);
            Assert.IsTrue(fileInfoObject.Length > 0);
        }

        /// <summary>
        /// The method tests method DeserializeFromBinary with WorkersCollection and Worker.
        /// </summary>
        [Test]
        public void Test_DeserializeCollectionAndObjectFromBinaryFile()
        {
            WorkersCollection<Worker> resultCollection = Serializer<WorkersCollection<Worker>>.DeserializeFromBinary(_binaryFileCollectionPath);
            Worker result = Serializer<Worker>.DeserializeFromBinary(_binaryFilePath);
            Assert.AreEqual(resultCollection, _workersCollection);
            Assert.AreEqual(result, _worker);
        }

        /// <summary>
        /// The method tests method SerializeToXml with WorkersCollection and Worker.
        /// </summary>
        [Test]
        public void Test_SerializeCollectionAndObjectToXmlFile()
        {
            Serializer<WorkersCollection<Worker>>.SerializeToXml(_xmlFileCollectionPath, _workersCollection);
            Serializer<Worker>.SerializeToXml(_xmlFilePath, _worker);
            var fileInfoCollection = new FileInfo(_xmlFileCollectionPath);
            var fileInfoObject = new FileInfo(_xmlFilePath);
            Assert.IsTrue(fileInfoCollection.Length > 0);
            Assert.IsTrue(fileInfoObject.Length > 0);
        }

        /// <summary>
        /// The method tests method DeserializeFromXml with WorkersCollection and Worker.
        /// </summary>
        [Test]
        public void Test_DeserializeCollectionAndObjectFromXmlFile()
        {
            WorkersCollection<Worker> resultCollection = Serializer<WorkersCollection<Worker>>.DeserializeFromXml(_xmlFileCollectionPath);
            Worker result = Serializer<Worker>.DeserializeFromXml(_xmlFilePath);
            Assert.AreEqual(resultCollection, _workersCollection);
            Assert.AreEqual(result, _worker);
        }

        /// <summary>
        /// The method tests method SerializeToJson with WorkersCollection and Worker.
        /// </summary>
        [Test]
        public void Test_SerializeCollectionAndObjectToJsonFile()
        {
            Serializer<WorkersCollection<Worker>>.SerializeToJson(_jsonFileCollectionPath, _workersCollection);
            Serializer<Worker>.SerializeToJson(_jsonFilePath, _worker);
            var fileInfoCollection = new FileInfo(_jsonFileCollectionPath);
            var fileInfoObject = new FileInfo(_jsonFilePath);
            Assert.IsTrue(fileInfoCollection.Length > 3);
            Assert.IsTrue(fileInfoObject.Length > 3);
        }

        /// <summary>
        /// The method tests method DeserializeFromJson with WorkersCollection and Worker.
        /// </summary>
        [Test]
        public void Test_DeserializeCollectionAndObjectFromJsonFile()
        {
            WorkersCollection<Worker> resultCollection = Serializer<WorkersCollection<Worker>>.DeserializeFromJson(_jsonFileCollectionPath);
            Worker result = Serializer<Worker>.DeserializeFromJson(_jsonFilePath);
            Assert.AreEqual(resultCollection, _workersCollection);
            Assert.AreEqual(result, _worker);
        }
    }
}
