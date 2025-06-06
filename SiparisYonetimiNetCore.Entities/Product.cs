using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Required, Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Product Description")]
        public string? Description { get; set; }
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }
        [Display(Name = "Stock")]
        public int Stock { get; set; }
        [StringLength(150)]
        [Display(Name = "Image Product")]
        public string? Image { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Home Page")]
        public bool IsHome { get; set; }
        [Display(Name = "Product Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Product Brand")]
        public int BrandId { get; set; }
        [Display(Name = "Product Brand")]
        public virtual Brand? Brand { get; set; }
        [Display(Name = "Product Brand")]
        public virtual Category? Category { get; set; } // Ürün classı üzerinden ürünün kategori bilgisine entity framework ile ulaşabilmek için
        [Display(Name = "Date Add"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
