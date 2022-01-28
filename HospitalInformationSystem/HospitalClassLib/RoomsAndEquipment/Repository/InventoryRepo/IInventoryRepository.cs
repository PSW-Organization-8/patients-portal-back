
using HospitalClassLib.RoomsAndEquipment.Model;
using HospitalClassLib.SharedModel;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.RoomsAndEquipment.InventoryRepo
{
    interface IInventoryRepository:IGenericRepository<Inventory,String>
    {
        
    }
}
