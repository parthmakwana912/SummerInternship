using BookStore.Models.ViewModels;

namespace BookStore.Models.Models
{
    public class CartModel
    {
        public CartModel() { }

        public CartModel(Cart cart)
        {
            Id = cart.Id;
            //TODO: add all properties
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
