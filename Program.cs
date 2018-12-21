using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test01();
            Test02();
            Test03();
            Test04();
        }

        static void Test01()
        {
            bool result;
            Card myResultCard;
            Game game = new Game(new string[] { "Allan", "Barney", "Carrol", "Daine", "Erica", "Frank" });
            Card[] hiddenCards = new Card[3] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) };
            game.SetHidden(hiddenCards);
            //game.ShowHiddenCards();
            List<Card>[] playerCards = new List<Card>[]
            {
                new List<Card> { new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom), new Card(Card.RoomID.Kitchen)},
                new List<Card> { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Wrench), new Card(Card.SuspectID.ColonelMustard)}, 
                new List<Card> { new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Conservatory), new Card(Card.RoomID.Study)},
                new List<Card> { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.LeadPipe), new Card(Card.WeaponID.Knife)},
                new List<Card> { new Card(Card.SuspectID.MrsPeacock), new Card(Card.SuspectID.ProfessorPlum), new Card(Card.RoomID.Hall)},
                new List<Card> { new Card(Card.RoomID.Library), new Card(Card.RoomID.Ballroom), new Card(Card.RoomID.BilliardRoom)} 
            };
            game.SetPlayerCards(playerCards);
            //game.ShowPlayerCards();

            game.Moving(0);

            result = game.Suggest(1, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(4, 5, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 0, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 1, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(5);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.SuspectID.MissScarlet) == true);


            result = game.Suggest(1, 2, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(1, 3, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(2);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 0, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(4, 5, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(5);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.WeaponID.Revolver) == true);

            game.Moving(1);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(3);

            result = game.Suggest(4, 5, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 0, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 1, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 2, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(5, 0, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 1, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);

            result = game.Suggest(1, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 0, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(4);

            result = game.Suggest(5, 0, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Knife), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Knife), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Knife), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.RoomID.Conservatory) == true);

            game.Moving(1);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 5, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 0, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 1, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(4);
            game.Moving(5);
        }

        static void Test02()
        {
            bool result;
            Card myResultCard;
            Game game = new Game(new string[] { "Allan", "Barney", "Carrol", "Daine", "Erica", "Frank" });
            Card[] hiddenCards = new Card[3] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Library) };
            game.SetHidden(hiddenCards);
            //game.ShowHiddenCards();
            List<Card>[] playerCards = new List<Card>[]
            {
                new List<Card> { new Card(Card.RoomID.Ballroom), new Card(Card.RoomID.BilliardRoom), new Card(Card.WeaponID.Candlestick)},
                new List<Card> { new Card(Card.RoomID.Conservatory), new Card(Card.WeaponID.Knife), new Card(Card.RoomID.DiningRoom)},
                new List<Card> { new Card(Card.SuspectID.MrGreen), new Card(Card.RoomID.Hall), new Card(Card.RoomID.Kitchen)}, 
                new List<Card> { new Card(Card.RoomID.Lounge), new Card(Card.SuspectID.ColonelMustard), new Card(Card.SuspectID.MrsPeacock)},
                new List<Card> { new Card(Card.WeaponID.Revolver), new Card(Card.WeaponID.Rope), new Card(Card.SuspectID.MissScarlet)},
                new List<Card> { new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Study), new Card(Card.SuspectID.MrsWhite)} 
            };
            game.SetPlayerCards(playerCards);
            //game.ShowPlayerCards();

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.SuspectID.MrsWhite) == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
        }

        static void Test03()
        {
            bool result;
            Card myResultCard;
            Game game = new Game(new string[] { "Allan", "Barney", "Carrol", "Daine", "Erica", "Frank" });
            Card[] hiddenCards = new Card[3] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Knife), new Card(Card.RoomID.Kitchen) };
            game.SetHidden(hiddenCards);
            //game.ShowHiddenCards();

            List<Card>[] playerCards = new List<Card>[]
            {
                new List<Card> { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Conservatory)},
                new List<Card> { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.DiningRoom)},
                new List<Card> { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Hall) },
                new List<Card> { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Library)},
                new List<Card> { new Card(Card.SuspectID.MrsWhite), new Card(Card.RoomID.Ballroom), new Card(Card.RoomID.Lounge)},
                new List<Card> { new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom), new Card(Card.RoomID.Study)}
            };
            game.SetPlayerCards(playerCards);
            //game.ShowPlayerCards();

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 5, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.RoomID.Study) == true);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 5, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 0, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 1, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(5, 0, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 4, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 0, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 1, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 2, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 5, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.LeadPipe), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.RoomID.BilliardRoom) == true);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 5, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 0, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 1, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(5, 0, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 1, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 3, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.BilliardRoom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 0, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 1, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 5, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.WeaponID.Candlestick) == true);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 5, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 0, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 1, new Card[] { new Card(Card.SuspectID.MrsPeacock), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.RoomID.Ballroom) == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 0, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 1, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Hall) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);
            myResultCard = game.SuggestWithCard(0, 4, new Card[] { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(myResultCard.IsEqual(Card.RoomID.Lounge) == true);

            result = game.Suggest(4, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 0, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Wrench), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(5, 0, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(5, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Library) });
            System.Diagnostics.Debug.Assert(result == true);

            /*
                Pe4 : W  Spanner Ballroom  : Pl,Sc,M,W   G
                Pl5 : W  Can     Library   : Sc,M,W      G
             */
        }

        static void Test04()
        {
            bool result;
            Card myResultCard;
            Game game = new Game(new string[] { "Allan", "Barney", "Carrol", "Daine", "Erica", "Frank" });
            Card[] hiddenCards = new Card[3] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Lounge) };
            game.SetHidden(hiddenCards);
            //game.ShowHiddenCards();

            List<Card>[] playerCards = new List<Card>[]
            {
                new List<Card> { new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom), new Card(Card.RoomID.Kitchen)}, //Scarlett (Sc):0
                new List<Card> { new Card(Card.SuspectID.MissScarlet), new Card(Card.WeaponID.Wrench), new Card(Card.SuspectID.ColonelMustard)}, //Mustard (M):1
                new List<Card> { new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Conservatory), new Card(Card.RoomID.Study)}, // White (W):2
                new List<Card> { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.LeadPipe), new Card(Card.WeaponID.Knife)}, //Green (G):3
                new List<Card> { new Card(Card.SuspectID.MrsPeacock), new Card(Card.SuspectID.ProfessorPlum), new Card(Card.RoomID.Hall)}, //Peacock (Pe):4
                new List<Card> { new Card(Card.RoomID.Library), new Card(Card.RoomID.Ballroom), new Card(Card.RoomID.BilliardRoom)} //Plum (Pl)5
            };
            game.SetPlayerCards(playerCards);
            //game.ShowPlayerCards();

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(3, 5, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Ballroom) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(4, 5, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 0, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 1, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(4, 2, new Card[] { new Card(Card.SuspectID.MrGreen), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            game.Moving(5);
            result = game.Suggest(0, 1, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 2, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 3, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 4, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(0, 5, new Card[] { new Card(Card.SuspectID.MrsWhite), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.DiningRoom) });
            System.Diagnostics.Debug.Assert(result == false);

            result = game.Suggest(1, 2, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Rope), new Card(Card.RoomID.Study) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(2, 3, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 4, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 5, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 0, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == false);
            result = game.Suggest(2, 1, new Card[] { new Card(Card.SuspectID.ColonelMustard), new Card(Card.WeaponID.Candlestick), new Card(Card.RoomID.Conservatory) });
            System.Diagnostics.Debug.Assert(result == true);

            result = game.Suggest(3, 4, new Card[] { new Card(Card.SuspectID.ProfessorPlum), new Card(Card.WeaponID.Revolver), new Card(Card.RoomID.Lounge) });
            System.Diagnostics.Debug.Assert(result == true);
        }
    }
}
