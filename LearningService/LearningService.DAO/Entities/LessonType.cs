﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class LessonType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<Lesson> Lessons { get; set; }
    }
}