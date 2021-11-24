using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int JumpsRemaining = 5;
    public Monster[] Enemies;
    
    void Start()
    {
        Enemies = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpTrigger()
    {
        JumpsRemaining -= 1;
        foreach (Monster enemy in Enemies)
        {
            enemy.AttackToggle();
        }
        //find all enemies
        // toggle attacking
        
    }
}
