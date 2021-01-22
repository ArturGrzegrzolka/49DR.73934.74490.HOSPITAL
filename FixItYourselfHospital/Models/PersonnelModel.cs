using FixItYourselfHospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItYourselfHospital.Models
{
    // Main model for maintaining all of the hospital's staff
    public class PersonnelModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSecondName{ get; set; }
        public string UserEmail { get; set; }
        public int UserRole { get; set; }
        public int UserSpecialization { get; set; }
        public string UserPwd { get; set; }
        public string UserPesel { get; set; }
        public RoleModel UserRoleModel { get; set; }
        public SpecializationModel UserSpecializationModel { get; set; }

        // for full and proper model these two props should be added in there
        // but for security reasons we don't want to store users' login info
        // it has no use in the application
        //
        // public string UserLogin { get; set; }
        // public string UserPassword { get; set; }
    }
}
