using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAdvance : IEnemyAdvance
{
    float _speed;
    int _currentWaypoint;
    Vector3 _dir;
    TargetWaypoints _allWaiPoint;
    GameObject _meshCollider;
    GameObject _boxCollider;
    Transform _transform;

    public NormalAdvance(float speed, Transform transform, int currentWayPoint, Vector3 dir, TargetWaypoints allWaiPoint, GameObject meshCollider, GameObject boxCollider)
    {
        _speed = speed;
        _transform = transform;
        _currentWaypoint = currentWayPoint;
        _dir = dir;
        _allWaiPoint = allWaiPoint;
        _meshCollider = meshCollider;
        _boxCollider = boxCollider;
    }

    public void EnemyAdvance()
    {
        _dir = _allWaiPoint.targets[_currentWaypoint].transform.position - _transform.transform.position;
        _dir.y = 0;
        _transform.transform.position += _dir.normalized * _speed * Time.deltaTime;

        if (_dir.x >= 0)
        {
            _meshCollider.transform.rotation = Quaternion.Euler(0, 145, 0);
        }
        else
        {
            _meshCollider.transform.rotation = Quaternion.Euler(0, -145, 0);
        }

        if (_dir.magnitude < 0.5f)
        {
            _boxCollider.SetActive(false);
            if (_currentWaypoint < 1)
            {
                _currentWaypoint++;
            }
            else if (_currentWaypoint > _allWaiPoint.targets.Count - 1)
            {
                _currentWaypoint = 0;
            }
        }
    }
}
