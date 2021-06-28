using System;

namespace HiveBoxCodeExtractor
{
    public class HiveCodeEvent
    {
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int BoxNumber { get; set; }

        public string openCode { get; set; }

        public string vendor { get; set; }
    }
}
