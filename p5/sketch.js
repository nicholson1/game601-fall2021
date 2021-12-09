function setup() {
	createCanvas(windowWidth, windowHeight);
	
	randomSeed(random(100));
	
	//randomize sky color
	background(random(115,130), random(140, 175), random(175,255));
	MakeClouds(random(3,15));
	
	
	
	//make random number of trees 1- 4
	for(let i = 0; i < random(0, 4); i++){
		
		MakeTree();
	}
	
	
	
	RandomizeGrass();
	MakeText();
	
		
	
	
	
	
}
function MakeText(){
	
	let Nouns = ['tree', 'cat', 'dog', 'rain drop', 'fart', 'video game', 'pope', 'bear', 'sound'];
	let Verbs = ['falls', 'cries', 'dreams', 'sleeps', 'farts', 'plays', 'eats', 'shits', 'sings'];
	//If a noun1 verb1 in a forest does it even make a noun2?

	
	
	
	
	fill(0,0,0);
	strokeWeight(5);
	stroke(155,0,0);
	textSize(50);
	text('If a ' + random(Nouns) +' '+ random(Verbs) + ' in a forest does it even make a ' + random(Nouns) +'?', 50,100);
}


function MakeTree(){
	//make the trunk
	let TreeTop = MakeTreeBase();
	//make the leaves
	MakeTreeLeaves(TreeTop[0], TreeTop[1]);
	MakeTreeLeaves(TreeTop[0], TreeTop[1] -200 );
	
	MakeTreeLeaves(TreeTop[0] + 100, TreeTop[1] - 100);
	MakeTreeLeaves(TreeTop[0] - 100, TreeTop[1] -100);
	
	
	MakeTreeLeaves(TreeTop[0] - 200, TreeTop[1]);
	MakeTreeLeaves(TreeTop[0] + 200, TreeTop[1]);
	
	
					 
	
}
function MakeTreeLeaves(Xpos, Ypos){
	noStroke();
	fill(1,random(50, 120), 1);
	
	//place at top of tree so you dont see the quad
	ellipse(Xpos , Ypos, random(100,150),random(100,150));
	
	for (let i = 0; i < 10; i++){
		fill(1,random(50, 120), 1);
		
		ellipse(Xpos + random(-100, 100), Ypos + random(-100,50), random(100,150),random(100,150));
	}

	
}
	

	


function MakeTreeBase(){
	
	
	//get starting X pos
	let Xstart = random(10, width *0.75);
	let BaseWidth = random(200, 300);
	let TrunkWidth = random (150, 200);
	let BaseHeight = random(30, 75);
	
	let x1 = (Xstart + random(50,(TrunkWidth/2)));
	let y1 = ((height -100) - BaseHeight);
	let x2 = Xstart + TrunkWidth
	let y2 = (height -100) - BaseHeight;
	
	//for trunk
	let TrunkHeight = random(200, 500);
	let TrunkShift = random(25, 75) * random([-1,1]);
	
	for(let i = 0; i <10; i++){
	let color = [random(90,110), random(50, 70), random (5,20)];
	fill(color[0], color[1], color[2]);
	stroke(color[0], color[1], color[2]);
	
	//base
	quad(Xstart + (10*i), (height - 100)- (3*i), x1 + (5*i) , y1 + (5*i) , x2 - (5*i), y2 + (5*i) , Xstart + BaseWidth - (10*i), (height -100) - (3*i));
	//trunk
	quad(x1 + (5*i), y1 + (5*i), x1 + TrunkShift + (5*i), (y1 - TrunkHeight) +(5*i), x2 - (5*i) + TrunkShift, y2 +(5*i) - TrunkHeight, x2 -(5*i) , y2 + (5*i));
	}
	
	return [((x1 + TrunkShift)+ (x2 + TrunkShift))/2, y1 - TrunkHeight];
	
}


function RandomizeGrass(){
	//Base Grass at bottom of the screen
	noStroke();
	fill(7, 71, 16);
	rect(0, height - 100, width, 100);
	
	//randomize the grass
	noFill();
	for (let y = 0; y < 12; y ++){
		for (let x = 0; x < width/10; x++) {
			stroke(1,random(90, 175), 1);
			strokeWeight(random(8, 11));
			arc( x *15,height-(100 - (y*10)), random(60, 90), random( 50, 100),PI, PI + QUARTER_PI);
		}
	}
}






function MakeCloud(Xpos, Ypos){
	noStroke();
	for(let x = 0; x < random(7,25); x ++){
		fill(random(210, 230), random(245, 230), 255)
		ellipse(Xpos + x*15, Ypos + random(-20,20), random(60,70),random(60,70));
	}
}
function MakeClouds(number){
	for (let i = 0; i < number ; i++){
		MakeCloud(random(0, windowWidth), random(0, windowHeight/2));
	}
}




