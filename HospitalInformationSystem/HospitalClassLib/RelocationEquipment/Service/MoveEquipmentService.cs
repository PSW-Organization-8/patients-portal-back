using HospitalClassLib.Equipment.Repository;
using HospitalClassLib.Equipment.Repository.IRepository;
using HospitalClassLib.Equipment.Service;
using HospitalClassLib.RelocationEquipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalClassLib.RelocationEquipment.Service
{
    public class MoveEquipmentService
    {
        private readonly IMoveEquipmentRepository moveEquipmentRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly EquipmentService equipmentService;
        private readonly IRoomRepository roomRepository;


        public MoveEquipmentService(IMoveEquipmentRepository moveEquipmentRepository, IEquipmentRepository equipmentRepository, EquipmentService equipmentService, IRoomRepository roomRepository)
        {
            this.moveEquipmentRepository = moveEquipmentRepository;
            this.equipmentRepository = equipmentRepository;
            this.equipmentService = equipmentService;
            this.roomRepository = roomRepository;
        }

        ////////
        public MoveEquipmentService(IMoveEquipmentRepository moveEquipmentRepository, IEquipmentRepository equipmentRepository, EquipmentService equipmentService)
        {
            this.moveEquipmentRepository = moveEquipmentRepository;
            this.equipmentRepository = equipmentRepository;
            this.equipmentService = equipmentService;
        }
        ///////


        public List<MoveEquipment> GetAllEquipments()
        {
            return moveEquipmentRepository.GetAll();
        }

        public void CreateAllEquipments(List<MoveEquipment> allNewEquipments)
        {
            foreach (MoveEquipment newEquipments in allNewEquipments)
            {
                CreateEquipments(newEquipments);
            }
        }

        public MoveEquipment CreateEquipments(MoveEquipment newEquipments)
        {
            return moveEquipmentRepository.Create(newEquipments);
        }

        public MoveEquipment Get(long id)
        {
            return moveEquipmentRepository.Get(id);
        }

        public bool SubmitRelocation(long idEq, long idRoom, double amount, long destinationRoom, DateTime time, string duration)
        {
            SharedModel.Equipment equipment = equipmentRepository.Get(idEq);


            if (equipment != null && equipmentRepository.Get(idEq).Amount < amount)
            {
                return false;
            }

            // MoveEquipmentDTO meDTO = new MoveEquipmentDTO();

            return equipmentService.MoveEquipment(equipmentRepository.Get(idEq),
                roomRepository.Get(destinationRoom), amount);
        }

        public bool SubmitRelocation(long id, SharedModel.Equipment equipment, double amount, Room destination, TimeAndDuration td)
        {

            if (equipment.Amount < amount)
            {
                return false;
            }

            TimeAndDuration timeAndDuration = new TimeAndDuration(td.RelocationTime, td.Duration);

            MoveEquipment me = new MoveEquipment(id, equipment, destination, amount, timeAndDuration);
            moveEquipmentRepository.Create(me);
            return equipmentService.MoveEquipment(equipment, destination, amount);

        }
    }
}
