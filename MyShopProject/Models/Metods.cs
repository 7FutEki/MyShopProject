using MyShopProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopProject.Models
{
    public class Metods
    {
        //Вход в аккаунт
        public static bool LoginCheck(string log, string pass)
        {
            using (var db = new ApplicationContext())
            {
                var s = db.Users.FirstOrDefault(x => x.Login == log && x.Password == pass);
                if (s != null) return true;
                else return false;
            }
        }
       
        //Регистрация нового пользователя
        public static string RegUser(string log, string pass)
        {
            using (var db = new ApplicationContext())
            {
                //Проверяем на наличие пользователя с таким же именем
                var checkUser = db.Users.FirstOrDefault(x => x.Login == log && x.Password == pass);
                if (checkUser != null)
                {
                    return "Имя занято";
                }
                //Добавляем нового пользователя в базу данных
                else
                {
                    User user = new User()
                    {
                        Login = log,
                        Password = pass
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return "Вы успешно вошли в аккаунт";
                }
            }
        }
    }
}
