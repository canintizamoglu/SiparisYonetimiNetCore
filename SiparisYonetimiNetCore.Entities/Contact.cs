using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Name"), Required(ErrorMessage = "{0} Cannot be left blank!")]
        public string Name { get; set; }
        [Display(Name = "Surname"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} Cannot be left blank!")]
        public string Email { get; set; }
        [Display(Name = "Message"), Required(ErrorMessage = "{0} Cannot be left blank!")]
        public string Message { get; set; }
        [Display(Name = "Message date"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
