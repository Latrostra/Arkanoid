using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiHighScoreManager : MonoBehaviour
{
    [SerializeField]
    private IntSO highScore;
    [SerializeField]
    private IntSO score;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake() {
        if (score.Value > highScore.Value) {
            highScore.Value = score.Value;
        }
        text.text = highScore.Value.ToString();
    }
}
