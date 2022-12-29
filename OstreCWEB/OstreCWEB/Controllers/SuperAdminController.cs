using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.ViewModel.Characters;

namespace OstreCWEB.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly ISeeder _seeder;
        private readonly ICharacterRepository _repository;
        private readonly IMapper _mapper;
        // GET: SuperAdmin
        public SuperAdminController(ISeeder seeder,IMapper mapper,ICharacterRepository characterRepository)
        {
            _seeder = seeder;
            _mapper = mapper;
            _repository = characterRepository;
        }
        public ActionResult Index()
        { 
            return View();
        }

        // GET: SuperAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuperAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperAdmin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Seed()
        {
            _seeder.SeedDataBase();
            return View();
        }
    }
}
