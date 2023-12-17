﻿using TIProjekt.Classes;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Frame CurrentPage;
        Company? Company;
        List<CheckedItem> checkedItems_PositionLevel = new List<CheckedItem>() { };
        List<CheckedItem> checkedItems_ContractTypes = new List<CheckedItem>() { };
        List<CheckedItem> checkedItems_WorkTime = new List<CheckedItem>() { };
        List<CheckedItem> checkedItems_WorkType = new List<CheckedItem>() { };
       
        public Home(Frame CurrentPage)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            Initialie();
        }
     
        public Home(Frame CurrentPage, Company company)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            this.Company = company;
            Initialie();
        }
        public List<AnnouncmentItem> GetAnnouncmentAllInformations()
        {
            List<AnnouncmentItem> items = new List<AnnouncmentItem>();
            foreach (var item in App.DataAccess.GetAnnouncmentList())
            {
                items.Add(new AnnouncmentItem(item));
            }
            return items;
        }
        public void Initialie()
        {
            Announcments.ItemsSource = GetAnnouncmentAllInformations();
          
            if (IC_ItemsToChecked.Items.Count <= 0)
                BR_Items.Visibility = Visibility.Collapsed;
            else
                BR_Items.Visibility = Visibility.Visible;
        }
        public List<CheckedItem> GetCheckedTypeWork()
        {
            var checkedItems = new List<CheckedItem>() { };

            foreach (CheckedItem item in IC_ItemsToChecked.Items)
            {
                if(item.Checked)
                checkedItems.Add(item as CheckedItem);
            }
            return checkedItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<CheckedItem> listFromDatabase = new List<CheckedItem>();
            string? btnContent = ((Button)sender).Name;
            switch (btnContent)
            {
                case "Btn_PositionLevel":

                    checkedItems_PositionLevel = GetCheckedTypeWork();
                    foreach (var itemFromDatabase in App.DataAccess.GetPositionLevelList())
                    {
                        CheckedItem item = new CheckedItem();
                        item.ID = itemFromDatabase.ID;
                        item.Name = itemFromDatabase.Name;
                        if (checkedItems_PositionLevel.Contains(item))
                        {
                            item.Checked = true;
                        }
                        listFromDatabase.Add(item);
                    }
                    IC_ItemsToChecked.ItemsSource = listFromDatabase;
                    break;
                case "Btn_ContractType":

                    checkedItems_ContractTypes = GetCheckedTypeWork();
                    foreach (var itemFromDatabase in App.DataAccess.GetContractList())
                    {
                        CheckedItem item = new CheckedItem();
                        item.ID = itemFromDatabase.ID;
                        item.Name = itemFromDatabase.Name;
                        if (checkedItems_ContractTypes.Contains(item))
                        {
                            item.Checked = true;
                        }
                        listFromDatabase.Add(item);
                    }
                    IC_ItemsToChecked.ItemsSource = listFromDatabase;
                    break;
                case "Btn_WorkTime":

                    checkedItems_WorkTime = GetCheckedTypeWork();
                    foreach (var itemFromDatabase in App.DataAccess.GetWorkTimeList())
                    {
                        CheckedItem item = new CheckedItem();
                        item.ID = itemFromDatabase.ID;
                        item.Name = itemFromDatabase.Name;
                        if (checkedItems_WorkTime.Contains(item))
                        {
                            item.Checked = true;
                        }
                        listFromDatabase.Add(item);
                    }
                    IC_ItemsToChecked.ItemsSource = listFromDatabase;
                    break;
                case "Btn_WorkType":

                    checkedItems_WorkType = GetCheckedTypeWork();
                    foreach (var itemFromDatabase in App.DataAccess.GetWorkTypeList())
                    {
                        CheckedItem item = new CheckedItem();
                        item.ID = itemFromDatabase.ID;
                        item.Name = itemFromDatabase.Name;
                        if (checkedItems_WorkType.Contains(item))
                        {
                            item.Checked = true;
                        }
                        listFromDatabase.Add(item);
                    }
                    IC_ItemsToChecked.ItemsSource = listFromDatabase;
                    break;
                default:
                    break;
            }
            if (IC_ItemsToChecked.Items.Count <= 0)
                BR_Items.Visibility = Visibility.Collapsed;
            else
                BR_Items.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = GetAnnouncmentAllInformations();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = GetAnnouncmentAllInformations();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = GetAnnouncmentAllInformations();
        }

    

        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            AnnouncmentItem? tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if(tmpItem != null)
            {
                Announcment? item = tmpItem.Announcment;
              
                 if (item != null)
                {
                    CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, item));
                }
            }
           
        }

        private void Btn_GoToCompanyProfile_Click(object sender, RoutedEventArgs e)
        {
            Company? item = ((Button)sender).CommandParameter as Company;
            if(item != null)
            {
                CurrentPage.Navigate(new CompanyProfile(CurrentPage,item, false));
            }
        }
    }
}
