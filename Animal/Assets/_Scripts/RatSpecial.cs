using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatSpecial : AnimalQuestSpecial
{
    public GameObject QuestText;
    public GameObject PostQuestText;
    private AnimalRandomMovement _ARM;
    private void Start()
    {
        QuestText.SetActive(false);
        _ARM = GetComponent<AnimalRandomMovement>();
        PostQuestText.SetActive(false);
    }
    
    public IEnumerator WaitThenRemoveText()
    {
        
        yield return new WaitForSeconds(6f);
        
        _ARM.Stop = false;
        QuestText.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;


    }

    private Transform FindClosestCheese(GameObject[] req)
    {
        Transform x = req[0].transform;
        foreach (var VARIABLE in req)
        {
            if (Vector3.Distance(VARIABLE.transform.position, transform.position) <
                Vector3.Distance(x.position, transform.position))
            {
                x = VARIABLE.transform;
            }
        }

        return x;
    }

    public override void QuestSpecialAction(GameObject[] req)
    {

        GetComponent<AnimalInteract>().textBox.SetActive(false);
        QuestText.SetActive(true);
        _ARM.Activated = true;
        _ARM.SpecificMovment(FindClosestCheese(req).position, 1);
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
