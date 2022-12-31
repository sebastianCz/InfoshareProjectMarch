using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.SuperAdmin;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.SuperAdmin;

namespace OstreCWEB.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly ISeeder _seeder; 
        private readonly IStatusRepository _statusRepository;
        private readonly ICharacterActionsRepository _characterActionsRepository;
        private readonly IPlayableCharacterRepository _playableCharacterRepository;
        private readonly ISuperAdminRepository _superAdminRepository; 
        private readonly IMapper _mapper;
        // GET: SuperAdmin
        public SuperAdminController(ISuperAdminRepository superAdminRepository,IPlayableCharacterRepository playableCharacterRepository, ISeeder seeder,IMapper mapper, IStatusRepository statusRepository,ICharacterActionsRepository characterActionsRepository)
        {
            _seeder = seeder;
            _mapper = mapper; 
            _statusRepository = statusRepository;
            _characterActionsRepository = characterActionsRepository;
            _playableCharacterRepository = playableCharacterRepository;
            _superAdminRepository = superAdminRepository;

             
        }
        public async Task<ActionResult> Test()
        {

            //var status = new Status();
            //status.Description = " new status";
            //status.Name = "new name";

            //var statuses = await _statusRepository.GetAll();

            // await _statusRepository.Create(status);
            // statuses = await _statusRepository.GetAll() ;

            // status.Description = "Newer description";
            //await _statusRepository.Update(status);
            //statuses = await _statusRepository.GetAll();

            ////await _statusRepository.Delete(status);
            ////statuses = await _statusRepository.GetAll();

            _superAdminRepository.Test();
      

            return RedirectToAction(nameof(Index));





        }

        public ActionResult Index()
        {
            var model = new SuperAdminView();
            //foreach (var status in _statusRepository.GetAll().Result)
            //{
            //    model.Statuses.Add(_mapper.Map<StatusView>(status));
            //}
            return View(model);
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
