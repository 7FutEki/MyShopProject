using MyShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShopProject.ViewModels
{
    public class ApplicationViewModels :INotifyPropertyChanged
    {

        private string _Login;
        public string Login
        {
            get { return _Login; }
            set 
            {
                _Login = value;
                OnPropertyChanged();
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _LogIn;
        public RelayCommand LogInCommand
        {
            get
            {
                return _LogIn ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool resultbool;
                    resultbool = Metods.LoginCheckMetod(Login, Password);
                    if (resultbool == true)
                    {
                        Metods.OpenMainShopWindow();
                        wnd.Close();
                    }
                    else
                        MessageBox.Show("Неправильно введенные данные");
                });
                
            }
        }
        private RelayCommand _OpenWindowTest;
        public RelayCommand OpenWindowTest
        {
            get
            {
                return _OpenWindowTest ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    Metods.OpenMainShopWindow();
                    wnd.Close();

                });

                
            }
        }
        
        


        #region Реализация интерфейса
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
}
