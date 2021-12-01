using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentAndPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform parentToSet;
    public Vector3 offsetPos;
    public Vector3 offsetRot;
    public Vector3 offsetScale;
    private bool moved = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!moved)
        
        {
            transform.SetParent(parentToSet);
            transform.localPosition = Vector3.zero + offsetPos;
            transform.localEulerAngles = Vector3.zero + offsetRot;
            transform.localScale = Vector3.one + offsetScale;
            moved = true;
            
        }

    }
}
