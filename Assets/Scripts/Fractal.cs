using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fractal : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private int iteration;

    [SerializeField]
    private float size;


    void Start()
    {
        CreateSponge(iteration, Vector3.zero, (size*(float)Math.Pow(3,iteration))/3);
    }

    void CreateSponge(int level, Vector3 center, float size)
    {
        if (level == 1)
        {
            GameObject cube = Instantiate(cubePrefab, center, Quaternion.identity);
            cube.transform.localScale = Vector3.one * size;
            cube.transform.parent = transform;
        }
        else
        {
            float newSize = size/3f;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        if (Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) > 1)
                        {
                            Vector3 offset = new Vector3(x, y, z) * newSize;
                            Vector3 pos = center + offset;
                            CreateSponge(level - 1, pos, newSize);
                        }
                    }
                }
            }
        }
    }
}
