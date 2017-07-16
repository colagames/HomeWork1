using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Day2MVCDemo.Models.ViewModels
{
    public class BatchUpdateVM
    {
        //ID
        public int Id { get; set; }
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
    }
}