using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DNETClassLib
{
    public class Card
    {
        public static Suit myTrump;
        public static bool useTrumps = true;
        public static bool isAceHigh = true;

        private Rank myCardRank;
        private Suit myCardSuit;
        private int myCardValue;
        private bool isFaceUp;
        

        #region Constructors
        public Card()
        {
            //trump = Suit.Hearts;
            cardRank = Rank.Ace;
            cardSuit = Suit.Hearts;
            faceUp = false;
            

            this.myCardValue = (int)cardRank;
        }

        public Card(Suit cardSuit, Rank cardRank)
        {
            this.cardRank = cardRank;
            this.cardSuit = cardSuit;
            faceUp = false;

            this.myCardValue = (int)cardRank;
        }
        #endregion

        #region Class Methods

        public override int GetHashCode()
        {
            return this.myCardValue * 100 + (int)this.myCardSuit * 10 + ((this.faceUp) ? 1 : 0);
        }

        public override string ToString()
        {

            string cardString;


            cardString = myCardRank.ToString() + " of " + myCardSuit.ToString();

            return cardString;
        }

        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;

            if (faceUp != true)
            {
                imageName = "Back";
            }
            else
            {
                //using the enumerations the card name is stored in the imageName variable
                imageName = myCardRank.ToString() + "_" + myCardSuit.ToString();
            }

            //the cardImage Image object is set to the the image matching the card's name in the recources
          
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            return cardImage;
        }
        
        #endregion

        #region Relational Operators

        //returns the values of two cards that are compared with the > operator and takes into account trump and ace being high
        public static bool operator >(Card cardOne, Card cardTwo)
        {
            if (useTrumps)
            {
                if (cardOne.cardSuit == myTrump && cardTwo.cardSuit != myTrump)
                {
                    return true;
                }
                else if (cardOne.cardSuit != myTrump && cardTwo.cardSuit == myTrump)
                {
                    return false;
                }
                else
                {
                    if (isAceHigh)
                    {
                        if (cardOne.cardRank == Rank.Ace && cardTwo.cardRank != Rank.Ace)
                        {
                            return true;
                        }
                        else if (cardOne.cardRank != Rank.Ace && cardTwo.cardRank == Rank.Ace)
                        {
                            return false;
                        }
                        else
                        {
                            if (cardOne.cardValue > cardTwo.cardValue)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (cardOne.cardValue > cardTwo.cardValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
            else
            {
                if (cardOne.cardValue > cardTwo.cardValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //allows two card objects to be compared with the < operator, takes into account trump and ace bieng high
        //this function uses the previously created > operator and returns the opposite
        public static bool operator <(Card cardOne, Card cardTwo)
        {
            return !(cardOne > cardTwo);
        }

        //allows two card objects to be compared with the >= operator and takes into account trump and ace being high
        public static bool operator >=(Card cardOne, Card cardTwo)
        {
            if (useTrumps)
            {
                if (cardOne.cardSuit == myTrump && cardTwo.cardSuit != myTrump)
                {
                    return true;
                }
                else if (cardOne.cardSuit != myTrump && cardTwo.cardSuit == myTrump)
                {
                    return false;
                }
                else
                {
                    if (isAceHigh)
                    {
                        if (cardOne.cardRank == Rank.Ace && cardTwo.cardRank != Rank.Ace)
                        {
                            return true;
                        }
                        else if (cardOne.cardRank != Rank.Ace && cardTwo.cardRank == Rank.Ace)
                        {
                            return false;
                        }
                        else
                        {
                            if (cardOne.cardValue >= cardTwo.cardValue)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (cardOne.cardValue >= cardTwo.cardValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
            else
            {
                if (cardOne.cardValue >= cardTwo.cardValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //allows the user to compare two cards using the <= operator, uses the opposite of the > operator
        public static bool operator <=(Card cardOne, Card cardTwo)
        {
            return !(cardOne > cardTwo);
        }

        //allows the other methods when comparing cards to compared both the rank and suit of the cards
        public static bool operator ==(Card cardOne, Card cardTwo)
        {
            return (cardOne.myCardSuit == cardTwo.myCardSuit) && (cardOne.myCardRank == cardTwo.myCardRank);
        }

        //uses the == method above and returns the opposite to returns the opposite allowing the user to compare with != 
        public static bool operator !=(Card cardOne, Card cardTwo)
        {
            return !(cardOne == cardTwo);
        }

        //allows the user to use Equals using the comparison operator == to check of the rank and suit are equal
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        #endregion

        #region Getters and Setters

        public Suit trump
        {
            get { return myTrump; }
            set { myTrump = value; }
        }

        public Rank cardRank
        {
            get { return myCardRank; }
            set { myCardRank = value; }
        }

        public Suit cardSuit
        {
            get { return myCardSuit; }
            set { myCardSuit = value; }
        }

        public int cardValue
        {
            get { return myCardValue; }
            set { myCardValue = value; }
        }

        public bool faceUp
        {
            get { return isFaceUp; }
            set { isFaceUp = value; }
        }
        #endregion
    }
}
