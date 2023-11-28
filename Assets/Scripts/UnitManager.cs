using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitBehaviour> currentUnits;
    public bool isPlaying = true;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        StartCoroutine(ManageRound());
    }
    public IEnumerator ManageRound()
    {
        while (isPlaying)
        {
            currentUnits.Sort(new Comparer());
            currentUnits.Reverse();
            foreach (UnitBehaviour cu in currentUnits)
            {
                cu.GetComponent<StateManager>().Activate();
                yield return new WaitForSeconds(1f);
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

