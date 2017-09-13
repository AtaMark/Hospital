using Hospital.Models.DataBase;
using Hospital.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models.EntityManager
{
    //This class will handle CRUD operations for User Entity
    public class UserManager
    {
        public void AddUser(UserModel user) {
            using (HOSPITALEntities db = new HOSPITALEntities())
            {
                User newUser = new User();
                newUser.name = user.name;
                newUser.email = user.email;
                newUser.departmentID = user.departmentId;
                newUser.user_contact = user.user_contact;
                db.Users.Add(newUser);
            }

        }
    }
}