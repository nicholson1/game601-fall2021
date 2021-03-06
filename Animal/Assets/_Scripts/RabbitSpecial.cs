using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitSpecial : AnimalQuestSpecial
{
    public GameObject QuestText;
    public GameObject PostQuestText;
    private AnimalRandomMovement _ARM;
    public GameObject butterflyies;
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
        Instantiate(butterflyies, req[0].transform);
        Instantiate(butterflyies, req[1].transform);

        req[0].GetComponent<AnimalInteract>().textBox.GetComponentInChildren<Text>().text = "I like Carrots";
        req[1].GetComponent<AnimalInteract>().textBox.GetComponentInChildren<Text>().text = "I like Turnips";
        req[0].GetComponent<AnimalRandomMovement>().Activate(5);
        req[1].GetComponent<AnimalRandomMovement>().Activate(5);

        _ARM.SpecificMovment(req[0].transform.position, 3);
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
