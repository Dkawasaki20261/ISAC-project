using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		public float gravity = 20.0f;
		public float jumpPower = 500.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){

			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			var moveDirection = new Vector3(moveHorizontal,0,moveVertical);
			float moveHeight = 0;
			if (Input.GetAxis("Vertical") != 0) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if (Input.GetKeyDown(KeyCode.Space)){
				Debug.Log("jumpPressed");
				moveHeight = Mathf.Sqrt(jumpPower* -2.0f *gravity);
			}

			if(controller.isGrounded){
				Vector3 movement = new Vector3(moveHorizontal, moveHeight, moveVertical);
				moveDirection = movement;
			}
		//transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * speed * Time.deltaTime);
			//moveDirection.y -= gravity * Time.deltaTime;
		}
}
