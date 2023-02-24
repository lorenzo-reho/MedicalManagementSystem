using MedicalManagementSystem.Model;
using System;
using System.Collections.ObjectModel;
using System.Net;


namespace MedicalManagementSystem.Repository
{

    // In questa interfaccia vengono definiti tutti i metodi necessari per interagire
    // con le tabelle del database corrispondenti agli utenti (Dottori, Pazienti, Personale e Amministratori)

    internal interface IUserRepository
    {

        Tuple<string, string> AutenticazioneUtente(NetworkCredential networkCredential);
        void FiltroUtenti(BaseUserModel filtro, ObservableCollection<BaseUserModel> utenti);
        BaseUserModel GetUserByCodiceFiscale(String codiceFiscale);
        ObservableCollection<String> EstrazioneResidenze();
        bool AggiungiUtente(BaseUserModel utente);
        bool AggiornaUtente(BaseUserModel utente);


    }
}
