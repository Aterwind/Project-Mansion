using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public int stock = 0;
    private int updateEnemies;
    private int limiteList;
    private int _RandomListEnemy;
    private int _MaxRandomListEnemy;

    [SerializeField]private float waveRate = 2;
    [SerializeField] private float nextWaveTime = 2;

    public List<EnemiesBase> enemyType = new List<EnemiesBase>();
    public List<GameObject> spawnList = new List<GameObject>();
    public ObjectPool<EnemiesBase> pool;

    void Start()
    {
        updateEnemies = stock;
        limiteList = enemyType.Count;
        _MaxRandomListEnemy = spawnList.Count;

        pool = new ObjectPool<EnemiesBase>(BulletReturn, enemyType[_RandomListEnemy].TurnOn, enemyType[_RandomListEnemy].TurnOff, stock);
        EventManager.Trigger("UpdateUIenemyTotal", updateEnemies);
    }

    void Update()
    {
        if(Time.time >= nextWaveTime)
        {
            Spawn();
            nextWaveTime = Time.time + 1 / waveRate * 30;
        }
    }

    void Spawn()
    {
        enemyType[_RandomListEnemy] = pool.GetObject();

        int spawnRandomList = Random.Range(0, _MaxRandomListEnemy);

        enemyType[_RandomListEnemy].transform.position = spawnList[spawnRandomList].transform.position;
        enemyType[_RandomListEnemy].transform.forward = spawnList[spawnRandomList].transform.forward;
        enemyType[_RandomListEnemy].BackStock = pool.ReturnObject;
    }

    public EnemiesBase BulletReturn()
    {
        _RandomListEnemy = Random.Range(0,limiteList);
        return Instantiate(enemyType[_RandomListEnemy]);
    }

}
