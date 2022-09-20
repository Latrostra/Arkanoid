using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerUp : MonoBehaviour, IPowerUp
{
    public void SetPower(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
