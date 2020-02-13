using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LearningService.Domain.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Add(ArticleDTO article)
        {
            var entity = Mapper.Map<Article>(article);
            entity.SetActive(true);
            _articleRepository.Add(entity);
        }

        public void Update(ArticleDTO articleDTO)
        {
            var article = _articleRepository.GetById(articleDTO.Id);
            article.SetHeadline(articleDTO.Headline);
            article.SetContent(articleDTO.ContentArticle);
            if (!article.DataChanged)
                return;

            _articleRepository.Update(article);
        }

        public IEnumerable<ArticleDTO> Get(string userId)
        {
            var entities = _articleRepository.Get(userId);
            return Mapper.Map<IEnumerable<ArticleDTO>>(entities);
        }

        public IEnumerable<ArticleDTO> GetFromOtherUsers(string userId)
        {
            var entities = _articleRepository.Get();
            return Mapper.Map<IEnumerable<ArticleDTO>>(entities.Where(x => x.User.Id != userId && x.Active == true));
        }

        public IEnumerable<ArticleDTO> GetActive(string userId)
        {
            var entities = _articleRepository.Get(userId);
            return Mapper.Map<IEnumerable<ArticleDTO>>(entities.Where(x => x.Active == true));
        }

        public ArticleDTO Get(int id)
        {
            var entity = _articleRepository.GetById(id);
            return Mapper.Map<ArticleDTO>(entity);
        }

        public void Delete(int articleId)
        {
            var article = _articleRepository.GetById(articleId);
            article.SetActive(false);
            if (!article.DataChanged)
                return;

            _articleRepository.Update(article);
        }
    }
}