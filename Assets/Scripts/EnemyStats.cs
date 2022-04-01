using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public CreatureSpawner spawner;

    void Start()
    {
        spawner.RegisterDinosaur(this);
    }

    private void OnDestroy()
    {
        spawner.RegisterDinosaur(this);
    }
}
