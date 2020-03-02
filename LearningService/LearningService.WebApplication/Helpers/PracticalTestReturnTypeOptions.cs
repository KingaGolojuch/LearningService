using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningService.WebApplication.Helpers
{
    public static class PracticalTestReturnTypeOptions
    {
        public static List<SelectListItem> Get()
        {
            //return new List<SelectListItem>()
            //{
            //    new SelectListItem { Text = "void", Value = "void" },
            //    new SelectListItem { Text = "string", Value = "string" }
            //    //new SelectListItem { Text = "int", Value = "int" },
            //};
            return new List<SelectListItem>()
            {
                new SelectListItem { Text = "nie", Value = "void" },
                new SelectListItem { Text = "tak", Value = "string" }
                //new SelectListItem { Text = "int", Value = "int" },
            };
        }
    }
}
