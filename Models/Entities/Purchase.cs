using SQLite;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MarketPlace.Model.Entities
{
    public class Purchase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [Ignore]
        public DateTime Date { get; set; }

        [Column("Date")]
        public string DateString
        {
            get { return this.Date.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.Date = DateTime.Parse(value); }
        }
        public string Content { get; set; }

        public Purchase() { }
        public Purchase(Basket basket, DateTime date)
        {
            Date = date;
            Content = XmlSerializeBasket(basket);
        }

        public string XmlSerializeBasket(Basket basket)
        {
            var serializer = new XmlSerializer(typeof(Basket));
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, basket);
            }

            return sb.ToString();
        }
    }
}
