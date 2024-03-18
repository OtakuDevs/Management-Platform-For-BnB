using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Data.Seeders;

public class RoomsSeeder
{
    public readonly ICollection<Room> _Rooms;
    public readonly ICollection<RoomsUtilityTypes> _RoomsUtilityTypes;
    public readonly ICollection<RoomsFacilityTypes> _RoomsFacilityTypes;

    public RoomsSeeder()
    {
        _Rooms = new List<Room>();
        _Rooms = GenerateRooms();
        _RoomsUtilityTypes = new List<RoomsUtilityTypes>();
        _RoomsUtilityTypes = GenerateRoomUtilityMapping();
        _RoomsFacilityTypes = new List<RoomsFacilityTypes>();
        _RoomsFacilityTypes = GenerateRoomFacilityMapping();
    }

    private ICollection<Room> GenerateRooms()
    {
        var rooms = new List<Room>()
        {
            new Room()
            {
                Id = Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"),
                RoomNumber = 01,
                RoomTypeId = 3,
                BedTypeId = 2,
                Capacity = 4,
                Rate = 1200,
                IsAvailable = true,
                IsRequested = false,
                Images = "room1.1, room1.2, room1.3",
                ViewTypeId = 3,
                ExtraBedId = 4
            },
            new Room()
            {
                Id = Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"),
                RoomNumber = 02,
                RoomTypeId = 2,
                BedTypeId = 2,
                Capacity = 2,
                Rate = 1200,
                IsAvailable = true,
                IsRequested = false,
                Images = "room2.1, room2.2, room2.3",
                ViewTypeId = 3,
                ExtraBedId = null
            },
            new Room()
            {
                Id = Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"),
                RoomNumber = 03,
                RoomTypeId = 2,
                BedTypeId = 2,
                Capacity = 2,
                Rate = 1200,
                IsAvailable = true,
                IsRequested = false,
                Images = "room3.1, room3.2, room3.3",
                ViewTypeId = 3,
                ExtraBedId = null
            },
            new Room()
            {
                Id = Guid.Parse("462311ac-09ec-4c65-be8d-a7ba24d9c304"),
                RoomNumber = 04,
                RoomTypeId = 3,
                BedTypeId = 2,
                Capacity = 4,
                Rate = 1300,
                IsAvailable = true,
                IsRequested = false,
                Images = "room4.1, room4.2, room4.3",
                ViewTypeId = 3,
                ExtraBedId = 3
            },
            new Room()
            {
                Id = Guid.Parse("863e9ef3-7684-4afe-9e47-fa9834692ea3"),
                RoomNumber = 05,
                RoomTypeId = 2,
                BedTypeId = 2,
                Capacity = 2,
                Rate = 1100,
                IsAvailable = true,
                IsRequested = false,
                Images = "room5.1, room5.2, room5.3",
                ViewTypeId = 2,
                ExtraBedId = null
            }
        };
        return rooms;
    }

    private ICollection<RoomsUtilityTypes> GenerateRoomUtilityMapping()
    {
        var list = new List<RoomsUtilityTypes>()
        {
            // Room 1
            new RoomsUtilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"), utilityTypeId: 4),
            new RoomsUtilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"), utilityTypeId: 6),
            // Room 2
            new RoomsUtilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"), utilityTypeId: 4),
            new RoomsUtilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"), utilityTypeId: 6),
            // Room 3
            new RoomsUtilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"), utilityTypeId: 4),
            new RoomsUtilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"), utilityTypeId: 6),
            // Room 4
            new RoomsUtilityTypes(roomId: Guid.Parse("462311ac-09ec-4c65-be8d-a7ba24d9c304"), utilityTypeId: 4),
            new RoomsUtilityTypes(roomId: Guid.Parse("462311ac-09ec-4c65-be8d-a7ba24d9c304"), utilityTypeId: 5),
            new RoomsUtilityTypes(roomId: Guid.Parse("462311ac-09ec-4c65-be8d-a7ba24d9c304"), utilityTypeId: 6),
            // Room 5
            new RoomsUtilityTypes(roomId: Guid.Parse("863e9ef3-7684-4afe-9e47-fa9834692ea3"), utilityTypeId: 4),
            new RoomsUtilityTypes(roomId: Guid.Parse("863e9ef3-7684-4afe-9e47-fa9834692ea3"), utilityTypeId: 6),
        };
        return list;
    }

    private ICollection<RoomsFacilityTypes> GenerateRoomFacilityMapping()
    {
        var list = new List<RoomsFacilityTypes>()
        {
            // Room 1
            new RoomsFacilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"),
                facilityTypeId: 1),
            new RoomsFacilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"),
                facilityTypeId: 2),
            new RoomsFacilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"),
                facilityTypeId: 3),
            new RoomsFacilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"),
                facilityTypeId: 4),
            new RoomsFacilityTypes(roomId: Guid.Parse("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"),
                facilityTypeId: 5),
            // Room 2
            new RoomsFacilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"),
                facilityTypeId: 2),
            new RoomsFacilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"),
                facilityTypeId: 3),
            new RoomsFacilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"),
                facilityTypeId: 4),
            new RoomsFacilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"),
                facilityTypeId: 5),
            new RoomsFacilityTypes(roomId: Guid.Parse("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"),
                facilityTypeId: 6),
            // Room 3
            new RoomsFacilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"),
                facilityTypeId: 1),
            new RoomsFacilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"),
                facilityTypeId: 2),
            new RoomsFacilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"),
                facilityTypeId: 3),
            new RoomsFacilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"),
                facilityTypeId: 4),
            new RoomsFacilityTypes(roomId: Guid.Parse("8cae901b-6b04-4ada-8353-76f10e080009"),
                facilityTypeId: 5),
        };
        return list;
    }
}