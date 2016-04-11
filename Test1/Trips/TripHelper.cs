using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips
{
    public class TripHelper
    {
        public IEnumerable<Tuple<string, string>> SortCards(IEnumerable<Tuple<string, string>> cards)
        {
            Dictionary<string, string> startPoints = new Dictionary<string, string>(cards.Count() - 2);
            Dictionary<string, string> endPoints = new Dictionary<string, string>(cards.Count() - 2);

            var ll = new LinkedList<string>();
            var firstCard = cards.FirstOrDefault();
            ll.AddFirst(firstCard.Item1);
            ll.AddLast(firstCard.Item2);

            foreach (var card in cards.Skip(1))
            {
                if (ll.Last.Value == card.Item1)
                {
                    ll.AddLast(card.Item2);
                }
                else if (ll.First.Value == card.Item2)
                {
                    ll.AddFirst(card.Item1);
                }
                else
                {
                    startPoints.Add(card.Item1, card.Item2);
                    endPoints.Add(card.Item2, card.Item1);
                }
            }

            bool tripStartFound = startPoints.Count == 0;
            bool tripEndFound = endPoints.Count == 0;

            if (tripStartFound && tripEndFound)
            {
                return cards;
            }

            while (!(tripStartFound && tripEndFound))
            {
                if (!tripStartFound)
                {
                    //          Проверяем существование конечного узла, совпадающего с уже добавленным в список начальным
                    if (endPoints.ContainsKey(ll.First.Value))
                    {
                        ll.AddFirst(endPoints[ll.First.Value]);
                    }
                    else
                    {
                        tripStartFound = true;
                    }
                }
                if (!tripEndFound)
                {
                    //          Проверяем существование начального узла, совпадающего с уже добавленным  в список конечным
                    if (startPoints.ContainsKey(ll.Last.Value))
                    {
                        ll.AddLast(startPoints[ll.Last.Value]);
                    }
                    else
                    {
                        tripEndFound = true;
                    }
                }

            }

            return SplitToCards(ll);

        }

        private IEnumerable<Tuple<string, string>> SplitToCards(LinkedList<string> ll)
        { 
            LinkedListNode<string> f = ll.First;
            List<Tuple<string, string>> tuples = new List<Tuple<string, string>>(ll.Count - 1);

            while (f.Next != null)
            {
                tuples.Add(new Tuple<string, string>(f.Value, f.Next.Value));
                f = f.Next;
            }
            return tuples;
        }
    }
}
