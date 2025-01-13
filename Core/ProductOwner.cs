using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public  class ProductOwner
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string OwnerADObjectId { get; set; }
        [MaxLength(1000)]
        public string OwnerName { get; set; }
    }
}
