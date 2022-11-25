using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Expense_Tracker.Models
{
    public class login
    {
        [Key]

        public int Id { get; set; }



        [Required(ErrorMessage = "Please Enter Username..")]
        [RegularExpression(@"[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed")]
        [Display(Name = "UserName")]
        // [NotMapped]
        public string Username { get; set; }



        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        // [NotMapped]
        [Display(Name = "Password")]
        public string Password { get; set; }



    }
}
