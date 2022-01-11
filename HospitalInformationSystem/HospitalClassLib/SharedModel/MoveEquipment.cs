using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.SharedModel
{
    public class MoveEquipment
    {
        public long ID { get; set; }

        public Equipment Equipment { get; set; }

        public double Amount { get; set; }
        public Room DestinationRoom { get; set; }

        public TimeAndDuration TimeAndDuration{ get; set;}

        // public ArrayList freeTrerms { get; set; }

        public MoveEquipment()
        {

        }

        public MoveEquipment(long id, Equipment eq, Room destination, double amount, TimeAndDuration td)
        {
            this.ID = id;
            this.Equipment = eq;
            this.DestinationRoom = destination;
            this.TimeAndDuration = td;
            this.Amount = amount;

            Validate();
        }

        private void Validate()
        {
            if (Amount <= 0) throw new ArgumentException("Amount must be strictly positive");
        }
    }
}
