using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.DtoModels
{
    public class EventDTO
    {
        public DateTime StartLecture { get; set; }
        public DateTime EndLecture { get; set; }

        public int? TutorialId { get; set; }
        public Tutorial Tutorial { get; set; }
    }
}
