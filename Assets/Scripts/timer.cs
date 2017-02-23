using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
	
	public Color col, defCol; //кол на какой меняется, второй по умолчанию
	public GameObject mCube; //сам куб
	private Color lastCol;
	
	void Start () {
		lastCol = mCube.GetComponent <Renderer> ().material.color;
	}
	
	void Update () {
		if (!mCube.GetComponent <GameCntrl> ().lose) {
			if (transform.position.x < -121f)
				Destroy (gameObject);
			if (transform.position.x < -1.5f)
				GetComponent <Renderer> ().material.color = Color.Lerp (GetComponent <Renderer> ().material.color, col, Time.deltaTime);
			transform.position -= new Vector3 (0.1f, 0, 0);
		}

		if (mCube.GetComponent <Renderer> ().material.color != lastCol) { //если сейчас цвет куба и цвет который был до этого отличаютс
			lastCol = mCube.GetComponent <Renderer> ().material.color; // значит полосу можем востановить  и поставил цвет
			transform.position = new Vector3 (0, transform.position.y, 0);
			GetComponent <Renderer> ().material.color = defCol;
		}
	}
	
	void OnDestroy () {
		if (mCube)
			mCube.GetComponent <GameCntrl> ().lose = true;
	}	
}