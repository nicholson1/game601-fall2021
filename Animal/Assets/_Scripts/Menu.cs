using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


   private SoundManager _sm;

   private void Start()
   {
      _sm = FindObjectOfType<SoundManager>();
   }

   public void ReloadScene()
   {
      _sm.MenuButtonSound();
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void TurnOnMenu()
   {

      _sm = FindObjectOfType<SoundManager>();

      _sm.MenuButtonSound();
      gameObject.SetActive(true);
   }
   public void TurnOffMenu()
   {
      _sm.MenuButtonSound();

      gameObject.SetActive(false);
   }

}
