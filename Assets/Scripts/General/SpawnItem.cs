using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public SpawnItem itemSpawn;
    public int stock = 0;
    private int limiteList;
    private int _RandomListItem;
    private int _MaxRandomListItemm;

    [SerializeField] private float waveRate = 2;
    private float nextWaveTime = 2;

    public List<UnitItem> itemType = new List<UnitItem>();
    public List<GameObject> spawnList = new List<GameObject>();
    public ObjectPool<UnitItem> pool;


    void Start()
    {
        limiteList = itemType.Count;
        _MaxRandomListItemm = spawnList.Count;
        pool = new ObjectPool<UnitItem>(BulletReturn, itemType[_RandomListItem].TurnOn, itemType[_RandomListItem].TurnOff, stock);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextWaveTime)
        {
            Spawn();
            nextWaveTime = Time.time + 1 / waveRate * 30;
        }

        void Spawn()
        {
            itemType[_RandomListItem] = pool.GetObject();
            int spawnRandomList = Random.Range(0, _MaxRandomListItemm);

            itemType[_RandomListItem].transform.position = spawnList[spawnRandomList].transform.position;
            itemType[_RandomListItem].transform.forward = spawnList[spawnRandomList].transform.forward;
            itemType[_RandomListItem].BackStock = pool.ReturnObject;
        }
    }

    public UnitItem BulletReturn()
    {
        _RandomListItem = Random.Range(0, limiteList);
        return Instantiate(itemType[_RandomListItem]);
    }
}
