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
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSecondName{ get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public string UserSpecialization { get; set; }
        public string UserPwd { get; set; }
        public string UserPesel { get; set; }
    }
}
