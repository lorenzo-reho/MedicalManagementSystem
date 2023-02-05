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

                String queryString = "SELECT CodiceFiscale, Nome, Cognome, Residenza, DataDiNascita, Email, Sesso FROM Utenti WHERE Ruolo = 'Paziente' AND ";
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
                command.Parameters.Add("@dataDiNascita", System.Data.SqlDbType.Date);
                command.Parameters.Add("@sesso", System.Data.SqlDbType.Char);

                command.Parameters["@codiceFiscale"].Value = string.IsNullOrEmpty(filtro.CodiceFiscale) ? (object)DBNull.Value : filtro.CodiceFiscale;
                command.Parameters["@nome"].Value = string.IsNullOrEmpty(filtro.Nome) ? (object)DBNull.Value : filtro.Nome;
                command.Parameters["@cognome"].Value = string.IsNullOrEmpty(filtro.Cognome) ? (object)DBNull.Value : filtro.Cognome;
                command.Parameters["@residenza"].Value = string.IsNullOrEmpty(filtro.Residenza) ? (object)DBNull.Value : filtro.Residenza;
                command.Parameters["@dataDiNascita"].Value = string.IsNullOrEmpty(filtro.DataDiNascita) ? (object)DBNull.Value : filtro.DataDiNascita;
                command.Parameters["@sesso"].Value = filtro.Sex == '\0' ? (object)DBNull.Value : filtro.Sex;


                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read())
                    {
                        utenti.Add(new BaseUserModel
                        {
                            CodiceFiscale = reader.GetString(0),
                            Nome = reader.GetString(1),
                            Cognome = reader.GetString(2),
                            Residenza = reader.GetString(3),
                            DataDiNascita = reader.GetDateTime(4).Date.ToString("d"),
                            Email = reader.GetString(5),
                            Sex = reader.GetString(6).ToCharArray()[0]
                        });
                    }
                }
            }

        }
    }
}
