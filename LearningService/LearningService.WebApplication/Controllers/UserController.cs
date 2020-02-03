using AutoMapper;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace LearningService.WebApplication.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ApplicationUserManager _applicationUserManager;

        public UserController(
            IUserService userService,
            ApplicationUserManager applicationUserManager)
        {
            _userService = userService;
            _applicationUserManager = applicationUserManager;
        }

        // GET: Test
        public ViewResult Index()
        {
            var users = _applicationUserManager.Users.ToList();
            var model = Mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(model);
        }

        // GET: Test
        public ViewResult Edit(string userId)
        {
            var user = _applicationUserManager.Users.Where(x => x.Id == userId).SingleOrDefault();
            var model = Mapper.Map<UserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _applicationUserManager.Users.Where(x => x.Id == model.Id).SingleOrDefault();
            user.Name = model.Name;
            user.Surname = model.Surname;
            await _applicationUserManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        // GET: Test
        public async Task<RedirectToRouteResult> Enable(string userId)
        {
            var user = _applicationUserManager.Users.Where(x => x.Id == userId).SingleOrDefault();
            user.Active = true;
            await _applicationUserManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        public async Task<RedirectToRouteResult> Disable(string userId)
        {
            var user = _applicationUserManager.Users.Where(x => x.Id == userId).SingleOrDefault();
            user.Active = false;
            await _applicationUserManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}