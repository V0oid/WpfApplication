using TIProjekt.Classes;
using TIProjekt.Models;
using TIProjekt.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TIProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company? Company;
        bool UserCompanyFlag;
        public MainWindow()
        {
            InitializeComponent();
            Page.Navigate(new Home(Page));
            RB_ComapnyProfile.Visibility = Visibility.Collapsed;
        }
        public MainWindow(string Login, bool UserCompanyFlag)
        {
            InitializeComponent();
            this.UserCompanyFlag = UserCompanyFlag;
            if (UserCompanyFlag)
            {
                RB_ComapnyProfile.Visibility = Visibility.Collapsed;
            }
            else
            {
                Company = App.DataAccess.GetCompanyList(Login);
            }
         
            
        }
        
     
     
        private void Home_clicked(object sender, RoutedEventArgs e)
        {
           
           if (Company != null && !UserCompanyFlag)
            {
                Page.Navigate(new Home(Page, Company));
            }
        }
        
        private void LogOut_clicked(object sender, RoutedEventArgs e)
        {
            (new Login()).Show();
            this.Close();
        }

        private void Company_clicked(object sender, RoutedEventArgs e)
        {
            if(Company != null)
            {
                Page.Navigate(new CommpanyAccountControl(Page, Company));
            }
            
        }

        private void CompanyProfile_cliked(object sender, RoutedEventArgs e)
        {
            if (Company != null)
            {
                Page.Navigate(new CompanyProfile(Page, Company,true));
            }
        }
    }
}
