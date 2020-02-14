namespace LearningService.DAO.Entities
{
    public class LessonComponent
    {
        public virtual bool DataChanged { get; protected set; } = false;

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
