using Microsoft.EntityFrameworkCore;
using MyShopProject.DB;
using MyShopProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShopProject.Models
{
    public class Metods
    {
        #region Действия над пользователем
        //Вход в аккаунт
        public static bool LoginCheckMetod(string log, string pass)
        {
            using (var db = new ApplicationContext())
            {
                db.Database.Migrate();
                //Проверяем, есть ли в базе данных пользователь с таким логином/почтой/номером телефона и паролем
                User userFromDb = db.Users.Where(x => (x.Login == log || x.Email == log || x.NumberPhone == log) && x.Password == pass).FirstOrDefault();
                if (userFromDb != null) return true;
                else return false;
            }
        }
       
        //Регистрация нового пользователя
        public static string AddUserMetod(string log, string pass)
        {
            using (var db = new ApplicationContext())
            {
                //Проверяем на наличие пользователя с таким же именем
                var checkUser = db.Users.FirstOrDefault(x => x.Login == log && x.Password == pass);
                if (checkUser != null)
                {
                    return "Имя занято";
                }
                
                else
                {
                    //Создаем новый объект юзера и задаем ему значения из входных параметров
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
        #endregion

        #region Действия над товарами
        //Отгрузка товаров из базы данных
        public static ObservableCollection<Product> GetProducts()
        {
            using(var db = new ApplicationContext())
            {
                return new ObservableCollection<Product>(db.Products.ToList());
            }
        }

        //Добавление товара в базу данных
        public static bool AddProductMetod(string title, float price, string manufacturer, bool active, byte[] photoByte, string description)
        {
            using(var db = new ApplicationContext())
            {
                //Если товар с таким названием уже есть в базе данных возвращаем false
                var s = db.Products.FirstOrDefault(x => x.Title == title);
                if (s != null) return false;
                else
                {
                    //Создаем новый объект продукта и задаем ему значения из входных параметров
                    Product product = new Product()
                    {
                        Title = title,
                        Manufacturer = manufacturer,
                        Price = price,
                        Description = description,
                        Active = active,
                        PhotoByte = photoByte
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                    return true;
                }
            }
        }
        
        //Редактирование товара в базе данных
        public static bool EditProductMetod(Product oldproduct, string title, float price, string manufacturer, bool active, byte[] photoByte, string description)
        {
            using(var db = new ApplicationContext())
            {
                //Ищем в базе данных товар с таким же айди как в списке товаров
                Product productFromDb = db.Products.Where(x => x.Id == oldproduct.Id).FirstOrDefault();
                if (productFromDb != null)
                {
                    //Задаем товару из базы данных новые значения из входных параметров
                    productFromDb.Title = title;
                    productFromDb.Price = price;
                    productFromDb.Manufacturer = manufacturer;
                    productFromDb.Active = active;
                    productFromDb.PhotoByte = photoByte;
                    productFromDb.Description = description;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        //Удаление товара из базы данных
        public static bool RemoveProductMetod(Product product)
        {
            using(var db = new ApplicationContext())
            {
                //Ищем в базе данных товар с таким же айди как в списке товаров
                Product productFromDb = db.Products.Where(x=>x.Id == product.Id).FirstOrDefault();
                if (productFromDb != null)
                {
                    //Удаляем из базы данных
                    db.Products.Remove(productFromDb);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        #endregion

        #region Действия с окнами


       
        
        public static void OpenMainShopWindow()
        {
            MainShopWindow mainShopWindow = new MainShopWindow();
            mainShopWindow.ShowDialog();
        }

        public static void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        #endregion
    }
}
