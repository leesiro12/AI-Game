using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public StateManager stateManager;
    void Awake()
    {
        stateManager.states.Add(new IdleState());
        stateManager.states.Add(new AttackState());
        stateManager.states.Add(new HitState());
        stateManager.states.Add(new DefState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
