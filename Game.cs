using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Game
    {
        public Players GamePlayers { get; set; }
        public Card[] HiddenCards { get; set; }
        public List<Card>[] PlayerCards { get; set; }

        private Random rnd = new Random();

        public Game(string [] names)
        {
            rnd = new Random();
            GamePlayers = new Players(names);
        }

        public Card[] RandomSelectHidden()
        {
            HiddenCards = new Card[3];
            HiddenCards[0] = Card.GetRandomSuspect(rnd);
            HiddenCards[1] = Card.GetRandomWeapon(rnd);
            HiddenCards[2] = Card.GetRandomRoom(rnd);
            System.Diagnostics.Debug.Assert(VerifyHasEachKind(HiddenCards) == true);

            return HiddenCards;
        }

        private bool VerifyComplete(Card[] trio, List<Card>[] playerCards)
        {
            List<int> list = new List<int>();
            if (list.Contains(trio[0].Id) == true) return false;
            list.Add(trio[0].Id);
            if (list.Contains(trio[1].Id) == true) return false;
            list.Add(trio[1].Id);
            if (list.Contains(trio[2].Id) == true) return false;
            list.Add(trio[2].Id);

            for(int i = 0; i < playerCards.Length; i++)
            {
                for(int j = 0; j < playerCards[i].Count; j++)
                {
                    if (list.Contains(playerCards[i][j].Id) == true)
                    {
                        return false;
                    }
                    list.Add(playerCards[i][j].Id);
                }
            }
            list.Sort();
            {
                int j = (int)Card.SuspectID.MinSuspectID;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != j) return false;
                    j++;
                }
                if (j - 1 != (int)Card.RoomID.MaxRoomID)
                {
                    return false;
                }
            }
            return true;
        }
        private bool VerifyHasEachKind(Card[] trio)
        {
            if(trio[0].IsSuspect() == false && trio[1].IsSuspect() == false && trio[2].IsSuspect() == false)
            {
                return false;
            }
            if (trio[0].IsWeapon() == false && trio[1].IsWeapon() == false && trio[2].IsWeapon() == false)
            {
                return false;
            }
            if (trio[0].IsRoom() == false && trio[1].IsRoom() == false && trio[2].IsRoom() == false)
            {
                return false;
            }
            return true;
        }

        public void SetHidden(Card[] hidden)
        {
            System.Diagnostics.Debug.Assert(hidden.Length == 3);
            System.Diagnostics.Debug.Assert(VerifyHasEachKind(hidden) == true);

            HiddenCards = new Card[3];
            HiddenCards[0] = hidden[0];
            HiddenCards[1] = hidden[1];
            HiddenCards[2] = hidden[2];
        }


        public List<Card>[] DistributeCards()
        {
            List<Card> remaining = new List<Card>();

            for (int suspect = (int)Card.SuspectID.MinSuspectID; suspect <= (int)Card.SuspectID.MaxSuspectID; suspect++)
            {
                if (suspect == HiddenCards[0].Id || suspect == HiddenCards[1].Id || suspect == HiddenCards[2].Id)
                {
                    continue;
                }
                remaining.Add(new Card(suspect));

            }
            for (int weapon = (int)Card.WeaponID.MinWeaponID; weapon <= (int)Card.WeaponID.MaxWeaponID; weapon++)
            {
                if (weapon == HiddenCards[0].Id || weapon == HiddenCards[1].Id || weapon == HiddenCards[2].Id)
                {
                    continue;
                }
                remaining.Add(new Card(weapon));
            }
            for (int room = (int)Card.RoomID.MinRoomID; room <= (int)Card.RoomID.MaxRoomID; room++)
            {
                if (room == HiddenCards[0].Id || room == HiddenCards[1].Id || room == HiddenCards[2].Id)
                {
                    continue;
                }
                remaining.Add(new Card(room));
            }

            PlayerCards = new List<Card>[GamePlayers.NumPlayers];
            int player;
            for (player = 0; player < GamePlayers.NumPlayers; player++)
            {
                PlayerCards[player] = new List<Card>();
            }

            player = 0;
            while (remaining.Count > 0)
            {
                int idx = rnd.Next(remaining.Count);
                Card card = remaining[idx];
                PlayerCards[player].Add(card);
                player = (player + 1) % GamePlayers.NumPlayers;
                //System.Diagnostics.Debug.WriteLine(card);
                remaining.RemoveAt(idx);
            }
            System.Diagnostics.Debug.Assert(VerifyComplete(HiddenCards, PlayerCards) == true);
            return PlayerCards;
        }

        public void SetPlayerCards(List<Card>[] playerCards)
        {
            System.Diagnostics.Debug.Assert(playerCards.Length == GamePlayers.NumPlayers);
            PlayerCards = new List<Card>[GamePlayers.NumPlayers];
            int player;
            for (player = 0; player < GamePlayers.NumPlayers; player++)
            {
                PlayerCards[player] = new List<Card>();
                foreach(Card card in playerCards[player])
                {
                    PlayerCards[player].Add(card);
                }
            }
            System.Diagnostics.Debug.Assert(VerifyComplete(HiddenCards, PlayerCards) == true);
        }


        public void ShowHiddenCards()
        {
            System.Diagnostics.Debug.WriteLine("Hidden = " + Card.CardsToString(HiddenCards));
        }

        public void ShowPlayerCards()
        {
            for(int player = 0; player < GamePlayers.NumPlayers; player++)
            {
                System.Diagnostics.Debug.WriteLine(GamePlayers.Names[player] + " = " + Card.CardsToString(PlayerCards[player].ToArray()));
            }
        }

        public void Moving(int id)
        {

        }

        public bool Suggest(int idFrom, int idTo, Card[] cards)
        {
            System.Diagnostics.Debug.Assert(idFrom >= 0);
            System.Diagnostics.Debug.Assert(idFrom < GamePlayers.NumPlayers);

            System.Diagnostics.Debug.Assert(idTo >= 0);
            System.Diagnostics.Debug.Assert(idTo < GamePlayers.NumPlayers);

            System.Diagnostics.Debug.Assert(idFrom != idTo);

            System.Diagnostics.Debug.Assert(cards != null);
            System.Diagnostics.Debug.Assert(cards.Length > 0);

            for(int i = 0; i < cards.Length; i++)
            {
                for (int j = 0; j < PlayerCards[idTo].Count; j++)
                {
                    if (PlayerCards[idTo][j].Id == cards[i].Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Card SuggestWithCard(int idFrom, int idTo, Card[] cards)
        {
            System.Diagnostics.Debug.Assert(idFrom >= 0);
            System.Diagnostics.Debug.Assert(idFrom < GamePlayers.NumPlayers);

            System.Diagnostics.Debug.Assert(idTo >= 0);
            System.Diagnostics.Debug.Assert(idTo < GamePlayers.NumPlayers);

            System.Diagnostics.Debug.Assert(idFrom != idTo);

            System.Diagnostics.Debug.Assert(cards != null);
            System.Diagnostics.Debug.Assert(cards.Length > 0);

            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = 0; j < PlayerCards[idTo].Count; j++)
                {
                    if (PlayerCards[idTo][j].Id == cards[i].Id)
                    {
                        return cards[i];
                    }
                }
            }
            return null;
        }

    }
}
