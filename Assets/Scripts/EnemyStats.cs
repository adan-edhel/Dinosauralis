using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int E_Health, E_Damage;
    [SerializeField] GameObject _Corpse;
    GameObject _Player;

    public CreatureSpawner spawner;

    void Start()
    {
        spawner.RegisterDinosaur(this);
        _Player = FindObjectOfType<PlayerStats>().gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BiteTag")
        {
            E_TakeDamage(25);
        }

        if (collision.gameObject == _Player)
        {
            PlayerStats P_Stats = _Player.GetComponent<PlayerStats>();
            P_Stats.TakeDamage(E_Damage);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        spawner.RegisterDinosaur(this);
    }

    public void E_TakeDamage(int Damage)
    {
        E_Health -= Damage;
        if (E_Health <= 0)
        {
            E_Health = 0;
            SpawnCorpse();
        }
    }
    public void SpawnCorpse()
    {
        GameObject CurrentCorpse = Instantiate(_Corpse);
        CurrentCorpse.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
