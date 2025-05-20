using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MySingleton<BackgroundManager>
{
    [SerializeField] protected List<BackgroundReaping> backgroundReapings;
}
