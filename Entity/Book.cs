using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Book
    {
        int id;
        string name, author, publisher;
        decimal price;

        public Book(int id, string name, string author, string publisher, decimal price)
        {
            this.name = name;
            this.id = id;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
