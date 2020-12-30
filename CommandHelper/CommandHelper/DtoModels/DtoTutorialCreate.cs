using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.DtoModels
{
    public class DtoTutorialCreate
    {
 
        public string TutorialName { get; set; }
        public string Difficulty { get; set; }
        public bool IsActive { get; set; }

        public Event Event { get; set; }
    }
}
