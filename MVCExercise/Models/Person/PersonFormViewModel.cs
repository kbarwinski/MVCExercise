using MVCExercise.Models.Email;
using System.ComponentModel.DataAnnotations;

namespace MVCExercise.Models.Person
{
    public class PersonFormViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; }

        public IEnumerable<EmailViewModel> Emails { get; set; } = Enumerable.Empty<EmailViewModel>();
    }
}
