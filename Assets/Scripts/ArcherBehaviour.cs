using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehaviour : UnitBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        thisCharacterClass = CharacterClass.DPS;
        aggressionValue = 0.7f;
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
                priorityValue = 0f;
            }
            else if (target.thisCharacterClass == CharacterClass.Support)
            {
                priorityValue += 1f;
            }
            else if (target.thisCharacterClass == CharacterClass.Tank)
            {
                priorityValue -= 1f;
            }
            if (target.team != team && target.rankPos != 0)
            {
                if (priorityValue > 0)
                {
                    actualtarget = target;
                    otherCharacterClass = target.thisCharacterClass;
                    Debug.Log(actualtarget.thisCharacterClass);
                }
                else
                {
                    actualtarget = target;
                    otherCharacterClass = target.thisCharacterClass;
                    Debug.Log(actualtarget.thisCharacterClass);
                }

            }
            if (actualtarget == this)
            {
                UnitManager.instance.isPlaying = false;
                return;
            }
            else
            {
                switch (otherCharacterClass)
                {
                    case CharacterClass.Tank:
                        actualtarget.attacking = true;
                        actualtarget.hitPoint -= dmgValue;
                        actualtarget.slider.value -= dmgValue;
                        break;
                    case CharacterClass.DPS:
                        actualtarget.attacking = true;
                        actualtarget.hitPoint -= dmgValue * 2;
                        actualtarget.slider.value -= dmgValue;
                        break;
                    case CharacterClass.Support:
                        actualtarget.attacking = true;
                        actualtarget.hitPoint -= dmgValue / 2;
                        actualtarget.slider.value -= dmgValue;
                        break;
                    default:
                        break;
                }
            }
        }
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
