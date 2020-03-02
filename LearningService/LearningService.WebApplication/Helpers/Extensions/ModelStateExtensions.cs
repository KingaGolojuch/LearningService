﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace LearningService.WebApplication.Helpers.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).Distinct().ToList();
        }
    }
}