using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int P_Health, P_Hunger, MaxHP, MaxHung;
    public float FoodTime;
    [SerializeField] TextMeshProUGUI HPUI, HungerUI;
    GameManager _GameManager;

    void Start()
    {
        _GameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        MaxHP = P_Health;
        MaxHung = P_Hunger;
        HPUI.text = P_Health.ToString();
        HungerUI.text = P_Hunger.ToString();
        StartCoroutine(HungerTimer());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(3);

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            FillHunger(5);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            P_Hunger -= 10;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        HPUI.text = P_Health.ToString();
        HungerUI.text = P_Hunger.ToString();
    }

    public void TakeDamage(int Damage)
    {
        P_Health -= Damage;
        if (P_Health <= 0)
        {
            P_Health = 0;
            _GameManager.TitleScreen();
            //DEATH
        }
        UpdateUI();
    }
    public void FillHunger(int Amount)
    {
        P_Hunger += Amount;
        P_Health += 10;
        if (P_Hunger >= MaxHung)
        {
            P_Hunger = MaxHung;
        }
        UpdateUI();
    }


    public IEnumerator HungerTimer()
    {
        yield return new WaitForSeconds(FoodTime);
        if (P_Hunger <= 0)
        {
            TakeDamage(10);
        }
        else
        {
            P_Hunger -= 5;
        }
        UpdateUI();
        StartCoroutine(HungerTimer());
    }
}
