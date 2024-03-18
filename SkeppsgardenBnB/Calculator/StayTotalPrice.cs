namespace Calculator
{
    public class StayTotalPrice
    {
        public static int CalculateTotalPrice(int roomNumber, int numberOfNights, int totalPrice)
        {
            int basePrice = totalPrice * numberOfNights;
            if (numberOfNights == 1)
                return basePrice;

            switch (roomNumber)
            {
                case 1:
                case 2:
                case 3:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return CalculateDiscountedPrice(basePrice, numberOfNights, 200, 600);
                case 4:
                    return CalculateDiscountedPrice(basePrice, numberOfNights, 200, 700);
                default:
                    return basePrice;
            }
        }

        private static int CalculateDiscountedPrice(int basePrice, int numberOfNight, int discountPerNight,
            int maxDiscount)
        {
            int discount;
            if (numberOfNight > 2)
                discount = maxDiscount;
            else
                discount = discountPerNight;
            
            return basePrice - discount;
        }
    }
}