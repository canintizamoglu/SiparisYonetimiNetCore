using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required, Display(Name = "Name")]
        public string Name { get; set; }
        [StringLength(50), Required, Display(Name = "Surname")]
        public string Surname { get; set; }
        [StringLength(50), Required]
        public string Email { get; set; }
        [StringLength(15), Display(Name = "Phone")]
        public string? Phone { get; set; }
        [StringLength(500), Display(Name = "Address")]
        public string? Address { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Date Added"), ScaffoldColumn(false)] // ScaffoldColumn(false) kodu mvc de ekranları oluştururken CreateDate için ekranda alan oluşmasını engeller
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
