using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Commands.Spells
{
    public class DashSpellCommand : BaseCommand
    {
        public DashSpellCommand(GameObject playerRef) : base(playerRef) { }

        public override void execute()
        {
            // move towards
            float targetX = _actorReference.MousePosition_X;
            float targetY = _actorReference.MousePosition_Y;
            Console.WriteLine("[" + _actorReference.Position_X + "," + _actorReference.Position_Y + "] " + _actorReference.name + " dashed towards: " + targetX + ", " + targetY);
        }
    }
}
