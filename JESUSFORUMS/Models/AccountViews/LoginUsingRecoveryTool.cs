using System.ComponentModel.DataAnnotations;


namespace JESUSFORUMS.Models.AccountViews
{
    public class LoginUsingRecoveryTool
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }
    }
}
