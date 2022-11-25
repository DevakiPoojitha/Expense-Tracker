using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Expense_Tracker.Models
{
    public class SignUp
    {
        [Key]
        public int user_Id { get; set; }



        [Required(ErrorMessage = "Please Enter Email...")]
        [DataType(DataType.EmailAddress)]
        // [NotMapped]
        [Display(Name = "E-mail ID")]
        public string Email_id { get; set; }



        [Required(ErrorMessage = "Please Enter Username..")]
        [RegularExpression(@"[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed")]
        [Display(Name = "UserName")]
        //  [NotMapped]
        public string Username { get; set; }




        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        // [NotMapped]
        [Display(Name = "Password")]
        public string Password { get; set; }




        [Required(ErrorMessage = "Please Enter the Confirm Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        // [NotMapped]
        [Compare("Password")]
        public string Confirm_Password { get; set; }
    }
}
