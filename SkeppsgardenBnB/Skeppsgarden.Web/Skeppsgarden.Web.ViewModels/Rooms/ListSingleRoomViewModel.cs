namespace Skeppsgarden.Web.ViewModels.Rooms;

public class ListSingleRoomViewModel
{
   public Guid Id { get; set; }
   
   public string[] Image { get; set; } = null!;
   
   public int RoomNumber { get; set; }
   
   //First floor or ground floor
   public string Level { get; set; } = null!;
   
   public string View { get; set; } = null!;
   
   public string RoomType { get; set; } = null!;
   
   //If room type is Family, the areas will be listed here : bedroom, kitchen, etc.
   public string? Areas { get; set; }
   
   public int Capacity { get; set; }
   
   public string BedTypes { get; set; } = null!;
   
   public int Rate { get; set; }
   
   public bool IsAvailable { get; set; }
   
}
