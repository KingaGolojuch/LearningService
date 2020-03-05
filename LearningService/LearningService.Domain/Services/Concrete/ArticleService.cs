using AutoMapper;
using LearningService.DAO.CustomTypes;
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
        private readonly IUserRepository _userRepository;

        public ArticleService(
            IArticleRepository articleRepository,
            IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public void Add(ArticleDTO articleDTO)
        {
            var article = Mapper.Map<Article>(articleDTO);
            article.SetActive(true);
            article.SetCreateTime();
            article.SetUpdateTime();
            _articleRepository.Add(article);
            var user = _userRepository.GetById(articleDTO.UserId);
            user.AddActivityLog($"Utworzono artykuł: {article.Headline}", ActivityTypeCustom.ArticleOwnManagement);
            _userRepository.Update(user);
        }

        public void Update(ArticleDTO articleDTO)
        {
            var article = _articleRepository.GetById(articleDTO.Id);
            article.SetHeadline(articleDTO.Headline);
            article.SetContent(articleDTO.ContentArticle);
            if (!article.DataChanged)
                return;

            article.SetUpdateTime();
            _articleRepository.Update(article);
            var user = _userRepository.GetById(article.User.Id);
            user.AddActivityLog($"Edytowano artykuł: {article.Headline}", ActivityTypeCustom.ArticleOwnManagement);
            _userRepository.Update(user);
        }

        public IEnumerable<ArticleDTO> Get(string userId)
        {
            var entities = _articleRepository.Get(userId);
            return Mapper.Map<IEnumerable<ArticleDTO>>(entities);
        }

        public IEnumerable<ArticleDTO> GetFromOtherUsers(string userId)
        {
            var entities = _articleRepository.Get();
            return Mapper.Map<IEnumerable<ArticleDTO>>(
                entities
                .Where(x => x.User.Id != userId && x.Active == true)
                .OrderByDescending(x => x.CreateTime)
            );
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

            article.SetUpdateTime();
            _articleRepository.Update(article);
        }
    }
}
