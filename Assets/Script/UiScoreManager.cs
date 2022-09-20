using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScoreManager : MonoBehaviour
{
    [SerializeField]
    private IntSO score;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private bool resetScore;

    private void Start() {
        text.text = score.Value.ToString();
        if (resetScore) {
            score.Value = 0;
        }
    }
}
