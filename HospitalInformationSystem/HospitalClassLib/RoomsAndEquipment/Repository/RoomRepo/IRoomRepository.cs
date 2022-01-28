
using HospitalClassLib.RoomsAndEquipment.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.RoomsAndEquipment.RoomRepo
{
    interface IRoomRepository:IGenericRepository<Room,String>
    {
        List<Room> UcitajProstorijeZaPreglede();
    }
}
