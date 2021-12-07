using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;


public class Jigsaw : MonoBehaviour
{
	// Start is called before the first frame update
	///////////////////////////
	///establish game object lists
	public Library Library;

	public List<GameObject> jump = new List<GameObject>();
	public List<GameObject> nojump = new List<GameObject>();
	public List<GameObject> start = new List<GameObject>();
	public List<GameObject> end = new List<GameObject>();
	

	////////////////////////////////////////
	//////queue so that chunks dont repeat 
	public int queue_size = 15;
	private List<GameObject> chunk_queue = new List<GameObject>();

	////////////////////////////////////////

	public List<GameObject> possible_chunks = new List<GameObject>();
	private GameObject current_chunk;
	private Transform current_anch;
	public int total_chunks = 30;

	public int chunks_placed = 0;

	////////////////////////////////////////
	////////space out the puzzle chunks
	public int Jump_spacing = 5;
	private int Jump_count = 0;
	private int TotalJumps;



	///////////////////
	///////for list removal from possible
	private List<GameObject> updated = new List<GameObject>();


	////////////
	///get() recurssion stop
	private int get_stop = 30;


	public int seed;


	//Button and door list

	//private GameObject[] buttonlists;



	private GameManager _GM;

	void Awake()
	{
		
		_GM = FindObjectOfType<GameManager>();
		total_chunks = _GM.totalChunks;
		Jump_spacing = _GM.JumpSpacing;
		TotalJumps = _GM.totalJumps;
		queue_size = _GM.queueSize;

	}

	public System.Random rand1;

	void Start()
	{

		if (seed != 0)
		{
			rand1 = new System.Random(seed);


		}
		else
		{
			seed = Random.Range(1, 1000000);
			rand1 = new System.Random(seed);


		}

		Debug.Log("Seed: " + seed.ToString());

		Library = FindObjectOfType<Library>();

		nojump = Library.nojump;
		jump = Library.jump;
		end = Library.end;
		start = Library.start;
		



		current_anch = gameObject.transform;
		//current_chunk = start[Random.Range(0, start.Count-1)];
		//Debug.Log(start.Count);
		current_chunk = start[rand1.Next(0, start.Count - 1)];
		//Debug.Log(current_chunk);

		PlaceChunk(current_chunk);



		//chunk_queue.Add(current_chunk);


		//Time.timeScale = 0;

		//Get start


	}

	private void PlaceChunk(GameObject chunk)
	{
		GameObject x = Instantiate(chunk, current_anch.position, current_chunk.transform.rotation);
		current_anch = x.GetComponent<info>().anchor;
		total_chunks -= 1;
		TotalJumps += x.GetComponent<info>().Jumps;

	}

	private bool go = true;
	// Update is called once per frame
	void Update()
	{
		if (go)
		{
			while (total_chunks > 0)
			{
				//GET CHUNK
				GetChunk();
				PlaceChunk(current_chunk);
			}
			if (total_chunks <= 0)
			{
			
				current_chunk = end[rand1.Next(0, end.Count)];
				PlaceChunk(current_chunk);
				go = false;
				FindObjectOfType<levelManager>().LevelStart();

			}
		}
		
	}

	void GetChunk()
	{
		possible_chunks = nojump;
		if (TotalJumps > Jump_count)
		{
			//make a list of all the objects with a lower or equal jump value to total jumps - jump count;
			List<GameObject> possibleJumps = new List<GameObject>();
			foreach (GameObject j in jump)
			{
				if (j.GetComponent<info>().Jumps <= TotalJumps - Jump_count)
				{
					possibleJumps.Add(j);
				}
			}
			
			possible_chunks.AddRange(possibleJumps);
			Debug.Log(possibleJumps.Count);

		}
		

		possible_chunks = list_out(possible_chunks, chunk_queue);

		
		//get random
		current_chunk = possible_chunks[rand1.Next(0, possible_chunks.Count)];
		// add it to chunk que
		// chunk_queue.Add(current_chunk);
		// if (chunk_queue.Count > queue_size)
		// {
		// 	chunk_queue = chunk_queue.GetRange(1, queue_size - 1);
		// }
		

	}
	
	List<GameObject> list_out(List<GameObject> possible_chunks, List<GameObject> Exception){
		updated = possible_chunks.Except(Exception).ToList();
		return updated;

	}
}

