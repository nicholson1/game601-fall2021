using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitSpecial : AnimalQuestSpecial
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
        
        yield return new WaitForSeconds(10f);
        
        _ARM.Stop = false;
        QuestText.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;


    }

    public override void QuestSpecialAction(GameObject[] req)
    {

        QuestText.SetActive(true);
        req[0].GetComponent<AnimalInteract>().textBox.GetComponentInChildren<Text>().text = "I like Carrots";
        req[1].GetComponent<AnimalInteract>().textBox.GetComponentInChildren<Text>().text = "I like Turnips";
        _ARM.SpecificMovment(req[0].transform.position, 3);
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
