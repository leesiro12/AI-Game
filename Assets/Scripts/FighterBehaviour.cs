using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehaviour : UnitBehaviour
{
    public UnitManager unitManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = hitPoint;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public new void AttackSth(StateManager state)
    {
        List<UnitBehaviour> potentialTargets = state.unitManagerScript.currentUnits;
        actualtarget = this;
        foreach (UnitBehaviour target in potentialTargets)
        {
            
            if (target.team != team && target.rankPos == 0)
            {
                actualtarget = target;
            }
            else if (actualtarget == this)
            {
                actualtarget = null;
                unitManagerScript.isPlaying = false;
            }
        }
        actualtarget.attacking = true;
        actualtarget.hitPoint -= dmgValue;
        actualtarget.slider.value -= dmgValue;
    }

    public new IEnumerator HitSth(StateManager state)
    {
        AttackSth(state);
        actualtarget.ren.material = mat[0];
        Debug.Log(name + " attacks " + actualtarget.name + " Dmg: " + dmgValue);
        yield return new WaitForSeconds(1f);
        actualtarget.ren.material = mat[1];
        attacking = false;
    }

}
