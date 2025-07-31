using System.ComponentModel.DataAnnotations;

namespace AkademikAi.Web.Models
{
    public class UpdateProfileViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş olamaz.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş olamaz.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Numara alanı boş olamaz.")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
