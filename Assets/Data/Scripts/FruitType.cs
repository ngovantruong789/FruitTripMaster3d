using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitType : TruongMonoBehaviour
{
    [SerializeField] protected FruitTypeSO fruitTypeSO;
    [SerializeField] protected string nameFruit;
    [SerializeField] protected int fruitID;
    public int FruitID => fruitID;

    protected override void LoadLink()
    {
        base.LoadLink();
        if(fruitTypeSO == null)
        {
            string path = "FruitType/" + transform.name;
            fruitTypeSO = Resources.Load<FruitTypeSO>(path);
        }
    }

    protected override void LoadData()
    {
        base.LoadData();
        nameFruit = fruitTypeSO.fruitName;
        fruitID = fruitTypeSO.fruitID;
    }
}
