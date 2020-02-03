﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name{ get; set; }
    }
}