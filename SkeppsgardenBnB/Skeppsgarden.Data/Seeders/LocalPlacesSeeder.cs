using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Data.Seeders;

public class LocalPlacesSeeder
{
    public readonly ICollection<LocalPlace> _LocalPlaces;

    public LocalPlacesSeeder()
    {
        _LocalPlaces = new List<LocalPlace>();
        _LocalPlaces = GenerateLocalPlaces();
    }

    private ICollection<LocalPlace> GenerateLocalPlaces()
    {
        var list = new List<LocalPlace>()
        {
            new LocalPlace()
            {
                Id = 1,
                Name = "Valdemarsvik",
                Description =
                    "Valdemarsvik is a locality situated alongside the bay of Valdemarsviken, which connects to the Baltic Sea, and is the seat of Valdemarsvik Municipality in Östergötland County, Sweden. The coastal area is a popular summer destination, particularly with Swedish tourists.",
                Url = "https://www.valdemarsvik.se/visit/",
                ImageUrl = "~/images/local-places/Valdemarsvik.jpg"
            },
            new LocalPlace()
            {
                Id = 2,
                Name = "Gamleby",
                Description =
                    "Gamleby is the second largest locality situated in Västervik Municipality, Kalmar County, Sweden with 2,775 inhabitants in 2010. It is situated about 20 km north-west of Västervik, in the area known as Tjust.",
                Url = "https://www.gamleby.se/turist.html",
                ImageUrl = "~/images/local-places/Gamleby.jpg"
            },
            new LocalPlace()
            {
                Id = 3,
                Name = "Loftahammar",
                Description =
                    "Loftahammar is a locality situated in Västervik Municipality, Kalmar County, Sweden with 404 inhabitants in 2010. It is a coastal town located on a peninsula and has roots dating back to the mid-13th century, with a population that grows by several thousand during the summer months.",
                Url = "https://loftahammar.com/pa-besok/",
                ImageUrl = "~/images/local-places/Loftahammar.jpg"
            },
            new LocalPlace()
            {
                Id = 4,
                Name = "Tindered",
                Description =
                    "Tindered is a popular destination in Småland, Sweden, where visitors can enjoy a variety of activities and amenities. At Tindered Lantkök, the on-site restaurant and café, guests can enjoy fika, home-baked goods, daily specials, and à la carte dishes, as well as visit the farm shop for gifts, locally produced items, newspapers, and ice cream.",
                Url = "https://www.tindered.se/",
                ImageUrl = "~/images/local-places/Tindered.jpg"
            },
            new LocalPlace()
            {
                Id = 5,
                Name = "Västervik",
                Description =
                    "Västervik is a city and the seat of Västervik Municipality, Kalmar County, Sweden, with 36,747 inhabitants in 2021. It is one of three coastal towns with a notable population size in the province of Småland and is known as the archipelago town in Småland, where visitors can experience tranquility, nature, fun events and at the same time put a golden edge on their existence.",
                Url = "https://www.vastervik.com/",
                ImageUrl = "~/images/local-places/Vastervik.jpg"
            },
            new LocalPlace()
            {
                Id = 6,
                Name = "Vimmerby",
                Description =
                    "Vimmerby is a city and the seat of Vimmerby Municipality, Kalmar County, Sweden with 10,934 inhabitants in 2010. It is one of the oldest cities in Sweden and received its charter as early as the fourteenth century, with its main street, Storgatan, still retaining its medieval shape.",
                Url = "https://www.vimmerby.com/",
                ImageUrl = "~/images/local-places/Vimmerby.jpg"
            },
            new LocalPlace()
            {
                Id = 7,
                Name = "Norrköping",
                Description =
                    "Norrköping is a city in the province of Östergötland in eastern Sweden and the seat of Norrköping Municipality, Östergötland County, about 160 km southwest of the national capital Stockholm. The city has a population of 95,618 inhabitants in 2016, out of a municipal total of 130,050, making it Sweden’s tenth largest city and eighth largest municipality.",
                Url = "https://www.norrkoping.se/",
                ImageUrl = "~/images/local-places/Norrkoping.jpg"
            },
            new LocalPlace()
            {
                Id = 8,
                Name = "Kolmården",
                Description =
                    "Kolmården is a densely forested rocky ridge that separates the Swedish provinces of Södermanland and Östergötland, and historically formed the border between the land of the Swedes and the land of the Geats. It is also home to Kolmården Wildlife Park, one of Scandinavia’s most exciting experiences, covering 1.5 square kilometers and home to countless animal species, thrilling rides, and magical shows.",
                Url = "https://www.kolmarden.com/",
                ImageUrl = "~/images/local-places/Kolmarden.jpg"
            },
            new LocalPlace()
            {
                Id = 9,
                Name = "Söderköping",
                Description =
                    "Söderköping is a locality and the seat of Söderköping Municipality, Östergötland County, Sweden with 6,951 inhabitants in 2010. It is a charming small town with a rich history, located at the mouth of the river Storån on the Baltic Sea coast, and is known for its well-preserved medieval town center and beautiful natural surroundings.",
                Url = "https://visit.soderkoping.se/sv/",
                ImageUrl = "~/images/local-places/Soderkoping.jpg"
            },
            new LocalPlace()
            {
                Id = 10,
                Name = "Visit Sweden",
                Description =
                    "Sweden is a Scandinavian nation with thousands of coastal islands and inland lakes, along with vast boreal forests and glaciated mountains. Its principal cities, eastern capital Stockholm and southwestern Gothenburg and Malmö, are all coastal. Stockholm is built on 14 islands. It has more than 50 bridges, as well as the medieval old town, Gamla Stan, royal palaces and museums such as open-air Skansen.",
                Url = "https://visitsweden.com/",
                ImageUrl = "~/images/local-places/VisitSweden.jpg"
            }
        };
        return list;
    }
}