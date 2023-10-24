using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public StateManager stateManager;
    // Start is called before the first frame update
    void Awake()
    {
        stateManager.states.Add(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
