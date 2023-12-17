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
using Application = System.Windows.Application;

namespace TIProjekt
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
         
        }

        private void Register_Clicked(object sender, RoutedEventArgs e)
        {
            (new Register()).Show();
            this.Close();
        }

        private void Login_Clicked(object sender, RoutedEventArgs e)
        {

           
            if(App.DataAccess.GetCompanyList(textLogin.Text).Login == textLogin.Text && App.DataAccess.GetCompanyList(textLogin.Text).Password == textPassword.Password)
            {
                var MainWindow = new MainWindow(textLogin.Text, false);
                MainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Podano niepoprawne dane");
            }
        }
    
        
    }
}
