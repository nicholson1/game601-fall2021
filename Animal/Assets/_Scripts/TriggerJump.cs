using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement1 _playerMovement;
    public SoundManager _SoundManager;
    void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement1>();
    }

    public void Jump()
    {
        _playerMovement.JumpRB();
    }

    public void playRandomFootstep()
    {
        _SoundManager.playRandomFootstep();
    }
    
    public void playlanding()
    {
        _SoundManager.landingSound();

    }
}
