using Newtonsoft.Json;
using SQLite;
using System;

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
            Content = JsonConvert.SerializeObject(basket, Formatting.Indented);
        }
    }
}
