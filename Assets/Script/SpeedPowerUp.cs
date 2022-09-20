using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour, IPowerUp
{
    public void SetPower(GameObject gameObject)
    {
        gameObject.GetComponent<Paddle>().speed = 15;
    }
}
