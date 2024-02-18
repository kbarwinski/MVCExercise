using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCExercise.Domain.Entities;
using MVCExercise.Infrastructure.Services.Person;
using MVCExercise.Models;
using MVCExercise.Models.Person;
using MVCExercise.Persistence.Queries.Pagination;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MVCExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPersonService personService, IMapper mapper)
        {
            _logger = logger;
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageNumber = 0, int pageSize = 10, string sortingOrders = "")
        {
            var filterRules = new Dictionary<Expression<Func<Person, bool>>, bool> { };

            var orderRules = new Dictionary<string, Expression<Func<Person, object>>>
            {
                [""] = x => x.CreatedAt
            };

            var (people, pagination) = await _personService.GetPage(new PaginationQuery(pageNumber, pageSize, sortingOrders),
                filterRules,
                orderRules,
                CancellationToken.None);

            var mapped = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(people);

            return View(new PersonListViewModel { People = mapped, Pagination = pagination });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Create()
        [HttpGet]
        public IActionResult Create()
        {
            return View("EditOrCreate", new PersonFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Person>(model);
                await _personService.Create(entity, CancellationToken.None);

                return RedirectToAction("Index");
            }

            return View("EditOrCreate", model);
        }
        #endregion

        #region Edit()
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var person = await _personService.Get(x => x.Id.ToString() == id, CancellationToken.None);
            if (person == null)
                return NotFound();

            var mapped = _mapper.Map<PersonFormViewModel>(person);

            return View("EditOrCreate", mapped);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Person>(model);
                await _personService.Update(entity, CancellationToken.None);

                return RedirectToAction("Index");
            }

            return View("EditOrCreate", model);
        }
        #endregion

        #region Delete()
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var person = await _personService.Get(x => x.Id.ToString() == id, CancellationToken.None);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.Delete(person, CancellationToken.None);

            return RedirectToAction("Index");
        }
        #endregion
    }
}