using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LearningService.WebApplication.Models;
using AutoMapper;
using LearningService.WebApplication.Models.User;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.ActivityLog;
using System.Collections.Generic;

namespace LearningService.WebApplication.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IUserService _userService;
        private readonly IArticleService _articleService;
        private readonly ICourseService _courseService;
        private readonly IActivityLogService _activityLogService;

        public ManageController(
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            IUserService userService,
            IArticleService articleService,
            ICourseService courseService,
            IActivityLogService activityLogService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _userService = userService;
            _articleService = articleService;
            _courseService = courseService;
            _activityLogService = activityLogService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Hasło zostało zmienione."
                : message == ManageMessageId.ChangePersonalDataSuccess ? "Dane zostały zmienione"
                : message == ManageMessageId.Error ? "Wystąpił błąd."
                : "";

            var userId = GetUserId;
            var user = await _userManager.FindByIdAsync(userId);
            var model = new UserManageViewModel
            {
                User = Mapper.Map<UserViewModel>(user),
                ArticleCount = _articleService.Get(userId).Count(),
                CourseCount = _courseService.Get(userId).Count()
            };
            return View(model);
        }

        public async Task<ActionResult> Edit()
        {
            var userId = GetUserId;
            var user = await _userManager.FindByIdAsync(userId);
            var model = Mapper.Map<UserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);
            user.Name = model.Name;
            user.Surname = model.Surname;
            _userManager.Update(user);
            _userService.LogEditAccountData(user.Id, "Edytowano dane osobowe");
            return RedirectToAction("Index", new { message = ManageMessageId.ChangePersonalDataSuccess });
        }
        
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }
        
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                _userService.LogEditAccountData(user.Id, "Zmieniono hasło");
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        public ActionResult Activities()
        {
            var userId = GetUserId;
            var activites = _activityLogService.GetLogs(userId);
            var model = new ActivityLogContainerViewModel
            {
                UserActivities = Mapper.Map<IEnumerable<ActivityLogViewModel>>(activites)
            };
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
        
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error.Contains("Incorrect password"))
                {
                    ModelState.AddModelError("", "Niepoprawne hasło");
                    continue;
                }
                
                ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            ChangePersonalDataSuccess,
            Error
        }
    }
}