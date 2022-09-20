using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMapGenerator {
    int[,] GenerateMap(int brickCount);
}

