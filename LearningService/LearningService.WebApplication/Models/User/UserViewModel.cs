using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Display(Name = "Status")]
        public bool Active { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string GetActiveAsString {
            get
            {
                return Active ? "Aktywny" : "Nieaktywny";
            }
        }
    }
}