using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] float E_Health = 50, E_Damage = 25;
    [SerializeField] GameObject _Corpse;
    PlayerStats player;

    private AudioSource bite;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        bite = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BiteTag")
        {
            E_TakeDamage(25);
            bite.Play();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject == player.gameObject)
        {
            player.TakeDamage(E_Damage);
            bite.Play();
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

        transform.parent.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(transform.parent.gameObject, 1f);
    }
}
