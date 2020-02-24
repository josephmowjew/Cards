using System;


namespace Cards
{
    
	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private PlayingCard[,] cardPack;
        private Random randomCardSelector = new Random();

        public Pack()
        {
            this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];

            //fill the cardpack with the actual cards inside

            for (Suit suit = Suit.Clubs; suit < Suit.Spades; suit++)
            {
                    for(Value value = Value.Two; value <= Value.Ace; value++)
                    {
                    //create a new card 
                        this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                    }
            }
        }

        public PlayingCard DealCardFromPack()
        {
            //generate a random card 

            Suit suit = (Suit)this.randomCardSelector.Next(NumSuits);
            
            //check if the suit is empty or not

            while(this.IsSuitEmpty(suit))
            {
                //select another suit from the list

                 suit = (Suit)this.randomCardSelector.Next(NumSuits);

            }

            Value value = (Value)this.randomCardSelector.Next(CardsPerSuit);

            //check if the card in the suit has already been dealt from the stack of cards

            while(this.IsCardAlreadyDealt(suit,value))
            {
                //pick another card from the stack

                value = (Value)this.randomCardSelector.Next(CardsPerSuit);
            }



            PlayingCard dealtCard = this.cardPack[(int)suit, (int)value];

            //set the dealt card to null in the pack of cards

            this.cardPack[(int)suit, (int)value] = null;


            return dealtCard;
            
        }

        private bool IsSuitEmpty(Suit suit)
        {
            //loop in the suit checking if all values in that suit are set or not

            bool result = true;

            for(Value value = Value.Two; value <= Value.Ace; value++)
            {
                if(!IsCardAlreadyDealt(suit , value))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            //check key value pair of the card within cardpack if null

            if (this.cardPack[(int)suit, (int)value] == null)
            {
                return true;
            }

            return false;
        }
    }
}