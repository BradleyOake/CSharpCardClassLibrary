using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNETLab4GUIDesign;

namespace DNETClassLib
{
    public class Player
    {
        public bool isComputer;

        public Cards hand;

        public List<CardControl> playerList;

        // Default Constructor.
        public Player()
        {
            playerList = new List<CardControl>();
            hand = new Cards();
            isComputer = false;
        }

        public Player(bool isNotPlayer)
        {
            playerList = new List<CardControl>();
            hand = new Cards();
            isComputer = isNotPlayer;
        }
    }
}
