using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;

    [SerializeField] private Sprite empty;
    [SerializeField] private Sprite blue;
    [SerializeField] private Sprite red;

    [SerializeField] private bool player = true;

    

    public void OnClickColumn(GameObject column)
    {
        for (int i = column.transform.childCount - 1; i >= 0; i--)
        {
            if(column.transform.GetChild(i).GetComponent<Image>().sprite == empty)
            {
                column.transform.GetChild(i).GetComponent<Image>().sprite = player ? blue : red;

                player = player ? false : true;
                break;
            }
        }

        bool currentWinner = true; 

        int[] verticalWinCount = new int[2];
        for (int i = column.transform.childCount - 1; i >= 0; i--)
        {
            if(column.transform.GetChild(i).GetComponent <Image>().sprite == blue)
            {
                verticalWinCount[0]++;
                verticalWinCount[1] = 0;
                currentWinner = true;
            }
            else if(column.transform.GetChild(i).GetComponent<Image>().sprite == red)
            {
                verticalWinCount[1]++;
                verticalWinCount[0] = 0;
                currentWinner = false;
            }
        }

        int totalCount = Mathf.Max(verticalWinCount[0], verticalWinCount[1]);

        if (totalCount >= 4)
        {
            Debug.Log((currentWinner ? "Blue" : "Red") + " wins!");
        }

        

    }
}
