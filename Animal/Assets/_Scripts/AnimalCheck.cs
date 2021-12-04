using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AnimalCheck : MonoBehaviour
{
	public AnimalInteract animalInteract;
	
	public List<AnimalFollow> animalsFollowingMe = new List<AnimalFollow>();
	

	

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Animal"))
		{
			if (animalInteract == null)
			{
				animalInteract = other.GetComponent<AnimalInteract>();
				animalInteract.ShowToolTip(transform.parent);
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Animal"))
		{
			if (animalInteract == other.GetComponent<AnimalInteract>())
			{
				animalInteract.Disengage();
				animalInteract = null;
			}
			
		}
	}

	private void Update()
	{
		if (animalInteract != null)
		{
			if (Input.GetButtonDown("Submit"))
			{
				animalInteract.Interact(transform.parent.transform);
				FollowMe();
			}
		}
	}
	
	public void FollowMe()
	{
		AnimalFollow animalFollow = animalInteract.GetComponent<AnimalFollow>();
		ItemCarry myItems = GetComponent<ItemCarry>();
		if (myItems.item1 != null)
		{
			if(animalFollow.itemsToFollow.Contains(myItems.item1.type))
			{
				animalFollow.objectToFollow = transform;
				animalFollow.following = true;
				animalsFollowingMe.Add(animalFollow);

				return;
			}
		}

		if (myItems.item2 != null)
		{
			if( animalFollow.itemsToFollow.Contains(myItems.item2.type) )
			{
				animalFollow.objectToFollow = transform;
				animalFollow.following = true;
				animalsFollowingMe.Add(animalFollow);

				return;
			}
		}
		
		//if item or item 2 is in animalInteract.getcomponent
		
	}

	

	
	
}
