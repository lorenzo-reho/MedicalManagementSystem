using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.Model
{
    internal class DoctorModel : BaseUserModel
    {
        public String Specializzazione { get; set; }
        public String Password { get; set; }
    }
}
