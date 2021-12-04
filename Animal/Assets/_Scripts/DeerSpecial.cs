using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class DeerSpecial : AnimalQuestSpecial
{
    public GameObject QuestText;
    public GameObject PostQuestText;
    private AnimalRandomMovement _ARM;
    private AnimalPathedMovement _APM;

    private void Start()
    {
        QuestText.SetActive(false);
        _ARM = GetComponent<AnimalRandomMovement>();
        _APM = GetComponent<AnimalPathedMovement>();

        PostQuestText.SetActive(false);
    }
    
    public IEnumerator WaitThenRemoveText()
    {
        _APM.Stop = true;

        yield return new WaitForSeconds(20f);

        QuestText.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;
        


    }

    

    public override void QuestSpecialAction(GameObject[] req)
    {

        QuestText.SetActive(true);
        _ARM.Activate(20);
        
        
        //_ARM.SpecificMovment(req[0].transform.position, 10);
        req[0].transform.LookAt(transform);
        
        StartCoroutine(WaitThenRemoveText());


    }
    
    
}
