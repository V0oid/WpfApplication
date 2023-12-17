using TIProjekt.Classes;
using TIProjekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace TIProjekt
{
    /// <summary>
    /// Interaction logic for Register_Clicked.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, RoutedEventArgs e)
        {
            Company company = new Company();
            company.Login = textLogin.Text;
            company.Password = TextPassword.Password;
            if(company != null)
            {
                App.DataAccess.Add_Company(company);
            }
            (new Login()).Show();
            this.Close();
        }
    }
}
