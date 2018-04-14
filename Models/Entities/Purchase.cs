using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MarketPlace.Model;

namespace MarketPlace.Model.Entities
{
    public class Purchase
    {
        [XmlAttribute]
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        public Purchase(){}
        public Purchase(DateTime date, Product[] products)
        {
            Products = new List<Product>(products);
            Date = date;
            TotalPrice = products.Sum(x => x.Price);
        }
    }
}
