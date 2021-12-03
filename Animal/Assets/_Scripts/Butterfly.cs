using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butterfly : MonoBehaviour
{
    public float speed;

    //public float maxDistance;

    public Vector3 end;

    public float TimeAlive;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, end,
            speed * Time.deltaTime);
        
        TimeAlive -= Time.deltaTime;
        if (TimeAlive < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
