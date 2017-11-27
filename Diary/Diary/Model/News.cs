using System;

namespace Diary.Model
{
    public class News
    {
        private string header;
        private string body;
        private string url;

        public string URL
        {
            get { return url; }
            set { url = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        public override string ToString()
        {
            return String.Format($"{header}"+ Environment.NewLine + $"{body}" + Environment.NewLine + $"{url}");
        }
    }
}
