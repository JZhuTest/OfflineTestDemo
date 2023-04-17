namespace PizzeriaDemoAPI.Models
{
    public class MenuItem
    {
        public int LocationId { get; set; }
        public int PizzaTypeId { get; set; }
        public decimal Price { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}