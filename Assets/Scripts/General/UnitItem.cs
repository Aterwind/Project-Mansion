using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitItem : MonoBehaviour
{
    public  Action<UnitItem> BackStock;
    public abstract void TurnOff(UnitItem b);
    public abstract void TurnOn(UnitItem b);
}
