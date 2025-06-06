        using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Required!"), Display(Name = "Name")] // Veritabanında oluşan kolonun nvarcharmax yerine nvarchar(50) olması için
        public string Name { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Required!"), Display(Name = "Surname")]
        public string Surname { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Required!")]
        public string Email { get; set; }
        [StringLength(15), Display(Name = "Phone")]
        public string? Phone { get; set; }
        [StringLength(50), Display(Name = "Username")]
        public string? Username { get; set; }
        [StringLength(50), Display(Name = "Password"), Required(ErrorMessage = "{0} Required!")]
        public string Password { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Date Added"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
