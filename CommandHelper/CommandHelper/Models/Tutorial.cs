using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Models
{
    public class Tutorial
    {
        public int Id { get; set; }
        public string TutorialName { get; set; }
        public string Difficulty { get; set; }
        public bool IsActive { get; set; }
        
        public Event Event { get; set; }
    }
}
