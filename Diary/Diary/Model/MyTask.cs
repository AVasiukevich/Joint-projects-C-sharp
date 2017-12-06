using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Model
{
    class MyTask
    {
        private string name;
        private TimeSpan? time_interval;
        private DateTime? date;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public TimeSpan? Time_interval
        {
            get { return time_interval; }
            set { time_interval = value; }
        }
        public DateTime? Date
        {
            get { return date; }
            set { date = value; }
        }

        public MyTask(string name) : this(name, null, null)
        {}
        public MyTask(string name, DateTime date) : this(name, date, null)
        {}
        public MyTask(string name, DateTime? date, TimeSpan? time_interval)
        {
            this.name = name;
            this.date = date;
            this.time_interval = time_interval;
        }
    }
}
