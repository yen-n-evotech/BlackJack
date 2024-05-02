using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        public string Type { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }

        public Card(string type, string rank, int value)
        {
            Type = type;
            Rank = rank;
            Value = value;
        }
    }
}
