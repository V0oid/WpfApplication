using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TIProjekt.Models;

namespace TIProjekt.Classes
{
    public class DataAccess
    {
        public readonly SQLiteAsyncConnection _database;
        public DataAccess(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Announcment>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<Company>().Wait();
            _database.CreateTableAsync<ContractType>().Wait();
            _database.CreateTableAsync<PositionLevel>().Wait();
        
            _database.CreateTableAsync<WorkTime>().Wait();
            _database.CreateTableAsync<WorkType>().Wait();
        }
     
        
        //--------- Announcment ---------//
        public List<Announcment> GetAnnouncmentList()
        {
            return _database.Table<Announcment>().ToListAsync().Result;
        }
        public List<Announcment> GetAnnouncmentList(Company company)
        {
            return _database.Table<Announcment>().Where(item=>item.CompanyID == company.CompanyID).ToListAsync().Result;
        }
        public Task Add_Announcment(Announcment announcment)
        {
            return _database.InsertAsync(announcment);
        }
        public Task Update_Announcment(Announcment announcment)
        {
            return _database.UpdateAsync(announcment);
        }
        public Task Delete_Announcment(Announcment announcment)
        {
            return _database.DeleteAsync(announcment);
        }
       
        //--------- Category ---------//
        public List<Category> GetCategoryList()
        {
            return _database.Table<Category>().ToListAsync().Result;
        }
        public int Add_Category(Category category)
        {
            return _database.InsertAsync(category).Result;
        }
        public Task Update_Category(Category category)
        {
            return _database.UpdateAsync(category);
        }
        public Task Delete_Category(Category category)
        {
            return _database.DeleteAsync(category);
        }
        //--------- Company ---------//
        public List<Company> GetCompanyList()
        {
            return _database.Table<Company>().ToListAsync().Result;
        }
        public Company GetCompanyList(string Login)
        {
            return _database.Table<Company>().Where(item=>item.Login == Login).FirstAsync().Result;
        }
        public Company GetCompanyFromID(int id)
        {
            return _database.Table<Company>().Where(item => item.CompanyID == id).FirstAsync().Result;
        }
        public int Add_Company(Company company)
        {
            return _database.InsertAsync(company).Result;
        }
        public Task Update_Company(Company company)
        {
            return _database.UpdateAsync(company);
        }
        public Task Delete_Company(Company company)
        {
            return _database.DeleteAsync(company);
        }
        //--------- ContractType ---------//
        public List<ContractType> GetContractList()
        {
            return _database.Table<ContractType>().ToListAsync().Result;
        }
        public int Add_ContractType(ContractType item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_ContractType(ContractType item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_ContractType(ContractType item)
        {
            return _database.DeleteAsync(item).Result;
        }
     
       
     
        //--------- PositionLevel ---------//
        public List<PositionLevel> GetPositionLevelList()
        {
            return _database.Table<PositionLevel>().ToListAsync().Result;
        }
        public int Add_PositionLevel(PositionLevel item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_PositionLevel(PositionLevel item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_PositionLevel(PositionLevel item)
        {
            return _database.DeleteAsync(item).Result;
        }

        //--------- PositionLevel ---------//


        //--------- WorkTime ---------//
        public List<WorkTime> GetWorkTimeList()
        {
            return _database.Table<WorkTime>().ToListAsync().Result;
        }
        public int Add_WorkTime(WorkTime item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_WorkTime(WorkTime item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_WorkTime(WorkTime item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- WorkType ---------//
        public List<WorkType> GetWorkTypeList()
        {
            return _database.Table<WorkType>().ToListAsync().Result;
        }
        public int Add_WorkType(WorkType item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_WorkType(WorkType item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_WorkType(WorkType item)
        {
            return _database.DeleteAsync(item).Result;
        }
    }
}
