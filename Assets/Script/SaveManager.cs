using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private MapSO mapSo;
    public void SaveMap() {
        mapSo.MapGrid = MapManager.Instance.mapGrid;
    }
}
