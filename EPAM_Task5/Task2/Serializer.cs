using EPAM_Task5.Task2.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace EPAM_Task5.Task2
{
    public static class Serializer<T>
    {
        public static void SerializeToBinary(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var binarySerializer = new BinaryFormatter();
                binarySerializer.Serialize(fileStream, obj);
            }
        }

        public static void SerializeToXml(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                xmlSerializer.WriteObject(fileStream, obj);
            }
        }

        public static void SerializeToJson(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                jsonSerializer.WriteObject(fileStream, obj);
            }
        }

        public static T DeserializeFromBinary(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var binarySerializer = new BinaryFormatter();
                return (T)binarySerializer.Deserialize(fileStream);
            }
        }

        public static T DeserializeFromXml(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                return (T)xmlSerializer.ReadObject(fileStream);
            }
        }

        public static T DeserializeFromJson(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(fileStream);
            }
        }
    }
}
