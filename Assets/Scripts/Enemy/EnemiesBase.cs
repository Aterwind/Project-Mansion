using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemiesBase:MonoBehaviour
{
    public  Action<EnemiesBase> BackStock;
    public abstract void TurnOff(EnemiesBase b);
    public abstract void TurnOn(EnemiesBase b);
}
