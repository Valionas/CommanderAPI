using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.DtoModels
{
    public class DtoLecturerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<LecturerPlatform> LecturePlatforms { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
