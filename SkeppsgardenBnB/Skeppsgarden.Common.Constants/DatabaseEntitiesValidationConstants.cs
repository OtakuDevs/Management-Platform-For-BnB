namespace Skeppsgarden.Common.Constants;

public static class DatabaseEntitiesValidationConstants
{
    public static class EventConstants
    {
        public const int TitleMaxLength = 255;
        public const int DescriptionMaxLength = 1000;
        public const int LocationMaxLength = 100;
        public const int ImageUrlMaxLength = 255;
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm";
    }

    public static class HyperlinkConstants
    {
        public const int TextMaxLength = 50;
        public const int UrlMaxLength = 255;
    }

    public static class MenuItemConstants
    {
        public const int NameMaxLength = 50;
        public const int TypeMaxLength = 50;
        public const int IngredientsMaxLength = 255;
    }

    public static class RestaurantConstants
    {
        public const int DescriptionMaxLength = 1000;
        public const int ImageUrlMaxLength = 255;
    }

    public static class CustomerConstants
    {
        public const int FirstNameMaxLength = 50;
        public const int LastNameMaxLength = 50;
        public const string NameRegex = @"^[\w-\' ]+$";
        public const string PhoneNumberRegex = @"^(([+][\d]{1,3})|(0)|(00[\d]{1,3}))(\d{7,9})$";
    }

    public static class LocalPlaceConstants
    {
        public const int NameMaxLength = 50;
        public const int DescriptionMaxLength = 1000;
        public const int UrlMaxLength = 255;
        public const int ImageUrlMaxLength = 255;
    }
    
    public static class ActivitiesConstants
    {
        public const int NameMaxLength = 50;
        public const int DescriptionMaxLength = 1000;
        public const int UrlMaxLength = 255;
        public const int ImageUrlMaxLength = 255;
    }
}