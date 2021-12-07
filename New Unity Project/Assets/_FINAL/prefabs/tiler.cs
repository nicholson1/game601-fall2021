using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject block;
    public Sprite sprite;
    private Transform check;
    public int count = 10;
    private GameObject ore;
    public bool go = false;
    public int varience;
    private int change;
    private bool go_up = true;

    void Start()
    {
    	ore = GameObject.Find("ORE");
    	check = gameObject.transform.Find("tile_detect");
        change = Random.Range(-varience,varience+1);

        if (count < 0)
        {
	        count = Mathf.Abs(count);
	        go_up = false;
        }
        
        count += change;
        
        //Debug.Log(change);
        
    }

    // Update is called once per frame
    void Update()
    {

    	
    	go = !ore.activeSelf;
    	if (go){
	        if (go_up)
	        {
		        RaycastHit2D Info = Physics2D.Raycast(check.position, Vector2.up, .25f);
		        if (Info.collider == false){
			        GameObject x = Instantiate(block, gameObject.transform.position, gameObject.transform.rotation);
			        x.GetComponent<SpriteRenderer>().sprite = sprite;
			        gameObject.transform.position += new Vector3(0,1,0);
			        count -= 1;
	
		        }else{
			        gameObject.SetActive(false);
		        }
	
		        if(count <= 0){
			        gameObject.SetActive(false);
	
		        } 
	        }
	        else
	        {


		        RaycastHit2D Info = Physics2D.Raycast(check.position, Vector2.down, 3f);
		        if (Info.collider == false)
		        {
			        GameObject x = Instantiate(block, gameObject.transform.position, gameObject.transform.rotation);
			        x.GetComponent<SpriteRenderer>().sprite = sprite;
			        gameObject.transform.position += new Vector3(0, -1, 0);
			        count -= 1;

		        }
		        else
		        {
			        gameObject.SetActive(false);
		        }

		        if (count <= 0)
		        {
			        gameObject.SetActive(false);

		        }
	        }
        }
        
    }
}
