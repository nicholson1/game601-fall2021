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

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        
        if (fadeOut || fadeIn)
        {
            _image.color = new Color(0, 0, 0, alpha);
        }

        if (fadeIn)
        {
            alpha -= .01f;
            
        }

        if (fadeOut)
        {
            alpha += .01f;
        }

        if (alpha > 1 || alpha < 0)
        {
            fadeIn = false;
            fadeOut = false;
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
        fadeIn = true;
        _image.color = Color.black;
        alpha = 1;
    }

    public void FadeOut()
    {
        fadeOut = true;
        //transparent black
        _image.color = new Color(0,0,0,0);
        alpha = 0;


    }
}
