using TIProjekt.Classes;
using TIProjekt.Models;
using System;
using System.Collections.Generic;
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

namespace TIProjekt.Pages
{
    /// <summary>
    /// Interaction logic for AnnouncmentPage.xaml
    /// </summary>
    public partial class AnnouncmentPage : Page
    {
        AnnouncmentItem? item; 
        Frame CurrentPage;
        public AnnouncmentPage(Frame currentPage, Announcment announcment)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            item = new AnnouncmentItem(announcment);
            G_Page.DataContext = item;
            LV_Responsibilities.ItemsSource = item.Responsibilities;
            LV_Requirements.ItemsSource = item.Requirements;
            Lbl_Adress.Content = item.City;
            DateTime? date = item.EndDate;
            if (date != null)
            {
                Lbl_EndDate.Content = $"Do: {date.Value.Day}.{date.Value.Month}.{date.Value.Year}";
            }
            Lbl_Position.Content = item.PositionName;
            Lbl_WorkTime.Content = item.WorkingTime;
            Lbl_PositionLevel.Content = item.PositionLevel;
            Lbl_WorkType.Content = item.WorkType;
           
            
        }
       
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.GoBack();
        }

        private void Btn_Application_Click(object sender, RoutedEventArgs e)
        {
          
            CurrentPage.GoBack();
        }
    }
}
