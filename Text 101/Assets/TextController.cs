using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour 
{
	public Text text;
	private enum States {cell,mirror,sheets_0,lock_0,sheets_1,lock_1,cell_mirror,freedom};
	private States myState;
	
	void Start () 
	{	myState = States.cell;
	
	}

	void Update () 
	{	print(myState);
	
		if(myState == States.cell)					{state_cell();}
		else if(myState == States.sheets_0)			{state_sheets_0 ();}
		else if(myState == States.mirror)			{state_mirror ();}
		else if(myState == States.lock_0)			{state_lock_0 ();}
		else if(myState == States.sheets_1)			{state_sheets_1 ();}
		else if(myState == States.cell_mirror)		{state_cell_mirror ();}
		else if(myState == States.lock_1)			{state_lock_1 ();}
		else if(myState == States.freedom)			{state_freedom ();}
	}
	
	void state_cell ()
	{	text.text = "You are in a cell and its dark.. You cannot stop looking at the"+
					" metallic frame of a mirror shining in moon light that peeps"+
					" through a small vent on one of the walls. The cell has a peculiar stetch"+
					" of the sheets on the bed..the smell of blood. Your eyes are red from all the sleepless"+
					" nights hearing the horrific screams from the tormented innmates. You hear your countdown"+
					" of death by the rattling lock in your cell, draining you hope of life..shredding your sane mind.."+
					" Death seems to be more satisfying than to be alive\n\n"+
					"[S] Sheets  [M] Mirror  [L] Lock  [R] Return";
					
		if(Input.GetKeyDown(KeyCode.S))					{myState = States.sheets_0;}
		else if(Input.GetKeyDown(KeyCode.M))			{myState = States.mirror;}
		else if(Input.GetKeyDown(KeyCode.L))			{myState = States.lock_0;}
		else if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell;}
	}
	
	void state_sheets_0 ()
	{	text.text = " There is a naustiating stench of a corpse.. The smell of death all over the sheets\n\n"+
				"[R] Return";
				
		if(Input.GetKeyDown(KeyCode.R))					{myState = States.cell;}
	}
	
	void state_mirror ()
	{	text.text = "You look at your own reflection in the mirror..the moon light fades away..your body becomes cold"+
					" and the stench gets stronger..the mirror slowly starts to crack..your shoulders feel heavy,"+
					" your body is paralized as you see a pair of pale arms around your neck choking you from behind.."+
					"There is skin peeling off , slowly gaining courage to look into the mirror.. you see a dark figure of a woman behind you with firey red eyes"+
					" and mirror shatters..\n\n"+
					"[T] Take  [R] Return";
				
		if(Input.GetKeyDown(KeyCode.T))					{myState = States.cell_mirror;}		
		else if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell;}
	}
	
	void state_lock_0 ()
	{	text.text = "There is an old rusty lock that hits against the steel.. counting every breath you take.. eagarly waiting for your death\n\n"+
				"[R] Return";
				
		if(Input.GetKeyDown(KeyCode.R))					{myState = States.cell;}
	}
	
	void state_cell_mirror ()
	{	text.text = "The moon light creeps back in.. you see pieces of shattred mirror on the floor..you are in agonising pain"+
					" as your hands are lacerated from holding the mirror shard.. you just want to escape from the cell\n\n"+
					"[S] Sheets  [L] Lock";
					
		if(Input.GetKeyDown(KeyCode.S))					{myState = States.sheets_1;}
		else if(Input.GetKeyDown(KeyCode.L))			{myState = States.lock_1;}
	}
	
	void state_sheets_1 ()
	{	text.text = " There is nothing you can do now.. you rip the sheets with frustration and pain.."+
					" the smell of blood fills the cell from your bleeding hands dripping onto the sheets and all over the floor \n\n"+
					"[R] Return";
		
		if(Input.GetKeyDown(KeyCode.R))					{myState = States.cell_mirror;}
	}
	
	void state_lock_1 ()
	{	text.text = "You slowly put your hand through the bars in attempts to reach out to the lock.."+
					"you try to look at the lock through the mirror shard in your hand.. its a simple lock.."+
					"just impossible to reach..you look at your desperate eyes in the shard, leaning back on the bars..you smile..\n\n"+
					"[F] Freedom  [R] Return";
					
		if(Input.GetKeyDown(KeyCode.F))					{myState = States.freedom;}
		else if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell_mirror;}
	}
	
	void state_freedom ()
	{	text.text = "You hear a rumbling sound..you are surprised as the cell door slides open..you cannot believe it."+
					"The heavy burden on your shoulder is no more..You are finally free from the chains of pain and sufferering. "+
					"Confused by this, you turn around to the cell to look at it for one last time.. you see a body amidst a pool of blood"+
					"..its a woman with a slit throat..she has a mirror shard in her hand covered in blood.. you pick it up and realize that its the same shard"+
					"..you look closely at your own reflection and you see yourself pale.. and your eyes are as red as the fires of hell..\nDeath is only the begining..\n\n"+
					"[P] Play again";
					
		if(Input.GetKeyDown(KeyCode.P))					{myState = States.cell;}
	
	}
}
