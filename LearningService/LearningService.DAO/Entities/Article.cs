using LearningService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class Article
    {
        public virtual bool DataChanged { get; protected set; } = false;

        public virtual int Id { get; set; }
        public virtual string Headline { get; protected set; }
        public virtual string ContentArticle { get; protected set; }
        public virtual bool Active { get; protected set; }

        public virtual ApplicationUser User { get; set; }

        public virtual void SetHeadline(string name)
        {
            if (Headline == name)
                return;

            Headline = name;
            DataChanged = true;
        }

        public virtual void SetContent(string name)
        {
            if (ContentArticle == name)
                return;

            ContentArticle = name;
            DataChanged = true;
        }

        public virtual void SetActive(bool status)
        {
            if (Active == status)
                return;

            Active = status;
            DataChanged = true;
        }
    }
}
