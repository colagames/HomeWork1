using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{

        public IQueryable<客戶資料> get前10筆資料()
        {
            return this.All().Where(p => p.是否已刪除 !=true).Take(10);
        }

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<客戶資料> FindByKeyWord(string keyword)
        {
            IQueryable<客戶資料> 客戶資料 = this.All();

            return (from p in 客戶資料 where p.客戶名稱.Contains(keyword) select p);
          
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}