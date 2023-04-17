namespace PizzeriaDemoAPI.Models
{
    public class PizzaType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string IngredientsDescription { get; set; }
    }
}