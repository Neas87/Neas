using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Vector3 Speed;
	private Camer cam;// ссылка на скрипт камеры.
	private bool Jamp;
   public GameObject Cube1;

	void Start () {
		cam = GameObject.FindWithTag ("MainCamera").GetComponent <Camer> ();
	}
	
	void OnCollisionEnter (Collision col) // проверка находится ли перс на земле (куб1)
	{
		if (col.gameObject.name == "Cube1")
						Jamp = false;
		
	}
	void Update () {
			transform.rotation = Quaternion.Euler (0, cam.CurrentCoord.y, 0);// привязываем камерук персу
			transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Speed.x * Time.deltaTime);
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * Speed.y * Time.deltaTime);
	
	if (Input.GetButtonDown ("Jump")) {
			if (Jamp == false) {
				Jamp = true;
				rigidbody.AddForce (0, Speed.z * 100, 0)	;

			}
	}
	}
}

		

	
	 
		 
	 
