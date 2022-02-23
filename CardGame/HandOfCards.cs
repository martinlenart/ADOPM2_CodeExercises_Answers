using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartBAnswers_B2
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        public void Add(PlayingCard card)
        {
            cards.Add(card);
        }
        public HandOfCards() : base()
        {
            cards.Clear();
        }
    }
}
