using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Data.Seeders;

public class ActivitiesSeeder
{
    public readonly ICollection<Activities> _Activities;

    public ActivitiesSeeder()
    {
        _Activities = new List<Activities>();
        _Activities = GenerateActivities();
    }

    private ICollection<Activities> GenerateActivities()
    {
        var list = new List<Activities>()
        {
            new Activities()
            {
                Id = 1,
                Name = "Fishing",
                Description = "Enjoy the serenity of casting your line into calm waters and embracing the art of fishing. Whether you're a seasoned angler or a novice adventurer, fishing offers a tranquil escape into nature's embrace. Feel the excitement as you wait for the tug on your line, surrounded by the picturesque beauty of lakes, rivers, or the vast ocean. Discover the joy of reeling in your catch and creating cherished memories amidst serene landscapes.",
                Url = "",
                ImageUrl = "~/images/activities/fishing.jpg"
            },
            new Activities()
            {
                Id = 2,
                Name = "Cycling",
                Description = "Explore scenic landscapes and picturesque routes on an exhilarating cycling adventure. Feel the wind in your face as you pedal through tranquil countryside and challenging trails. Discover hidden gems and breathtaking vistas while embracing the freedom of the open road. Cycling offers invigorating experiences for enthusiasts of all levels.",
                Url = "",
                ImageUrl = "~/images/activities/cycling.jpg"
            },
            new Activities()
            {
                Id = 3,
                Name = "Hiking",
                Description = "Experience the freedom of hiking amidst nature's wonders. Explore winding trails through forests, mountains, and valleys. Whether you prefer a leisurely walk or a challenging ascent, hiking offers a chance to connect with the wilderness. Immerse yourself in the sights and sounds of nature as you uncover hidden treasures along the way. Embrace the adventure and serenity of hiking.",
                Url = "",
                ImageUrl = "~/images/activities/hiking.jpg"
            },
            new Activities()
            {
                Id = 4,
                Name = "Cruise",
                Description = "Sail away on an unforgettable coastal journey with a scenic cruise. Experience the beauty of our coastline from the comfort of a boat as you glide through tranquil waters and soak in breathtaking views. Whether you crave relaxation or adventure, our cruise promises an unforgettable experience for all. Discover hidden gems and picturesque landscapes as you sail along our stunning shores.",
                Url = "",
                ImageUrl = "~/images/activities/cruise.jpg"
            }
        };

        return list;
    }
}