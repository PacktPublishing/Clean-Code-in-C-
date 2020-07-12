using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.Builder
{
    public class Product
    {
        private readonly List<string> _parts;

        public Product()
        {
            _parts = new List<string>();
        }

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void PrintPartsList()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Parts Listing:");
            foreach (var part in _parts)
                sb.AppendLine($"- {part}");
            Console.WriteLine(sb.ToString());
        }
    }
}
