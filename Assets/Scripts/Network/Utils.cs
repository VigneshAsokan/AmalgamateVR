using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static Vector3 GetSpawnPoint()
    {
        return new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));
    }
}
