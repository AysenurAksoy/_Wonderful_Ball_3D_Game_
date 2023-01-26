using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmove : MonoBehaviour
{


    public float speed = 1.5f;
    public Vector3 startPos1;
    public Vector3 startPos2;

    public Transform currentpoint;
    public GameObject objehareket;
    
    void Start()
    {
        startPos1 = objehareket.transform.position;
    }

    
    void Update()
    {
        objehareket.transform.position = Vector3.MoveTowards(objehareket.transform.position, startPos1, Time.deltaTime * speed);
        if (objehareket.transform.position == startPos1)
        {
            startPos1 = startPos2;
            if (startPos1 == startPos2)
            {
                startPos2 = objehareket.transform.position;
            }
        }
    }
}
