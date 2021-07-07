using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand : ICommand
{
    internal GameObject _actorReference;
    internal PrefabList _prefabReference;
    public BaseCommand(GameObject actor)
    {
        _actorReference = actor;
        _prefabReference = GameObject.FindGameObjectWithTag("PREFABLIST").GetComponent<PrefabList>();
    }

    public abstract void Execute();
}
