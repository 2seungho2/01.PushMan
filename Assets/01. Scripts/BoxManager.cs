using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public GameObject box;
    public float boxDelay = 0.0f;
   

    void Update()
    {
        BoxDrop();
    }

    void BoxDrop()
    {
       
        if (boxDelay > 2.0f)
        {
            boxDelay = 0.0f;
            Instantiate(box, transform.position, box.transform.rotation);
        }
        boxDelay += Time.deltaTime;
    }
}
