using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using static GridManager;

public abstract class GridSystem: ScriptableObject
{
    public abstract void mount(GridManager gridManager);
    public abstract void unmount();
}
