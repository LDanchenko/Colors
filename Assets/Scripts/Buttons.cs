using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour { // клас для всех кнопок , добавили к ним collider

	public Sprite layer_blue, layer_green; //спрайты - кнопки картинками

	void OnMouseDown ()  //когда палец на кнопке
	{
		GetComponent <SpriteRenderer> ().sprite = layer_green;
		//при нажатии на кнопку меняем ее цвет  - меняем спрайт (картинку)
	}

	void OnMouseUp() //когда палец убирает с экрана
	{
		GetComponent <SpriteRenderer> ().sprite = layer_blue;
		//пользователь убрал палец заменили зеленым
	}

	void OnMouseUpAsButton(){ //нажал на кнопку с этой кнопки и снял палец
		switch(gameObject.name){ //проверяем имя обьекта
			case "Play": //если Play открываем игру
			Application.LoadLevel("play");
			break;
			case "Rating": //в магазин
			Application.OpenURL("https://google.com.ua");
			break;
			case "Replay":
			Application.LoadLevel("play");
			break;
			case "Home":
			Application.LoadLevel("main");
			break;
		}
	}

}

