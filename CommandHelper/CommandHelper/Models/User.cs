using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
