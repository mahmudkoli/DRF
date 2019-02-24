using DRF.Common;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Services
{
    public class UserService
    {
        private UserUnitOfWork _userUnitOfWork;
        private PatientService _patientService;
        public UserService()
        {
            _userUnitOfWork = new UserUnitOfWork(new DRFDbContext());
            _patientService = new PatientService();
        }

        public bool Add(User user)
        {
            try
            {
                var newUser = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = CustomCrypto.Hash(user.Password),
                    IsEmailVerified = true, //  Should be false
                    ActivationCode = Guid.NewGuid(),
                    UserRoleId = user.UserRoleId
                };
                _userUnitOfWork.UserRepository.Add(newUser);

                //Send Email to User
                //CustomEmail.SendVerificationLinkEmail(newUser.Email, newUser.ActivationCode.ToString());

                var isSaved = _userUnitOfWork.Save();

                //--------Save with Patient---------
                if (newUser.UserRoleId == (int)CustomEnum.UserType.Patient)
                {
                    var newPatient = new Patient()
                    {
                        UserId = newUser.Id
                    };
                    _patientService.Add(newPatient);
                }

                return isSaved;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _userUnitOfWork.UserRepository.GetAll();
        }

        public User GetByEmail(string email)
        {
            return _userUnitOfWork.UserRepository.GetByEmail(email);
        }

        public IEnumerable<UserRole> GetAllUserRoles()
        {
            return  _userUnitOfWork.UserRepository.GetAllUserRoles();
        }

        public bool EmailVerification(string code)
        {
            try
            {
                var user = _userUnitOfWork.UserRepository.Get(x => x.ActivationCode == new Guid(code)).FirstOrDefault();
                if (user != null)
                {
                    user.IsEmailVerified = true;
                    return _userUnitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool SendResetPasswordCode(string email)
        {
            try
            {
                var user = _userUnitOfWork.UserRepository.GetByEmail(email);
                if (user != null)
                {
                    user.ResetPasswordCode = Guid.NewGuid().ToString();
                    _userUnitOfWork.UserRepository.Update(user);

                    CustomEmail.SendVerificationLinkEmail(user.Email, user.ResetPasswordCode, "ResetPassword");

                    return _userUnitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool IsResetPasswordCodeExist(string code)
        {
            try
            {
                var user = _userUnitOfWork.UserRepository.Get(x => x.ResetPasswordCode == code).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool ResetUserPassword(User user)
        {
            try
            {
                var existUser = _userUnitOfWork.UserRepository.Get(x => x.ResetPasswordCode == user.ResetPasswordCode).FirstOrDefault();
                if (existUser != null)
                {
                    existUser.Password = CustomCrypto.Hash(user.Password);
                    existUser.ResetPasswordCode = "";
                    _userUnitOfWork.UserRepository.Update(existUser);

                    return _userUnitOfWork.Save();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}
