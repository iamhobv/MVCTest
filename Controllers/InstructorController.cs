using System.Linq;
using lab2.Models;
using lab2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ICourse Course;
        private readonly IDepartment Department;
        private readonly IInstructor Instructor;
        private readonly ICrsResult CrsResult;

        public InstructorController(ICourse crs, IDepartment dept, IInstructor ins, ICrsResult crsRes)
        {
            Course = crs;
            Department = dept;
            Instructor = ins;
            CrsResult = crsRes;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            int skip = 5 * (id - 1);
            List<Instructor> instructors = Instructor.getInsWithDeptAndPaging(skip, 5);
            int insLength = Instructor.InstructorCount();
            return View("Index", new
            {
                insList = instructors,
                insCount = insLength,
                navId = id
            });

        }

        public IActionResult Details(int id)
        {
            Instructor instructor = Instructor.GetInstractorDetails(id);

            return View("Details", instructor);
        }

        public IActionResult addNew()
        {
            InswithDeptCrsViewModel insVM = new InswithDeptCrsViewModel();
            insVM.Departments = Department.GetAll();
            insVM.Courses = Course.GetAll();
            return View("addNew", insVM);
        }

        [HttpPost]
        public IActionResult addInsToDB(InswithDeptCrsViewModel insForm)
        {

            if (insForm.Name != null)
            {
                Instructor ins = new Instructor();
                ins.Salary = insForm.Salary;
                ins.Address = insForm.Address;
                ins.CrsId = insForm.CrsId;
                ins.DeptId = insForm.DeptId;
                ins.ImgUrl = insForm.ImgUrl;
                ins.Name = insForm.Name;

                Instructor.Insert(ins);
                Instructor.Save();

                return RedirectToAction("index", new { id = 1 });
            }

            insForm.Departments = Department.GetAll();
            insForm.Courses = Course.GetAll();
            return View("addNew", insForm);



        }


        public IActionResult EditIns(int id)
        {
            Instructor ins = Instructor.GetById(id);
            InswithDeptCrsViewModel insVM = new InswithDeptCrsViewModel
            {
                Id = ins.Id,
                Address = ins.Address,
                CrsId = ins.CrsId,
                DeptId = ins.DeptId,
                Name = ins.Name,
                ImgUrl = ins.ImgUrl,
                Salary = ins.Salary,
                Courses = Course.GetAll(),
                Departments = Department.GetAll()
            };

            return View("EditIns", insVM);
        }
        public IActionResult saveEdit(InswithDeptCrsViewModel insEditedForm)
        {
            if (insEditedForm.Name != null)
            {
                Instructor ins = Instructor.GetById(insEditedForm.Id);

                ins.Salary = insEditedForm.Salary;
                ins.Address = insEditedForm.Address;
                ins.CrsId = insEditedForm.CrsId;
                ins.DeptId = insEditedForm.DeptId;
                ins.ImgUrl = insEditedForm.ImgUrl;
                ins.Name = insEditedForm.Name;

                Instructor.Save();

                return RedirectToAction("index", new { id = 1 });
            }

            insEditedForm.Departments = Department.GetAll();
            insEditedForm.Courses = Course.GetAll();
            return View("EditIns", insEditedForm);

        }


        /*------------------------------------*/
        public IActionResult GetCrsByDept(int id)
        {
            return Json(Course.GetCrsByDeptID(id));
        }

    }
}
