using Model;
using Model.Model;
using Services.Services;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Attributes;
using WebUI.Models;

namespace WebUI.Controllers
{
    [CustomAuthorize]
    public class TaskController : Controller
    {
        private ITaskServices _taskService;
        private IUserServices _userService;
        private IProjectServices _projectService;

        public TaskController(ITaskServices taskISrv, IUserServices accISrv, IProjectServices projISrv)
        {
            _taskService = taskISrv;
            _userService = accISrv;
            _projectService = projISrv;
        }

        // ---------------- New Task --------------
        [HttpGet]
        public ActionResult newTask()
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                TaskModel taskModel = new TaskModel();

                List<User> empList = new List<User>();
                taskModel.Users = _userService.GetAllEmployeesFromManagerDepartment(Company.CurrentUser.DepartmentID);
                ViewBag.empList = taskModel.Users;

                List<Project> projectList = new List<Project>();
                taskModel.Projects = _projectService.GetAllProjectsByManager(Company.CurrentUser.Id);
                ViewBag.projectList = taskModel.Projects;

                return View();
            }
            else
            {
                return RedirectToAction("Authorize", "Task");
            }
        }

        public ActionResult Authorize()
            {
                return View();
            }

        [HttpPost]
        public ActionResult newTask(Task task)
        {
            if (ModelState.IsValid)
            {
            
                var user = _userService.GetUserByID(task.EmployeeID);
                var project = _projectService.GetProjectByID(task.ProjectID);
                var newTask = _taskService.InsertTask(task.Title, task.StartDate, task.EndDate, task.EstimatedWorkingHour, task.RemainingWorkingHour, task.Description, task.Comment, task.StateOfTask, user.Id, project.Id);

                if (newTask != null)
                {
                    return View("Success");
                }
                else
                    return RedirectToAction("Authorize");
            }
            else
            {
                ModelState.AddModelError("", "Invalid data");
            }
            return View("newTask");
        }

        //------------GET TASKS ---------------------------------

        [HttpGet]
        public ActionResult getTasks()
        {
            if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                var tasksManager = _taskService.GetAllTasksForManager(Company.CurrentUser.Id);
                return View("getTasksManager",tasksManager);
            }
            else if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Employee))
            {
                var tasks = _taskService.GetAllTasksForEmployee(Company.CurrentUser.Id);
                return View("getTasks", tasks);
            }
            else
                return View("Authorize");

        }

        public ActionResult getTasksManager()
        {
            return View();
        }
        //------------------UPDATE  TASK------------------------------------------

        // GET: /Task/Edit/2
        public ActionResult Edit(int id)
        {
            if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                TaskModel taskModel = new TaskModel();

                List<User> empList = new List<User>();
                taskModel.Users = _userService.GetAllEmployeesFromManagerDepartment(Company.CurrentUser.DepartmentID);
                ViewBag.empList = taskModel.Users;

                List<Project> projectList = new List<Project>();
                taskModel.Projects = _projectService.GetAllProjectsByManager(Company.CurrentUser.Id);
                ViewBag.projectList = taskModel.Projects;

                Task task = _taskService.GetTaskByID(id);
                return View(task);
            }
            else if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Employee))
            {
                Task taskEmployee = _taskService.GetTaskByID(id);
                return View("EditForEmployee", taskEmployee);
            }
            return View("Authorize");
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (task != null)
            {
                Project project = _projectService.GetProjectByID(task.ProjectID);
                User employee = _userService.GetUserByID(task.EmployeeID);

                if (project != null && employee != null)
                {
                    var updateTask = _taskService.UpdateTask(task);
                }
            }
            else
            {
                return View("Fail", "Task");
            }
            return RedirectToAction("getTasks", "Task");
        }

        //------------------DELETE  TASK------------------------------------------
        // just state = "canceled"
        // GET: /Task/Delete/2
        public ActionResult Delete(int id)
        {
            if ((Company.CurrentUser.UserType).Equals(UserType.Manager))
            {
                Task task = _taskService.GetTaskByID(id);

                return View(task);
            }
            else
            {
                return RedirectToAction("NotManager");
            }
        }

        [HttpPost]
        public ActionResult Delete(Task task)
        {
            if (task != null)
            {
                _taskService.deleteTask(task);
            }
            else
            {
                return RedirectToAction("Fail", "Task");
            }
            return RedirectToAction("getTasks", "Task");
        }

        public ActionResult NewTaskManager()
        {
            return View();
        }

        public ActionResult Fail()
        {
            return View();
        }
    }
}