using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    private int _RandomListEnemy;
    public int stock = 0;
    private int updateEnemies;
    private int limiteList;

    public List<EnemiesBase> enemyType = new List<EnemiesBase>();
    public List<GameObject> spawnList = new List<GameObject>();
    public ObjectPool<EnemiesBase> pool;

    void Start()
    {
        updateEnemies = stock;
        limiteList = enemyType.Count;
        pool = new ObjectPool<EnemiesBase>(BulletReturn, enemyType[_RandomListEnemy].TurnOn, enemyType[_RandomListEnemy].TurnOff, stock);
        EventManager.Subscribe("NewWave", Spawn);
        EventManager.Trigger("UpdateUIenemyTotal", updateEnemies);
    }

    void Update()
    {
        EventManager.Trigger("NewWave");
    }

    void Spawn(params object[] parameters)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            enemyType[_RandomListEnemy] = pool.GetObject();

            int spawnRandomList = Random.Range(0, 8);

            enemyType[_RandomListEnemy].transform.position = spawnList[spawnRandomList].transform.position;
            enemyType[_RandomListEnemy].transform.forward = spawnList[spawnRandomList].transform.forward;
            enemyType[_RandomListEnemy].BackStock = pool.ReturnObject;
        }
    }

    public EnemiesBase BulletReturn()
    {
        _RandomListEnemy = Random.Range(0,limiteList);
        return Instantiate(enemyType[_RandomListEnemy]);
    }

}
