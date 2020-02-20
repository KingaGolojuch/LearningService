using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningService.WebApplication.Helpers
{
    public static class PracticalTestReturnTypeOptions
    {
        public static List<SelectListItem> Get()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Text = "void", Value = "void" },
                new SelectListItem { Text = "int", Value = "int" },
                new SelectListItem { Text = "string", Value = "string" },
            };
        }
    }
}
