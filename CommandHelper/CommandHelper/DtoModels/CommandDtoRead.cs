using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.DtoModels
{
    public class CommandDtoRead
    {
        public int Id { get; set; }
    
        public string HowTo { get; set; }
      
        public string Line { get; set; }

        public PlatformDto Platform { get; set; }
      
    }
}
