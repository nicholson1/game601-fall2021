using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{


    public GameObject WolfToDeactive;
    public GameObject WolfToActivate;
    public GameObject TheCousin;

    public int QuestsCompleted = 0;
    public int QuestRequiredToWin = 10;

    private bool hasTriggeredWolf;
    private SoundManager _sm;

    private void Start()
    {
        _sm = FindObjectOfType<SoundManager>();
        WolfToActivate.SetActive(false);
    }

    public void CompleteQuest()
    {
        QuestsCompleted += 1;
        _sm.PlayQuestCompleteSound();
        if (QuestsCompleted >= QuestRequiredToWin && !hasTriggeredWolf)
        {
            WolfToActivate.transform.position = WolfToDeactive.transform.position;
            WolfToActivate.transform.rotation = WolfToDeactive.transform.rotation;
            WolfToDeactive.SetActive(false);
            WolfToActivate.SetActive(true);
            TheCousin.SetActive(true);
            
            
            
        }
    }
}
