using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapManager : MonoBehaviour
{
    public Action OnBrickDestroy;
    public int[,] mapGrid;
    public static MapManager Instance;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private BrickSO[] bricksSO;
    [SerializeField]
    private MapSO mapSo;
    [SerializeField]
    private BoolSO loadContext;
    private IMapGenerator mapGenerator;
    private int brickCount = 0;
    private void Awake() {
        Instance = this;
        mapGenerator = GetComponent<IMapGenerator>();
    }

    private void Start() {
        if (mapSo.MapGrid != null && loadContext) {
            mapGrid = mapSo.MapGrid;
        }
        else {
            mapGrid = mapGenerator.GenerateMap(bricksSO.Length);
        }
        for (int x = 0; x < mapGrid.GetLength(0); x++)
        {
            for (int y = 0; y < mapGrid.GetLength(1); y++)
            {
                if (mapGrid[x,y] == 0) {
                    continue;
                }
                GenerateBrick(x, y);
                brickCount++;
            }
        }
    }

    private void GenerateBrick(int x, int y)
    {
        var value = mapGrid[x,y];
        var vec = new Vector3(prefab.transform.position.x + (prefab.transform.localScale.x * x), prefab.transform.position.y + prefab.transform.localScale.y * y, 0);
        var obj = Instantiate(prefab, vec, Quaternion.identity);
        obj.transform.parent = this.transform;
        var brick = obj.GetComponent<Brick>();
        brick.brickSO = bricksSO[value - 1];
        brick.x = x;
        brick.y = y;
    }

    public void BrickDestroy(int x, int y) {
        mapGrid[x, y] = 0;
        brickCount--;
        OnBrickDestroy?.Invoke();
        if (brickCount <= 0) {
            FindObjectOfType<BootManager>().LoadScene(2);
        }
    }

    public void OnHit(int x, int y) {
        mapGrid[x, y] -= 1;
    }
}
