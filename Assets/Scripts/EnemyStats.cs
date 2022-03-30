using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int E_Health, E_Damage;
    GameObject _Player;

    public CreatureSpawner spawner;

    void Start()
    {
        spawner.RegisterDinosaur(this);
        _Player = FindObjectOfType<PlayerStats>().gameObject;
    }

    // Remove function before shipping
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        spawner.RegisterDinosaur(this); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _Player)
        {
            PlayerStats P_Stats = _Player.GetComponent<PlayerStats>();
            P_Stats.TakeDamage(E_Damage);
        }
    }

    public void E_TakeDamage(int Damage)
    {
        E_Health -= Damage;
        if (E_Health <= 0)
        {
            E_Health = 0;
            //Spawn corpse
            Destroy(gameObject);
            //DEATH
        }
    }

}
