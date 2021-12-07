using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = System.Object;

public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int JumpsRemaining = 5;
    public Monster[] Enemies;
    public Text jumpText;
    public Camera _mainCamera;
    public Fade _fade;
    private DoorEnter _doorEnter;
    private bool chaosTriggered;
    public void LevelStart()
    {
        Enemies = FindObjectsOfType<Monster>();
        _doorEnter = FindObjectOfType<DoorEnter>();
        jumpText.text = "Jumps Remaining: " + JumpsRemaining;
        _mainCamera = FindObjectOfType<Camera>();
        _fade = FindObjectOfType<Fade>();
        _fade.gameObject.SetActive(true);
        _fade.FadeIn();
        StartCoroutine(waitThenOpenDoor());

    }

    private void Update()
    {
        if (!chaosTriggered)
        {
            if (JumpsRemaining < 0)
            {
                RandomScale[] scales = FindObjectsOfType<RandomScale>();
                foreach (RandomScale rs in scales)
                {
                    rs.Chaos = true;
                    rs.timeToChange = 0;
                }

                chaosTriggered = true;
            }
        }
    }

    public IEnumerator waitThenOpenDoor()
    {
        while (!_fade.done)
        {
            yield return new WaitForSeconds(.1f);
        }
        _doorEnter._am.SetTrigger("johnny");
        
    }
    

    // Update is called once per frame
    public void UpdateText()
    {
        if (JumpsRemaining >= 0)
        {
            jumpText.text = "Jumps Remaining: " + JumpsRemaining;
        }
        else
        {

            jumpText.text = "RUN" + new String('!' , (JumpsRemaining * -1) - 1 ) ;
            jumpText.fontSize = jumpText.fontSize + 20;
        }

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

    public IEnumerator waitThenRestart()
    {
        while (!_fade.done)
        {
            yield return new WaitForSeconds(.1f);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator waitThenLoadNext()
    {
        while (!_fade.done)
        {
            yield return new WaitForSeconds(.1f);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextLevel()
    {
        _fade.gameObject.SetActive(true);
        _fade.FadeOut();
        StartCoroutine(waitThenLoadNext());
    }
    

    public void RestartLevel()
    {

        //fade out
        _fade.gameObject.SetActive(true);
        _fade.FadeOut();
        StartCoroutine(waitThenRestart());
        //restart current level

    }
}
