using UnityEngine;
using System.Collections;

public class charController : MonoBehaviour {
	
	//Character Related
	public float speed;
	
	private bool movedLeft;
	private bool movedRight;
	private bool movedUp;
	private bool movedDown;
	
	private	RaycastHit hit;
	bool contact;
	
	// Use this for initialization
	void Start () {	
		speed = 2f;
		movedLeft = false;
		movedRight = false;
		movedUp = false;
		movedDown = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movedLeft = false;
		movedRight = false;
		movedUp = false;
		movedDown = false;
		

		//Vector3 left1 = Vector3(-1.0f,0.0f,0.0f);
		//Handle Input
		if(Input.GetKey(KeyCode.A))//left
		{
			contact = rigidbody.SweepTest(Vector3.left, out hit, speed*Time.deltaTime);
			if(contact)
			{
				//print ("hiya");
				transform.Translate((-hit.distance)+0.01f,0f,0f,Space.World);
			}
			else
			{
				transform.Translate(-speed*Time.deltaTime,0f,0f,Space.World);
			}
		}
		if(Input.GetKey(KeyCode.D))//right
		{
			contact = rigidbody.SweepTest(Vector3.right, out hit, speed*Time.deltaTime);
			if(contact)
			{
				//print ("hiya");
				transform.Translate((hit.distance)-0.01f,0f,0f,Space.World);
			}
			else
			{
				transform.Translate(speed*Time.deltaTime,0f,0f,Space.World);
			}	
		}
		if(Input.GetKey(KeyCode.W))//up
		{
			contact = rigidbody.SweepTest(Vector3.forward, out hit, speed*Time.deltaTime);
			if(contact)
			{
				//print ("hiya");
				transform.Translate(0f,0f,(hit.distance)-0.01f,Space.World);
			}
			else
			{
				transform.Translate(0f,0f,speed*Time.deltaTime,Space.World);
			}	
		}
		if(Input.GetKey(KeyCode.S))//down
		{
			contact = rigidbody.SweepTest(Vector3.back, out hit, speed*Time.deltaTime);
			if(contact)
			{
				//print ("hiya");
				transform.Translate(0f,0f,(-hit.distance)+0.01f,Space.World);
			}
			else
			{
				transform.Translate(0f,0f,-speed*Time.deltaTime,Space.World);
			}	
		}
		//	transform.Translate(0f,0f,-speed*Time.deltaTime);
		
	}
	
	/*void OnTriggerStay(Collider col) 
	{
		if(col.gameObject.tag== "Wall")
		{ 
			Vector3 pos = transform.position;
			pos.z = col.transform.collider.bounds.min.z - transform.collider.bounds.extents.z;
			transform.position = pos;				
		}
	}*/
}
