using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    public Renderer ren;
    public Material[] mat;
    public int hitPoint = 5;
    public int dmgValue = 5;
    public int spdValue = 5;

    public void AttackSth()
    {
        hitPoint -= dmgValue;
    }
    public IEnumerator HitSth()
    {
        AttackSth();
        ren.material = mat[0];
        yield return new WaitForSeconds(.7f);
        ren.material = mat[1];
    }
}
