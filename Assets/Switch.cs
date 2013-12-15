using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public float percentFlipped = 0.0f;
	public float flipSpeed = 0.1f;
	protected Animator animator;
	protected bool isGrabbed = false;
	public SkinnedMeshRenderer targetMesh; 


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetFloat("flipped_percent", 0.5f);


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)) {
			isGrabbed = false;
			Screen.showCursor = true;
		}
		changeSwitchColor ();
		updateFlippedPercent();
		animator.SetFloat("flipped_percent", percentFlipped);

	}

	void changeSwitchColor() {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast (ray, out hit, 1000f)) {
			if(!isGrabbed) {
				targetMesh.renderer.material.color = Color.red;
			}
			
			if(Input.GetMouseButtonDown(0)) {
				isGrabbed = true;
				Screen.showCursor = false;
			}
			
		} else {
			if(!isGrabbed) {
				targetMesh.renderer.material.color = Color.black;
			}
		}
	}

	void updateFlippedPercent() {
		if(isGrabbed) {
			float newPercentFlipped = percentFlipped + (flipSpeed * Input.GetAxis("Mouse Y") * -1);
			
			percentFlipped = Mathf.Clamp(newPercentFlipped, 0.0f, 1.0f);
		}
	}

	void OnMouseOver() {
		Debug.Log ("Mouse Over!");
	}

	void OnMouseExit() {
		Debug.Log ("EXIT!");
	}



}
