using UnityEngine;
using System;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {


	public int columns = 7;
	public int rows = 7;
	public GameObject gameTiles;
	public GameObject buttonTiles;

	private Transform boardHolder;


	void boardSetup(){
		boardHolder = new GameObject ("Board").transform;


		int checkColumns = columns * 5 - 15;
		int checkRows = rows * 5 - 19;
		int x,y;
		for (x = -15; x<checkColumns; x=x+5) {
			for (y = -19; y<checkRows; y=y+5) {

				GameObject toInstantiate = gameTiles;
				GameObject instance = Instantiate(toInstantiate,new Vector3(x,y,0f),Quaternion.identity) as GameObject;

				instance.transform.SetParent(boardHolder);
			}
			GameObject toInstantiateButtons = buttonTiles;
			GameObject buttonInstance = Instantiate(toInstantiateButtons,new Vector3(x,y,0f),Quaternion.identity) as GameObject;
			
			buttonInstance.transform.SetParent(boardHolder);
			buttonInstance.AddComponent<ButtonClick>();
		
		}

	}

	public void setupScene(){
		boardSetup (); 
	}

	public void performAction(int i){
		Debug.Log ("JJJ");
	}
}
