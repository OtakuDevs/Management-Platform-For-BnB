namespace Skeppsgarden.Web.ViewModels.Rooms;

public class ListRoomsViewModel
{
    // public DateTime CheckIn { get; set; }
    //
    // public DateTime CheckOut { get; set; }
    //
    // public int Nights => (CheckOut - CheckIn).Days;
    //
    // public int NumberOfPeople { get; set; }
    
    public ICollection<ListSingleRoomViewModel> Rooms { get; set; } = new List<ListSingleRoomViewModel>();
    
    // public CustomerViewModel Customer { get; set; } = null!;
    //
    // public string SpecialRequirements { get; set; } = null!;
}