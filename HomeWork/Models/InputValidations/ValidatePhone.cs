using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Day2MVCDemo.Models.InputValidations
{
    public class ValidatePhone : DataTypeAttribute
    {
        public ValidatePhone() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            string l_phone = (string)value;

            return isPhone(l_phone);
        }
        public bool isPhone(string p_phone)
        {
          
            return Regex.IsMatch(p_phone, "\\d{4}-\\d{6}");
        
        }
    }
}