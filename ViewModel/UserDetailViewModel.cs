using MedicalManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    internal class UserDetailViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigationStore;

        public UserDetailViewModel(NavigationStore navigationStore) {
            _navigationStore = navigationStore;
        }

    }
}
