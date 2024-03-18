using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Data.Seeders;

public class RestaurantSeeder
{
    public readonly Restaurant _Restaurant;
    public readonly ICollection<MenuItem> _MenuItems;

    public RestaurantSeeder()
    {
        _MenuItems = new List<MenuItem>();
        _Restaurant = GenerateRestaurant();
        _MenuItems = GenerateMenuItems(_Restaurant);
    }

    private Restaurant GenerateRestaurant()
    {
        var restaurant = new Restaurant()
        {
            Id = Guid.Parse("023e64ca-0b90-4977-8fba-bfbfeaf794a9"),
            Description =
                "Skeppsgården's restaurant is a place where you can enjoy a delicious meal with a beautiful view of the lake. The restaurant is open for breakfast, lunch and dinner. We offer a variety of dishes, including vegetarian and vegan options. We also have a bar with a wide selection of drinks and cocktails.",
            Image = "~/images/restaurant/restaurant.jpg",
            MenuItems = _MenuItems
        };

        return restaurant;
    }

    private ICollection<MenuItem> GenerateMenuItems(Restaurant restaurant)
    {
        var list = new List<MenuItem>()
        {
            //Appetizers
            new MenuItem()
            {
                Name = "Mozzarella Sticks",
                MenuItemTypeId = 1,
                Ingredients = "Mozzarella, breadcrumbs, eggs",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Broccoli Bites",
                MenuItemTypeId = 1,
                Ingredients = "Broccoli, breadcrumbs, eggs",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Popcorn Shrimp",
                MenuItemTypeId = 1,
                Ingredients = "Shrimp, breadcrumbs, eggs",
                Price = 10,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Waffle fries",
                MenuItemTypeId = 1,
                Ingredients = "Potatoes, oil",
                Price = 5,
                RestaurantId = restaurant.Id
            },

            //Main dishes
            new MenuItem()
            {
                Name = "Pasta",
                MenuItemTypeId = 2,
                Ingredients = "Pasta, tomato sauce, cheese",
                Price = 10,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Pizza",
                MenuItemTypeId = 2,
                Ingredients = "Pizza dough, tomato sauce, cheese, ham, mushrooms",
                Price = 15,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Burger",
                MenuItemTypeId = 2,
                Ingredients = "Burger bun, beef patty, cheese, lettuce, tomatoes, onions",
                Price = 12,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Steak",
                MenuItemTypeId = 2,
                Ingredients = "Beef steak, potatoes, vegetables",
                Price = 20,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Chicken",
                MenuItemTypeId = 2,
                Ingredients = "Chicken breast, potatoes, vegetables",
                Price = 15,
                RestaurantId = restaurant.Id
            },

            //Vegetarian
            new MenuItem()
            {
                Name = "Vegetarian Pasta",
                MenuItemTypeId = 3,
                Ingredients = "Pasta, tomato sauce, cheese",
                Price = 10,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Vegetarian Pizza",
                MenuItemTypeId = 3,
                Ingredients = "Pizza dough, tomato sauce, cheese, mushrooms",
                Price = 15,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Salad",
                MenuItemTypeId = 3,
                Ingredients = "Lettuce, tomatoes, cucumbers, olives, feta cheese",
                Price = 8,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Vegetarian Burger",
                MenuItemTypeId = 3,
                Ingredients = "Burger bun, veggie patty, cheese, lettuce, tomatoes, onions",
                Price = 12,
                RestaurantId = restaurant.Id
            },

            //Kid menu
            new MenuItem()
            {
                Name = "Kid Pasta",
                MenuItemTypeId = 4,
                Ingredients = "Pasta, tomato sauce, cheese",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Kid Pizza",
                MenuItemTypeId = 4,
                Ingredients = "Pizza dough, tomato sauce, cheese",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Kid Burger",
                MenuItemTypeId = 4,
                Ingredients = "Burger bun, beef patty, cheese",
                Price = 5,
                RestaurantId = restaurant.Id
            },

            //Desserts
            new MenuItem()
            {
                Name = "Ice cream",
                MenuItemTypeId = 5,
                Ingredients = "Ice cream, chocolate sauce, whipped cream",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Chocolate cake",
                MenuItemTypeId = 5,
                Ingredients = "Chocolate cake, chocolate sauce, whipped cream",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Cheesecake",
                MenuItemTypeId = 5,
                Ingredients = "Cheesecake, chocolate sauce, whipped cream",
                Price = 5,
                RestaurantId = restaurant.Id
            },
            new MenuItem()
            {
                Name = "Fruit salad",
                MenuItemTypeId = 5,
                Ingredients = "Bananas, apples, oranges, kiwis, strawberries",
                Price = 5,
                RestaurantId = restaurant.Id
            }
        };

        return list;
    }
}