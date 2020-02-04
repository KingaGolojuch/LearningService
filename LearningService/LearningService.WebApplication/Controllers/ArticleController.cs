using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.Article;
using LearningService.WebApplication.Models.Course;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;


namespace LearningService.WebApplication.Controllers
{
    [Authorize]
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: Article
        public ActionResult Index()
        {
            var articles = _articleService.Get(GetUserId);
            var model = Mapper.Map<IEnumerable<ArticleBaseViewModel>>(articles);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleBaseViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var articleDTO = Mapper.Map<ArticleDTO>(model);
            articleDTO.UserId = GetUserId;
            _articleService.Add(articleDTO);
            return RedirectToAction("Index");
        }
    }
}