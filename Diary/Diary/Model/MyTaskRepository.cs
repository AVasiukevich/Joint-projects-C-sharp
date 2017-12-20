using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Diary.Model
{
    public static class MyTaskRepository
    {
        private static ObservableCollection<MyTask> repository;

        public static ObservableCollection<MyTask> Repository
        {
            get
            {
                if (repository == null)
                    LoadXML();
                return repository;
            }
        }
        public static void SaveXML(ObservableCollection<MyTask> rep)
        {
            using (FileStream file = new FileStream("TaskBD.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<MyTask>));
                xmlFormat.Serialize(file, rep);
            }
        }
        public static void LoadXML()
        {
            if (File.Exists("TaskBD.xml"))
            {
                using (FileStream file = new FileStream("TaskBD.xml", FileMode.Open))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<MyTask>));
                    repository = (ObservableCollection<MyTask>)xmlFormat.Deserialize(file);
                }
            }
            else
            {
                repository = new ObservableCollection<MyTask>();
            }
        }
    }
}
