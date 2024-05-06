using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehaviour : UnitBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        priorityValue = 0.7f;
        slider.maxValue = hitPoint;
        slider.value = slider.maxValue;
    }

    public new void AttackSth()
    {
        List<UnitBehaviour> potentialTargets = UnitManager.instance.currentUnits;
        actualtarget = this;
        foreach (UnitBehaviour target in potentialTargets)
        {
            if (target.team != team && target.rankPos != 0)
            {
                actualtarget = target;
            }
            
        }
        if (actualtarget == this)
        {
            UnitManager.instance.isPlaying = false;
            return;
        }
        else
        {
            actualtarget.attacking = true;
            actualtarget.hitPoint -= dmgValue;
            actualtarget.slider.value -= dmgValue;
        }
        actualtarget.attacking = true;
        actualtarget.hitPoint -= dmgValue;
        actualtarget.slider.value -= dmgValue;
    }

    public new IEnumerator HitSth()
    {
        AttackSth();
        actualtarget.ren.material = mat[0];
        Debug.Log(name + " attacks " + actualtarget.name + " Dmg: " + dmgValue);
        yield return new WaitForSeconds(1f);
        actualtarget.ren.material = mat[1];
        attacking = false;
    }
}
