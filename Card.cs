using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Card
    {
        public enum CardType
        {
            Suspect,
            Weapon,
            Room
        }

        public enum SuspectID
        {
            MinSuspectID = 1,
            ColonelMustard = 1,
            MissScarlet = 2,
            ProfessorPlum = 3,
            MrGreen = 4,
            MrsWhite = 5,
            MrsPeacock = 6,
            MaxSuspectID = 6,
        }

        public enum WeaponID
        {
            MinWeaponID = 7,
            Candlestick = 7,
            Knife = 8,
            LeadPipe = 9,
            Rope = 10,
            Revolver = 11,
            Wrench = 12,
            MaxWeaponID = 12,
        }

        public enum RoomID
        {
            MinRoomID = 13,
            Kitchen = 13,
            Ballroom = 14,
            Conservatory = 15,
            DiningRoom = 16,
            BilliardRoom = 17,
            Library = 18,
            Lounge = 19,
            Hall = 20,
            Study = 21,
            MaxRoomID = 21,
        }

        public int Id { get; set;  }

        public Card(int id)
        {
            this.Id = id;
        }

        public Card(SuspectID id)
        {
            this.Id = (int)id;
        }

        public Card(WeaponID id)
        {
            this.Id = (int)id;
        }

        public Card(RoomID id)
        {
            this.Id = (int)id;
        }

        public bool IsEqual(SuspectID id)
        {
            return this.Id == (int)id;
        }

        public bool IsEqual(WeaponID id)
        {
            return this.Id == (int)id;
        }

        public bool IsEqual(RoomID id)
        {
            return this.Id == (int)id;
        }


        public bool IsSuspect()
        {
            if(this.Id >= (int)SuspectID.MinSuspectID && this.Id <= (int)SuspectID.MaxSuspectID)
            {
                return true;
            }
            return false;
        }

        public bool IsWeapon()
        {
            if (this.Id >= (int)WeaponID.MinWeaponID && this.Id <= (int)WeaponID.MaxWeaponID)
            {
                return true;
            }
            return false;
        }

        public bool IsRoom()
        {
            if (this.Id >= (int)RoomID.MinRoomID && this.Id <= (int)RoomID.MaxRoomID)
            {
                return true;
            }
            return false;
        }

        public static Card GetRandomSuspect(Random rnd)
        {
            return new Card(rnd.Next(6) + 1);
        }

        public static Card GetRandomWeapon(Random rnd)
        {
            return new Card(rnd.Next(6) + 7);
        }

        public static Card GetRandomRoom(Random rnd)
        {
            return new Card(rnd.Next(9) + 13);
        }

        public static String CardsToString(Card[] cards)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < cards.Length; i++)
            {
                if(i + 1 < cards.Length)
                {
                    sb.Append(cards[i].ToString() + ", ");
                }
                else
                {
                    sb.Append(cards[i].ToString());
                }
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            if(this.Id == (int)SuspectID.ColonelMustard)
            {
                return "ColonelMustard";
            }
            if (this.Id == (int)SuspectID.MissScarlet)
            {
                return "MissScarlet";
            }
            if (this.Id == (int)SuspectID.ProfessorPlum)
            {
                return "ProfessorPlum";
            }
            if (this.Id == (int)SuspectID.MrGreen)
            {
                return "MrGreen";
            }
            if (this.Id == (int)SuspectID.MrsWhite)
            {
                return "MrsWhite";
            }
            if (this.Id == (int)SuspectID.MrsPeacock)
            {
                return "MrsPeacock";
            }


            if (this.Id == (int)WeaponID.Candlestick)
            {
                return "Candlestick";
            }
            if (this.Id == (int)WeaponID.Knife)
            {
                return "Knife";
            }
            if (this.Id == (int)WeaponID.LeadPipe)
            {
                return "LeadPipe";
            }
            if (this.Id == (int)WeaponID.Rope)
            {
                return "Rope";
            }
            if (this.Id == (int)WeaponID.Revolver)
            {
                return "Revolver";
            }
            if (this.Id == (int)WeaponID.Wrench)
            {
                return "Wrench";
            }


            if (this.Id == (int)RoomID.Kitchen)
            {
                return "Kitchen";
            }
            if (this.Id == (int)RoomID.Ballroom)
            {
                return "Ballroom";
            }
            if (this.Id == (int)RoomID.Conservatory)
            {
                return "Conservatory";
            }
            if (this.Id == (int)RoomID.DiningRoom)
            {
                return "DiningRoom";
            }
            if (this.Id == (int)RoomID.BilliardRoom)
            {
                return "BilliardRoom";
            }
            if (this.Id == (int)RoomID.Library)
            {
                return "Library";
            }
            if (this.Id == (int)RoomID.Lounge)
            {
                return "Lounge";
            }
            if (this.Id == (int)RoomID.Hall)
            {
                return "Hall";
            }
            if (this.Id == (int)RoomID.Study)
            {
                return "Study";
            }
            if(this.Id == 0)
            {
                return "None";
            }
            return base.ToString();
        }
    }
}
