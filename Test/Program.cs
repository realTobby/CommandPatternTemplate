using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Commands;
using Test.Commands.Spells;

namespace Test
{
    class Program
    {
        static CommandHandler myCommandHandler = new CommandHandler();

        static void Main(string[] args)
        {
            GameObject playerObj = new GameObject();
            playerObj.name = "PlayerObject";
            playerObj.Position_X = 0;
            playerObj.Position_Y = 0;
            playerObj.MousePosition_X = 100;
            playerObj.MousePosition_Y = 100;
            myCommandHandler.executeCommand(new DashSpellCommand(playerObj));

            GameObject enemyObj = new GameObject();
            enemyObj.name = "EnemyObject";
            enemyObj.Position_X = 100;
            enemyObj.Position_Y = 100;
            enemyObj.MousePosition_X = 0;
            enemyObj.MousePosition_Y = 0;

            myCommandHandler.executeCommand(new FireSpellCommand(enemyObj));

            Console.ReadKey();

        }
    }
}
