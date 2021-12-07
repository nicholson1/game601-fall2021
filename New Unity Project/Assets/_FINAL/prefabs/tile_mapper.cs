using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_mapper : MonoBehaviour
{
    // Start is called before the first frame update

    private bool UL = false;
    private bool U = false;
    private bool UR = false;
    private bool L = false;
    private bool R = false;
    private bool DL = false;
    private bool D = false;
    private bool DR = false;

    public Sprite[] sprites;

   
    public bool go = false;
    private bool once = true;



    void Start()
    {
    	

       
    }
    void Update(){
    	
    	if(go && once){
    		tile();
    		once =false;
    	}

    }

    void tile(){

        RaycastHit2D ULrc = Physics2D.Raycast(gameObject.transform.position + new Vector3(-1,1,0), Vector2.up, .1f);
		RaycastHit2D Urc = Physics2D.Raycast(gameObject.transform.position + new Vector3(0,1,0), Vector2.up, .1f);
		RaycastHit2D URrc = Physics2D.Raycast(gameObject.transform.position + new Vector3(1,1,0), Vector2.up, .1f);
		RaycastHit2D Lrc = Physics2D.Raycast(gameObject.transform.position + new Vector3(-1,0,0), Vector2.up, .1f);
		RaycastHit2D Rrc = Physics2D.Raycast(gameObject.transform.position + new Vector3(1,0,0), Vector2.up, .1f);
		RaycastHit2D DLrc = Physics2D.Raycast(gameObject.transform.position + new Vector3(-1,-1,0), Vector2.up, .1f);
		RaycastHit2D Drc = Physics2D.Raycast(gameObject.transform.position + new Vector3(0,-1,0), Vector2.up, .1f);
		RaycastHit2D DRrc = Physics2D.Raycast(gameObject.transform.position + new Vector3(1,-1,0), Vector2.up, .1f);

    	if(ULrc.collider == true && ULrc.collider.tag == "tile"){
    		UL = true;
    	}
    	if(Urc.collider == true && Urc.collider.tag == "tile"){
    		U = true;
    	}
    	if(URrc.collider == true && URrc.collider.tag == "tile"){
    		UR = true;
    	}
    	if(Lrc.collider == true && Lrc.collider.tag == "tile"){
    		L = true;
    	}
    	if(Rrc.collider == true && Rrc.collider.tag == "tile"){
    		R = true;
    	}
    	if(DLrc.collider == true && DLrc.collider.tag == "tile"){
    		DL = true;
    	}
    	if(Drc.collider == true && Drc.collider.tag == "tile"){
    		D = true;
    	}
    	if(DRrc.collider == true && DRrc.collider.tag == "tile"){
    		DR = true;
    	}

    	
    	if(!U && !L && R  && !D ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
    	}
    	if( !U &&  L && R  && !D ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
    	}
    	if( !U  && L && !R  && !D ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
    	}
    	if( !U &&  !L && R &&  D && !DR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
    	}
    	if( !U &&  L && !R &&  D && !DL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
    	}
    	if( U  && !L && R &&  D && !DR && ! UR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
    	}
    	if( !U  && L && R &&  D && !DL && !DR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
    	}
    	if( U  && L && R &&  D && !DL && !DR && !UL && UR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[8];
    	}
    	if( U  && L && R &&  D && !DL && !UR && !UL && DR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[9];
    	}
    	if( U  && L && R &&  D && !UR && !DR && UL && DL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[10];
    	}
    	if( U  && L && R &&  D && !DL && !DR &&UR && UL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[11];
    	}
    	if( !U &&  !L && !R  && D ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[12];
    	}
    	if( !U &&  !L && R  && D  && DR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[13];
    	}
    	if( !U &&  L && R  && D  && DR && DL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[14];
    	}
    	if( !U &&  L && !R  && D  && DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[15];
    	}
    	if( U &&  !L && R  && !D  && !UR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[16];
    	}
    	if( U &&  L && !R  && !D  && !UL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[17];
    	}
    	if( U &&  L && R  && !D  && !UL && !UR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[18];
    	}
    	if( U &&  L && !R  && D  && !DL && !UL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[19];
    	}
    	if( U  && L && R &&  D && !DL && !DR && !UR && UL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[20];
    	}
    	if( U  && L && R &&  D && DL && !DR && !UR && !UL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[21];
    	}
    	if( U  && L && R &&  D && DL && DR && !UR && !UL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[22];
    	}
    	if( U  && L && R &&  D && !DL && DR && UR && !UL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[23];
    	}
    	if( U  && !L && !R &&  D ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[24];
    	}
    	if( U  && !L && R &&  D  && DR && UR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[25];
    	}
    	if( U  && L && R &&  D && UL && UR && DL && DR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[26];
    	}
    	if( U  && L && !R &&  D  && DL && UL){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[27];
    	}
    	if( U  && !L && R &&  D  && DR && !UR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[28];
    	}
    	if( !U  && L && R &&  D  && !DR && DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[29];
    	}
    	if( U  && !L && R &&  D  && !DR && UR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[30];
    	}
    	if( !U  && L && R &&  D  && DR && !DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[31];
    	}
    	if( U  && L && R &&  D  && !DR && UR&& UL && DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[32];
    	}
    	if( U  && L && R &&  D  && DR && UR&& UL && !DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[33];
    	}
    	if( U  && L && R &&  D  && !DR && UR&& !UL && DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[34];
    	}
    	if( U  && L && R &&  D  && DR && !UR&& UL && !DL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[35];
    	}
    	if( U  && !L && !R &&  !D  ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[36];
    	}
    	if( U  && !L && R &&  !D  && UR){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[37];
    	}
    	if( U  && L && R &&  !D  && UR && UL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[38];
    	}
    	if( U  && L && !R &&  !D && UL  ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[39];
    	}
    	if( U  && L && R &&  !D && !UL && UR  ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[40];
    	}
    	if( U  && L && !R &&  D && !DL && UL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[41];
    	}
    	if( U  && L && R &&  !D && UL && !UR  ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[42];
    	}
    	if( U  && L && !R &&  D && DL && !UL ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[43];
    	}
    	if( U  && L && R &&  D && DL && UL && !UR && DR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[44];
    	}
    	if( U  && L && R &&  D && DL && !UL && UR && DR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[45];
    	}
    	if( U  && L && R &&  D && !DL && !UL && !UR && !DR ){
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[46];
    	}










    }

    // Update is called once per frame

}
