using System.Collections.Generic;

namespace LearningService.Domain.ModelsDTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public bool IsSubscribed { get; set; }

        public IEnumerable<string> UsersSubscribers { get; set; }
        public int LessonCount { get; set; }
        public int UserSubscriberFinishedLesson { get; set; }
    }
}