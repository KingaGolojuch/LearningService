using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.Domain.ModelsDTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LesssonType { get; set; }
        public string Headline { get; set; }
        public string LessonContent { get; set; }
    }
}