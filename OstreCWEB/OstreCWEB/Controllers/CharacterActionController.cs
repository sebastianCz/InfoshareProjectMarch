using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.ViewModel.Characters;

namespace OstreCWEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class CharacterActionController : Controller
    {
        public ICharacterClassRepository _characterClassRepository { get; } 
        public IMapper _Mapper { get; }
        public ICharacterActionsRepository _characterActionsRepository { get; }
        public IStatusRepository _statusRepository { get; }

        public CharacterActionController(IMapper mapper,ICharacterActionsRepository characterActionsRepository,IStatusRepository status, ICharacterClassRepository characterClassRepository)
        { 
            _Mapper = mapper;
            _characterActionsRepository = characterActionsRepository;
            _statusRepository = status;
            _characterClassRepository = characterClassRepository;   
        }
        // GET: ItemController
        public async Task<ActionResult> Index()
        {
            var actions = await _characterActionsRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<CharacterActionView>>(actions);
            return View(model);
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CharacterActionEditView();
            model.AllStatuses = new Dictionary<int, string>();
            model.AllClasses = new Dictionary<int, string>();
            var statuses = await  _statusRepository.GetAllAsync();
            var classes = await _characterClassRepository.GetAllAsync();
            statuses.ForEach(x => model.AllStatuses.Add(x.StatusId, x.StatusType.ToString()));
            classes.ForEach(x => model.AllClasses.Add(x.PlayableClassId, x.ClassName));
            return View(model);
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CharacterActionEditView item)
        {
            try
            {
                await _characterActionsRepository.UpdateAsync(_Mapper.Map<CharacterAction>(item));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //var model = _Mapper.Map<ItemEditView>(await _ItemRepository.GetByIdAsync(id));
            //var allActions = await _characterActionsRepository.GetAllAsync();
            //var allClasses = await _characterClassRepository.GetAllAsync();
            //model.AllExistingActions = new Dictionary<int, string>();
            //model.AllExistingClasses = new Dictionary<int, string>();
            //allActions.ForEach(x => model.AllExistingActions.Add(x.CharacterActionId,x.ActionName));
            //allClasses.ForEach(x => model.AllExistingClasses.Add(x.PlayableClassId, x.ClassName));
            return View();
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ItemEditView item)
        {
            try
            {
                //await _ItemRepository.UpdateAsync(_Mapper.Map<Item>(item));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ItemController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                //await _ItemRepository.DeleteAsync(id);
               
            }
            catch
            {
                //log error
            } 
            return RedirectToAction(nameof(Index));
        } 
    }
}
