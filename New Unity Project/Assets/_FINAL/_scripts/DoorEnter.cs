using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    // Start is called before the first frame update
    private levelManager _levelManager;
    public GameObject Johnny;
    public GameObject Balloon;
    public Animator _am;
    private FadeEnterObj _fadeEnterObj;
    public Sprite ballonSprite;
    public Sprite johnnySprite;

    private bool releasedBalloon = false;
    void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
        _am = GetComponent<Animator>();
        _fadeEnterObj = GetComponentInChildren<FadeEnterObj>();
    }

    private void Update()
    {
        if (_levelManager.JumpsRemaining < 0 && !releasedBalloon )
        {
            //play door opening animation
            _am.SetTrigger("balloon");
            releasedBalloon = true;

        }
    }


    // Update is called once per frame
    public void MakeJohnny()
    {
        GameObject john =Instantiate(Johnny, _fadeEnterObj.transform.position, Johnny.transform.rotation);
        _levelManager._mainCamera.GetComponent<CameraFollow>().Player = john.transform;
    }
    public void MakeBallon()
    {
        GameObject ball = Instantiate(Balloon, _fadeEnterObj.transform.position, Balloon.transform.rotation);
        Transform trans = FindObjectOfType<playerScript>().transform;
        ball.GetComponent<Balloon>()._player = trans;
    }       

    public void balloonEntrance()
    {
        _fadeEnterObj.sprite.sprite = ballonSprite;
        _fadeEnterObj.gameObject.SetActive(true);
        _fadeEnterObj.StartBalloonCo();
    }
    public void JohnnyEntrance()
    {
        _fadeEnterObj.sprite.sprite = johnnySprite;
        _fadeEnterObj.gameObject.SetActive(true);
        _fadeEnterObj.StartJohnnyCo();
    }
}
