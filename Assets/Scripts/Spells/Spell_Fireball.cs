using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Fireball : BaseCommand
{
    public float targetX = 0f;
    public float targetY = 0f;

    public Spell_Fireball(GameObject actor) : base(actor)
    {
        targetX = actor.GetComponent<PlayerBehaviour>().CurrentMousePosition.x;
        targetY = actor.GetComponent<PlayerBehaviour>().CurrentMousePosition.y;
    }

    public override void Execute()
    {
        GameObject newobj = GameObject.Instantiate(_prefabReference._fireballPrefab, _actorReference.transform.position, Quaternion.identity);
        newobj.GetComponent<FireballBehaviour>().InitFireball(new Vector2(targetX, targetY), _actorReference.GetComponent<PlayerBehaviour>().DamageValue);
    }



}
