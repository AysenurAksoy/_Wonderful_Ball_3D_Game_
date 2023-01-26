using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conRotate : MonoBehaviour
{

    public float yanglespeed = 1f;

    void Update()
    {
        transform.Rotate(0, yanglespeed, 0);
    }
}
