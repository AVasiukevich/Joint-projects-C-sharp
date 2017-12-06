using System;

namespace Diary.Model
{
    public class New
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

        public New(string header, string body = null, string url = null)
        {
            this.header = header;
            this.body = body;
            this.url = url;
        }

        public override string ToString()
        {
            return String.Format($"{header}"+ Environment.NewLine + $"{body}" + Environment.NewLine + $"{url}");
        }
    }
}
