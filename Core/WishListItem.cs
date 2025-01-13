using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class WishListItem
    {
        public long Id { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        [MaxLength(200)]
        public string OwnerADObjectId { get; set; }
    }
}
