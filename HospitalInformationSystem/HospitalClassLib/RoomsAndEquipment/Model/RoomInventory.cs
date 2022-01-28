using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.RoomsAndEquipment.Model
{
    public class RoomInventory
    {
        public string RoomNumber { get; set; }
        public string ID { get; set; }
        public int Quantity { get; set; }

        public RoomInventory()
        {

        }

        public RoomInventory(string roomNumber, string idInv, int quantity)
        {
            this.RoomNumber = roomNumber;
            this.ID = idInv;
            this.Quantity = quantity;
        }
    }
}
