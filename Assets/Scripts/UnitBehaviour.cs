using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBehaviour : MonoBehaviour
{
    public float aggressionValue;
    public float maxHP;
    public float hitPoint;
    public int dmgValue = 50;
    public int spdValue = 50;
    public bool attacking = false;
    public Slider slider;
    public int team;
    public int rankPos;
    public UnitBehaviour actualtarget;
    public Renderer ren;
    public Material[] mat;
    public float priorityValue = 0;


    public CharacterClass thisCharacterClass;
    public CharacterClass otherCharacterClass;
    public enum CharacterClass
    {
        Tank,
        DPS,
        Support
    }

    private void Awake()
    {
        maxHP = hitPoint;
    }
    private void Start()
    {
        
        slider.maxValue = hitPoint;
        slider.value = slider.maxValue;
    }
    public void AttackSth()
    {
        List<UnitBehaviour> potentialTargets = UnitManager.instance.currentUnits;
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
    public void Defend()
    {
        List<UnitBehaviour> potentialTargets = UnitManager.instance.currentUnits;
        actualtarget = this;
        foreach (UnitBehaviour target in potentialTargets)
        {
            if (target.team != team)
            {
                actualtarget = target;
            }
        }
    }
    public IEnumerator HitSth()
    {
            AttackSth();
            actualtarget.ren.material = mat[0];
            Debug.Log(name + " attacks " + actualtarget.name + " Dmg: " + dmgValue);
            yield return new WaitForSeconds(1f);
            actualtarget.ren.material = mat[1];
            attacking = false;
    }
}
