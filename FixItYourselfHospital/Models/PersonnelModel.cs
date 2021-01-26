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
        public string UserPwz { get; set; }
        public string UserPesel { get; set; }
        public RoleModel UserRoleModel { get; set; }
        public SpecializationModel UserSpecializationModel { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
    }
}
