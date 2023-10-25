using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnFruit : TruongMonoBehaviour
{
    [SerializeField] protected List<Transform> pointsLocation;
    [SerializeField] protected Transform holder;

    [SerializeField] protected LevelSO levelSO;
    public LevelSO LevelSO => levelSO;

    protected override void Start()
    {
        base.Start();
        Spawning();
    }

    protected override void LoadLink()
    {
        base.LoadLink();
        if(levelSO == null)
        {
            string levelName = SceneManager.GetActiveScene().name;
            string path = "Level/" + levelName;
            levelSO = Resources.Load<LevelSO>(path);
        }
    }

    protected override void LoadData()
    {
        base.LoadData();
        if(pointsLocation.Count <= 0)
        {
            Transform point = transform.Find("PointsLocation");
            foreach(Transform transform in point)
                pointsLocation.Add(transform);
        }

        if (holder == null) holder = transform.Find("Holder");
    }

    //Spawn fruit ở tọa độ ngẫu nhiện từ pointsLocation và đặt tên
    protected virtual void Spawning()
    {
        List<GameObject> listFruits = levelSO.ListFruits;
        for(int i = 0; i < listFruits.Count; i++)
        {
            int rand = Random.Range(0, pointsLocation.Count);
            GameObject fruit = Instantiate(listFruits[i], pointsLocation[rand].position, Quaternion.identity);
            fruit.name = listFruits[i].name;
            fruit.transform.SetParent(holder);
        }
    }
}
