using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MedicalManagementSystem.Repository
{
    internal class UsefulChecks
    {

        public const string motif = @"^\+?[1-9]\d{1,14}$";

        public static bool CheckCodiceFiscale(String codiceFiscale)
        {
            // Controllare il codice fiscale facendo la prova con gli altri dati anagrafici inseriti
            if (String.IsNullOrEmpty(codiceFiscale)) return false;
            return codiceFiscale.Length == 16;
        }

        public static bool CheckEmail(String email)
        {
            if (String.IsNullOrEmpty(email)) return true;

            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }

        public static bool CheckTelefono(String telefono)
        {
            if (String.IsNullOrEmpty(telefono)) return true;
            return Regex.IsMatch(telefono, motif);
        }

    }
}
