using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade _fade;
    private void Start()
    {
        _fade.FadeIn();
    }

}
