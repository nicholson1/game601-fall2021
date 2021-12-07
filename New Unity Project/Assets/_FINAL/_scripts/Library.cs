using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Library: MonoBehaviour
{
    // Start is called before the first frame update

	public List<GameObject> jump = new List<GameObject>();
	public List<GameObject> start = new List<GameObject>();
	public List<GameObject> end = new List<GameObject>();
	public List<GameObject> nojump = new List<GameObject>();

	
	private string path;
	private GameObject temp;
	 private string type;

    void Awake(){

	    Library[] library = FindObjectsOfType<Library>();

	    if (library.Length > 1)
	    {
		    Destroy(this.gameObject);
	    }

	    DontDestroyOnLoad(this.gameObject);
	    
	    var chunks = Resources.LoadAll("library/Chunks", typeof(GameObject)).Cast<GameObject>().ToArray();
    	//string[] newprechunks =  AssetDatabase.FindAssets("_", new[] {"Assets/Resources/library3/Chunks"});

        

        foreach(GameObject temp in chunks)
        {
	        info info = temp.GetComponent<info>();
	        if (info.is_end)
	        {
		        end.Add(temp);
	        }

	        else if (info.is_start)
	        {
		        start.Add(temp);
	        }
	        else 

	        if (info.Jumps > 0)
	        {
		        jump.Add(temp);
	        }
	        else
	        {
		        nojump.Add(temp);
	        }

	        if (info.is_end)
	        {
		        end.Add(temp);
	        }

	        else if (info.is_start)
	        {
		        start.Add(temp);
	        }





        }


    }

}
