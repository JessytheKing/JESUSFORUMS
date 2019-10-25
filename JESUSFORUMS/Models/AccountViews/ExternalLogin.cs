using System.ComponentModel.DataAnnotations;

namespace JESUSFORUMS.Models.AccountViews
{
    public class ExternalLogin
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
