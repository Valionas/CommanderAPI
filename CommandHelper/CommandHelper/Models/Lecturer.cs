using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
         [JsonIgnore]
        public ICollection<LecturerPlatform> LecturePlatforms { get; set; }
       
        public ICollection<Event> Events { get; set; }

    }
}
