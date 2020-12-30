using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommandHelper.Models
{
    public class LecturerPlatform
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        
        public int PlatformId { get; set; }
        [JsonIgnore]
        public Platform Platform { get; set; }
    }
}
