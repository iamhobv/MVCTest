using lab2.Models;
using lab2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
    public class CourseController : Controller
    {
        //databaseContext context = new databaseContext();
        private readonly ICourse Course;
        private readonly IDepartment Department;
        private readonly IInstructor Instructor;
        private readonly ICrsResult CrsResult;

        public CourseController(ICourse crs, IDepartment dept, IInstructor ins, ICrsResult crsRes)
        {
            Course = crs;
            Department = dept;
            Instructor = ins;
            CrsResult = crsRes;
        }
        public IActionResult Index()
        {

            List<Course> courses = Course.CoursesDeptIns();

            CourseWithSearchVM crs = new CourseWithSearchVM { Courses = courses };

            return View("Index", crs);
        }

        public IActionResult AddNew()
        {


            ViewData["deptList"] = Department.GetAll();
            ViewData["insList"] = Instructor.GetAll();
            return View("AddNew");

        }

        public IActionResult SaveNewToDb(CourseWithDeptInsVM formCrs)
        {

            List<Instructor> selectedIns = new List<Instructor>();

            foreach (int id in formCrs.Instructors)
            {
                selectedIns.Add(Instructor.GetById(id));
            }



            Course crs = new Course
            {
                Name = formCrs.Name,
                Degree = formCrs.Degree,
                MinDegree = formCrs.MinDegree,
                Hours = formCrs.Hours,
                DeptId = formCrs.DeptId,
                Instructors = selectedIns,

            };
            if (ModelState.IsValid)
            {
                try
                {
                    Course.Insert(crs);
                    Course.Save();
                    return RedirectToAction("index");
                }
                catch (Exception e)
                {

                    ModelState.AddModelError(string.Empty, e.InnerException.Message);
                }

            }
            ViewData["deptList"] = Department.GetAll();
            ViewData["insList"] = Instructor.GetAll();

            return View("AddNew", formCrs);

        }

        public IActionResult DeleteCrs(int delCrsId)
        {
            if (delCrsId != 1)
            {
                Course crs = Course.GetById(delCrsId);
                if (crs != null)
                {
                    List<Instructor> dumgedInstructor = Instructor.GetInstructorsByCrsId(delCrsId);
                    List<CrsResult> dumgedCrsResult = CrsResult.GetResultsByCrsId(delCrsId);
                    foreach (Instructor instructor in dumgedInstructor)
                    {
                        instructor.CrsId = 1;
                    }
                    foreach (CrsResult crsResult in dumgedCrsResult)
                    {
                        crsResult.CrsId = 1;
                    }
                    Course.Delete(crs.Id);
                    Course.Save();
                }
            }
            return RedirectToAction("index");


        }

        public IActionResult Searching(string searchText)
        {
            if (searchText == null || searchText == "" || searchText == " ")
            {
                return RedirectToAction("index");
            }
            else
            {
                List<Course> courses = Course.GetByNameWithDeptIns(searchText);
                CourseWithSearchVM crs = new CourseWithSearchVM
                {
                    Courses = courses,
                    SearchText = searchText

                };
                //.Include("Department").Include("Instructors").ToList();
                return View("Index", crs);
            }
        }

        public IActionResult CheckHours(int Hours)
        {
            if (Hours % 3 == 0)
            {

                return Json(true);
            }
            return Json(false);


        }



    }

}
