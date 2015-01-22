using UnityEngine;
using System.Collections;

public class Camer : MonoBehaviour {
	[SerializeField]
	float Smoothness = 4; // скорость с которой будет поворачиваться камера, т.е. голова
	[SerializeField]
	Vector2 Sensitivity = new Vector2 (4,4);// скорость изменения новых координат
	private Vector2 NewCoord;// в которое повернется камера
	public Vector2 CurrentCoord;// текущее положение
	[SerializeField]
	Vector2 Limit = new Vector2 (-70, 80);// ограничение на поворот
	private Vector2 vel;// хер знает что. но нужна для функции

	void Update () {
		NewCoord.x = Mathf.Clamp (NewCoord.x, Limit.x, Limit.y); // ограничение на поворот, что бы не делать сальто головой
		NewCoord.x-= Input.GetAxis ("Mouse Y")* Sensitivity.x;
		NewCoord.y+= Input.GetAxis ("Mouse X")* Sensitivity.y;
		CurrentCoord.x = Mathf.SmoothDamp (CurrentCoord.x, NewCoord.x, ref vel.x, Smoothness/100); // для реалестичного и плавного поворота
		CurrentCoord.y = Mathf.SmoothDamp (CurrentCoord.y, NewCoord.y, ref vel.y, Smoothness/100);
		transform.rotation = Quaternion.Euler (CurrentCoord.x, CurrentCoord.y, 0);
	}
}
