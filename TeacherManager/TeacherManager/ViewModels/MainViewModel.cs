

namespace TeacherManager.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public StartViewModel Start { get; set; }




        #endregion

        #region Constructors
        public MainViewModel()
        {
            this.Login = new LoginViewModel();

        }
        #endregion

        //Singleton permite crear una sola MainViewModel en todo el proyecto
        //llamamos a la MainViewModel desde cualquier clase sin tener que instanciar otra MainViewModel
        #region Singleton 
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }

        #endregion
    }
    //crol+r+r --> para que refactorice
}
