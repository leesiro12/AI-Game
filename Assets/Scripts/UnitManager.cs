using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitBehaviour> currentUnits;
    public bool isPlaying = true;
    public static UnitManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isPlaying = true;
        StartCoroutine(ManageRound());
    }
    public IEnumerator ManageRound()
    {
        while (isPlaying)
        {
            List<UnitBehaviour> healthChecks = new List<UnitBehaviour>(currentUnits);
            foreach (UnitBehaviour cu in healthChecks)
            {
                if (cu.hitPoint <= 0)
                {
                    currentUnits.Remove(cu); 
                }
            }

            currentUnits.Sort(new Comparer());
            currentUnits.Reverse();
            foreach (UnitBehaviour cu in currentUnits)
            {
                cu.GetComponent<Manager>().Activate();
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}

public class Comparer : IComparer<UnitBehaviour>
{
    public int Compare(UnitBehaviour x, UnitBehaviour y)
    {
        return x.spdValue.CompareTo(y.spdValue);
    }
}

