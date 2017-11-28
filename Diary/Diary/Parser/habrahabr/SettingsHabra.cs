using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Parser.habrahabr
{
    class SettingsHabra : IParserSettings
    {

        public SettingsHabra(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://habrahabr.ru";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int EndPoint { get; set; }
        public int StartPoint { get; set; }
    }
}
