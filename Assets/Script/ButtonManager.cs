using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    public MapSO mapGrid;
    [SerializeField]
    public Button button;

    private void Awake() {
        // if (mapGrid.MapGrid != null) {
        //     Debug.Log("wtf");
        //     button.interactable = true;
        //     return;
        // }
        // button.interactable = false;
    }
}
