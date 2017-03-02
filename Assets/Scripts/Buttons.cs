using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour { // клас для всех кнопок , добавили к ним collider

	public GameObject m_off, m_on;
	public Sprite layer_blue, layer_green; //спрайты - кнопки картинками

	void Start (){
		if (gameObject.name == "Music"){
		if (PlayerPrefs.GetString("Music") == "no") {
			m_on.SetActive(false);
			m_off.SetActive(true);
		}
		else {
			m_on.SetActive(true);
			m_off.SetActive(false);
		}
		}
	}

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
		if (PlayerPrefs.GetString("Music") != "no")
		GameObject.Find ("Click Audio").GetComponent <AudioSource> ().Play(); //клик при нажатии клавиши
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
			case "How To":
			Application.LoadLevel("howTo");
			break;
			case "Close":
			Application.LoadLevel("main");
			break;
			case "Music":
			if (PlayerPrefs.GetString("Music") != "no") {
			PlayerPrefs.SetString ("Music", "no");
			m_on.SetActive(false);
			m_off.SetActive(true);
			}
			else {
				PlayerPrefs.SetString ("Music", "yes");
				m_on.SetActive(true);
				m_off.SetActive(false);
			}
			break;
		}
	}

}

