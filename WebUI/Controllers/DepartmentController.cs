using Model;
using Model.Model;
using Services;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Attributes;
using WebUI.Models;

namespace WebUI.Controllers
{
    [CustomAuthorize]
    public class DepartmentController : Controller
    {
        private IDepartmentServices _departmentService;
        private ICompanyServices _companyService;

        public DepartmentController(IDepartmentServices depISrv, ICompanyServices compISrv)
        {
            _departmentService = depISrv;
            _companyService = compISrv;
        }
        //------------------CREATE NEW  DEPARTMENT------------------------------------------
        [HttpGet]
        public ActionResult newDepartment()
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Administrator))
            {
                DepartmentModel depModel = new DepartmentModel();
                List<Company> ComList = new List<Company>();
                depModel.Companies = _companyService.GetAllCompanies();
                ViewBag.comList = depModel.Companies;
                return View();
            }
            else
            {
                return RedirectToAction("NotAdministrator");
            }
       }

        [HttpPost]
        public ActionResult newDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                var com = _companyService.GetCompanyByID(department.ComapanyID);
                var newDepartment = _departmentService.InsertDepartment(department.Name, department.Description, com.Id);

                if (newDepartment != null)
                {
                    return RedirectToAction("SuccessDepartment");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid data");
            }
            return View("newDepartment");
        }

        //------------------GET ALL  DEPARTMENTS------------------------------------------
        [HttpGet]
        public ActionResult getDepartments()
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Administrator))
            {
                DepartmentModel depModel = new DepartmentModel();
                List<Company> ComList = new List<Company>();
                depModel.Companies = _companyService.GetAllCompanies();
                ViewBag.comList = depModel.Companies;

                var dep = _departmentService.GetAllDepartments();
                return View(dep);
            }
            else
            {
                return RedirectToAction("NotAdministrator");
            }
        }

        //------------------UPDATE  DEPARTMENT------------------------------------------
        // GET: /Department/Edit/2
        public ActionResult Edit(int id)
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Administrator))
            {
                DepartmentModel depModel = new DepartmentModel();
                List<Company> ComList = new List<Company>();
                depModel.Companies = _companyService.GetAllCompanies();
                ViewBag.comList = depModel.Companies;

                Department department = _departmentService.GetDepartmentByID(id);
                return View(department);
            }
            else
            {
                return RedirectToAction("NotAdministrator");
            }
       }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (department != null)
            {
                Company company = _companyService.GetCompanyByID(department.ComapanyID);

                if (company != null)
                {
                    var updateDepartment = _departmentService.UpdateDepartment(department);
                }
            }
            else
            {
                return View("Fail", "Department");
            }
            return RedirectToAction("getDepartments", "Department");
        }

        //------------------DELETE  DEPARTMENT------------------------------------------

        // GET: /Department/Delete/2
        public ActionResult Delete(int id)
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Administrator))
            {
                Department department = _departmentService.GetDepartmentByID(id);

                return View(department);
            }
            else
            {
                return RedirectToAction("NotAdministrator");
            }
        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {
            if (department != null)
            {
               _departmentService.deleteDepartment(department);
            }
            else
            {
                return View("Fail", "Department");
            }
            return RedirectToAction("getDepartments", "Department");
        }

        public ActionResult NotAdministrator()
        {
            return View();
        }

        public ActionResult SuccessDepartment()
        {
            return View();
        }

    }
}