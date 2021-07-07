using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Commands.Spells
{
    public class FireSpellCommand : BaseCommand
    {
        public FireSpellCommand(GameObject playerRef) : base(playerRef) { }
        public override void execute()
        {
            // instantiate at
            float posX = _actorReference.Position_X;
            float posY = _actorReference.Position_Y;

            // moveTowards
            float targetX = _actorReference.MousePosition_X;
            float targetY = _actorReference.MousePosition_Y;


            Console.WriteLine("[" + posX + "," + posY + "] " + _actorReference.name + " casted fireball towards: " + targetX + ", " + targetY);
        }
    }
}
