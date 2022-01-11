using HospitalClassLib.Equipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Service
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository equipmentRepository;


        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;

        }

        public List<SharedModel.Equipment> GetAllEquipments()
        {
            return equipmentRepository.GetAll();
        }

        public void CreateAllEquipments(List<SharedModel.Equipment> allNewEquipments)
        {
            foreach (SharedModel.Equipment newEquipments in allNewEquipments)
            {
                CreateEquipments(newEquipments);
            }
        }

        public SharedModel.Equipment CreateEquipments(SharedModel.Equipment newEquipments)
        {
            return equipmentRepository.Create(newEquipments);
        }

        public SharedModel.Equipment Get(long id) 
        {
            return equipmentRepository.Get(id);
        }


        public SharedModel.Equipment GetEquipmentByNameAndRoom(string name, Room room)
        {
            List<SharedModel.Equipment> allEquipment = GetAllEquipments();
            foreach (SharedModel.Equipment e in allEquipment)
            {
                if (e.Name == name && e.Room.ID == room.ID)
                    return e;
            }

            return null;
        }

        public SharedModel.Equipment GetByID(int equipmentID)
        {
            List<SharedModel.Equipment> allEquipment = GetAllEquipments();
            foreach (SharedModel.Equipment e in allEquipment)
            {
                if (e.ID == equipmentID)
                    return e;
            }

            return null;
        }

        public bool MoveEquipment(SharedModel.Equipment equipment, Room room, double amount)
        {
            if (equipment.Amount < amount)
                return false;

            List<SharedModel.Equipment> allEquipment = GetAllEquipments();
            foreach (SharedModel.Equipment e in allEquipment)
            {
                if (e.Name == equipment.Name && e.Room.ID == room.ID)
                {
                    e.Amount += amount;
                    equipmentRepository.Update(e);
                    equipment.Amount -= amount;
                    equipmentRepository.Update(equipment);
                    if (equipment.Amount == 0)
                    {
                        allEquipment.Remove(equipment);
                        equipmentRepository.Delete(equipment.ID);
                    }
                    return true;
                }
            }
            SharedModel.Equipment eq = new SharedModel.Equipment(GetNextID(), equipment.Name, room, amount);
            allEquipment.Add(eq);
            equipmentRepository.Create(eq);
            equipment.Amount -= amount;
            equipmentRepository.Update(equipment);

            if (equipment.Amount == 0)
            {
                allEquipment.Remove(equipment);
                equipmentRepository.Delete(equipment.ID);
            }
            return true;
        }

        public List<SharedModel.Equipment> GetAllInRoom(Room room)
        {
            List<SharedModel.Equipment> foundEquipments = new List<SharedModel.Equipment>();

            foreach (SharedModel.Equipment e in equipmentRepository.GetAll())
            {
                if (e.Room == room)
                    foundEquipments.Add(e);
            }

            return foundEquipments;
        }

        public long GetNextID()
        {
            List<SharedModel.Equipment> allEquipment = GetAllEquipments();
            long max = 0;
            foreach (SharedModel.Equipment e in allEquipment)
            {
                if (e.ID > max)
                    max = e.ID;
            }
            return max + 1;
        }

        public List<SharedModel.Equipment> Search(string str)
        {
            List<SharedModel.Equipment> foundEquipment = new List<SharedModel.Equipment>();

            foreach (SharedModel.Equipment e in GetAllEquipments())
            {
                if (e.Name.Contains(str))
                    foundEquipment.Add(e);

            }

            return foundEquipment;
        }

    }
}
