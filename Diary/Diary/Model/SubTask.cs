using System;

namespace Diary.Model
{
    [Serializable]
    public class SubTask
    {
        private string description;
        private bool isReady;

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public bool IsReady
        {
            get
            {
                return isReady;
            }
            set
            {
                isReady = value;
            }
        }
        public SubTask()
        {}

        public override string ToString()
        {
            return String.Format($"{description}");
        }
    }
}
