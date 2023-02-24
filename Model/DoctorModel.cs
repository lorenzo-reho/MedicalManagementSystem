using System;

namespace MedicalManagementSystem.Model
{
    internal class DoctorModel : BaseUserModel
    {
        public String Specializzazione { get; set; }
        public String Password { get; set; }
    }
}
