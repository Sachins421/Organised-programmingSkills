using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndExtensionMethod
{
    public class Card
    {
        public string Rank;
        public string Suit;
        public Card(string str) 
        {
            var values = str.Split('-');
            Rank = values[0];
            Suit = values[1];
        }

        public int RankValue
        {
            get {
                var facecard = new Dictionary<string,int> { { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 } };
                return facecard.ContainsKey(Rank) ? facecard[Rank] : int.Parse(Rank);  
            }
        }

        public override string ToString()
        {
            return $"{Rank}-{Suit}";
        }

        public static bool IsLegalNotation(string str)
        {
            var segments = str.Split('-');
            if (segments.Length != 2 ) 
                return false;

            var validSuit = new [] {"c","d","h","s" };
            if (!validSuit.Any(s => s == segments[1]) ) 
                return false;
            
            var validRank = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            if (!validRank.Any(r => r == segments[0])) 
                return false;
            
            return true;
        }

        //This method is called when we pass string to card object here TheDeck.Add("A-c");
        //this is mandotory fucntioned when you do this kind of action
        public static implicit operator Card(string str) 
        {   
            if (IsLegalNotation(str)) 
                return new Card(str);
            return null;
        }
    }

}
