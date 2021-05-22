using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherManager.Class.Login
{
    class Check
    {
        public bool CheckUser(string email) 
        {
            bool userOk = false;
            if (email.Equals("mondongo")) 
            {
                userOk = true;
            }
            return userOk;
        }


        public bool CheckPassword(string password) 
        {
            bool passwordOk = false;

            if (password.Equals("mondongo mayor")) 
            {
                passwordOk = true;

            }
            return passwordOk;
        }

    }
}
