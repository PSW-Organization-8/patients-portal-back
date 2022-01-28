
using System;
using System.Collections.Generic;
using System.Text;

using SIMS.Repositories;
using HospitalClassLib.RoomsAndEquipment.Model;

namespace HospitalClassLib.RoomsAndEquipment.RoomInventoryRepo
{
    public interface IRoomInventoryRepository:IGenericRepository<RoomInventory,String>
    {
        RoomInventory ReadNoConsistifying(string brojProstorije, string idInventara);
        RoomInventory Read(string brojProstorije, string idInventara);
    }
}
