using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get; set;}

        [Required]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Passwrod length must be from 5 to 16 letters")]
        public string Password {get; set;}
    }
}