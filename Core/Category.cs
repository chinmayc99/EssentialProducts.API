using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Category
    {
        public short Id { get; set; }

        [Required]
        [MinLength(5),MaxLength(500)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
