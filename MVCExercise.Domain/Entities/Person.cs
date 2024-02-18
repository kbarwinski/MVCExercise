using MVCExercise.Domain.Common;

namespace MVCExercise.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}
