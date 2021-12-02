using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalModel : MonoBehaviour
{
    public GameObject Model;
    public GameObject TempModel;

    private void Start()
    {
        TempModel.SetActive(false);
        GameObject model = Instantiate(Model, transform);
        model.name = "AnimalModel";
        model.transform.rotation = transform.rotation;



    }

    private IEnumerator waitThenMakeModel()
    {
        yield return new WaitForSeconds(.1f);


    } 
}
