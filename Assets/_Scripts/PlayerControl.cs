using UnityEngine;
using System.Collections;
using System;
using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;
//also, when creating an object used multiple times, create a prefab folder and put it in the folder. our pick up is a pre fab for example
//to make it a pre fab, drag it into a prefab folder. to set a tag, change its tag from untagged to add tag in the client
//then, set element 0 to the object name or whatever you want to tag it as
//IMPORTANT, to set the tag, CLICK ON THE PREFAb ICON INSIDE THE PREFAB FOLDER


//when collidiing with other objects, make sure that the moving/chaing object being changed trigger is on. then, add a rigid body and 
//set kinimatic to true so that it oesnt fall through te ground.

//GUI TEXT
//after creating the guitext var in its holding class, drag the guitext from the heirarchy into the guitext field

public class PlayerControl : MonoBehaviour {

	public GUIText testText;

	public GameObject myo = null;


	private Pose _lastPose = Pose.Unknown;

	public float speed;

	void Update(){
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();


		float horizontal = 0;
		float verticle = 0;
		float up = 0;
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;


			// forward
			if (thalmicMyo.pose == Pose.FingersSpread) {
				verticle=1;

				
			//left
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				horizontal=-1;


			} 
			//right
			else if (thalmicMyo.pose == Pose.WaveOut) {
				horizontal=1;

			} 
			//backwards
			else if (thalmicMyo.pose == Pose.Fist) {
				verticle=-1;

			}
			else if(thalmicMyo.pose == Pose.ThumbToPinky){
				up=1;

				rigidbody.AddForce (new Vector3 (horizontal, up, verticle)*speed*(Time.deltaTime+1));
				//transform.Translate (Vector3.up * 260 * Time.deltaTime, Space.World);
				return;
			}


			rigidbody.AddForce (new Vector3 (horizontal, up, verticle)*speed*(Time.deltaTime+1));

		}
		testText.text = thalmicMyo.pose.ToString ();
	}

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rigidbody.AddForce (movement*speed*Time.deltaTime);
		
		
	}
}