using MedicalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    internal class CreateNewUserViewModel : BaseViewModel
    {

        public UserRepository userRepository;
        public ObservableCollection<String> ResidenzeList { get; set; }

        public CreateNewUserViewModel() {

            userRepository = new UserRepository();
            ResidenzeList = userRepository.EstrazioneResidenze();

        }

    }
}
