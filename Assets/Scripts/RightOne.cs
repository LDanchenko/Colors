using UnityEngine;
using System.Collections;

public class RightOne : MonoBehaviour {

	private GameObject mainCub; //обьявили переменную в которой будем находить главнй куд

	void Start () {
		mainCub = GameObject.Find ("mainCub"); //находим главный куб сстарте по названию
	}

	void OnMouseDown () {
		//нажали один из кубиков и проверяем
		if (GetComponent <Renderer> ().material.color == mainCub.GetComponent <Renderer> ().material.color) //если цвет блока который нажали равен цвету главного куда
			mainCub.GetComponent <GameCntrl> ().next = true; //GameCntrl скрипт, туда записываем некст - тру  - переходим на следующий этап
		else
			mainCub.GetComponent <GameCntrl> ().lose = true; // если неправильно т олуз - проиграл
	}
}
