using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour {

	public GameObject followTarget;

	private Vector3 targetTurn;
	public float angle = 90;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 t = followTarget.transform.position - this.transform.position;

		float a = Mathf.Atan2 (t.y, t.x);
		this.transform.localEulerAngles = new Vector3 (0, 0, (a * Mathf.Rad2Deg) + angle);
	}


}
