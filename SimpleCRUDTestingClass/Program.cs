using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;

namespace SimpleCRUDTestingClass
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userTesting = new GenericDataService<User>(new DBContextOptionsFactory());
            for (int id = 1; id < 10; id++)
            {
                CreateUserTestMethod(userTesting, "NewUser" + id);
            }
            Console.WriteLine(userTesting.Get(2).Result);
            GetUserTestMethod(userTesting, 4);
            UpdateUserTestMethod(userTesting, 6, "RandomName");
            DeleteUserTestMethod(userTesting, 4);
            Console.ReadKey();
        }
        static void CreateUserTestMethod(IDataService<User> user, string username, string email="noEmail", string password="noPassword")
        {
            user.Create(new User { Username = username, Password = password, Email = email }).Wait();
        }
        static void GetUserTestMethod(IDataService<User> user, int id)
        {
            Console.WriteLine(user.Get(id).Result);
            Console.WriteLine("1");
        }
        static void UpdateUserTestMethod(IDataService<User> newUser, int id, string newUsername="EmptyUsername", string email = "noEmail", string password = "noPassword")
        {
            newUser.Update(id, new User() { Username = newUsername, Email = email, Password = password });
        }
        static void DeleteUserTestMethod(IDataService<User> user, int id)
        {
            user.Delete(id);
        }
    }
}
