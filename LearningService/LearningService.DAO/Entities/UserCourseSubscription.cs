using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class UserCourseSubscription
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
