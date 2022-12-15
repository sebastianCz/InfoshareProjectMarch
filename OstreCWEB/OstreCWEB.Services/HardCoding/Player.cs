using OstreCWEB.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.HardCoding
{
    public class Player : Character
    {
        public int ActionCounter = 2;
        public Player()
        {
            ID = 1;
            Name = "Yolo Swaggins";
            Race = "Human";
            HealthPoints = 10;
            Actions = new List<CharacterAction>();
            Actions.Add(CharacterAction.ATTACK);
            Actions.Add(CharacterAction.HEAL);

        }
    }

}
