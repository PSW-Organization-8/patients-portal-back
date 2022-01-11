// File:    Prostorija.cs
// Author:  paracelsus
// Created: Monday, March 22, 2021 6:41:35 PM
// Purpose: Definition of Class Prostorija



using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;

namespace HospitalClassLib.RoomsAndEquipment.Model
{
    public class Room
    {
        public DateTime? RenovationStart { get; set; }
        public DateTime? RenovationEnd { get; set; }
        public RoomType RoomType { get; set; }
        public string Number { get; set; }

        ///////////////
        //public long ID { get; set; }
        //public string Name { get; set; }
        //public Floor Floor { get; set; }
        //public RoomGraphics Graphics { get; set; }

        //public Room(long id, string name, Floor floor)
        //{
        //    this.ID = id;
        //    this.Name = name;
        //    this.Floor = floor;
        //}
        //////////////


        public Dictionary<string, int> InventoryAmounts
        {
            get; set;
        }

        public Room()
        {
            InventoryAmounts = new Dictionary<string, int>();
            this.Number = "";
            this.RoomType = RoomType.patientRoom;
            
        }

        public Room(string Number, RoomType RoomType)
        {
            InventoryAmounts = new Dictionary<string, int>();
            this.Number = Number;
            this.RoomType = RoomType;
            
        }

        public Room(string Number, RoomType RoomType, Dictionary<string, int> InventoryAmounts)
        {
            this.Number = Number;
            this.RoomType = RoomType;
            this.InventoryAmounts = InventoryAmounts;
            
        }


        public string AvailableToString
        {
            get
            {
                return Conversion.RoomAvailabilityToString(Available);
            }
        }

        
        
        public bool Available {
            get
            {
                bool renovating = false;
                if (RenovationStart != null && RenovationEnd != null)
                {
                    renovating = RenovationStart < DateTime.Now && RenovationEnd > DateTime.Now;
                }
                return !renovating;
            }
        }
        
        

       /* public bool GetIfFreeForAppointment(Appointment newAppointment)
        {
            DoctorAppointmentService doctorAppointmentController = new DoctorAppointmentService();
            foreach (Appointment currentAppointment in doctorAppointmentController.GetUpcommingAppointmentsByRoom(this))
            {
                if (newAppointment.GetEndTime() > currentAppointment.StartTime && newAppointment.GetEndTime() <= currentAppointment.GetEndTime())
                    return false;

                if (newAppointment.StartTime >= currentAppointment.StartTime && newAppointment.StartTime < currentAppointment.GetEndTime())
                    return false;
            }

            return true;                
        } */

        /*public bool GetIfFreeForAppointmentUpdate(Appointment newAppointment)
        {
            DoctorAppointmentService doctorAppointmentController = new DoctorAppointmentService();
            foreach (Appointment currentAppointment in doctorAppointmentController.GetUpcommingAppointmentsByRoom(this))
            {
                if (currentAppointment.AppointmentID != newAppointment.AppointmentID)
                {
                    if (newAppointment.GetEndTime() > currentAppointment.StartTime && newAppointment.GetEndTime() <= currentAppointment.GetEndTime())
                        return false;

                    if (newAppointment.StartTime >= currentAppointment.StartTime && newAppointment.StartTime < currentAppointment.GetEndTime())
                        return false;
                }
            }

            return true;
        } */

    }
}