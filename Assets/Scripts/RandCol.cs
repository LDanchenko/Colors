using UnityEngine;
using System.Collections;

public class RandCol : MonoBehaviour { //меняет цвет про 

	public bool main = false, right = false;
	//main - главнй куб или нет?*
	//right - является ли куб цветов такой же как и главный?

	private static Color aColor; //куда записывается увет - статик один раз

	void Awake () { //срабатывает до функции старт
	//если куб мейн то в цвет пишем рандомный цвет
		if (main)
			aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1);
			//Vector 4 так как четыре параметра у колор
	}

	void Start () {
		//если куб основной или цвет такой как у основного то цвет ставим такой же 
		if (main || right)
			GetComponent <Renderer> ().material.color = aColor;
		else
		//если не такой то ставим для него похожий цвет - близкий
			GetComponent <Renderer> ().material.color = new Vector4 (aColor.r + Random.Range (0.1f, 0.3f), aColor.g + Random.Range (0.1f, 0.3f), aColor.b + Random.Range (0.1f, 0.3f), aColor.a);
	}
}