using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SpawnFruitSelected", fileName = "SpawnFruitSelected")]
public class SpawnFruitSelectedSO : ScriptableObject
{
    public Vector3 firstSpawnPos;
    public Vector3 rotSpawn;
    public float distanceSpawn;
    public int limitSpawn;
}
