﻿using MedicalManagementSystem.Model;
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

        // Codice Fiscale
        private bool _isCheckedCodiceFiscale;
        private bool _isEnabledCodiceFiscale;
        private String _textCodiceFiscale;
        public bool IsCheckedCodiceFiscale
        {
            get { return _isCheckedCodiceFiscale; }
            set {
                _isCheckedCodiceFiscale = value;
                    OnPropertyChanged(nameof(IsCheckedCodiceFiscale));
                }
        }
        public bool IsEnabledCodiceFiscale
        {
            get { return _isEnabledCodiceFiscale; }
            set { _isEnabledCodiceFiscale = value;
                OnPropertyChanged(nameof(IsEnabledCodiceFiscale)); }
        }
        public String TextCodiceFiscale
        {
            get { return _textCodiceFiscale; }
            set { _textCodiceFiscale= value;
                OnPropertyChanged(nameof(TextCodiceFiscale));
            }

        }

        // Nome
        private bool _isCheckedNome;
        private bool _isEnabledNome;
        private String _textNome;

        public bool IsCheckedNome
        {
            get { return _isCheckedNome; }
            set
            {
                _isCheckedNome = value;
                OnPropertyChanged(nameof(IsCheckedNome));
            }
        }
        public bool IsEnabledNome
        {
            get { return _isEnabledNome; }
            set
            {
                _isEnabledNome = value;
                OnPropertyChanged(nameof(IsEnabledNome));
            }
        }
        public String TextNome
        {
            get { return _textNome; }
            set
            {
                _textNome = value;
                OnPropertyChanged(nameof(TextNome));
            }

        }

        // Cognome
        private bool _isCheckedCognome;
        private bool _isEnabledCognome;
        private String _textCognome;
        public bool IsCheckedCognome
        {
            get { return _isCheckedCognome; }
            set
            {
                _isCheckedCognome = value;
                OnPropertyChanged(nameof(IsCheckedCognome));
            }
        }
        public bool IsEnabledCognome
        {
            get { return _isEnabledCognome; }
            set
            {
                _isEnabledCognome = value;
                OnPropertyChanged(nameof(IsEnabledCognome));
            }
        }
        public String TextCognome
        {
            get { return _textCognome; }
            set
            {
                _textCognome = value;
                OnPropertyChanged(nameof(TextCognome));
            }

        }

        // Residenza
        private bool _isCheckedResidenza;
        private bool _isEnabledResidenza;
        private String _textResidenza;
        public bool IsCheckedResidenza
        {
            get { return _isCheckedResidenza; }
            set
            {
                _isCheckedResidenza = value;
                OnPropertyChanged(nameof(IsCheckedResidenza));
            }
        }
        public bool IsEnabledResidenza
        {
            get { return _isEnabledResidenza; }
            set
            {
                _isEnabledResidenza = value;
                OnPropertyChanged(nameof(IsEnabledResidenza));
            }
        }
        public String TextResidenza
        {
            get { return _textResidenza; }
            set
            {
                _textResidenza = value;
                OnPropertyChanged(nameof(TextResidenza));
            }

        }

        // Data di nascita
        private bool _isCheckedDataDiNascita;
        private bool _isEnabledDataDiNascita;
        private DateTime _selectedDataDiNascita;
        public bool IsCheckedDataDiNascita
        {
            get { return _isCheckedDataDiNascita; }
            set
            {
                _isCheckedDataDiNascita = value;
                OnPropertyChanged(nameof(IsCheckedDataDiNascita));
            }
        }
        public bool IsEnabledDataDiNascita
        {
            get { return _isEnabledDataDiNascita; }
            set
            {
                _isEnabledDataDiNascita = value;
                OnPropertyChanged(nameof(IsEnabledDataDiNascita));
            }
        }
        public DateTime SelectedDataDiNascita
        {
            get { return _selectedDataDiNascita; }
            set
            {
                _selectedDataDiNascita = value;
                OnPropertyChanged(nameof(SelectedDataDiNascita));
            }

        }


        // Sesso
        private bool _isCheckedSex;
        private bool _isEnabledSex;
        private String _textSex;
        public bool IsCheckedSex
        {
            get { return _isCheckedSex; }
            set
            {
                _isCheckedSex = value;
                OnPropertyChanged(nameof(IsCheckedSex));
            }
        }
        public bool IsEnabledSex
        {
            get { return _isEnabledSex; }
            set
            {
                _isEnabledSex = value;
                OnPropertyChanged(nameof(IsEnabledSex));
            }
        }
        public String TextSex
        {
            get { return _textSex; }
            set
            {
                _textSex = value;
                OnPropertyChanged(nameof(TextSex));
            }

        }
        public ObservableCollection<BaseUserModel> UsersList { get; set; }
        
        public ICommand CommandCheckCodiceFiscale { get; }
        public ICommand CommandCheckNome { get; }
        public ICommand CommandCheckCognome { get; }
        public ICommand CommandCheckResidenza { get; }
        public ICommand CommandCheckDataDiNascita { get; }
        public ICommand CommandCheckSesso { get; }
        public ICommand CommandApplicaFiltro { get; }

        UserRepository userRepository;

        public UserManageModel() {

            userRepository = new UserRepository();
            
            UsersList = new ObservableCollection<BaseUserModel>();

            userRepository.FiltroUtenti(new BaseUserModel {  }, UsersList);

            CommandCheckCodiceFiscale = new CommandViewModel(ExecuteCheckCodiceFiscale, (o) => { return true; });
            CommandCheckNome = new CommandViewModel(ExecuteCheckNome, (o) => { return true; });
            CommandCheckCognome = new CommandViewModel(ExecuteCheckCognome, (o) => { return true; });
            CommandCheckResidenza = new CommandViewModel(ExecuteCheckResidenza, (o) => { return true; });
            CommandCheckDataDiNascita = new CommandViewModel(ExecuteCheckDataDiNascita, (o) => { return true; });
            CommandCheckSesso = new CommandViewModel(ExecuteCheckSesso, (o) => { return true; });
            CommandApplicaFiltro = new CommandViewModel(ExecuteApplicaFiltro, CanExecuteApplicaFiltro);

            SelectedDataDiNascita = System.DateTime.Now;
        }

        private bool CanExecuteApplicaFiltro(object obj)
        {
            return true;
        }

        private void ExecuteApplicaFiltro(object obj)
        {
            userRepository.FiltroUtenti(new BaseUserModel
            {
                CodiceFiscale = IsEnabledCodiceFiscale ? TextCodiceFiscale : null,
                Nome = IsEnabledNome ? TextNome : null,
                Cognome = IsEnabledCognome ? TextCognome : null,
                Residenza = IsEnabledResidenza ? TextResidenza : null,
                DataDiNascita = IsEnabledDataDiNascita ? SelectedDataDiNascita.Date.ToString("g") : null
            }, UsersList);
        }

        private void ExecuteCheckSesso(object obj) { IsEnabledSex = IsCheckedSex; }
        private void ExecuteCheckDataDiNascita(object obj){ IsEnabledDataDiNascita = IsCheckedDataDiNascita; }
        private void ExecuteCheckResidenza(object obj){ IsEnabledResidenza = IsCheckedResidenza; }
        private void ExecuteCheckCognome(object obj){ IsEnabledCognome = IsCheckedCognome; }
        private void ExecuteCheckNome(object obj){ IsEnabledNome = IsCheckedNome; }
        private void ExecuteCheckCodiceFiscale(object obj){ IsEnabledCodiceFiscale = IsCheckedCodiceFiscale; }
    }
}
