namespace ChoseYourDrink.BLL.BusinessObjects
{
    public class DrinkOrderItemBO
    {
        public UserBO User { get; set; }
        public DrinkItemBO Drink { get; set; }
        public int Quantity { get; set; }
    }
}
