using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Model
{

    /*
        DATABASE:
            pazienti
            medici
            segreteria

            BaseUserModel
      Paziente Medico Segretari*
     
     */

    internal class BaseUserModel
    {
        public String CodiceFiscale { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Residenza { get; set; }
        public String Role { get; set; }
        public char Sex { get; set; }
        public String DataDiNascita { get; set; }
        public String Telefono { get; set; }

    }
}
