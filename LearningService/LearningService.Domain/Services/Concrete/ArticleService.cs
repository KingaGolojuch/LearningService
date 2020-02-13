using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;

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
            entity.Active = true;
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

        public ArticleDTO Get(int id)
        {
            var entity = _articleRepository.GetById(id);
            return Mapper.Map<ArticleDTO>(entity);
        }
    }
}