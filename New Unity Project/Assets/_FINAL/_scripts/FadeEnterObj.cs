using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FadeEnterObj : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sprite;
    private float alpha = 0;
    public DoorEnter door;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1,1,1,alpha);

        //StartCoroutine(FadeIn());
    }
    public void StartJohnnyCo()
    {
        StartCoroutine(FadeInJohnny());
    }

    public IEnumerator FadeInJohnny()
    {

        alpha = 0;
        sprite.color = new Color(1,1,1,alpha);

        while (sprite.color.a < .9f)
        {
            sprite.color = new Color(1,1,1,alpha);
            alpha += .1f;
            yield return new WaitForSeconds(.1f);

        }
        door.MakeJohnny();
        door._am.SetTrigger("close");

        gameObject.SetActive(false);



    }

    public void StartBalloonCo()
    {
        StartCoroutine(FadeInBalloon());
    }
    public IEnumerator FadeInBalloon()
    {

        
        alpha = 0;
        sprite.color = new Color(1,1,1,alpha);

        
        while (sprite.color.a < .9f)
        {
            sprite.color = new Color(1,1,1,alpha);
            alpha += .1f;
            yield return new WaitForSeconds(.1f);

        }

        door.MakeBallon();
        door._am.SetTrigger("close");
        gameObject.SetActive(false);



    }
}
