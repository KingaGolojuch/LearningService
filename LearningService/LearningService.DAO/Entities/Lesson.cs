﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        public virtual string ValidAnswer { get; set; }
        

        public virtual Course Course { get; set; }
        public virtual LessonType LessonType { get; set; }
        public virtual IList<LessonComponent> LessonComponents { get; set; }
        public virtual IList<UserLesson> UserLessons { get; set; }

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

        public virtual void SetComponents(IEnumerable<LessonComponent> lessonComponents, string validAnswer)
        {
            foreach (var lessonComponent in LessonComponents.ToList())
            {
                var lessonComponentInNewList = lessonComponents.SingleOrDefault(x => x.Id == lessonComponent.Id);
                if (lessonComponentInNewList == null)
                {
                    LessonComponents.Remove(lessonComponent);
                    continue;
                }
                if (lessonComponent.Name == lessonComponentInNewList.Name)
                    continue;

                lessonComponent.Name = lessonComponentInNewList.Name;
                
            }

            foreach (var lessonComponent in lessonComponents.Where(x => x.Id == 0))
            {
                LessonComponents.Add(lessonComponent);
            }

            ValidAnswer = validAnswer;
            DataChanged = true;
        }

        public virtual bool IsAnswerTheoryTestCorrect(int answerId)
        {
            var validAnswerComponent = LessonComponents.Single(x => x.Name == ValidAnswer);
            if (validAnswerComponent.Id == answerId)
                return true;

            return false;
        }

        public virtual bool IsUserPassedLesson(string userId)
        {
            if (UserLessons.Any(x => x.User.Id == userId))
                return true;

            return false;
        }

        public virtual void SetRequiredNames(IEnumerable<string> requiredNames)
        {
            if (LessonComponents.Select(x => x.Name).SequenceEqual(requiredNames))
                return;

            var lessonComponents = requiredNames.Select(x => new LessonComponent
            {
                Name = x,
                Lesson = this
            });
            LessonComponents.Clear();
            foreach (var lessonComponent in lessonComponents)
            {
                LessonComponents.Add(lessonComponent);
            }
            DataChanged = true;
        }

        public virtual void SetAnswer(string answer)
        {
            if (ValidAnswer == answer)
                return;

            ValidAnswer = answer;
            DataChanged = true;
        }

        public virtual int GetCountOfUserCompletedLesson()
        {
            if (!UserLessons.Any())
                return 0;

            return UserLessons.Count;
        }
    }
}
