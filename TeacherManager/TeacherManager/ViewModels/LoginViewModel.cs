

namespace TeacherManager.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using TeacherManager.Views;
    using Xamarin.Forms;
    using Services;
    using TeacherManager.Class;
    using TeacherManager.Class.Login;
    using TeacherManager.Class.Connection;

    class LoginViewModel : ViewsModels.BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private Connection connection;
        private CheckIfLoginEmpty fields;

        #endregion

        #region Attributes
        private string email;
        private string password;
        #endregion

        #region Properties
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }



        #endregion

        #region Constructors
        public LoginViewModel(){
            this.apiService = new ApiService();
            this.fields = new CheckIfLoginEmpty();
            this.connection = new Connection();

        }

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get 
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {

            bool emptyFields = fields.Check(Email,Password);

            var connectionState = await this.connection.CheckConnection();
            bool loginOK=true;

            if (emptyFields==true) {

                fields.PaintMessageLoginEmpty();
                loginOK = false;
            }

            if (!connectionState.IsSuccess)
            {
                connection.ConnectionFailedMessage();
                loginOK = false;
            }


            var token = await this.apiService.GetUser(
               "https://localhost:44322/api/users/Mirian",
               this.Email);

            await Application.Current.MainPage.DisplayAlert(
                "Error",
                token.Email,
                "Aceptar");
            return;

            if (loginOK) 
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Start = new StartViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new StartPage());
            }

        }
        #endregion
    }
}
