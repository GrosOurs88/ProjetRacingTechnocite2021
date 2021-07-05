using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{
    public static CameraManagerScript instance;

    private void Awake()
    {
        instance = this;
    }
}
