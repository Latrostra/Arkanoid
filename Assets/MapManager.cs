using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private int xGrid;
    [SerializeField]
    private int yGrid;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private BrickSO[] bricksSO;
    [SerializeField]
    private int brickCount = 50;
    [SerializeField]
    private int density = 1;
    private int actualBrick = 0;

    private void Start() {
        for(int x = 0; x < xGrid/2; x++) {
            for (int y = 0; y < yGrid; y++)
            {
                int random = Random.Range(0, bricksSO.Length + 1 + density);
                if (random <= 0 + density)
                {
                    continue;
                }
                var obj = GenerateBrick(x, y, random, -1);
                if (x == 0)
                {
                    continue;
                }
                obj = GenerateBrick(x, y, random, 1);
                if (brickCount < actualBrick) {
                    return;
                }
            }
        }
    }

    private GameObject GenerateBrick(int x, int y, int random, int factor)
    {
        var vec = new Vector3(prefab.transform.position.x + (prefab.transform.localScale.x * x) * factor, prefab.transform.position.y + prefab.transform.localScale.y * y, 0);
        var obj = Instantiate(prefab, vec, Quaternion.identity);
        obj.GetComponent<Brick>().brickSO = bricksSO[random - 1 - density];
        actualBrick++;
        return obj;
    }
}
