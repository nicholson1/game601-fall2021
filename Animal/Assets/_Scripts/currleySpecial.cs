using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currleySpecial : AnimalQuestSpecial
{
    public GameObject QuestTextOnLarry;
    public GameObject PostQuestText;
    public GameObject LarryPostQuestText;

    public GameObject larry;
    public GameObject Butterfly;
    public GameObject LarryQuest;
    
    
    private void Start()
    {
        QuestTextOnLarry.SetActive(false);
        PostQuestText.SetActive(false);
        LarryQuest.SetActive(false);
        LarryPostQuestText.SetActive(false);
    }
    
    public IEnumerator WaitThenRemoveText()
    {
        
        yield return new WaitForSeconds(6f);
        
        QuestTextOnLarry.SetActive(false);
        LarryQuest.SetActive(true);
        GetComponent<AnimalInteract>().textBox = PostQuestText;
        larry.GetComponent<AnimalInteract>().textBox = LarryPostQuestText;
        Debug.Log("how tf did i run");


        larry.GetComponent<AnimalFollow>().DontNeedItem = true;


    }

    

    public override void QuestSpecialAction(GameObject[] req)
    {
        Debug.Log("how tf did i run");
        GetComponent<AnimalInteract>().textBox.SetActive(false);
        Instantiate(Butterfly, larry.transform);
        QuestTextOnLarry.SetActive(true);
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
