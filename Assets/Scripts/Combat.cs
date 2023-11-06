using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Renderer ren;
    public Material[] mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator HitSth()
    {
        ren.material = mat[0];
        yield return new WaitForSeconds(0.3f);
        ren.material = mat[1];
    }
}
