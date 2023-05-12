using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndExtensionMethod
{
    static class CardExtension
    {
        public static string ToFormattedValue(this Card card)
        {
            var outSuit = card.Suit == "C" ? "♣" : card.Suit == "d" ? "♦" : card.Suit == "h" ? "♥" : "♠";
            return card.Rank + outSuit;
        }
    }
}
