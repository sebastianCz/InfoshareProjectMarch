using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Services.StoryService;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Controllers
{
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
            var model = new List<StoryView>();
            foreach (var item in stories)
            {
                model.Add(_mapper.Map<StoryView>(item));
            }

            return View(model);
        }

        // GET: StoryBuilderController/Details/5/1
        public async Task<ActionResult> Details(int id, int paragraphId)
        {
            var story = await _storyService.GetStoryById(id);
            var model = _mapper.Map<StoryDetailsView>(story);
            if (model.AmountOfParagraphs > 0)
            {
                foreach (var item in await _storyService.GetPreviousParagraphsById(paragraphId, id))
                {
                    model.PreviousParagraphs.Add(_mapper.Map<ParagraphView>(item));
                }

                model.CurrentParagraphView = _mapper.Map<ParagraphView>(await _storyService.GetParagraphById(paragraphId));

                foreach (var item in await _storyService.GetNextParagraphsById(paragraphId, id))
                {
                    model.NextParagraphs.Add(_mapper.Map<ParagraphView>(item));
                }
            }
            return View(model);
        }

        public async Task<ActionResult> StoryAllParagraphs(int id)
        {
            var test = _mapper.Map<StoryAllParagraphsView>(await _storyService.GetStoryById(id));
            return View(test);
        }


        // GET: StoryBuilderController/ParagraphDetails/5
        public async Task<ActionResult> ParagraphDetails(int id)
        {
            var paragraph = await _storyService.GetParagraphById(id);
            var model = _mapper.Map<ParagraphView>(paragraph);

            return View(model);
        }

        // GET: StoryBuilderController/Create
        public async Task<ActionResult> CreateStory()
        {
            var model = new StoryView();
            return View(model);
        }

        // POST: StoryBuilderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStory(StoryView story)
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
            return View(_mapper.Map<StoryView>(await _storyService.GetStoryById(id)));
        }

        // POST: StoryBuilderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStory(StoryView model)
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
            return View(_mapper.Map<StoryView>(await _storyService.GetStoryById(id)));
        }

        // POST: StoryBuilderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStory(StoryView story)
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
