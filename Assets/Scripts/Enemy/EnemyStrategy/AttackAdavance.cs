﻿
using UnityEngine;

public class AttackAdavance : IEnemyAdvance
{
    Animator _anim;

    public AttackAdavance(Animator anim)
    {
        _anim = anim;
    }

    public void EnemyAdvance()
    {
        _anim.SetTrigger("Attack");
    }
}
