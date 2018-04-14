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

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("Date")]
        public string DateString
        {
            get { return this.Date.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.Date = DateTime.Parse(value); }
        }

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
