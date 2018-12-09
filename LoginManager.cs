using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CSharpProject.Models;

namespace CSharpProject
{
    public static class LoginManager
    {
        readonly static List<User> users = new List<User>() { new User() { Login = "123", Password = "123" } };

        public static bool ValidateUser(string username, string password)
        {
            var user = users.FirstOrDefault(x => x.Login == username);
            if (user != null)
            {

                if( password == users.Find(x => x.Login == user.Login).Password)
                {
                    SerializeUser(user);
                    return true;
                }
            }
            return false;
        }
        private static void SerializeUser(User user)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);

            }
        }
        public static User DeserializeUser()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                User user = (User)formatter.Deserialize(fs);
                return user;
            }
        }
        public static void ClearDat()
        {
            if (File.Exists("user.dat"))
            {
                File.Delete("user.dat");
            }
        }
    }
}
