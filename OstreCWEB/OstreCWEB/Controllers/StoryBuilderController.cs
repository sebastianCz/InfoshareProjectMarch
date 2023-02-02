using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Services.Identity;
using OstreCWEB.Services.StoryServices;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Controllers
{
    [Authorize]
    public class StoryBuilderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<StoryBuilderController> _logger;
        private readonly IStoryService _storyService;
        private readonly IUserService _userService;

        public StoryBuilderController(
            IMapper mapper,
            ILogger<StoryBuilderController> logger,
            IEnumerable<IStoryService> storyService,
            IUserService userService)
        {
            _mapper = mapper;
            _logger = logger;
            _storyService = storyService.First();
            _userService = userService;
        }

        /*
                |S|
                |T|
                |O|
                |R|
                |Y| 
        */

        // GET: StoryBuilderController
        public async Task<ActionResult> Index()
        {
            _logger.LogWarning(this + " Index(24)", DateTime.Now);
            var stories = await _storyService.GetStoriesByUserId(_userService.GetUserId(User));
            var model = new List<StoriesView>();
            foreach (var item in stories)
            {
                model.Add(_mapper.Map<StoriesView>(item));
            }

            return View(model);
        }

        // GET: StoryBuilderController/CreateStory
        public async Task<ActionResult> CreateStory()
        {
            var model = new StoriesView();
            return View(model);
        }

        // POST: StoryBuilderController/CreateStory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStory(StoriesView story)
        {
            try
            {
                await _storyService.AddStory(_mapper.Map<Story>(story), _userService.GetUserId(User));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryBuilderController/DeleteStory/5
        public async Task<ActionResult> DeleteStory(int id)
        {
            return View(_mapper.Map<StoriesView>(await _storyService.GetStoryById(id)));
        }

        // POST: StoryBuilderController/DeleteStory/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStory(StoriesView story)
        {
            try
            {
                await _storyService.DeleteStory(story.Id, _userService.GetUserId(User));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryBuilderController/EditStory/5
        public async Task<ActionResult> EditStory(int id)
        {
            return View(_mapper.Map<StoriesView>(await _storyService.GetStoryById(id)));
        }

        // POST: StoryBuilderController/EditStory/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStory(StoriesView model)
        {
            try
            {
                await _storyService.UpdateStory(model.Id, model.Name, model.Description, _userService.GetUserId(User));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryBuilderController/StoryParagraphsList
        public async Task<ActionResult> StoryParagraphsList(int id)
        {
            var model = _mapper.Map<StoryParagraphsView>(await _storyService.GetStoryWithParagraphsById(id));
            return View(model);
        }

        /*
                |P|
                |A|
                |R|
                |A|
                |G|
                |R|
                |A|
                |P|
                |H|   
        */

        // GET: StoryBuilderController/ParagraphDetails/5/1
        public async Task<ActionResult> ParagraphDetails(int id, int paragraphId)
        {
            var paragraphDetail = await _storyService.GetParagraphDetailsById(paragraphId, id);
            var model = _mapper.Map<ParagraphDetailsView>(paragraphDetail);

            return View(model);
        }

        // GET: StoryBuilderController/CreatNewParagraph/1
        public async Task<ActionResult> CreatNewParagraph(int id)
        {
            var model = new CreatNewParagraphView();
            model.StoryId = id;
            return View(model);
        }

        // POST: StoryBuilderController/CreatNewParagraph
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatNewParagraph(CreatNewParagraphView paragraph)
        {
            try
            {
                if (paragraph.ParagraphType == ParagraphType.Test)
                {
                    return RedirectToAction(nameof(CreatParagraphTest), paragraph);
                }
                else if(paragraph.ParagraphType == ParagraphType.Fight)
                {
                    return RedirectToAction(nameof(CreatParagraphFight), paragraph);
                }
                else
                {
                    return RedirectToAction(nameof(StoryParagraphsList), paragraph.StoryId);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryBuilderController/CreatParagraphTest
        public async Task<ActionResult> CreatParagraphTest(CreatNewParagraphView paragraph)
        {
            var model = new CreatParagraphTestView();
            return View(model);
        }

        // GET: StoryBuilderController/CreatParagraphFight
        public async Task<ActionResult> CreatParagraphFight(CreatNewParagraphView paragraph)
        {
            var model = new CreatParagraphFightView();
            return View(model);
        }

        /*
                |C|
                |H|
                |O|
                |I|
                |C|
                |E|
   
        */


    }
}
