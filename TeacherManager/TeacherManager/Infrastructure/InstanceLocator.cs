

namespace TeacherManager.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewModels;

    class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();//patron "Locator" para poder ligar la login a la MainViewModel
        }
        #endregion
    }

}
