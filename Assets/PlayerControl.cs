using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float webDist = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 lookDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponentInParent<CharacterController>();
		if (Input.GetButton ("LWeb")) {
			Debug.Log("Button deteteced.");
			Vector3 origin = transform.position + transform.InverseTransformDirection(new Vector3(-3, 3, 0));
			RaycastHit[] rcInfo;
			rcInfo = Physics.SphereCastAll (origin, 2.5F, -transform.right, webDist);
			Debug.Log(rcInfo.Length);
			if(rcInfo.Length > 0){
				Debug.Log("Hit!");
			}
		}
		if (controller.isGrounded) {

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
