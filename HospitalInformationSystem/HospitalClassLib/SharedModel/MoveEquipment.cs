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

        public DateTime RelocationTime { get; set; }

        public string Duration { get; set; }

        // public ArrayList freeTrerms { get; set; }


        public MoveEquipment()
        {

        }

        public MoveEquipment(long id, Equipment eq, Room destination, DateTime time, string durationRel, double amountt)
        {
            this.ID = id;
            this.Equipment = eq;
            this.DestinationRoom = destination;
            this.RelocationTime = time;
            this.Duration = durationRel;
            this.Amount = amountt;
        }
    }
}
