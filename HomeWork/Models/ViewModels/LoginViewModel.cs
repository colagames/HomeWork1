using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day2MVCDemo.Models.ViewModels
{
    public class LoginViewModel : IValidatableObject
    {
        [Required(ErrorMessage ="請輸入必要欄位:{0}")]
        [DisplayName("帳號")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "請輸入必要欄位:{0}")]
        [DisplayName("密碼")]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (this.NAME == "123" && this.PASSWORD == "123")
            //{
            yield break;
            //}
            //else
            //{
            //    yield return new ValidationResult("登入帳號或密碼錯誤", new string[] { "NAME" });
            //}
        }
    }
}