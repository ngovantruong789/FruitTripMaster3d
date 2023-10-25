using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Level", fileName = "Level")]
public class LevelSO : ScriptableObject
{
    [SerializeField] protected string mapName;
    [SerializeField] protected int level;
    [SerializeField] protected List<GameObject> listFruits;
    public List<GameObject> ListFruits => listFruits;

    public bool isComplete;
}
