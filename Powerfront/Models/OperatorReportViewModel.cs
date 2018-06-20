using Powerfront.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerfront.Models
{
    public class OperatorReportViewModel 
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public int ProactiveSent { get; set; }
        public int ProactiveAnswered { get; set; }
        public int ProactiveResponseRate { get; set; }
        public int ReactiveReceived { get; set; }
        public int ReactiveAnswered { get; set; }
        public int ReactiveResponseRate { get; set; }
        public string TotalChatLength { get; set; }
        public string AverageChatLength { get; set; }
    }

   
}