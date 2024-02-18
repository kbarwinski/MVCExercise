using MVCExercise.Domain.Common;

namespace MVCExercise.Domain.Entities
{
    public class Email : BaseEntity
    {
        public string Address { get; set; }
        public virtual Person Person { get; set; }
    }
}
