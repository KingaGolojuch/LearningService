using LearningService.Domain.Enums;

namespace LearningService.Domain.ModelsDTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public LessonTypeCustom LessonType { get; set; }
        public string Headline { get; set; }
        public string LessonContent { get; set; }
        public int OrderLesson { get; set; }

        public string ValidAnswer { get; set; }
        public bool AlreadyPassed { get; set; }
    }
}
