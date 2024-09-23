using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {
	public BoardManager boardManager;

	void Start(){

	}

	void OnMouseUpAsButton(){

			boardManager.GetComponent<BoardManager>().performAction(5);
	}

}
