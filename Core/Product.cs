using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(1000)]
        public string Name { get; set; }
        [Required]
        [MinLength(100), MaxLength(8000)]
        public string Descriptions { get; set; }
        [Range(5, 9000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime AvailableSince { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(200)]
        public string CreatedBy { get; set; } 
        public DateTime ModifiedDate { get; set; }
        [MaxLength(200)]
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public short? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? ProductOwnerId { get; set; }

        public virtual ProductOwner ProductOwner { get; set; }

        public virtual List<ProductImage> ProductImages { get; set; }

       
    }
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Mime { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }


    }

}
