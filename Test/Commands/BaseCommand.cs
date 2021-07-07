using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test.Commands
{
    public abstract class BaseCommand
    {
        internal GameObject _actorReference;

        public BaseCommand(GameObject actor)
        {
            _actorReference = actor;
        }
        public abstract void execute();


    }
}
