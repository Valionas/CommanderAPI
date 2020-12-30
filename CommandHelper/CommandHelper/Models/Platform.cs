using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommandHelper.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        [JsonIgnore]
        public ICollection<LecturerPlatform> LecturePlatforms { get; set; }

    }
}
