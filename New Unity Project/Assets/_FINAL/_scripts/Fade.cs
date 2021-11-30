using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image _image;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private float alpha;
    private levelManager _levelManager;
    public bool done = false;

    private void Start()
    {
        _image = GetComponent<Image>();
       // gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (fadeOut || fadeIn)
        {
            _image.color = new Color(0, 0, 0, alpha);
        }

        if (fadeIn)
        {
            alpha -= 1 * Time.deltaTime; //.01f * Time.deltaTime;

        }

        if (fadeOut)
        {
            alpha += 1 * Time.deltaTime; //.01f * Time.deltaTime;
        }

        if (!done && (alpha > 1.5f || alpha < -.5f))
        {
            if (fadeIn)
            {
                gameObject.SetActive(false);
            }
            fadeIn = false;
            fadeOut = false;
            done = true;
            
        }
    }

    /*public IEnumerator FadeOut(Action function)
    {
        while (alpha < 1)
        {
            _image.color = new Color(0, 0, 0, alpha);
            alpha += .01f;
        }
        function.Invoke();
        yield return ;
    }*/

    public void FadeIn()
    {
        done = false;
        fadeIn = true;
        if (_image == null)
        {
            _image = GetComponent<Image>();
        }
        _image.color = Color.black;
        alpha = 1.4f;
    }

    public void FadeOut()
    {
        done = false;
        fadeOut = true;
        //transparent black
        _image.color = new Color(0,0,0,0);
        alpha = 0;


    }
}
