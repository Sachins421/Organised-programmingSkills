using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace LINQAndExtensionMethod
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var TheDeck = new DeckSet<Card>();

            TheDeck.Add("A-c"); TheDeck.Add("A-d"); TheDeck.Add("A-h"); TheDeck.Add("A-s");
            TheDeck.Add("2-c"); TheDeck.Add("2-d"); TheDeck.Add("2-h"); TheDeck.Add("2-s");
            TheDeck.Add("3-c"); TheDeck.Add("3-d"); TheDeck.Add("3-h"); TheDeck.Add("3-s");
            TheDeck.Add("4-c"); TheDeck.Add("4-d"); TheDeck.Add("4-h"); TheDeck.Add("4-s");
            TheDeck.Add("5-c"); TheDeck.Add("5-d"); TheDeck.Add("5-h"); TheDeck.Add("5-s");
            TheDeck.Add("6-c"); TheDeck.Add("6-d"); TheDeck.Add("6-h"); TheDeck.Add("6-s");
            TheDeck.Add("7-c"); TheDeck.Add("7-d"); TheDeck.Add("7-h"); TheDeck.Add("7-s");
            TheDeck.Add("8-c"); TheDeck.Add("8-d"); TheDeck.Add("8-h"); TheDeck.Add("8-s");
            TheDeck.Add("9-c"); TheDeck.Add("9-d"); TheDeck.Add("9-h"); TheDeck.Add("9-s");
            TheDeck.Add("10-c"); TheDeck.Add("10-d"); TheDeck.Add("10-h"); TheDeck.Add("10-s");
            TheDeck.Add("J-c"); TheDeck.Add("J-d"); TheDeck.Add("J-h"); TheDeck.Add("J-s");
            TheDeck.Add("Q-c"); TheDeck.Add("Q-d"); TheDeck.Add("Q-h"); TheDeck.Add("Q-s");
            TheDeck.Add("K-c"); TheDeck.Add("K-d"); TheDeck.Add("K-h"); TheDeck.Add("K-s");

            TheDeck.Shuffle().Shuffle().Shuffle();

            //var values = TheDeck.GetEnumerator();

            //while (values.MoveNext())
            //{
            //    Console.WriteLine(values.Current.RankValue +" "+ values.Current.Suit + " "+ values.Current.Rank);
            //}

            //var thedeck = TheDeck.ToList(); //Convert DeckSet<T> to a list 
            //for (int i = 0; i < thedeck.Count(); i++)
            //{
            //    Console.WriteLine(thedeck[i]);
            //}

            //while (values.MoveNext())
            //{
            //    Console.WriteLine(values.Current);
            //}

            //Card Sachin = "joker";

            //Console.WriteLine(Sachin); debug this 

            Console.WriteLine(TheDeck.Count());

            var hand1 = new List<Card>();
            List<Card> hand2 = new List<Card>();
            List<Card> hand3 = new List<Card>();

            hand1.Add(TheDeck.Skip(1).First());
            hand1.Add(TheDeck.Skip(2).First());
            hand1.Add(TheDeck.Skip(3).First());

            hand2.Add(TheDeck.Skip(4).First());
            hand2.Add(TheDeck.Skip(5).First());
            hand2.Add(TheDeck.Skip(6).First());

            hand3.Add(TheDeck.Skip(7).First());
            hand3.Add(TheDeck.Skip(8).First());
            hand3.Add(TheDeck.Skip(9).First());

            Console.WriteLine("--Hand1--");
            foreach (var item in hand1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--Hand2--");
            foreach (var item in hand2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--Hand3--");
            foreach (var item in hand3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("The flop : " + TheDeck.Skip(1).First());
            Console.WriteLine("The burn : " + TheDeck.Skip(2).First());
            Console.WriteLine("The show : " + TheDeck.Skip(3).First());

            //var cards = from card in TheDeck
            //            select card;

            //var cards = from card in TheDeck
            //            where card.Suit == "d" && card.Rank == "5"
            //            orderby card.RankValue descending
            //            select card;
            Console.WriteLine("==Group by===");
            
            var cards = from card in TheDeck
                        group card by card.Suit; //into suit select new {Thesuit=suit.Key, suit};

            foreach (var item in cards)
            {
                //Console.WriteLine(item.RankValue +" " +item.Rank +"-" +item.Suit);
                Console.WriteLine("Rank " +item.Key);
                foreach (var it in item)
                {
                    Console.WriteLine(it.ToString());
                }
            }
            Console.WriteLine("==Group by===");

            var card1 = from card in TheDeck
                        group card by card.Suit into suit select new {Thesuit=suit.Key,suit};

            foreach (var item in card1)
            {
                Console.WriteLine(item.Thesuit);
            }
            Console.WriteLine("Anonymsous");
            var results = from card in TheDeck
                          group card by card.RankValue > 10 into facecards
                          select new { TheSuit = facecards.Key, facecards };

            foreach (var result in results)
            {
                Console.WriteLine(result.TheSuit);
            }

            var flipkart = new MarketPlace() { Name = "flipkart", OrderId = new Random().Next(1, 5) };
            var Amazon = new MarketPlace() { Name = "Amazon", OrderId = new Random().Next(1, 6) };
            var Koovs = new MarketPlace() { Name = "Koovs", OrderId = new Random().Next(1, 10) };

            var K = new Person() { OrderId = flipkart.OrderId, NoOfItemsInOrder = new Random().Next(0, 5) };
            var S = new Person() { OrderId = Amazon.OrderId, NoOfItemsInOrder = new Random().Next(0, 5) };
            var R = new Person() { OrderId = 2434, NoOfItemsInOrder = new Random().Next(0, 5) };

            List<MarketPlace> mp = new List<MarketPlace> { flipkart, Amazon, Koovs };
            List<Person> pr = new List<Person> { K, S, R };


            var Result = mp.Join(pr, 
                                mkp => mkp.OrderId,
                                person => person.OrderId,
                                (mkp,person) => new {Name = mkp.Name, OrderId = person.OrderId }
                                );

            Console.WriteLine("Join");
            foreach (var obj in Result)
            {
                Console.WriteLine($"{obj.Name} - {obj.OrderId}");
            }

            var inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            var context = new CsvContext();
            var hurricanes = context.Read<MyDataRow>(@"C:\Polling\atlantic_hurricanes.csv", inputFileDescription);
           
            Console.WriteLine(hurricanes.OrderByDescending(h => h.Year).Take(10).Select(h => new { h.Year, h.TropicalStormCount, h.HurricaneCount, h.StrongestStorm }));

            var cr = new Card("A-h");
            cr.ToFormattedValue();

            Console.WriteLine(cr.ToFormattedValue());

            Console.ReadLine();
        }
    }
}
