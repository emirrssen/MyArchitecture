using KutuphaneOtomasyonu.Core.DependencyResolvers;
using KutuphaneOtomasyonu.Core.Results;
using KutuphaneOtomasyonu.DataAccess;
using KutuphaneOtomasyonu.DataAccessB;
using KutuphaneOtomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Business
{
    public class UserManager
    {
        private UserDal _userDal;
        public UserManager()
        {
            _userDal = KutuphaneOtomasyonuFactory.CreateUserDal();
        }
        public DataResult<List<User>> GetUsers()
        {
            var result = _userDal.GetAllUsers();
            return new DataResult<List<User>>(true, "Kullanıcılar başarılı bir şekilde listelendi.", result);
        }

        public Result Login(string email, string password)
        {
            var result = _userDal.GetAllUsers().Where(u => u.Email == email && u.Password == password);

            if (result == null)
            {
                return new Result(false, "Kullanıcı bulunamadı!");
            }
            return new Result(true, "Giriş başarılı!");
        }

        public Result Register(User user)
        {
            if (CheckFirstName(user.FirstName) && CheckLastName(user.LastName) &&
                CheckEmail(user.Email) && CheckPassword(user.Password))
            {
                _userDal.AddUser(user);
                return new Result(true, "Kullanıcı başarılı bir şekilde eklendi!");
            }

            return new Result(false, "Kullanıcı bilgileri boş bırakılamaz!");
        }

        private bool CheckFirstName(string firstName)
        {
            return firstName.Length > 0 ? true : false;
        }

        private bool CheckLastName(string lastName)
        {
            return lastName.Length > 0 ? true : false;
        }

        private bool CheckEmail(string email)
        {
            return email.Length > 0 ? true :false;
        }

        private bool CheckPassword(string password)
        {
            return password.Length > 0 ? true : false;  
        }
    }
}
