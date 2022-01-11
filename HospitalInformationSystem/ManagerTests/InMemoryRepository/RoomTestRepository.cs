using HospitalClassLib.Equipment.Repository.IRepository;

using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTests.InMemoryRepository
{
    public class RoomTestRepository : IRoomRepository
    {
        private Dictionary<long, Room> allRooms = new Dictionary<long, Room>();

        public RoomTestRepository()
        {

            Building building = new Building(1, "Prva zgrada");
            Floor floor = new Floor(1, "Prvi sprat", building);

            Room room1 = new Room(1, "Prva soba", floor);
            room1.Graphics = new RoomGraphics(0, 0, 1, 1, 33);
            Room room2 = new Room(2, "Druga soba", floor);
            room2.Graphics = new RoomGraphics(0, 1, 1, 1, 33);
            Room room3 = new Room(3, "Treca soba", floor);
            room3.Graphics = new RoomGraphics(0, 2 ,1 ,1 ,33);
            Room room4 = new Room(4, "Cetvrta soba", floor);
            room4.Graphics = new RoomGraphics(1, 0 ,2, 1, 50);
            Room room5 = new Room(5, "Peta soba", floor);
            room5.Graphics = new RoomGraphics(1, 1, 2, 1, 50);
            Room room6 = new Room(6, "Sesta soba", floor);
            room6.Graphics = new RoomGraphics(2, 0, 1, 1, 25);
            Room room7 = new Room(7, "Sedma soba", floor);
            room7.Graphics = new RoomGraphics(2, 1, 1, 1, 25);
            Room room8 = new Room(8, "Osma soba", floor);
            room8.Graphics = new RoomGraphics(2, 2, 1, 1, 25);
            Room room9 = new Room(9, "Deveta soba", floor);
            room9.Graphics = new RoomGraphics(2, 3, 1, 1, 25);




            allRooms.Add(1, room1);
            allRooms.Add(2, room2);
            allRooms.Add(3, room3);
            allRooms.Add(4, room4);
            allRooms.Add(5, room5);
            allRooms.Add(6, room6);
            allRooms.Add(7, room7);
            allRooms.Add(8, room8);
            allRooms.Add(9, room9);
        }

        public Room Create(Room t)
        {
            allRooms.Add(t.ID, t);
            return allRooms[t.ID];
        }

        public bool Delete(long id)
        {
            return allRooms.Remove(id);
        }

        public bool ExistsById(long id)
        {
            return allRooms.ContainsKey(id);
        }

        public Room Get(long id)
        {
            return allRooms[id];
        }

        public List<Room> GetAll()
        {
            return allRooms.Values.ToList();
        }

        public Room Update(Room t)
        {
            allRooms[t.ID] = t;
            return allRooms[t.ID];
        }
    }
}
