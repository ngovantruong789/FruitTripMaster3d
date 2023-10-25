using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FruitSelected", fileName = "FruitSelected")]
public class FruitSelectedSO : ScriptableObject
{
    public List<GameObject> SelectedFruitImages;
}
