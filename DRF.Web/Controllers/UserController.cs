using DRF.Services;
using DRF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DRF.Authentication;
using DRF.Common;

namespace DRF.Web.Controllers
{
    public class UserController : Controller
    {
        private UserModel _userModel;
        public UserController()
        {
            _userModel = new UserModel();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(_userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //Email is already Exist 
                var isEmailExist = _userModel.IsEmailExist(model);
                if (isEmailExist)
                {
                    ModelState.AddModelError("Email", "Email already exist");
                    return View(model);
                }

                var isSaved = model.Add();
                if (isSaved)
                {
                    return RedirectToAction("Login");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var isVerfied = _userModel.EmailVerification(id);

                if (isVerfied)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginUserModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserModel model, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var isAuthUser = _userModel.IsAuthenticatedUser(model);

                if (isAuthUser != null)
                {
                    if (isAuthUser.UserRoleId == (int)CustomEnum.UserType.Doctor)
                    {
                        return RedirectToAction("Index", "Home", new {area = "Doctor"});
                    }
                    else if (isAuthUser.UserRoleId == (int)CustomEnum.UserType.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            CustomFormsAuthentication.Logout();
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            var model = new LoginUserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ForgotPassword([Bind(Exclude = "Password,RememberMe")]LoginUserModel model)
        {
            ModelState.Remove("Password");
            ModelState.Remove("RememberMe");

            if (ModelState.IsValid)
            {
                var isSendResetPasswordCode = _userModel.SendResetPasswordCode(model);
                if (isSendResetPasswordCode)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ResetPassword(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var isResetPasswordCodeExist = _userModel.IsResetPasswordCodeExist(id);
                if (isResetPasswordCodeExist)
                {
                    var resetPasswordModel = new ResetPasswordModel()
                    {
                        ResetCode = id
                    };
                    return View(resetPasswordModel);
                }
            }

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var isResetPassword = _userModel.ResetUserPassword(model);
                if (isResetPassword)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

    }
}