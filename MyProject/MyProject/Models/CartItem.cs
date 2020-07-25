using MyProject.ViewModels;

namespace MyProject.Models
{
    public class CartItem : ProductViewModel
    {
        public int Quantity { get; set; }
        public double Total => Quantity * Price;
    }
}
