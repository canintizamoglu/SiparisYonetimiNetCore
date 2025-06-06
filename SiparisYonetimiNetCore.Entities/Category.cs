using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Required, Display(Name = "Category Name")]
        public string Name { get; set; }
        [Display(Name = "Category Description")]
        public string? Description { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Date Added"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual List<Product>? Products { get; set; }
    }
}
