using UnityEngine;
using System.Collections;

public class CubeFloat : MonoBehaviour {

	public float speed, tilt; //скорость и наклон (скорость вращения)
	private Vector3 target = new Vector3 (0, 27f, 25f); //создали target - куда будет двигатся кубик, создали обеькт
	
	// каждый кадр
	void Update () {
	transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed); //двигаем кубик, откуда куда время 1.перемещаем
	//его позиция равна теперь новой кординате
	//2.меняем значения transform.position
		if (transform.position == target && target.y != 0.1f) //дошли туда, куда двигали - подвинули вверх
		{
			target.y = 0.1f; //двигаем вниз
		}
		else if (transform.position == target && target.y == 0.1f) // двигаем вверх
		{
			target.y = 27f;
		}
		//поворачиваем
		transform.Rotate (Vector3.up * tilt); //вращаем по y * скорость
		//Time.deltaTime рзазбивает по кадрам
	}
}
