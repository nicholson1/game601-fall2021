using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenSpecial : AnimalQuestSpecial
{
    public GameObject QuestText;
    public GameObject PostQuestText;
    private AnimalRandomMovement _ARM;
    public GameObject[] OtherChickens;
    public GameObject otherLostChicken;

    public Text[] TextsToChange;

    public String[] NewTexts;
    
    public GameObject butterflyies;
    private void Start()
    {
        QuestText.SetActive(false);
        _ARM = GetComponent<AnimalRandomMovement>();

        PostQuestText.SetActive(false);
        
    }
    
    public IEnumerator WaitThenRemoveText()
    {
        _ARM.Pause();
        _ARM.Activated = false;

        yield return new WaitForSeconds(10f);
        
        _ARM.Activated = true;
        QuestText.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;


    }

    public override void QuestSpecialAction(GameObject[] req)
    {

        GetComponent<AnimalFollow>().DontNeedItem = false;

        QuestText.SetActive(true);
        foreach (var chicken in OtherChickens)
        {
            Instantiate(butterflyies, chicken.transform);
            
            chicken.GetComponent<AnimalRandomMovement>().SpecificMovment(transform.position, 3);

        }

        if (otherLostChicken.GetComponentInChildren<Quest>().Completed)
        {
            Instantiate(butterflyies, otherLostChicken.transform);

            otherLostChicken.GetComponent<AnimalRandomMovement>().SpecificMovment(transform.position, 3);
            TextsToChange[TextsToChange.Length - 1].text = NewTexts[NewTexts.Length - 1];
        }
            
        for (int i = 0; i < TextsToChange.Length - 1; i++)
        {
            TextsToChange[i].text = NewTexts[i];

        }


        //_ARM.SpecificMovment(req[0].transform.position, 3);
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
