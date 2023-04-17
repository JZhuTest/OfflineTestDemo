namespace PizzeriaDemoAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Indicate if it is top ingredient
        public bool IsTop { get; set; }

        public override string ToString() 
        {
            return Name;
        }
    }
}