using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powersUp;
    private void Start() {
        MapManager.Instance.OnBrickDestroy += OnBrickDestroyHandler;
    }
    private void OnDestroy() {
        MapManager.Instance.OnBrickDestroy -= OnBrickDestroyHandler;
    }
    public void OnBrickDestroyHandler(float xPos, float yPos) {
        var rand = Random.Range(0, 20);
        if (rand == 3) {
            Instantiate(powersUp[0], new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
        if (rand == 4) {
            Instantiate(powersUp[1], new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
    }
}
