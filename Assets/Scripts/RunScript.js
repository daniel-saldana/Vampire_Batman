#pragma strict

	var walkSpeed: float = 10;
	var runSpeed: float = 25;

	private var chMotor: CharacterMotor;	

function Start () 
{
	chMotor = GetComponent(CharacterMotor);
	var ch:CharacterController = GetComponent(CharacterController);
}

function Update () 
{
	var vScale = 1.0f;
	var speed = walkSpeed;

	if (chMotor.grounded && Input.GetKey("left shift"))
	{
		speed = runSpeed;
	}
	chMotor.movement.maxForwardSpeed = speed;
	chMotor.movement.maxBackwardsSpeed = speed;
	chMotor.movement.maxSidewaysSpeed = speed;
}