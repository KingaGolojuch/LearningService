using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.Article;
using LearningService.WebApplication.Models.Course;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace LearningService.WebApplication.Controllers
{
    [Authorize]
    public class ArticleController : BaseController
    {
        public const int RecordsPerPage = 10;

        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: Article
        public ActionResult Index()
        {
            var articles = _articleService.GetActive(GetUserId);
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

        public ActionResult Edit(int articleId)
        {
            var articleDTO = _articleService.Get(articleId);
            if (articleDTO == null)
                return RedirectToAction("Index");

            var model = Mapper.Map<ArticleBaseViewModel>(articleDTO);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ArticleBaseViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var articleDTO = Mapper.Map<ArticleDTO>(model);
            _articleService.Update(articleDTO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int articleId)
        {
            _articleService.Delete(articleId);
            return RedirectToAction("Index");
        }

        public ActionResult UserArticles()
        {
            var articles = _articleService.GetFromOtherUsers(GetUserId);
            var model = Mapper.Map<IEnumerable<ArticleBaseViewModel>>(articles);
            return View(model);
        }
    }
}