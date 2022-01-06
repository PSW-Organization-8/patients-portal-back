﻿using HospitalClassLib.Equipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Service
{
   public class FloorService
    {
        private readonly IFloorRepository floorRepository;


        public FloorService(IFloorRepository floorRepository)
        {
            this.floorRepository = floorRepository;

        }

        public List<Floor> GetAllFloors()
        {
            return floorRepository.GetAll();
        }

        public void CreateAllFloors(List<Floor> allNewFloors)
        {
            foreach (Floor newFloors in allNewFloors)
            {
                CreateFloors(newFloors);
            }
        }

        public Floor CreateFloors(Floor newFloors)
        {
            return floorRepository.Create(newFloors);
        }
    }
}
