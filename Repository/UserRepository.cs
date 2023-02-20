using MedicalManagementSystem.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;

namespace MedicalManagementSystem.Repository
{

    // Quando cerco di utilizzare la classe UserRepository, devo controllare se sono connesso al DB 
    internal class UserRepository : DBRepository, IUserRepository
    {

        public Tuple<String, string> AutenticazioneUtente(NetworkCredential networkCredential)
        {

            /*
                Il motivo using dell'istruzione è garantire che l'oggetto venga eliminato non appena esce dall'ambito e non richiede codice esplicito per garantire che ciò accada.
             */
            String queryString = "SELECT CodiceFiscale, email, username, Ruolo, password FROM Utenti WHERE (username=@uname OR email=@uname) AND password=@password AND (Ruolo = 'Admin' OR Ruolo = 'Dottore' OR Ruolo = 'Segreteria')";
            String codiceFiscale = null;
            String ruolo = null;


            using (SqlConnection connection = GetConnection()) {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                
                // Metodi di prevenzione per SQL INJECTION
                
                command.Parameters.Add("@uname", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@password", System.Data.SqlDbType.Binary); // la password non viene salvata come stringa ma come binary
                command.Parameters["@uname"].Value = networkCredential.UserName;
                command.Parameters["@password"].Value = CryptoRepository.Hash(networkCredential.Password);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        codiceFiscale = reader.GetString(0);
                        ruolo = reader.GetString(3);
                    }
                }
                
            }

            return Tuple.Create(codiceFiscale, ruolo);
        }
        public void FiltroUtenti(BaseUserModel filtro, ObservableCollection<BaseUserModel> utenti) {

            using (SqlConnection connection = GetConnection()) {
                connection.Open();

                utenti.Clear();

                String queryString = "SELECT CodiceFiscale, Nome, Cognome, Residenza, DataDiNascita, Email, Sesso FROM Utenti WHERE Ruolo = @ruolo AND ";
                queryString += "(@codiceFiscale IS NULL OR CodiceFiscale=@codiceFiscale) AND ";
                queryString += "(@nome IS NULL OR Nome=@nome) AND ";
                queryString += "(@cognome IS NULL OR Cognome=@cognome) AND ";
                queryString += "(@residenza IS NULL OR Residenza=@residenza) AND ";
                queryString += "(@dataDiNascita IS NULL OR DataDiNascita=@dataDiNascita) AND ";
                queryString += "(@sesso IS NULL OR Sesso=@sesso)";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@codiceFiscale", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@nome", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@cognome", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@residenza", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@ruolo", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@dataDiNascita", System.Data.SqlDbType.Date);
                command.Parameters.Add("@sesso", System.Data.SqlDbType.Char);

                command.Parameters["@codiceFiscale"].Value = string.IsNullOrEmpty(filtro.CodiceFiscale) ? (object)DBNull.Value : filtro.CodiceFiscale;
                command.Parameters["@nome"].Value = string.IsNullOrEmpty(filtro.Nome) ? (object)DBNull.Value : filtro.Nome;
                command.Parameters["@cognome"].Value = string.IsNullOrEmpty(filtro.Cognome) ? (object)DBNull.Value : filtro.Cognome;
                command.Parameters["@residenza"].Value = string.IsNullOrEmpty(filtro.Residenza) ? (object)DBNull.Value : filtro.Residenza;
                command.Parameters["@ruolo"].Value = string.IsNullOrEmpty(filtro.Role) ? (object)DBNull.Value : filtro.Role;
                command.Parameters["@dataDiNascita"].Value = string.IsNullOrEmpty(filtro.DataDiNascita) ? (object)DBNull.Value : filtro.DataDiNascita;
                command.Parameters["@sesso"].Value = filtro.Sex == '\0' ? (object)DBNull.Value : filtro.Sex;


                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read())
                    {
                        utenti.Add(new BaseUserModel
                        {
                            CodiceFiscale = reader.IsDBNull(0) ? null : reader.GetString(0),
                            Nome = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Cognome = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Residenza = reader.IsDBNull(3) ? null : reader.GetString(3),
                            DataDiNascita = reader.IsDBNull(4) ? null : reader.GetDateTime(4).Date.ToString("d"),
                            Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Sex = reader.IsDBNull(6) ? '\0' : reader.GetString(6).ToCharArray()[0]
                        });
                    }
                }
            }

        }
        public ObservableCollection<String> EstrazioneResidenze() {
            ObservableCollection<String> residenze = new ObservableCollection<String>();
            using (SqlConnection connection = GetConnection()){
                connection.Open();

                String queryString = "SELECT DISTINCT Residenza FROM Utenti";
                SqlCommand command = new SqlCommand(queryString, connection);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read())
                        residenze.Add(reader.IsDBNull(0) ? null : reader.GetString(0));
                }

                return residenze;
            }
        }

        public bool AggiungiUtente(BaseUserModel utente)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String queryString = "INSERT INTO Utenti(CodiceFiscale, Nome, Cognome, Email, Username, Ruolo, DataDiNascita, Residenza, Sesso, Telefono) VALUES (@codiceFiscale, @nome, @cognome, @email, @username, @ruolo, @dataDiNascita, @residenza, @sesso, @telefono)";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@codiceFiscale", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@nome", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@cognome", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@ruolo", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@dataDiNascita", System.Data.SqlDbType.Date);
                command.Parameters.Add("@residenza", System.Data.SqlDbType.VarChar);
                command.Parameters.Add("@sesso", System.Data.SqlDbType.Char);
                command.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar);

                command.Parameters["@codiceFiscale"].Value = string.IsNullOrEmpty(utente.CodiceFiscale) ? (object)DBNull.Value : utente.CodiceFiscale;
                command.Parameters["@nome"].Value = string.IsNullOrEmpty(utente.Nome) ? (object)DBNull.Value : utente.Nome;
                command.Parameters["@cognome"].Value = string.IsNullOrEmpty(utente.Cognome) ? (object)DBNull.Value : utente.Cognome;
                command.Parameters["@email"].Value = string.IsNullOrEmpty(utente.Email) ? (object)DBNull.Value : utente.Email;
                command.Parameters["@username"].Value = string.IsNullOrEmpty(utente.UserName) ? (object)DBNull.Value : utente.UserName;
                command.Parameters["@ruolo"].Value = string.IsNullOrEmpty(utente.Role) ? (object)DBNull.Value : utente.Role;
                command.Parameters["@dataDiNascita"].Value = string.IsNullOrEmpty(utente.DataDiNascita) ? (object)DBNull.Value : utente.DataDiNascita;
                command.Parameters["@residenza"].Value = string.IsNullOrEmpty(utente.Residenza) ? (object)DBNull.Value : utente.Residenza;
                command.Parameters["@sesso"].Value = utente.Sex == '\0' ? (object)DBNull.Value : utente.Sex;
                command.Parameters["@telefono"].Value = string.IsNullOrEmpty(utente.Telefono) ? (object)DBNull.Value : utente.Telefono;

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }

            }
        }

        public BaseUserModel GetUserByCodiceFiscale(string codiceFiscale)
        {

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String queryString = "SELECT CodiceFiscale, Nome, Cognome, Email, Username, Ruolo, DataDiNascita, Residenza, Sesso, Telefono FROM Utenti WHERE CodiceFiscale=@codiceFiscale";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@codiceFiscale", System.Data.SqlDbType.VarChar);
                command.Parameters["@codiceFiscale"].Value = string.IsNullOrEmpty(codiceFiscale) ? (object)DBNull.Value : codiceFiscale;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new BaseUserModel()
                        {

                            CodiceFiscale = reader.IsDBNull(0) ? null : reader.GetString(0),
                            Nome = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Cognome = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                            UserName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Role = reader.IsDBNull(5) ? null : reader.GetString(5),
                            DataDiNascita = reader.IsDBNull(6) ? null : reader.GetDateTime(6).Date.ToString("d"),
                            Residenza = reader.IsDBNull(7) ? null : reader.GetString(7),
                            Sex = reader.IsDBNull(8) ? '\0' : reader.GetString(8).ToCharArray()[0],
                            Telefono = reader.IsDBNull(9) ? null : reader.GetString(9)

                        };
                        
                }
                return null;
            }

        }
    }
}
