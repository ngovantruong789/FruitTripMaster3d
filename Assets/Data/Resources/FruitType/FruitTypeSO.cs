using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FruitType", fileName = "FruitType")]
public class FruitTypeSO : ScriptableObject
{
    public string fruitName;
    public int fruitID;
}
