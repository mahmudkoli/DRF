using DRF.Entities;
using DRF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DRF.Authentication;
using DRF.Common;

namespace DRF.Web.Models
{
    public class UserModel : User
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }

        public string executeMessage;
        private UserService _userService;

        public IEnumerable<UserRole> UserRoles { get; set; }
        public UserModel()
        {
            executeMessage = "";
            _userService = new UserService();

            UserRoles = _userService.GetAllUserRoles();
        }

        public bool Add()
        {
            return _userService.Add(this);
        }
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public bool IsAuthenticateUser(LoginUserModel model)
        {
            try
            {
                var user = _userService.GetByEmail(model.Email);

                if (user != null)
                {
                    if (!user.IsEmailVerified)
                    {
                        executeMessage = "Please verify your email first";
                        return false;
                    }

                    if (String.Compare(CustomCrypto.Hash(model.Password), user.Password) == 0)
                    {
                        CustomFormsAuthentication.Login(user, model.RememberMe);
                        executeMessage = "";
                        return true;
                    }
                    else
                    {
                        executeMessage = "Invalid user email or password";
                        return false;
                    }
                }
                else
                {
                    executeMessage = "Invalid user email or password";
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                executeMessage = ex.Message;
                return false;
            }
        }

        public bool IsEmailExist(UserModel model)
        {
            var user = _userService.GetByEmail(model.Email);
            return user != null;
        }

        public bool EmailVerification(string code)
        {
            return _userService.EmailVerification(code);
        }

        public bool SendResetPasswordCode(LoginUserModel model)
        {
            return _userService.SendResetPasswordCode(model.Email);
        }

        public bool IsResetPasswordCodeExist(string code)
        {
            return _userService.IsResetPasswordCodeExist(code);
        }

        public bool ResetUserPassword(ResetPasswordModel model)
        {
            var user = new User()
            {
                Password = model.NewPassword,
                ResetPasswordCode = model.ResetCode
            };

            return _userService.ResetUserPassword(user);
        }
    }
}