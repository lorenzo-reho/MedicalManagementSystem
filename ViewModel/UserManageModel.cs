using MedicalManagementSystem.Model;
using MedicalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{

    internal class UserManageModel : BaseViewModel
    {

        public static ObservableCollection<BaseUserModel> UsersList { get; set; }
        private BaseViewModel _currentLateralPanel;
        private bool _isCheckedFilterButton;
        private bool _isCheckedEditButton;
        private bool _isEnabledFilterButton;
        private bool _isEnabledEditButton;


        public bool IsCheckedFilterButton
        {
            get { return _isCheckedFilterButton; }
            set { _isCheckedFilterButton = value;  OnPropertyChanged(nameof(IsCheckedFilterButton)); }
        }

        public bool IsCheckedEditButton
        {
            get { return _isCheckedEditButton; }
            set { _isCheckedEditButton = value; OnPropertyChanged(nameof(IsCheckedEditButton)); }
        }

        public BaseViewModel CurrentLateralPanel
        {
            get { return _currentLateralPanel; }
            set { _currentLateralPanel = value; OnPropertyChanged(nameof(CurrentLateralPanel)); }
        }

        public bool IsEnabledFilterButton
        {
            get { return _isEnabledFilterButton; }
            set { _isEnabledFilterButton = value; OnPropertyChanged(nameof(IsEnabledFilterButton)); }
        }

        public bool IsEnabledEditButton
        {
            get { return _isEnabledEditButton; }
            set { _isEnabledEditButton = value; OnPropertyChanged(nameof(IsEnabledEditButton)); }
        }


        public ICommand EditButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }

        public UserManageModel() {
            
            UsersList = new ObservableCollection<BaseUserModel>();

            UserRepository userRepository = new UserRepository();
            userRepository.FiltroUtenti(new BaseUserModel { }, UsersList);

            EditButtonCommand = new CommandViewModel(ExecuteEditButton, CanExecuteEditButton);
            SearchButtonCommand = new CommandViewModel(ExecuteSearchButton, CanExecuteSearchButton);

            IsEnabledFilterButton = true;
            IsEnabledEditButton = true;
        }

        private void ExecuteSearchButton(object obj)
        {
            if (!(CurrentLateralPanel is SearchFilterViewModel))
                CurrentLateralPanel = new SearchFilterViewModel();
        }

        private bool CanExecuteSearchButton(object obj)
        {
            return true;
        }

        private bool CanExecuteEditButton(object obj) {return true;}

        private void ExecuteEditButton(object obj)
        {

            IsEnabledFilterButton = !IsCheckedEditButton;

            if(!(CurrentLateralPanel is SearchFilterViewModel))
                CurrentLateralPanel = new SearchFilterViewModel();
        }
    }
}
