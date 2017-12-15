using Lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Services
{
    class NodeService
    {
        public static List<UINodeModel> Load(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (List<UINodeModel>)formatter.Deserialize(fs);
                Console.WriteLine("Deserialized");
            }
        }
        public static bool Save(string path, List<UINodeModel> item)
        {
            BinaryFormatter serializer = new BinaryFormatter();

            FileStream fs = new FileStream(path, FileMode.Create);
            try
            {
                serializer.Serialize(fs, item);
                Console.WriteLine("Serialized");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                return false;
            }
            finally
            {
                fs.Close();
            }
            return true;
        }
    }
}
