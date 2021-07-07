using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Dash : BaseCommand
{
    public Vector2 direction;
    public float dashBoost = 1000f;
    public Spell_Dash(GameObject actor) : base(actor)
    {
        direction = _actorReference.GetComponent<Rigidbody2D>().velocity;
    }

    public override void Execute()
    {
        Debug.Log("Dash Spell execute start!");
        
        _actorReference.GetComponent<Rigidbody2D>().AddForce(direction * dashBoost);
        EventExecutor.Instance.StartCoroutine(AfterDashCall());
        GameObject particles = GameObject.Instantiate(_prefabReference._dashParticlePrefab, _actorReference.transform.position, Quaternion.identity);
        GameObject.Destroy(particles, 100 * Time.deltaTime);
    }

    private IEnumerator AfterDashCall()
    {
        yield return new WaitForSeconds(0.05f);
        _actorReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        yield return new WaitForSeconds(0.06f);
        _actorReference.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }


}
