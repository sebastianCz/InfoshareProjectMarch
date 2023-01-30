using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Services.StoryServices;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Controllers
{
    public class StoryBuilderOLDController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStoryService _storyService;
        private readonly ILogger<StoryBuilderOLDController> _logger;

        public StoryBuilderOLDController(IMapper mapper, ILogger<StoryBuilderOLDController> logger, IEnumerable<IStoryService> storyService)
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


        // GET: StoryBuilderController/ParagraphDetails/5
        public async Task<ActionResult> ParagraphDetails(int id)
        {
            var paragraph = await _storyService.GetParagraphById(id);
            var model = _mapper.Map<GameParagraphView>(paragraph);

            return View(model);
        }

        // GET: StoryBuilderController/Create
        public async Task<ActionResult> CreateStory()
        {
            var model = new StoriesView();
            return View(model);
        }

        // POST: StoryBuilderController/Create
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

        // GET: StoryBuilderController/Edit/5
        public async Task<ActionResult> EditStory(int id)
        {
            return View(_mapper.Map<StoriesView>(await _storyService.GetStoryById(id)));
        }

        // POST: StoryBuilderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStory(StoriesView model)
        {
            try
            {
                await _storyService.UpdateStory(model.Id, model.Name, model.Description);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryBuilderController/Delete/5
        public async Task<ActionResult> DeleteStory(int id)
        {
            return View(_mapper.Map<StoriesView>(await _storyService.GetStoryById(id)));
        }

        // POST: StoryBuilderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStory(StoriesView story)
        {
            try
            {
                await _storyService.DeleteStory(story.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: StoryBuilderController/Create
        public async Task<ActionResult> CreateParagraph(int id)
        {
            var model = new ParagraphCreateView();
            model.StoryId = id;
            return View(model);
        }

        // POST: StoryBuilderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateParagraph(ParagraphCreateView paragraph)
        {
            try
            {
                await _storyService.AddParagraph(_mapper.Map<Paragraph>(paragraph));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
