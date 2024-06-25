namespace ChoseYourDrink.Models
{
    public class DrinkOrderItemViewModel
    {
        public UserViewModel User { get; set; }
        public DrinkItemViewModel Drink { get; set; }
        public int Quantity { get; set; }
    }
}
