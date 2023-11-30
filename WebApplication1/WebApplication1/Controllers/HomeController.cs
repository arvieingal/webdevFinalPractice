using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private friendDBEntities frienddb = new friendDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InputData()
        {
            ViewBag.Message = "Input your data";

            return View();
        }

        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["firstname"];
            String lastName = fc["lastname"];
            String email = fc["email"];
            String diko = fc["password"];

            user use = new user();
            use.firstname = firstName;
            use.lastname = lastName;
            use.email = email;
            use.password = diko;
            use.roleId = 1;

            friendDBEntities fe = new friendDBEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("InputData");
        }

        public ActionResult ShowUser()
        {
            friendDBEntities fe = new friendDBEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["userList"] = userList;
            return View();
        }

        public ActionResult EditUser(int userId)
        {
            int x = userId;

            return View();
        }

        //    public ActionResult UpdateData()
        //    {
        //        ViewBag.Message = "Update your data";

        //        friendDBEntities frienddb = new friendDBEntities();

        //        // Retrieve the list of users for the dropdown
        //        List<user> userList = frienddb.users.ToList();

        //        // Create a SelectList and set it in ViewBag
        //        ViewBag.UserList = new SelectList(userList, "userId", "firstname");

        //        return View(userList);
        //    }

        //    [HttpPost]
        //    public ActionResult UpdateUser(int userId, string firstname, string lastname, string email, string password)
        //    {
        //        // TODO: Validate input and handle errors if needed

        //        // Retrieve the user to update
        //        user userToUpdate = frienddb.users.Find(userId);

        //        // Update user properties
        //        if (userToUpdate != null)
        //        {
        //            userToUpdate.firstname = firstname;
        //            userToUpdate.lastname = lastname;
        //            userToUpdate.email = email;
        //            userToUpdate.password = password;

        //            // Save changes to the database
        //            frienddb.SaveChanges();
        //        }

        //        // Redirect to a different action or view after the update
        //        return RedirectToAction("UpdateData");
        //    }


        //    //public ActionResult UpdateUser(FormCollection fc)
        //    //{
        //    //    String firstname = fc["firstname"];
        //    //    String lastname = fc["lastname"];
        //    //    String email = fc["email"];
        //    //    String password = fc["password"];

        //    //    friendDBEntities frienddb = new friendDBEntities();

        //    //    user u = (from a in frienddb.users where a.userId == 3 select a).FirstOrDefault();

        //    //    u.firstname = "Aviella";
        //    //    u.lastname = "Cardines";
        //    //    u.email = "aviella@gmail.com";
        //    //    u.password = "gwapakaayo";
        //    //    u.roleId = 1;
        //    //    frienddb.SaveChanges();

        //    //    return View();
        //    //}

        //    public ActionResult DeleteUser()
        //    {
        //        friendDBEntities frienddb = new friendDBEntities();

        //        user u = (from a in frienddb.users where a.userId == 2 select a).FirstOrDefault();

        //        frienddb.users.Remove(u);
        //        frienddb.SaveChanges();

        //        return View();
        //    }
        //}
    }
}