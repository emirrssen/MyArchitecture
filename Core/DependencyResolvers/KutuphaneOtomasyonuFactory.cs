using KutuphaneOtomasyonu.Business;
using KutuphaneOtomasyonu.DataAccess.Base;
using KutuphaneOtomasyonu.DataAccessB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Core.DependencyResolvers
{
    public class KutuphaneOtomasyonuFactory
    {
        private static DataAccessBase _base;
        private static UserDal _userDal;
        private static UserManager _userManager;
        private static LoginScreen _loginScreen;
        private static RegisterScreen _registerScreen;

        public static DataAccessBase CreateDataAccessBase() { return _base == null ? new DataAccessBase() : _base; }
        public static UserDal CreateUserDal() { return _userDal == null ? new UserDal() : _userDal; }
        public static UserManager CreateUserManager() { return _userManager == null ? new UserManager() : _userManager; }
        public static LoginScreen CreateLoginScreen() { return _loginScreen == null ? new LoginScreen() : _loginScreen; }
        public static RegisterScreen CreateRegisterScreen() { return _registerScreen == null ? new RegisterScreen() : _registerScreen; }
    }
}
