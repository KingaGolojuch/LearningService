using System;

namespace LearningService.DAO.Entities
{
    public class Lesson
    {
        public virtual bool DataChanged { get; protected set; } = false;

        public virtual int Id { get; set; }
        public virtual int LessonTypeId { get; set; }
        public virtual int OrderLesson { get; set; }
        public virtual string Headline { get; set; }
        public virtual string LessonContent { get; set; }

        public virtual Course Course { get; set; }
        public virtual LessonType LessonType { get; set; }

        public virtual void SetHeadline(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Headline cannot be empty");

            if (Headline == name)
                return;

            Headline = name;
            DataChanged = true;
        }

        public virtual void SetContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new Exception("Lesson content cannot be empty");

            if (LessonContent == content)
                return;

            LessonContent = content;
            DataChanged = true;
        }
    }
}
