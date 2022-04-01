using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    public float fillAmount = 20;
    PlayerStats _Player;
    void Start()
    {
        _Player = FindObjectOfType<PlayerStats>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BiteTag")
        {
            _Player.FillHunger(fillAmount);
            Destroy(gameObject);
        }
    }
}
