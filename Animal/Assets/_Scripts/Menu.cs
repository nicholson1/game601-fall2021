using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{



   public void ReloadScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void TurnOnMenu()
   {
      gameObject.SetActive(true);
   }
   public void TurnOffMenu()
   {
      gameObject.SetActive(false);
   }

}
