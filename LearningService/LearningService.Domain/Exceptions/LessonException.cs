using System;

namespace LearningService.Domain.Exceptions
{
    public class LessonException : Exception
    {
        public LessonException()
        {

        }
        public LessonException(string message) : base(message)
        {

        }
        public LessonException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
