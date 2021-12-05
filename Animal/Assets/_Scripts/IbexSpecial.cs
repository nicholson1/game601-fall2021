using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IbexSpecial : AnimalQuestSpecial
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
        _ARM.Activated = true;
        _ARM.Stop = false;
        QuestText.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;
        GetComponent<Mount>().CanMount = true;


    }
    

    public override void QuestSpecialAction(GameObject[] req)
    {
        QuestText.SetActive(true);
        StartCoroutine(WaitThenRemoveText());
        GetComponentInChildren<Animator>().SetBool("Die", false);
        


    }
    
    
}
