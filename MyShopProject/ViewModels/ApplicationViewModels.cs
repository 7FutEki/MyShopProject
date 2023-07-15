using MyShopProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopProject.ViewModels
{
    public class ApplicationViewModels :INotifyPropertyChanged
    {
        // Реализация интерфейса
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

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

        private RelayCommand _Test;
        public RelayCommand Test
        {
            get
            {
                return _Test ?? new RelayCommand(obj =>
                Login = "test complete");
            }
        }


    }
}
