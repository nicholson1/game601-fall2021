using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LarrySpecial : AnimalQuestSpecial
{
    public GameObject QuestTextOnLarry;
    public GameObject QuestTextOnCurrly;
    public GameObject PostQuestText;
    public GameObject currly;
    public GameObject Butterfly;
    
    
    private void Start()
    {
        QuestTextOnLarry.SetActive(false);
        PostQuestText.SetActive(false);
    }
    
    public IEnumerator WaitThenRemoveTextLarry()
    {
        
        yield return new WaitForSeconds(6f);
        QuestTextOnCurrly.SetActive(false);
        QuestTextOnLarry.SetActive(false);
        
        GetComponent<AnimalInteract>().textBox = PostQuestText;

        
        GetComponent<AnimalRandomMovement>().Activate(3);
        GetComponent<AnimalFollow>().following = false;


    }

    

    public override void QuestSpecialAction(GameObject[] req)
    {
        GetComponent<AnimalPathedMovement>().Activated = false;
        Instantiate(Butterfly, currly.transform);
        QuestTextOnCurrly.SetActive(true);
        QuestTextOnLarry.SetActive(true);
        StartCoroutine(WaitThenRemoveTextLarry());


    }
    
    
}
