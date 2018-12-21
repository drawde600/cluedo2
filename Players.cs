using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Players
    {
        public int NumPlayers { get; set; }
        public string[] Names { get; set; }
        public Players(string [] names)
        {
            this.NumPlayers = names.Length;
            this.Names = new string[names.Length];
            for(int i = 0; i < names.Length; i++)
            {
                this.Names[i] = names[i];
            }
        }

    }
}
