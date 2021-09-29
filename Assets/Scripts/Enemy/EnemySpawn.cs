using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public EnemyTest enemyT;

    public ObjectPool<EnemyTest> pool;

    void Start()
    {
        enemySpawn = this;
        pool = new ObjectPool<EnemyTest>(BulletReturn, enemyT.TurnOn, enemyT.TurnOff, 10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            enemyT = pool.GetObject();
            enemyT.transform.position = this.transform.position;
            enemyT.transform.forward = this.transform.forward;

            enemyT.BackStock = pool.ReturnObject;
        }
    }

    public EnemyTest BulletReturn()
    {
        return Instantiate(enemyT);
    }
}
