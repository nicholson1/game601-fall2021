using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour
{
    public Animator anim;

    public AudioSource sounds;

    public AudioClip shoot;

    public GameObject dust;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger("defend");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("die");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("run");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("dizzy");
        }
        
        
        
        
    }

    void swordEffect()
    {
        sounds.PlayOneShot(shoot, 1);
    }

    void spawnDust()
    {
        Instantiate(dust, transform.position, dust.transform.rotation);
    }
}
