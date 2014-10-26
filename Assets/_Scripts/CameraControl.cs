using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {		
		//transform.eulerAngles = new Vector3 (0, 0, 0);
		transform.position = player.transform.position+offset;

	}
}
