using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsFFGBookAPI
{
    public class Book
    {
        // The unique identifier for the book
        public Guid Id { get; set; }

        // Name of the book
        public string Name { get; set; }

        // Type of the book (e.g., Core Rulebook, Supplement)
        public string Type { get; set; }

        // Parent book (if applicable, otherwise null)
        public string ChildOf { get; set; }

        // Unique SKU identifier for the book
        public string Sku { get; set; }

        // Priority value for acquiring the book (1-10 scale)
        public byte WantPriority { get; set; }

        // Price of the book
        public double Price { get; set; }

        // Whether the book is owned (true or false)
        public bool Owned { get; set; }

        // Constructor to initialize the properties
        public Book(Guid id, string name, string type, string childOf, string sku, byte wantPriority, double price, bool owned)
        {
            Id = id;
            Name = name;
            Type = type;
            ChildOf = childOf;
            Sku = sku;
            WantPriority = wantPriority;
            Price = price;
            Owned = owned;
        }
    }
}

