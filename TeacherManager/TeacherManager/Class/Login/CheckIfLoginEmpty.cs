using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TeacherManager.Class.Login
{
     public class CheckIfLoginEmpty 
    {
        public bool Check(string email, string password) {

            bool fieldsEmpty = false;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                fieldsEmpty = true;
            }



            return fieldsEmpty;
        }
        public async void PaintMessageLoginEmpty()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Debe rellenar todos los campos",
                "Aceptar");
            return;
        }

        public async void PaintMessageLoginIncorrect()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Email o contraseña no son correctos",
                "Aceptar");
            return;
        }
    }
}
