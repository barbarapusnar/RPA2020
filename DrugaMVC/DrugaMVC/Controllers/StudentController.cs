using DrugaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrugaMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var seznam = new List<Student> {
                new Student(){ StudentID=1,StudentIme="Janez",Leta=18},
                new Student(){ StudentID=2,StudentIme="Metka",Leta=22},
                new Student(){ StudentID=3,StudentIme="Francka",Leta=20},
            };
            return View(seznam);
        }
        public ActionResult TestRazorja()
        {
            return View();

        }
        public ActionResult UporabaModela()
        {
            Student x = new Student()
            { StudentID = 1, StudentIme = "Janez", Leta = 18 };
            return View(x);

        }
    }
}