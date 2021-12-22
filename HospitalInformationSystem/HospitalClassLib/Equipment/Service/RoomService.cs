﻿using HospitalClassLib.Equipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Service
{
   public  class RoomService
    {
        private readonly IRoomRepository roomRepository;
        

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
          
        }

        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAll();
        }

        public void CreateAllRooms(List<Room> allNewRooms)
        {
            foreach (Room newRooms in allNewRooms)
            {
                CreateRooms(newRooms);
            }
        }

        public Room CreateRooms(Room newRooms)
        {
            return roomRepository.Create(newRooms);
        }

        public Room GetByID(long roomID)
        {
            List<Room> allRooms = GetAllRooms();
            foreach (Room r in allRooms)
            {
                if (r.ID == roomID)
                    return r;
            }

            return null;

            //return roomRepository.Get(roomID);
        }

    }
}
