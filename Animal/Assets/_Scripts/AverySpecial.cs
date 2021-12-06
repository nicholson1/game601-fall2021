using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AverySpecial : AnimalQuestSpecial
{
    public GameObject QuestText;
    public GameObject PostQuestText;
    private void Start()
    {
        QuestText.SetActive(false);
        PostQuestText.SetActive(false);
    }
    
    public IEnumerator WaitThenRemoveText()
    {
        
        yield return new WaitForSeconds(6f);
        
        QuestText.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;
        
        //END GAME
        //FadeToBlack
        // thank you screen
        Debug.Log("end");


    }

    

    public override void QuestSpecialAction(GameObject[] req)
    {

        QuestText.SetActive(true);
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
