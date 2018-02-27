using Model;
using Model.Model;
using Services.Services;
using Services.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserServices _userService;
        private IDepartmentServices _departmentService;

        public AccountController(IUserServices accISrv, IDepartmentServices depISrv )
        {
            _userService = accISrv;
            _departmentService = depISrv;
        }

        //------------------LOG IN ------------------------------------------
        // GET: method
        public ActionResult Login()
        {
                return View();    //LOG IN page
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel logInData)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", logInData);     //LOG IN page
            }

            var result = _userService.LogIn(logInData.UserName, logInData.Password);

            Company.CurrentUser = result;

            Session["user"] = result;   

            if (result != null)
            {
                if ((Company.CurrentUser.UserType).Equals(UserType.Administrator))
                {
                    return View("HelloAdmin");  //Logged page for Administrator
                }
                if ((Company.CurrentUser.UserType).Equals(UserType.Manager))
                {
                    return View("HelloManager");  
                }
                if ((Company.CurrentUser.UserType).Equals(UserType.Employee))
                {
                    return View("HelloEmployee"); 
                }
            }
            return View("Login");   //NOT Succesffull
        }

        //------------------LOG OUT ------------------------------------------
        public ActionResult Logout()
        {
                Company.CurrentUser = null;
                return RedirectToAction("Login");    //LOG IN page
        }

        //---------------------CREATE NEW USER-------------------------------------------

        [HttpGet]
        public ActionResult newUser()
        {
            UserModel userModel = new UserModel();
            List<Department> DepList = new List<Department>();
            userModel.Departments = _departmentService.GetAllDepartments();
            ViewBag.depList = userModel.Departments;

            if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Administrator)) //Administrator can create new Admin, Manager & Employee
            {
                return View("newUserByUserType");
            }
            else
            {
                return View();  //creating new Employee
            }
        }

        [HttpPost]
        public ActionResult newUser(User user)
        {
            if (ModelState.IsValid)
            {
                var dep = _departmentService.GetDepartmentByID(user.DepartmentID);
                User newUser;

                if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Administrator))
                {
                    newUser = _userService.InsertUserByAdmin(user.UserName, user.Password, user.FirstName, user.LastName, user.Gender, user.Birthday, user.UserType, user.DepartmentID);
                }
                else
                {
                    newUser = _userService.InsertUser(user.UserName, user.Password, user.FirstName, user.LastName, user.Gender, user.Birthday, user.DepartmentID);
                }

                if (newUser != null && Company.CurrentUser == null)
                {
                    return View("Success");
                }

                else if (newUser != null && (Company.CurrentUser.UserType).Equals(UserType.Administrator))
                {
                    return View("SuccessAdmin");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid data");
            }
            return View("newUser");
        }

        //------------GET USERS ---------------------------------

        //[HttpGet]
        public ActionResult getUsers()
        {
            if (Company.CurrentUser !=null && (Company.CurrentUser.UserType).Equals(UserType.Administrator))
            {
                var users = _userService.GetAllUsersWithDepartmentName();
                return View(users);
            }
            else
            {
                return RedirectToAction("NotAdministrator");
            }
        }

        //------------------UPDATE  USER------------------------------------------
        // GET: /User/Edit/2
        public ActionResult Edit(int id)
        {
            if (Company.CurrentUser != null && (Company.CurrentUser.UserType).Equals(UserType.Administrator))
            {
                User user = _userService.GetUserByID(id);

                UserModel userModel = new UserModel();
                List<Department> DepList = new List<Department>();
                userModel.Departments = _departmentService.GetAllDepartments();
                ViewBag.depList = userModel.Departments;

                return View(user);
            }
            else
            {
                return RedirectToAction("NotAdministrator");
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (user != null)
            {
                Department department = _departmentService.GetDepartmentByID(user.DepartmentID);

                if (department != null)
                {
                    var updateTask = _userService.UpdateUser(user);
                }
            }
            else
            {
                return View("Fail", "Account");
            }
            return RedirectToAction("getUsers", "Account");
        }

        public ActionResult NotAdministrator()
        {
            return View();
        }
    }
}