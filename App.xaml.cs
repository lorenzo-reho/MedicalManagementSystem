using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MedicalManagementSystem.View;

namespace MedicalManagementSystem
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected void ApplicationStart(object sender, StartupEventArgs args) {
            
            InitializeComponent();

            HomeView homeView = new HomeView();
            homeView.Show();
            /*
            LoginView loginView = new LoginView();
            
            loginView.Show();
            
            loginView.IsVisibleChanged += (s, ev) =>
            {

                if (!loginView.IsVisible && loginView.IsLoaded)
                {
                    // Avvii una nuova View

                    HomeView homeView = new HomeView();
                    homeView.Show();
                    loginView.Close();
                }
                
            };
            */
        }
    }
}
