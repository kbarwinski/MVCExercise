using MVCExercise.Domain.Entities;
using MVCExercise.Persistence.Models;

namespace MVCExercise.Models.Person
{
    public class PersonListViewModel
    {
        public IEnumerable<PersonViewModel> People { get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
