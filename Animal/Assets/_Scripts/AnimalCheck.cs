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
				
				if(other.GetComponent<AnimalInteract>().canInteract)
				{
					animalInteract = other.GetComponent<AnimalInteract>();
					animalInteract.ShowToolTip(transform.parent);
				}
				
				
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

			if (Input.GetButtonUp("Mount"))
			{
				//mount
				TryMount();
			}
		}
	}

	public void TryMount()
	{
		Mount mount = animalInteract.GetComponent<Mount>();
		if (mount == null || mount.CanMount == false)
		{
			return;
		}
		else
		{
			mount.DoTheMount(gameObject.transform.parent.gameObject);
			GetComponentInParent<PlayerMovement1>().MountToggle();
			animalInteract.Disengage();

			animalInteract = null;
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

		if (animalFollow.DontNeedItem)
		{
			//if already following cancel
			if (animalFollow.following == false)
			{
				animalFollow.objectToFollow = transform;
				animalFollow.following = true;
				animalsFollowingMe.Add(animalFollow);
			}
			else
			{
				animalFollow.objectToFollow = null;
				animalFollow.following = false;
				animalsFollowingMe.Remove(animalFollow);
			}
			
		}
		
		//if item or item 2 is in animalInteract.getcomponent
		
	}

	

	
	
}
