using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNETClassLib
{
    public class Deck 
    {
        #region Constructors

        public Cards cards = new Cards();

        public Deck()
        {
            for (int suitValue = 0; suitValue < 4; suitValue++)
            {
                for (int rankValue = 1; rankValue < 14; rankValue++)
                {
                    cards.Add(new Card((Suit)suitValue, (Rank)rankValue));
                }
            }
        }

        #endregion 

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;

            }
        }
    }
}
