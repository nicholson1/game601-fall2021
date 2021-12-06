using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTalking : MonoBehaviour
{
    private Animator _am;

    public GameObject[] texts;
    private int index = 0;
    
    
    
    void Start()
    {
        foreach (var VARIABLE in texts)
        {
            VARIABLE.SetActive(false);
        }
        _am = GetComponentInChildren<Animator>();
    }
    
    public IEnumerator WaitThenRemoveText(GameObject ActivatedObj)
    {
        _am.SetTrigger("howl");
        ActivatedObj.SetActive(true);
        yield return new WaitForSeconds(10f);
        if (index < texts.Length - 1)
        {
            index += 1;
            StartCoroutine(WaitThenRemoveText(texts[index]));

        }
        else
        {
            AnimalPathedMovement _APM = GetComponent<AnimalPathedMovement>();
            if (_APM != null)
            {
                GetComponent<AnimalPathedMovement>().Activated = true;

            }
        }
        ActivatedObj.SetActive(false);

        
        
    }

    public void ActivateNextText()
    {
        StartCoroutine(WaitThenRemoveText(texts[index]));
    }



}
