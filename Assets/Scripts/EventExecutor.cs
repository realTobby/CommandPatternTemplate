using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExecutor : MonoBehaviour
{
    private static EventExecutor _instance;

    public static EventExecutor Instance 
    {
        get
        {
            Debug.Log("trying to access the EventExecutor...");
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EventExecutor>();

                if(_instance == null)
                {
                    Debug.Log("creating a new EventExecutor!");
                    GameObject container = new GameObject("EventExecutor");
                    _instance = container.AddComponent<EventExecutor>();
                }
            }
            return _instance;
        } 
    }

}
