namespace EntityFrameworkDemo.Controllers
{
    using EntityFrameworkDemo.Entities;
    using EntityFrameworkDemo.Repositories;
    using EntityFrameworkDemo.Services;
    using EntityFrameworkDemo.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class PersonController : Controller
    {
        IPeopleService _peopleService;

        public PersonController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var peopleViewModel = new PersonViewModel();
            peopleViewModel.People = this._peopleService.GetAllPeople();
            return View(peopleViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                this._peopleService.NewPerson(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Read(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var person = this._peopleService.GetPerson((int)id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Read(Person person)
        {
            if (ModelState.IsValid)
            {
                this._peopleService.SavePerson(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
