using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerBehaviour : UnitBehaviour
{
    [SerializeField] bool isHealing;
    public int healValue = 5;
    // Start is called before the first frame update
    void Start()
    {
        thisCharacterClass = CharacterClass.Support;
        aggressionValue = 0.4f;
        slider.maxValue = hitPoint;
        slider.value = slider.maxValue;
    }
    public new void AttackSth()
    {
        List<UnitBehaviour> potentialTargets = UnitManager.instance.currentUnits;
        actualtarget = this;
        foreach (UnitBehaviour target in potentialTargets)
        {
            if (target.thisCharacterClass == CharacterClass.DPS)
            {
                priorityValue = -1f;
            }
            else if (target.thisCharacterClass == CharacterClass.Support)
            {
                priorityValue = 0f;
            }
            else if (target.thisCharacterClass == CharacterClass.Tank)
            {
                priorityValue = 1f;
            }
            if (target.team == team)
            {
                float healIncentive;
                if (target.hitPoint <= target.maxHP * 0.7f)
                {
                    healIncentive = Random.Range(0, target.maxHP);
                    if (target.hitPoint <= 0)
                    {
                        actualtarget = target;
                        otherCharacterClass = target.thisCharacterClass;
                        isHealing = true;
                    }
                    else if (healIncentive > target.hitPoint)
                    {
                        actualtarget = target;
                        otherCharacterClass = target.thisCharacterClass;
                        isHealing = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (target.team != team)
            {
                if (priorityValue > 0)
                {
                    actualtarget = target;
                    otherCharacterClass = target.thisCharacterClass;
                    break;
                }
                else
                {
                    actualtarget = target;
                    otherCharacterClass = target.thisCharacterClass;
                    //Debug.Log(actualtarget.thisCharacterClass);
                }
            }
        }
        if (actualtarget == this)
        {
            UnitManager.instance.isPlaying = false;
            return;
        }
        else if (isHealing)
        {
            Debug.Log(actualtarget.name + " is healed by " + this.name);
            actualtarget.attacking = true;
            actualtarget.hitPoint += healValue;
            actualtarget.slider.value += healValue;
            isHealing = false;
        }
        else
        {
            switch (otherCharacterClass)
            {
                case CharacterClass.Tank:
                    actualtarget.attacking = true;
                    actualtarget.hitPoint -= dmgValue * 2;
                    actualtarget.slider.value -= dmgValue;
                    break;
                case CharacterClass.DPS:
                    actualtarget.attacking = true;
                    actualtarget.hitPoint -= dmgValue / 2;
                    actualtarget.slider.value -= dmgValue;
                    break;
                case CharacterClass.Support:
                    actualtarget.attacking = true;
                    actualtarget.hitPoint -= dmgValue;
                    actualtarget.slider.value -= dmgValue;
                    break;
                default:
                    break;
            }
        }
    }

    public new IEnumerator HitSth()
    {
        if (actualtarget != this)
        {
            AttackSth();
            actualtarget.ren.material = mat[0];
            Debug.Log(name + " attacks " + actualtarget.name + " Dmg: " + dmgValue);
            yield return new WaitForSeconds(1f);
            actualtarget.ren.material = mat[1];
            attacking = false;
        }
        else
        {
            yield break;
        }
    }
}
