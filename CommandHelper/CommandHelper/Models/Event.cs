using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartLecture { get; set; }
        public DateTime EndLecture { get; set; }
       
        public int? TutorialId { get; set; }

        public Tutorial Tutorial { get; set; }
    }
}
