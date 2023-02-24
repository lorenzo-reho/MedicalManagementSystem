using MedicalManagementSystem.Model;
using MedicalManagementSystem.Stores;
using MedicalManagementSystem.View;
using MedicalManagementSystem.ViewModel;
using System.Windows;

namespace MedicalManagementSystem
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {

        private NavigationStore _navigationStore;

        protected void ApplicationStart(object sender, StartupEventArgs args)
        {

            InitializeComponent();

            _navigationStore = new NavigationStore();

            // navigationStore.CurrentViewModel = new UserManageModel(navigationStore);

            HomeView homeView = new HomeView()
            {
                DataContext = new HomeViewModel(_navigationStore, CreateDashboardViewModel, CreateUserManageViewModel)

            };

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

        private DashboardViewModel CreateDashboardViewModel(object obj)
        {
            return new DashboardViewModel(_navigationStore);
        }

        private UserDetailViewModel CreateUserDetailViewModel(object obj)
        {
            return new UserDetailViewModel(_navigationStore, CreateUserManageViewModel, (BaseUserModel)obj);
        }

        private UserManageModel CreateUserManageViewModel(object obj)
        {
            return new UserManageModel(_navigationStore, CreateUserDetailViewModel);
        }


    }
}
