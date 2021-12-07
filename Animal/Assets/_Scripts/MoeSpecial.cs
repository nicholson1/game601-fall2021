using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoeSpecial : AnimalQuestSpecial
{
    public GameObject QuestTextOnMoe;
    public GameObject QuestTextOnCurrly;
    public GameObject PostQuestText;
    public GameObject Butterfly;
    
    
    private void Start()
    {
        QuestTextOnCurrly.SetActive(false);
        QuestTextOnMoe.SetActive(false);
        PostQuestText.SetActive(false);
    }
    
    public IEnumerator WaitThenRemoveTextMoe()
    {
        Debug.Log("this ran");
        yield return new WaitForSeconds(6f);
        QuestTextOnCurrly.SetActive(false);
        QuestTextOnMoe.SetActive(false);
        
        GetComponent<AnimalInteract>().textBox = PostQuestText;

        
        GetComponent<AnimalRandomMovement>().Activate(3);
        GetComponent<AnimalFollow>().following = false;


    }

    

    public override void QuestSpecialAction(GameObject[] req)
    {
        GetComponent<AnimalPathedMovement>().Activated = false;
        Instantiate(Butterfly, req[0].transform);
        QuestTextOnCurrly.SetActive(true);
        QuestTextOnMoe.SetActive(true);
        StartCoroutine(WaitThenRemoveTextMoe());


    }
    
    
}
