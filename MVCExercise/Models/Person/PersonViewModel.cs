using System.ComponentModel.DataAnnotations;

namespace MVCExercise.Models.Person
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string FirstEmailAddress { get; set; }
    }
}
