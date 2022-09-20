using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField]
    public IntSO score;
    private void Awake() {
        Instance = this;
    }
}
