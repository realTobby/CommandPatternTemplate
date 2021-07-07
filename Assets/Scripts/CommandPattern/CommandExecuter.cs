using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecuter
{
    public void ExecuteCommand(BaseCommand _concreteCommand)
    {
        _concreteCommand.Execute();
    }

}
