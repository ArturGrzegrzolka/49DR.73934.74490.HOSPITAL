using System;
using System.Collections.Generic;
using System.Linq;

namespace FixItYourselfHospital.Models
{
    public class ShiftModel
    {
        public DateTime ShiftDate { get; set; }
        public int ShiftMonth { get; set; }
        public string Month { get; set; }
        public string NurseIds { get; set; }
        public string DoctorIds { get; set; }
        public List<int> NurseIdsList 
        { 
            get 
            {
                if (string.IsNullOrEmpty(NurseIds))
                {
                    return new List<int>();
                }

                return NurseIds.Split(',').Select(Int32.Parse).ToList();
            }
        }
        public List<int> DoctorIdsList
        {
            get
            {
                if (string.IsNullOrEmpty(DoctorIds))
                {
                    return new List<int>();
                }

                return DoctorIds.Split(',').Select(Int32.Parse).ToList();
            }
        }
        public List<int> NurseAutoSchedule { get; set; }
        public List<int> DoctorAutoSchedule { get; set; }
    }
}
