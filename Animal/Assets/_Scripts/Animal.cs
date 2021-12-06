using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Start is called before the first frame update
    public Animaltype type;

    private Vector3 lastPosition;
    public bool important;
    void FixedUpdate()
    {

        bool hit = Physics.Raycast(transform.position + new Vector3(0,.1f,0), Vector3.down, 10);

        if (hit)
        {
            this.lastPosition = transform.position;
        }
        else
        {
            //Debug.Log("we fell through" + gameObject.name);
            if (important)
            {
                transform.position = new Vector3(transform.position.x, lastPosition.y +.1f , transform.position.z);

            }
            else
            {
                transform.position = new Vector3(transform.position.x, lastPosition.y +.05f , transform.position.z);
  
            }
        }

    }
    
    public enum Animaltype
    {
        Ibex,
        Bear,
        Chicken,
        Wolf,
        Cow, 
        Rabbit,
        Rat,
        BabyRabbit,
        Deer
        
    }
}
