using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    public GameObject playerReference;

    public Text damage_text;
    public Text defense_text;
    public Text speed_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // update player value to ui
        damage_text.text = playerReference.GetComponent<PlayerBehaviour>().DamageValue.ToString();

        defense_text.text = playerReference.GetComponent<PlayerBehaviour>().DefenseValue.ToString();

        speed_text.text = playerReference.GetComponent<PlayerBehaviour>().SpeedValue.ToString();


    }
}
