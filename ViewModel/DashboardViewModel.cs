using MedicalManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    internal class DashboardViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigationStore;

        public DashboardViewModel(NavigationStore navigationStore) {
            _navigationStore = navigationStore;
        }
    }
}
