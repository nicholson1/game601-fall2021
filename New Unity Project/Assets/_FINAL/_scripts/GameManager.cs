using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade _fade;

    public int totalChunks;
    public int JumpSpacing;
    public int totalJumps;
    public int queueSize;
    private void Start()
    {
        if(_fade != null)
            _fade.FadeIn();
    }

}
