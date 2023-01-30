using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Services.StoryServices;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Controllers
{
    [Authorize]
    public class StoryBuilderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStoryService _storyService;
        private readonly ILogger<StoryBuilderController> _logger;

        public StoryBuilderController(IMapper mapper, ILogger<StoryBuilderController> logger, IEnumerable<IStoryService> storyService)
        {
            _mapper = mapper;
            _storyService = storyService.First();
            _logger = logger;
        }

        // GET: StoryBuilderController
        public async Task<ActionResult> Index()
        {
            _logger.LogWarning(this + " Index(24)", DateTime.Now);
            var stories = await _storyService.GetAllStories();
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
                await _storyService.AddStory(_mapper.Map<Story>(story));
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

        // GET: StoryBuilderController/ParagraphDetails/5/1
        public async Task<ActionResult> ParagraphDetails(int id, int paragraphId)
        {
            var paragraphDetail = await _storyService.GetParagraphDetailsById(paragraphId, id);
            var model = _mapper.Map<ParagraphDetailsView>(paragraphDetail);

            return View(model);
        }
    }
}
