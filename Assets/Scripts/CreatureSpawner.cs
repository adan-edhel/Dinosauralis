using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] GameObject dinosaurPrefab;
    [SerializeField] private float spawnRadius = 3;
    [SerializeField] private int maxDinoAmount = 5;
    [SerializeField] private int spawnInterval = 5;
    private float spawnCounter;

    [SerializeField] private List<EnemyStats> dinosaurList = new List<EnemyStats>();

    private void Start()
    {
        spawnCounter = spawnInterval;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnInterval)
        {
            spawnCounter = 0;
            SpawnDinosaurs();
        }
    }

    private void SpawnDinosaurs()
    {
        if (dinosaurList.Count < maxDinoAmount)
        {
            Vector3 spawnPoint = Vector3.zero;
            int amountToSpawn = maxDinoAmount - dinosaurList.Count;
            for (int i = 0; i < amountToSpawn; i++)
            {
                spawnPoint = transform.position + new Vector3((Random.insideUnitCircle * (spawnRadius - .5f)).x, (Random.insideUnitCircle * (spawnRadius - .5f)).y, 0);
                GameObject GO = Instantiate(dinosaurPrefab, spawnPoint, Quaternion.identity);
                GO.GetComponent<EnemyStats>().spawner = this;
            }
            print("spawned");
        }
    }

    /// <summary>
    /// Handles the addition and removal of dinosaurs.
    /// </summary>
    /// <param name="dino"></param>
    public void RegisterDinosaur(EnemyStats dino)
    {
        if (!dinosaurList.Contains(dino))
        {
            dinosaurList.Add(dino);
        }
        else
        {
            dinosaurList.Remove(dino);
        }
    }

    private void Meteor()
    {
        for (int i = 0; i < dinosaurList.Count; i++)
        {
            Destroy(dinosaurList[i].gameObject);
        }
    }

    public void RefreshDinos()
    {
        Meteor();
        Invoke("SpawnDinosaurs", .4f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
