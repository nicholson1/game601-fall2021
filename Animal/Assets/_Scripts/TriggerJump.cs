using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement1 _playerMovement;
    void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement1>();
    }

    public void Jump()
    {
        _playerMovement.JumpRB();
    }
}
