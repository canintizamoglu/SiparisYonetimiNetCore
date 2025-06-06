using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Required, Display(Name = "Brand Name")]
        public string Name { get; set; }
        [StringLength(100)]
        public string? Logo { get; set; }
        [Display(Name = "Brand Description")]
        public string? Description { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Date Added"), ScaffoldColumn(false)] // view larda bu kolon oluşmasın!
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual List<Product>? Products { get; set; }
    }
}
