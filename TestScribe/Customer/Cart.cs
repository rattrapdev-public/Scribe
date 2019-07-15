using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RattrapDev.Scribe.Term;
using TestScribe.Store;

namespace TestScribe.Customer
{
    [ValueObject("Cart", "A collection of store items available for purchase")]
    public class Cart : IEnumerable<StoreItem>
    {
        private List<StoreItem> items;

        public Cart()
        {
            items = new List<StoreItem>();
        }

        public Cart(IEnumerable<StoreItem> existingItems)
        {
            items = new List<StoreItem>(existingItems);
        }

        public IEnumerator<StoreItem> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool HasItem(StoreItem item) => items.Any(i => i.ItemCode.Equals(item.ItemCode));

        public Cart AddItemToCart(StoreItem item)
        {
            var newCartList = new List<StoreItem>(items);
            newCartList.Add(item);
            return new Cart(newCartList);
        }

        public Cart RemoveItemsFromCart(StoreItem item)
        {
            var newCartList = new List<StoreItem>(items);

            if (HasItem(item))
            {
                newCartList.RemoveAll(i => i.ItemCode.Equals(item.ItemCode));
            }

            return new Cart(newCartList);
        }
    }
}
