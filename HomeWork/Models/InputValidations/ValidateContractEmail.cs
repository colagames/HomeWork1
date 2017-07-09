using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeWork.Models.InputValidations
{
    public class ValidateContractEmail : DataTypeAttribute
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        public ValidateContractEmail() : base(DataType.Text)
        {
        }
        public override bool IsValid(object value)
        {
            string email = (string)value;      
            客戶聯絡人 l_data = db.客戶聯絡人.Where(p => p.Email == email).FirstOrDefault() ;
            if (l_data == null)  return true; return false;

        }
    }
}