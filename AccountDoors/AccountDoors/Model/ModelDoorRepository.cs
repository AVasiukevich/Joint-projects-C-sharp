using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace AccountDoors.Model
{
    public static class ModelDoorRepository
    {
        private static ObservableCollection<ModelDoor> repository;

        public static ObservableCollection<ModelDoor> Repository
        {
            get
            {
                if (repository == null)
                    LoadXML();
                return repository;
            }
        }

        public static void SaveXML()
        {
            using (FileStream file = new FileStream("DoorsBD.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<ModelDoor>));
                xmlFormat.Serialize(file, repository);
            }
        }
        public static void LoadXML()
        {
            if (File.Exists("DoorsBD.xml"))
            {
                using (FileStream file = new FileStream("DoorsBD.xml", FileMode.Open))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<ModelDoor>));
                    repository = (ObservableCollection<ModelDoor>)xmlFormat.Deserialize(file);
                }
            }
            else
            {
                repository = new ObservableCollection<ModelDoor>();
            }
        }
    }
}
