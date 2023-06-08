using KutuphaneOtomasyonu.Core.DependencyResolvers;
using KutuphaneOtomasyonu.DataAccess;
using KutuphaneOtomasyonu.DataAccess.Base;
using KutuphaneOtomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.DataAccessB
{
    public class UserDal
    {
        private DataAccessBase _base;

        public UserDal()
        {
            _base = KutuphaneOtomasyonuFactory.CreateDataAccessBase();
        }

        public List<User> GetAllUsers()
        {
            string sqlSentence = "SELECT * FROM Users";
            var result = _base.Get(sqlSentence);
            return ParseToList(result);
        }

        public void AddUser(User user)
        {
            string sqlSentence = $"INSERT INTO Users (FirstName, LastName, Email, Password) VALUES ('{user.FirstName}', " +
                $"'{user.LastName}','{user.Email}','{user.Password}')";
            _base.Post(sqlSentence);
        }

        public void DeleteUser(User user)
        {
            string sqlSentence = $"DELETE FROM Users WHERE Id={user.Id}";
            _base.Post(sqlSentence); 
        }

        public void UpdateUser(User user)
        {
            string sqlSentence = $"UPDATE Users SET FirstName='{user.FirstName}'," +
                $"LastName='{user.LastName}', Email='{user.Email}', Password='{user.Password}' WHERE" +
                $" Id={user.Id}";
            _base.Post(sqlSentence);
        }

        private List<User> ParseToList(DataSet dataSet)
        {
            List<User> users = dataSet.Tables[0].AsEnumerable().Select(row =>
                new User
                {
                    Id = row.Field<int>("Id"),
                    FirstName = row.Field<string>("FirstName"),
                    LastName = row.Field<string>("LastName"),
                    Email = row.Field<string>("Email"),
                    Password = row.Field<string>("Password")
                }).ToList();

            return users;
        }
    }
}
