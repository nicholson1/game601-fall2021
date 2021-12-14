let xpos;
let ypos;
let step = 5;

	

let lives = 5;
let isPlaying = true;

let px = 100;
let py = 100;

let xmove = 10;
let ymove = 10;
let rad = 50;
let points = 0;
let ray = 50;
let rayMove = 2;
let colorMove = 2;
let colorVal = 30;
let highScore = 0;

let wingWidth = 200;
let flapDirection = 3;
let moveDirection = 5;
let footOffset = 0;
let footDirection = 1;
let colorP = 40;
let colorDir = 5;

let colorT = 10;
let triNumber = 100;
let shift = .01;
let tx = 100;
let ty = 100;
let tymove = -8;
let txmove = -8;

function setup() {
	xpos = width/2;
	ypos = height/2;
	createCanvas(windowWidth, windowHeight);
	background(100);
	xpos = windowWidth/2;
  ypos = windowHeight/2;
	
}

function draw() {
	
	if(lives < 0 && isPlaying){
	//lose
		isPlaying = false;
		textAlign(CENTER);
		background(0);
		fill(255);
		textSize(100);
		if(points < highScore){
			text("You Lose. " + points + " points...", width/2, height/4);
			text("Highscore: " + highScore, width/2, height/4 *3);
		}else{
			text("New highscore! \n You got " + points + " points...", width/2, height/4);
			highScore = points;
		}
		rectMode(CENTER)
		rect(width/2,height/2 + 25, 300, 100);
		fill(0);
		textSize(70);
		text("Restart", width/2,height/2 + 50)
		
		textAlign(LEFT);
		
		
		
		
		
	}
	if(isPlaying){
	
		if (keyIsPressed === true){
			if (keyCode === LEFT_ARROW) {
				xpos -= step;
			} else if (keyCode === RIGHT_ARROW) {
				xpos += step;
			}
			if (keyCode === UP_ARROW) {
				ypos -= step;
			}
			else if (keyCode === DOWN_ARROW) {
				ypos += step;
			}
		}
		
		

		if (colorVal > 40){
			colorMove *= -1;
			colorVal = 40;
			
		}else if (colorVal < 10){
			colorMove *= -1;
			colorVal = 10;
		}
			
		px += xmove;
		py += ymove;

		if(px < 0 || px > width * 4){
			xmove *= -1;
			colorP += colorMove;
			ymove += random(-3,3);
		}

		if(py < 0 ||py > height * 4){
			colorP += colorMove;
			ymove *= -1;
			xmove += random(-3,3);
		}
		
		ray += rayMove;
		if(ray > 90 || ray < 50){
			rayMove *= -1;
		}

		
		background(100);
		drawIce(15,20);
		
		
		/// PENGUIN SHIT
		push();
		scale(0.25);
		
		
		footOffset = footOffset + footDirection;
		if(footOffset > 10 || footOffset < -10){
			footDirection = footDirection * -1;
		}
		colorMode(HSB);
		noFill();
		if(xmove < 0){
			colorMode(HSB);
			stroke(colorP, 100, 80);
			colorMode(RGB);
		}
		else{
			colorMode(RGB);
			stroke(0);
		}
		
		strokeWeight(30);
		angleMode(DEGREES);
		arc(px, py + 100, wingWidth, 400, 180 , 0);
	
		colorMode(RGB);
		drawPenguin();
		colorP += colorDir;
		if(colorP > 360 || colorP < 0){
			colorDir *= -1;
		}
		wingWidth = wingWidth + flapDirection;

		if(wingWidth > 300 || wingWidth < 200){
			flapDirection = flapDirection * -1;
		}
		pop();
		//////////////////////
		
		
		
		colorMode(HSB);
		fill(colorVal, 100, 80);
		stroke(0);
		textSize(50);
		text("Points: " + points, 100,100);
		text("Lives: " + lives, 100, 200);
		noStroke();
		
		strokeWeight(10)
		stroke(colorVal + 3 , 100, 80);
		line(xpos - ray + 25 , ypos - ray -25, xpos + ray - 25, ypos + ray +25);
		line(xpos - ray - 25 , ypos - ray +25, xpos + ray + 25, ypos + ray -25);
		line(xpos - ray, ypos + 25, xpos + ray , ypos -25);
		line(xpos +25, ypos - ray , xpos -25, ypos + ray );
		
		
		stroke(colorVal - 3 , 100, 80);
		line(xpos - ray , ypos - ray, xpos + ray, ypos + ray);
		line(xpos - ray, ypos, xpos + ray , ypos);
		line(xpos, ypos - ray , xpos, ypos + ray );
		line(xpos + ray, ypos - ray , xpos - ray , ypos + ray);
		
		
		
		fill(colorVal, 100, 80);
		ellipse(xpos, ypos, rad * 2 , rad * 2);
		colorMode(RGB);
		fill(0);
		noStroke();
		angleMode(DEGREES);
		arc(xpos - 25, ypos -25, 35, 40, 0,180);
		arc(xpos + 25, ypos -25, 35, 40, 0,180);
		stroke(0);
		line(xpos - 15, ypos +25, xpos +15, ypos +25);
		noStroke();
		
		// triangle shit
		tx += txmove;
		ty += tymove;
		
		if(tx < 0 || tx > width){
			txmove *= -1;
			//tymove += random(-10,10);
		}

		if(ty < 0 ||ty > height){
			tymove *= -1;
			//txmove += random(-10,10);
		}
		
		tri(tx, ty);
		//
		
		// points stuff
		
		if(dist(px/4, py/4, xpos, ypos) < 50){
			points += 1;
			px = random(1, width*3);
			py = random(1, height * 3);
			colorVal += colorMove;
			let flip = random(0, 2);
			if(flip >= 1){
				xmove *= -1;
			}else{
				ymove *= -1;
			}
		}
		if(dist(tx, ty, xpos, ypos) < 100){
			lives -= 1;
			tx = random(1, width);
			yy = random(1, height);
			colorVal += colorMove * 4;
			let flip = random(0, 2);
			if(flip >= 1){
				txmove *= -1;
			}else{
				tymove *= -1;
			}
			
			
		}
			
		
		

		
	}
}
	
function mouseClicked() {
	if(!isPlaying){
			if(mouseX < width/2 + 150 && mouseX > width/2 - 150){
				if(mouseY < height/2 + 50 && mouseY > height/2 - 50){
					isPlaying = true;
					reset();
				}
			}
		}
}

function reset(){
	xpos = width/2;
	ypos = height/2;
	xmove = random(-3, 3);
	ymove = random(-3, 3);
	points = 0;
	lives = 5;
}

function drawIce(rows, col){ 
	colorMode(RGB);
	rectMode(CENTER);
	let spaceX = width / col;
	let spaceY = height / rows;
	let size = 40;
	let melt = 0;
	let distance = 0;
	fill(180,207,250);
	for(let r = 0; r < rows; r++){
		for (let c = 0; c <col ; c++){
			distance = dist(xpos,ypos, spaceX * c +spaceX/2, spaceY * r + spaceY/2);
			
			if(distance  < 300){
				melt = (300 - distance)/10;
				size = 40 * distance/300;
			}else {
				melt = 0;
				size = 40;
			}
				
			
			
			square(spaceX * c +spaceX/2, spaceY * r + spaceY/2, size, melt);
		}
	}
}
	
function drawPenguin(){
	noStroke();
	
	//Feet
	fill(255, 118, 0);
	triangle(px + 15, py + 160 + footOffset, px + 40, py + 120 + footOffset, px + 60, py + 160 + footOffset);
	triangle(px - 15, py + 160 - footOffset, px - 40, py + 120 - footOffset, px - 60, py + 160 - footOffset);
	
	
	//body1
	if(xmove < 0){
		colorMode(HSB);
		fill(colorP, 100, 80);
		colorMode(RGB);
	}
	else{
		colorMode(RGB);
		fill(0);
	}
	ellipse(px, py, 150, 300);
	
	
	//body2
	fill(255,255,255);
	ellipse(px, py, 125, 300);
	
	
	//head
	if(xmove < 0){
		colorMode(HSB);
		fill(colorP, 100, 80);
		colorMode(RGB);
	}
	else{
		colorMode(RGB);
		fill(0);
	}
	ellipse(px, py - 150, 100, 100);
	
	
	//beak
	fill(255, 118, 0);
	if(xmove > 0){
		triangle(px + 25, py - 160, px + 25, py - 140, px + 150, py - 150);
	}
	else{
		triangle(px - 25, py - 160, px - 25, py - 140, px - 150, py - 150);
		
	}
	
	//eye1
	fill(61, 178, 255);
	stroke(255,255,255);
	strokeWeight(7);
	ellipse(px, py - 150, 25, 25);
	fill(0,0,0);
	noStroke();
	ellipse(px + 2.5, py - 400 + 252.5, 10, 10);
	
	
	//hat
	
	noStroke();
	fill(250, 0, 0);
	if(xmove > 0){
		triangle(px - 50, py - 180, px + 25, py - 200, px -100 , py - 300);
		fill(255);
		ellipse(px -100 , py - 300, 25, 25);
	}
	else{
		triangle(px - 25, py - 200, px + 50, py -180, px +100 , py -300);
		fill(255);
		ellipse(px +100 , py -300, 25, 25);
	}
	
	
	
	stroke(255,255,255);
	strokeWeight(12);
	if(xmove > 0){
		line(px - 50, py -180, px + 25, py - 200);
	}
	else{
		line(px - 25, py -200, px + 50, py -180);
		
	}
}

function tri(tx, ty){
	trianglesBOI(100, tx - 100, ty - 100, tx + 100, ty - 100, tx, ty + 100 )
	//triNumber = 100;
}

	

function trianglesBOI(num, x1, y1, x2, y2, x3, y3 ){
	noStroke();
	colorMode(HSB);
	for(let i = 0; i < num; i++){
		colorT += 10;
		fill(colorT, 200, 200)
		
		triNumber -= 1;
		if(y2 + shift * i  > y1 - shift * i){
			
			triNumber = 0;
			break;
		}
		if(x2 - shift * i < x3 + shift * i){
			triNumber = 0;
			break;
		}
		
		triangle(x1, y1 - shift * i, x2 - shift * i, y2 + shift * i/2, x3 + shift * i, y3 + shift * i/2)
		if(colorT >= 360){
			colorT = 0;
		}
	}
}