using System;

namespace Diary.Model
{
    public class SubTask
    {
        private string description;
        private bool isReady;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public bool IsReady
        {
            get { return isReady; }
            set { isReady = value; }
        }

        public override string ToString()
        {
            return String.Format($"{description}");
        }
    }
}
