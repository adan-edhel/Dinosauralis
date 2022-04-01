using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] float E_Health = 50, E_Damage = 25;
    [SerializeField] GameObject _Corpse;
    PlayerStats player;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BiteTag")
        {
            E_TakeDamage(25);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject == player.gameObject)
        {
            player.TakeDamage(E_Damage);
        }
    }

    public void E_TakeDamage(int Damage)
    {
        E_Health -= Damage;
        if (E_Health <= 0)
        {
            E_Health = 0;
            SpawnCorpse();
        }

        GetComponentInParent<Animator>().SetBool("Hurt", true);
        Invoke("ResetHurt", .1f);
    }

    private void ResetHurt()
    {
        GetComponentInParent<Animator>().SetBool("Hurt", false);
    }

    public void SpawnCorpse()
    {
        GameObject CurrentCorpse = Instantiate(_Corpse);
        CurrentCorpse.transform.position = gameObject.transform.position;
        Destroy(transform.parent.gameObject);
    }
}
