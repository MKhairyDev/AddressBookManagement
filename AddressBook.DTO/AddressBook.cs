using System.ComponentModel.DataAnnotations;
namespace AddressBook.DTO
{

    public class AddressBookDTO
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30)]
        public string Name { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Job Position")]
        public string JobPosition { get; set; }

        public string institution { get; set; }


    }
}
