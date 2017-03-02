using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCntrl : MonoBehaviour {

	public GameObject pLost;
	public GameObject colBlock;
	public Vector3 [] positions;
	private GameObject block;
	private GameObject [] blocks = new GameObject[4];

	private int rand, count;
	private float rCol, gCol, bCol;
	public Text score;
	private static Color aColor;

	[HideInInspector]
	public bool next, lose;

	void Start () {
		count = 0; //score
		next = false; //переход на следующий уровень
		lose = false; //проиграли
		rand = Random.Range (0, positions.Length); //устанавливем рандомное значение от 0 до колличествв кубиков (0-4) - выбираем один кубик который будет правильного цвета
		for (int i = 0; i < positions.Length; i++) { //перебираем от 0 до вктора три
			blocks [i] = Instantiate (colBlock, positions[i], Quaternion.identity) as GameObject; //массив обьектов, создаем каждый кубик:колблок - префаб, ставим в позицию вектора,
			if (rand == i) //если рандомное число равно итерации - кубику 
				block = blocks [i]; 
				// записываем в гейм обджект 
		}
		block.GetComponent <RandCol> ().right = true; //и этому кубику даем цвет главного
	}

	void Update () { //клацнули
		if (lose) //если проиграл 
			playerLose ();
		if (next && !lose) //если дальше все ок , следующий уровень
			nextColors ();
	}

	void nextColors () { //
if (PlayerPrefs.GetString("Music") != "no")
		GetComponent<AudioSource> (). Play();
		count++; //плюс к скору
		score.text = count.ToString (); //записываем в текст скору
		aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1); //цвет меняем - тут создаем основной цвет
		GetComponent <Renderer> ().material.color = aColor; //прикрепили цвет
		next = false; //чтоб функция не вызывалась

		if (count < 3) {
			rCol = 0.2f;
			gCol = 0.2f;
			bCol = 0.2f;
		} else if (count >= 3 && count < 5) {
			rCol = 0.1f;
			gCol = 0.1f;
			bCol = 0f;
		} else if (count >= 5) {
			rCol = 0f;
			gCol = 0f;
			bCol = 0.05f;
		}

		// New colors for blocks
		rand = Random.Range (0, positions.Length); //выбрали тот который одинаковый п оцвету
		for (int i = 0; i < positions.Length; i++) {
			if (i == rand)
				blocks [i].GetComponent <Renderer> ().material.color = aColor; //даем ему главный цвет
			else {
				float r = aColor.r + Random.Range (0.1f, rCol) > 1f ? 1f : aColor.r + Random.Range (0.1f, rCol); //цвета
				float g = aColor.g + Random.Range (0.1f, gCol) > 1f ? 1f : aColor.g + Random.Range (0.1f, gCol); //цвета
				float b = aColor.b + Random.Range (0.1f, bCol) > 1f ? 1f : aColor.b + Random.Range (0.1f, bCol); //цвета
				blocks [i].GetComponent <Renderer> ().material.color = new Vector4 (r, g, b, aColor.a);
			}
		}
	}

	void playerLose () {
		if (PlayerPrefs.GetInt("Score") < count)  //если пользователь сейчас собрал больше чем было
		PlayerPrefs.SetInt ("Score", count);	
		pLost.SetActive (true);
		if (PlayerPrefs.GetString("Music") == "no")
		pLost.GetComponent<AudioSource> (). mute = true;
	}
}