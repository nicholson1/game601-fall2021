using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimalCheck : MonoBehaviour
{
	public AnimalInteract animalInteract;
	

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Animal"))
		{
			animalInteract = other.GetComponent<AnimalInteract>();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Animal"))
		{
			animalInteract.Disengage();
			animalInteract = null;
		}
	}

	private void Update()
	{
		if (animalInteract != null)
		{
			if (Input.GetButtonDown("Submit"))
			{
				animalInteract.Interact(transform.parent.transform);
			}
		}
	}
}
