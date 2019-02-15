using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNETClassLib
{
    public class Cards : CollectionBase
    {
        #region Class Methods

        //a method allowing the user to add a new card
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }

        //a method allowing the user to remove an old card
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }

        //this property allows the user to find a card based on the card's index in the collection
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }

        #endregion
    }
}
