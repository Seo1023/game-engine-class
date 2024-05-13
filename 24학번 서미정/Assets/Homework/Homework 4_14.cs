using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework4_14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 1; j < 10; j++)
        {
            if (j % 2 == 0)
            {
                continue;
            }
            Debug.Log(j);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
