using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public StateManager stateManager;
    private Combat combatScript;

    // Start is called before the first frame update
    void Awake()
    {
        stateManager.states.Add(new IdleState());
        stateManager.states.Add(new AttackState(combatScript));
        stateManager.states.Add(new HitState(combatScript));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
