using System.Diagnostics;
using lab2.Models;
using lab2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICourse Course;
        private readonly IDepartment Department;
        private readonly IInstructor Instructor;
        private readonly ICrsResult CrsResult;
        private readonly ITrainee Trainee;

        public StudentController(ICourse crs, IDepartment dept, IInstructor ins, ICrsResult crsRes, ITrainee trainee)
        {
            Course = crs;
            Department = dept;
            Instructor = ins;
            CrsResult = crsRes;
            Trainee = trainee;
        }
        public IActionResult Index()
        {
            List<Trainee> students = Trainee.TraineesWithDept();

            return View("Index", students);
        }

        public IActionResult GoToStdCrsRes()
        {
            List<Trainee> trainessThatHaveDegrees = new List<Trainee>();

            List<int> trainessIdFromResTable = CrsResult.GetTrainessId();


            foreach (int traineeID in trainessIdFromResTable)

            {
                Trainee trainee = Trainee.GetById(traineeID);
                if (!trainessThatHaveDegrees.Contains(trainee))
                    trainessThatHaveDegrees.Add(trainee);
            }



            ViewData["StudentList"] = trainessThatHaveDegrees;

            ViewData["CourseList"] = Course.GetAll();

            return View("GoToStdCrsRes");
        }

        public IActionResult CheckResult(StudentWithCrs studentWithCrs)
        {
            if (true)
            {

                //std_id // crs_id // std_grade
                StudentWithinCourseResult stdRes = new StudentWithinCourseResult();


                if (studentWithCrs.CrsID == 0 || studentWithCrs.StdID == 0)
                {
                    return Content("Please enter course or student name");
                }
                try
                {

                    Trainee? std = Trainee.GetById(studentWithCrs.StdID);
                    stdRes.StdName = std.Name;

                    Course crs = Course.GetById(studentWithCrs.CrsID);
                    stdRes.CrsName = crs.Name;

                    int stdGradeinCrs = CrsResult.GetStudentResultInCrs(studentWithCrs.CrsID, studentWithCrs.StdID);

                    stdRes.StdGrade = stdGradeinCrs;
                    stdRes.CourseMinGrade = crs.MinDegree;
                    stdRes.CourseFullGrade = crs.Degree;

                    if (stdGradeinCrs >= crs.MinDegree)
                    {
                        stdRes.StdColor = "green";
                        stdRes.statusString = "Passed :)";
                    }
                    else
                    {
                        stdRes.StdColor = "red";
                        stdRes.statusString = "Failed :( ";


                    }
                    stdRes.status = true;

                    return PartialView("CheckResult", stdRes);
                }
                catch
                {

                    stdRes.status = false;

                    return PartialView("CheckResult", stdRes);
                }





            }
        }

        public IActionResult GoTOStdAllGrades()
        {
            List<Trainee> students = Trainee.TraineesWithDept();
            ViewBag.std = students;
            return View("StdAllGrades");
        }

        public IActionResult GetCrsByStdID(int StdId)
        {
            var crsId = CrsResult.GetCrsIdByStdId(StdId);

            List<Course> crsName = new List<Course>();
            foreach (var item in crsId)
            {

                crsName.Add(Course.GetById(item));
            }
            return Json(crsName);
        }

        /*-----------------------*/
        public IActionResult GetStdAllGrades(int id)
        {
            var crss = CrsResult.GetCrsIdByStdId(id);

            Trainee trainee = Trainee.GetById(id);

            List<Course> courses = new List<Course>();
            Dictionary<string, int> crsRes = new Dictionary<string, int>();

            foreach (var item in crss)
            {
                courses.Add(Course.GetById(item));
            }

            foreach (var item in courses)
            {
                //
                crsRes.Add($"{item.Name}", CrsResult.GetStudentResultInCrs(item.Id, id));

            }




            return PartialView("_StudentAllGradesView", new
            {
                trainee = trainee,
                courses = courses,
                crsRes = crsRes
            });
        }
    }
}
