using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBehaviour : MonoBehaviour
{
    public int hitPoint;
    public int dmgValue = 5;
    public int spdValue = 5;
    public bool attacking = false;
    public Slider slider;
    public int team;
    public int rankPos;
    public UnitBehaviour actualtarget;
    public Renderer ren;
    public Material[] mat;

    private void Start()
    {
        slider.maxValue = hitPoint;
        slider.value = slider.maxValue;
    }
    public void AttackSth(StateManager state)
    {
        List<UnitBehaviour> potentialTargets = state.unitManagerScript.currentUnits;
        actualtarget = this;
        foreach (UnitBehaviour target in potentialTargets)
        {
            if (target.team != team)
            {
                actualtarget = target;
            }
        }
        actualtarget.attacking = true;
        actualtarget.hitPoint -= dmgValue;
        actualtarget.slider.value -= dmgValue;
    }
    public IEnumerator HitSth(StateManager state)
    {
            AttackSth(state);
            actualtarget.ren.material = mat[0];
            Debug.Log(name + " attacks " + actualtarget.name + " Dmg: " + dmgValue);
            yield return new WaitForSeconds(1f);
            actualtarget.ren.material = mat[1];
            attacking = false;
    }
}
