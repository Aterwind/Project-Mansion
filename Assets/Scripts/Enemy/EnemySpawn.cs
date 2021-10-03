using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    private int _RandomListEnemy;
    public int stock = 0;

    public List<EnemiesBase> enemyType = new List<EnemiesBase>();
    public List<GameObject> spawnList = new List<GameObject>();
    public ObjectPool<EnemiesBase> pool;

    void Start()
    {
        pool = new ObjectPool<EnemiesBase>(BulletReturn, enemyType[_RandomListEnemy].TurnOn, enemyType[_RandomListEnemy].TurnOff, stock);
        EventManager.Subscribe("NewWave", Spawn);
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

            int RandomList = Random.Range(0, 8);

            enemyType[_RandomListEnemy].transform.position = spawnList[RandomList].transform.position;
            enemyType[_RandomListEnemy].transform.forward = spawnList[RandomList].transform.forward;

            enemyType[_RandomListEnemy].BackStock = pool.ReturnObject;

            if(enemyType[0].BackStock != null)
            {
                Debug.Log("estoy aca");
            }
        }
    }

    public EnemiesBase BulletReturn()
    {
        _RandomListEnemy = Random.Range(0, 2);
        return Instantiate(enemyType[_RandomListEnemy]);
    }

}
