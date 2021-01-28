using FixItYourselfHospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FixItYourselfHospital.Data
{
    // let's solve Nurse Scheduling Problem
    public class ShiftRecalculation
    {
        // dateTime props
        private DateTime _dateOfInterest { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int daysAmount { get; set; }

        // personnel props
        public int nurseAmount { get; set; }
        public int cardiologistAmount { get; set; }
        public int laryngologistAmount { get; set; }
        public int neurologistAmount { get; set; }
        public int urologistAmount { get; set; }
        public List<PersonnelModel> personnelList { get; set; }
        public List<PersonnelModel> nurseList { get; set; }
        public List<PersonnelModel> cardiologistList { get; set; }
        public List<PersonnelModel> laryngologistList { get; set; }
        public List<PersonnelModel> neurologistList { get; set; }
        public List<PersonnelModel> urologistList { get; set; }
        public List<int> nurseIds { get; set; }
        public List<int> doctorIds { get; set; }
        public List<ShiftModel> shiftForMonth { get; set; }

        // utility props
        public int maxDaysInMonth { get { return 10; } }
        public int numberOfIterations { get { return daysAmount / maxDaysInMonth; } }

        public ShiftRecalculation(DateTime dateOfInterest)
        {
            // set dateTime props
            _dateOfInterest = dateOfInterest;
            month = _dateOfInterest.Month;
            year = _dateOfInterest.Year;
            daysAmount = DateTime.DaysInMonth(year, month);

            // set personnel props
            personnelList = StaticData.personnelModelList;

            nurseList = new List<PersonnelModel>();
            personnelList.Where(p => p.UserSpecialization.Equals(5)).ToList().ForEach(p => nurseList.Add(p));
            cardiologistList = new List<PersonnelModel>();
            personnelList.Where(p => p.UserSpecialization.Equals(1)).ToList().ForEach(p => cardiologistList.Add(p));
            laryngologistList = new List<PersonnelModel>();
            personnelList.Where(p => p.UserSpecialization.Equals(2)).ToList().ForEach(p => laryngologistList.Add(p));
            neurologistList = new List<PersonnelModel>();
            personnelList.Where(p => p.UserSpecialization.Equals(3)).ToList().ForEach(p => neurologistList.Add(p));
            urologistList = new List<PersonnelModel>();
            personnelList.Where(p => p.UserSpecialization.Equals(4)).ToList().ForEach(p => urologistList.Add(p));

            nurseAmount = nurseList.Count();
            cardiologistAmount = cardiologistList.Count();
            laryngologistAmount = laryngologistList.Count();
            neurologistAmount = neurologistList.Count();
            urologistAmount = urologistList.Count();
        }

        public void ScheduleShifts()
        {
            PrepareShiftModelList();
            ScheduleNurses();
            ScheduleDoctors(cardiologistAmount, cardiologistList);
            ScheduleDoctors(laryngologistAmount, laryngologistList);
            ScheduleDoctors(neurologistAmount, neurologistList);
            ScheduleDoctors(urologistAmount, urologistList);

            foreach (var shift in shiftForMonth)
            {
                shift.DoctorIds = string.Join(",", shift.DoctorAutoSchedule);
                shift.NurseIds = string.Join(",", shift.NurseAutoSchedule);
            }

            StaticData.dataContext.GenerateShifts(PrepareScheduleDataTable());
        }

        private void PrepareShiftModelList()
        {
            shiftForMonth = new List<ShiftModel>();

            for (int i = 1; i <= daysAmount; i++)
            {
                shiftForMonth.Add(new ShiftModel()
                {
                    ShiftDate = Convert.ToDateTime($"{i}/{month}/{year}"),
                    ShiftMonth = month,
                    NurseIds = string.Empty,
                    DoctorIds = string.Empty,
                    NurseAutoSchedule = new List<int>(),
                    DoctorAutoSchedule = new List<int>()
                });
            }
        }

        private void ScheduleNurses()
        {
            var maxShiftsCounterOdd = 1;
            var maxShiftsCounterEven = 1;
            var currentEmployeeOdd = new PersonnelModel();
            var currentEmployeeEven = new PersonnelModel();

            // create loop for every nurse because we want to schedule shift for every one of them
            try
            {
                for (int i = 0; i < nurseAmount; i++)
                {
                    // let's loop through every day in a month
                    for (int j = 1; j <= daysAmount; j++)
                    {
                        if (maxShiftsCounterOdd > maxDaysInMonth && maxShiftsCounterEven > maxDaysInMonth)
                        {
                            i += 2;
                            maxShiftsCounterOdd = 1;
                            maxShiftsCounterEven = 1;
                        }

                        if (j % 2 == 0 && !shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).NurseAutoSchedule.Contains(nurseList[i].UserId))
                        {
                            currentEmployeeEven = nurseList[i];
                            maxShiftsCounterEven++;
                            shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).NurseAutoSchedule.Add(currentEmployeeEven.UserId);
                        }
                        else if (!shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).NurseAutoSchedule.Contains(nurseList[i + 1].UserId))
                        {
                            currentEmployeeOdd = nurseList[i + 1];
                            maxShiftsCounterOdd++;
                            shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).NurseAutoSchedule.Add(currentEmployeeOdd.UserId);
                        }
                    }

                    if (maxShiftsCounterEven <= maxDaysInMonth)
                    {
                        for (int k = 2; k <= (maxDaysInMonth - maxShiftsCounterEven) + 1; k++)
                        {
                            if (k % 2 == 0 && !shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Contains(nurseList[i].UserId))
                            {
                                currentEmployeeEven = nurseList[i];
                                maxShiftsCounterEven++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Add(currentEmployeeEven.UserId);
                            }
                            else if (!shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Contains(nurseList[i + 1].UserId))
                            {
                                currentEmployeeOdd = nurseList[i + 1];
                                maxShiftsCounterOdd++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Add(currentEmployeeOdd.UserId);
                            }
                        }
                    }

                    if (maxShiftsCounterOdd <= maxDaysInMonth)
                    {
                        for (int k = 1; k <= maxDaysInMonth - maxShiftsCounterOdd; k++)
                        {
                            if (k % 2 == 0 && !shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Contains(nurseList[i].UserId))
                            {
                                currentEmployeeEven = nurseList[i];
                                maxShiftsCounterEven++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Add(currentEmployeeEven.UserId);
                            }
                            else if (!shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Contains(nurseList[i + 1].UserId))
                            {
                                currentEmployeeOdd = nurseList[i + 1];
                                maxShiftsCounterOdd++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).NurseAutoSchedule.Add(currentEmployeeOdd.UserId);
                            }
                        }
                    }

                    maxShiftsCounterEven = 1;
                    maxShiftsCounterOdd = 1;
                    i = nurseList.IndexOf(currentEmployeeOdd);
                }
            }
            // do nothing if we run out of employees or days in a month - just repeat for the last nurse which raised an esception
            catch (IndexOutOfRangeException ex) { }
            catch (ArgumentOutOfRangeException ex) { }
        }
        private void ScheduleDoctors(int doctorsAmount, List<PersonnelModel> doctorsList)
        {
            var maxShiftsCounterOdd = 1;
            var maxShiftsCounterEven = 1;
            var currentEmployeeOdd = new PersonnelModel();
            var currentEmployeeEven = new PersonnelModel();

            // create loop for every doctor because we want to schedule shift for every one of them
            try
            {
                for (int i = 0; i < doctorsAmount; i++)
                {
                    // let's loop through every day in a month
                    for (int j = 1; j <= daysAmount; j++)
                    {
                        if (maxShiftsCounterOdd > maxDaysInMonth && maxShiftsCounterEven > maxDaysInMonth)
                        {
                            i += 2;
                            maxShiftsCounterOdd = 1;
                            maxShiftsCounterEven = 1;
                        }

                        if (j % 2 == 0 && !shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).DoctorAutoSchedule.Contains(doctorsList[i].UserId))
                        {
                            currentEmployeeEven = doctorsList[i];
                            maxShiftsCounterEven++;
                            shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).DoctorAutoSchedule.Add(currentEmployeeEven.UserId);
                        }
                        else if (!shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).DoctorAutoSchedule.Contains(doctorsList[i + 1].UserId))
                        {
                            currentEmployeeOdd = doctorsList[i + 1];
                            maxShiftsCounterOdd++;
                            shiftForMonth.First(s => s.ShiftDate.Day.Equals(j)).DoctorAutoSchedule.Add(currentEmployeeOdd.UserId);
                        }
                    }

                    if (maxShiftsCounterEven <= maxDaysInMonth)
                    {
                        for (int k = 2; k <= (maxDaysInMonth - maxShiftsCounterEven) + 1; k++)
                        {
                            if (k % 2 == 0 && !shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Contains(doctorsList[i].UserId))
                            {
                                currentEmployeeEven = doctorsList[i];
                                maxShiftsCounterEven++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Add(currentEmployeeEven.UserId);
                            }
                            else if (!shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Contains(doctorsList[i + 1].UserId))
                            {
                                currentEmployeeOdd = doctorsList[i + 1];
                                maxShiftsCounterOdd++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Add(currentEmployeeOdd.UserId);
                            }
                        }
                    }

                    if (maxShiftsCounterOdd <= maxDaysInMonth)
                    {
                        for (int k = 1; k <= maxDaysInMonth - maxShiftsCounterOdd; k++)
                        {
                            if (k % 2 == 0 && !shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Contains(doctorsList[i].UserId))
                            {
                                currentEmployeeEven = doctorsList[i];
                                maxShiftsCounterEven++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Add(currentEmployeeEven.UserId);
                            }
                            else if (!shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Contains(doctorsList[i + 1].UserId))
                            {
                                currentEmployeeOdd = doctorsList[i + 1];
                                maxShiftsCounterOdd++;
                                shiftForMonth.First(s => s.ShiftDate.Day.Equals(k)).DoctorAutoSchedule.Add(currentEmployeeOdd.UserId);
                            }
                        }
                    }

                    maxShiftsCounterEven = 1;
                    maxShiftsCounterOdd = 1;
                    i = doctorsList.IndexOf(currentEmployeeOdd);
                }
            }
            // do nothing if we run out of employees or days in a month - just repeat for the last nurse which raised an esception
            catch (IndexOutOfRangeException ex) { }
            catch (ArgumentOutOfRangeException ex) { }
        }

        private DataTable PrepareScheduleDataTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("ShiftDay", typeof(DateTime));
            dataTable.Columns.Add("ShiftMonth", typeof(int));
            dataTable.Columns.Add("NurseIds", typeof(string));
            dataTable.Columns.Add("DoctorIds", typeof(string));

            foreach(var shift in shiftForMonth)
            {
                var dataRow = dataTable.NewRow();
                dataRow["ShiftDay"] = shift.ShiftDate;
                dataRow["ShiftMonth"] = shift.ShiftMonth;
                dataRow["NurseIds"] = shift.NurseIds;
                dataRow["DoctorIds"] = shift.DoctorIds;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
