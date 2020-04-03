using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrugaMVC.Models
{
    public class Student
    {
        [Display(Name = "Matična")]
        public int StudentID { get; set; }
        [Display(Name ="Ime študenta")]
        public string StudentIme { get; set; }
        public int Leta { get; set; }
    }
}