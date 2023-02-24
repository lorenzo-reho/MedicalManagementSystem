using MedicalManagementSystem.Stores;

namespace MedicalManagementSystem.ViewModel
{
    internal class DashboardViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigationStore;

        public DashboardViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
