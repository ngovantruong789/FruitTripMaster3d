using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnFruitSelected : TruongMonoBehaviour
{
    [Header("Link")]
    [SerializeField] protected SpawnFruitSelectedSO spawnFruitSelectedSO;
    [SerializeField] protected FruitSelectedSO fruitSelectedSO;
    [SerializeField] protected SpawnFruit spawnFruit;

    [Header("Data")]
    [SerializeField] protected GameObject canvasOver;
    [SerializeField] protected GameObject canvasLevel;
    [SerializeField] protected Vector3 firstSpawnPos;
    [SerializeField] protected Vector3 rotSpawn;
    [SerializeField] protected float distanceSpawn;
    [SerializeField] protected int limitSpawn;

    [SerializeField] protected bool isLose;
    public bool IsLose => isLose;

    protected override void Start()
    {
        base.Start();
        canvasOver.gameObject.SetActive(false);
        canvasLevel.gameObject.SetActive(false);
    }

    protected override void LoadLink()
    {
        base.LoadLink();
        if (fruitSelectedSO == null)
        {
            string path = "FruitSelected/FruitSelected";
            fruitSelectedSO = Resources.Load<FruitSelectedSO>(path);
        }

        if (spawnFruitSelectedSO == null)
        {
            string path = "FruitSelected/SpawnFruitSelected";
            spawnFruitSelectedSO = Resources.Load<SpawnFruitSelectedSO>(path);
        }

        spawnFruit = FindObjectOfType<SpawnFruit>();
    }

    protected override void LoadData()
    {
        base.LoadData();
        if (canvasOver == null) canvasOver = GameObject.Find("CanvasGameOver");
        if (canvasLevel == null) canvasLevel = GameObject.Find("CanvasLevel");

        firstSpawnPos = spawnFruitSelectedSO.firstSpawnPos;
        rotSpawn = spawnFruitSelectedSO.rotSpawn;
        distanceSpawn = spawnFruitSelectedSO.distanceSpawn;
        limitSpawn = spawnFruitSelectedSO.limitSpawn;
    }

    public void SpawnFruit(string name)
    {
        //Foreach lọc qua hình ảnh trái cây
        foreach(GameObject gameObject in fruitSelectedSO.SelectedFruitImages)
        {
            //Lấy thông tin của hình trái cây trong list SelectedFruitImages
            FruitSelectedType fruitSelectedType = gameObject.GetComponent<FruitSelectedType>();

            //Nếu tên của hình đúng với tên trái cây bị chọn
            if (fruitSelectedType.fruitName == name)
            {
                Vector3 pos;

                //Nếu đây là hình đâu tiên thì spawn ở vị trí firstSpawnPos
                //Nếu không đầu tiên thì spawn kế bên hình cuối cùng với khoảng cách là distanceSpawn
                if (transform.childCount <= 0) pos = firstSpawnPos;
                else
                {
                    pos = transform.GetChild(transform.childCount - 1).position;
                    pos = new Vector3(pos.x + distanceSpawn, pos.y, pos.z);
                }

                //Spawn Hình đó, điều chỉnh gốc, đặt lại tên, tắt particleSystem
                
                GameObject ImageSelected = Instantiate(gameObject, pos, Quaternion.identity);
                ImageSelected.transform.Rotate(rotSpawn);
                ImageSelected.name = name;
                ImageSelected.transform.SetParent(transform);
                ParticleSystem particleSystem = ImageSelected.GetComponentInChildren<ParticleSystem>();
                particleSystem.Stop();

                //Khi spawn xong kiểm tra hình trùng và giới hạn hình
                DestroySameObject();
                CheckLimitSpawn();
            }
        }
    }

    //Destroy obj trùng
    protected void DestroySameObject()
    {
        //Cho biến isSame kiểm tra trùng
        string nameSame = CheckSameOject();
        if (nameSame == "") return;

        //Lọc lại danh sách, xóa các obj có tên isSame
        for (int i = 0; i < transform.childCount; i++)
        {
            string childName = transform.GetChild(i).name;
            if (childName == nameSame)
            {
                FruitSelectedType fruitPickInfor = transform.GetChild(i).gameObject.GetComponent<FruitSelectedType>();
                fruitPickInfor.particleSystem.Play();
                Destroy(transform.GetChild(i).gameObject, 0.2f);
            }
        }

        //Xóa xong sẽ sắp xếp lại
        Invoke(nameof(SortObject), 0.2f);
        Invoke(nameof(CheckComplete), 0.2f);

        SoundManager.Instance.PlayAudioClip("TwinkleEffect");
    }

    //Kiểm tra trùng
    protected string CheckSameOject()
    {
        //Lấy tên object ở vị trí thứ i và duyệt các tên sau object đó
        //Nếu trùng trên 3 gồm cả obj i thì trả về tên trùng
        for (int i = 0; i < transform.childCount; i++)
        {
            string childName = transform.GetChild(i).name;
            int childSameCount = 0;
            for (int j = i + 1; j < transform.childCount; j++)
            {
                string childNextName = transform.GetChild(j).name;
                if (childName == childNextName) childSameCount++;
                if (childSameCount == 2) return childName;
            }
        }

        return "";
    }

    //Sắp xếp
    protected void SortObject()
    {
        if (transform.childCount <= 0) return;

        //Cho 1 List tạm chứa obj hiện có
        List<GameObject> tmp = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
            tmp.Add(transform.GetChild(i).gameObject);

        //Xóa obj
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);

        //Spawn ra lại
        for (int i = 0; i < tmp.Count; i++)
        {
            Vector3 pos;
            if (i == 0) pos = firstSpawnPos;
            else
            {
                pos = transform.GetChild(transform.childCount - 1).position;
                pos = new Vector3(pos.x + distanceSpawn, pos.y, pos.z);
            }

            GameObject objPick = Instantiate(tmp[i], pos, Quaternion.identity);
            ParticleSystem particleSystem = objPick.GetComponentInChildren<ParticleSystem>();
            particleSystem.Stop();

            objPick.transform.Rotate(rotSpawn);
            objPick.name = tmp[i].name;
            objPick.transform.SetParent(transform);
        }
    }

    //Kiểm tra giới hạn
    protected void CheckLimitSpawn()
    {
        if (transform.childCount < limitSpawn) return;

        string isSame = CheckSameOject();
        if (isSame == "")
        {
            isLose = true;
            canvasOver.gameObject.SetActive(true);
            SoundManager.Instance.SetMusicBackground(false);
            SoundManager.Instance.PlayAudioClip("GameOver");
        }
    }

    protected void CheckComplete()
    {
        Transform holder = spawnFruit.transform.Find("Holder");
        if (holder.transform.childCount <= 0 && !isLose)
        {
            canvasLevel.gameObject.SetActive(true);
            SoundManager.Instance.SetMusicBackground(false);
            SoundManager.Instance.PlayAudioClip("Finish");
        }
    }
}
