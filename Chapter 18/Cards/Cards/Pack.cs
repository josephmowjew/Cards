using System;
using System.Collections.Generic;

namespace Cards
{
    class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private Dictionary<Suit,  List<PlayingCard>> cardPack;
        private Random randomCardSelector = new Random();

        public Pack()
        {
            this.cardPack = new Dictionary<Suit, List<PlayingCard>>(NumSuits);

            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                //create a list of cards in a suit
                List<PlayingCard> cardsInSuit = new List<PlayingCard>(CardsPerSuit);
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    //add a particular card to the card stack
                    cardsInSuit.Add(new PlayingCard(suit, value));
                }

                //after adding the cards in a particular suit then add them in the card pack
                this.cardPack.Add(suit, cardsInSuit);
            }
        }

        public PlayingCard DealCardFromPack()
        {
            //select a random suit from the enum 
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);

            //if that suit doesnt have cards left in it then pick another suit at random
            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            //select a random value from the enumeration of values
            Value value = (Value)randomCardSelector.Next(CardsPerSuit);

            //if the card with that suit and value has been selected then pick another card from the same suit at random
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }
            //get the card from the card pack which is in a list in a dictionary

            //retrive all cards in a suit selected at random ealier
            List<PlayingCard> cardsInSuit = this.cardPack[suit];

            //find the card having the suit and value in the list

            PlayingCard card = cardsInSuit.Find(c => (c.CardSuit == suit) && c.CardValue == value);

            //Remove the card from the list when found

            cardsInSuit.Remove(card);
            
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;
            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }

            return result;

        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            List<PlayingCard> cardsInSuit = this.cardPack[suit];

            //check if the card having the particular value in the suit is there

            return (!cardsInSuit.Exists(c => (c.CardSuit == suit) && c.CardValue == value));
        }
    }
}