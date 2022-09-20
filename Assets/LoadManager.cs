using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [SerializeField]
    private BoolSO loadContext;

    public void SetContext(bool value) {
        loadContext.Value = value;
    }
}
