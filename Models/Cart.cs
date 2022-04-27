using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();
            //if more than one type of item in cart, add to quantity instead of creating another instance of the same item. 
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += 1;
            }
        }

        public virtual void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.Id == product.Id);

        //Create an UpdateItem method that is based off of the AddItem method
        
        public virtual void UpdateItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.Id == product.Id)
            .FirstOrDefault();
                    //if more than one type of item in cart, add to quantity instead of creating another instance of the same item. 
                    if (line == null)
                    {
                                   }
                    else
                    {
                line.Quantity = quantity;
                
                    }
                

        //lineCollection.Find(p => p.CartLineID == product.Id).Quantity =quantity;
    }

    public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);


    public virtual void Clear() => lineCollection.Clear();
    public virtual IEnumerable<CartLine> Lines => lineCollection;

}
public class CartLine
{
    public int CartLineID { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
}