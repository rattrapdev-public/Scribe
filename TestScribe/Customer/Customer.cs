using RattrapDev.Scribe.Term;
using System;
using TestScribe.Store;

namespace TestScribe.Customer
{
    [AggregateRoot("Customer", "Someone who buys things", "Customer")]
    public class Customer
    {
        private TestEntity TestEntity { get; set; } = new TestEntity();

        public Name Name { get; set; }
        public Cart ShoppingCart { get; set; } = new Cart();

        [CommandMethod("Update Profile", "Allow customer to update their name")]
        public void UpdateProfile(Name name) { }

        [CommandMethod("Outside Command", "Outside command definition")]
        public void OutsideCommand()
        {
            TestEntity.Command();
        }

        [CommandMethod("Add Item To Cart", "Add an item to the customers shopping cart")]
        public void AddItemToCart(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            ShoppingCart = ShoppingCart.AddItemToCart(item);
        }

        [CommandMethod("Remove Items From Cart", "Remove all items from cart associated with the item")]
        public void RemoveItemsFromCart(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            ShoppingCart = ShoppingCart.RemoveItemsFromCart(item);
        }

        [CommandMethod("Checkout", "Customer checks out of the store", new[] { typeof(CustomerCheckoutEvent)})]
        public void Checkout()
        {
            var evt = new CustomerCheckoutEvent { Name = Name, PurchasedItems = ShoppingCart };
            //publish event
            ShoppingCart = new Cart();
        }
    }
}
