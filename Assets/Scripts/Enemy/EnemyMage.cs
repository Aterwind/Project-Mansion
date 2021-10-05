using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Unit
{
    private bool _attack = false;
    private bool _isAtacking = false;
    private bool _canAttack = true;
    [SerializeField] private GameObject _player;
    private Vector3 pointPlayer;

    //esto deberia ir a unit creo
    public List<Transform> Allwaypoint = new List<Transform>();
    private int currentWaypoint = 0;
    [SerializeField] private GameObject rot = null;
    private void Awake()
    {

    }
    void Update()
    {
        if (_isAtacking == false)
            Movement();

        if (_player.transform.position.x <= transform.position.x + 0.5f && _player.transform.position.x >= transform.position.x - 0.5f && _isAtacking == false && _canAttack)
        {
            _isAtacking = true;
            _canAttack = false;
            Animation();
        }

        if (_attack)
        {
            _attack = false;
            Attack();
        }
           
    }


    private void Movement()
    {
        Debug.Log("Me muevo");
        
        //esto deberia ir a unit tmb
        Vector3 dir = Allwaypoint[currentWaypoint].transform.position - transform.position;
        dir.y = 0;
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (dir.x >= 0)
        {
            rot.transform.rotation = Quaternion.Euler(0, 145, 0);
        }

        else
        {
            rot.transform.rotation = Quaternion.Euler(0, -145, 0);
        }


        if (dir.magnitude < 0.5f)
        {
            currentWaypoint++;

            if (currentWaypoint > Allwaypoint.Count - 1)
                currentWaypoint = 0;
        }
    }


    private void Animation()
    {
        Debug.Log("Animacion");
        pointPlayer = _player.transform.position;
        //animacion movimiento
        _attack = true;
    }

    private void Attack()
    {
        Debug.Log("Attack");
        StartCoroutine(Instanciate());
        
    }

    IEnumerator Instanciate()
    {
        yield return new WaitForSeconds(0.25f);
        //instanciar ataque
        Debug.Log("yield");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("movimiento normal");
        _isAtacking = false;
        StartCoroutine(TimerAtaque());
    }

    IEnumerator TimerAtaque()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("puede atacar");
        _canAttack = true;
    }
}
