using Model;
using Model.Model;
using Services.Services;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Attributes;

namespace WebUI.Controllers
{
    [CustomAuthorize]
    public class ProjectController : Controller
    {
        private IProjectServices _projectService;
        private IDepartmentServices _departmentService;
        private IUserServices _userService;

        public ProjectController(IProjectServices projISrv, IDepartmentServices depISrv, IUserServices accISrv)
        {
            _projectService = projISrv;
            _departmentService = depISrv;
            _userService = accISrv;
        }

        //---------------- NEW  PROJECT------------------------------------------

        [HttpGet]
        public ActionResult newProject()
        {
            return View();  //CREATE new project page
        }

        [HttpPost]
        public ActionResult newProject(Project project)
        {
            if (ModelState.IsValid)
            {
                var newProject = _projectService.InsertProject(project.Title, project.StartDate, project.EndDate, project.Description, project.Cost, Company.CurrentUser.DepartmentID, Company.CurrentUser.Id);

                if (newProject != null)
                {
                    return View("Success");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid data");
            }
            return View("newProject");
        }
        //------------GET PROJECTS ---------------------------------

        [HttpGet]
        public ActionResult getProjects()
        {
            if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                var managersProjects = _projectService.GetAllProjectsByManagerWithDepartment(Company.CurrentUser.Id);
                return View(managersProjects);
            }
            else
            {
                return RedirectToAction("NotManager");
            }
        }

        //------------------UPDATE  PROJECT------------------------------------------
        // GET: /Project/Edit/2
        public ActionResult Edit(int id)
        {
            if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                Project project = _projectService.GetProjectByID(id);
                return View(project);
            }
            else
            {
                return RedirectToAction("NotManager");
            }
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (project != null)
            {
                project.ManagerID = Company.CurrentUser.Id;
                project.DepartmentID = Company.CurrentUser.DepartmentID;
                Department department = _departmentService.GetDepartmentByID(project.DepartmentID);
                User manager = _userService.GetUserByID(Company.CurrentUser.Id);

                if (department != null && manager != null)
                {
                    var updateProject = _projectService.UpdateProject(project);
                }
            }
            else
            {
                return View("Fail", "Project");
            }
            return RedirectToAction("getProjects", "Project");
        }

        public ActionResult NotManager()
        {
            return View();
        }


        //------------------DELETE  PROJECT------------------------------------------

        // GET: /Project/Delete/2
        public ActionResult Delete(int id)
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                Project project = _projectService.GetProjectByID(id);

                return View(project);
            }
            else
            {
                return RedirectToAction("NotManager");
            }
        }

        [HttpPost]
        public ActionResult Delete(Project project)
        {
            if (project != null)
            {
                _projectService.deleteProject(project);
            }
            else
            {
                return View("Fail", "Project");
            }
            return RedirectToAction("getProjects", "Project");
        }
    }
}