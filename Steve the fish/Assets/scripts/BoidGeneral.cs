using UnityEngine;
using System.Collections.Generic;

public class BoidGeneral : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float numbermax;
    [SerializeField] private GameObject BoidPrefab;
    public Vector3 spawnAreaMin = new Vector3(-20, -20, -20);
    public Vector3 spawnAreaMax = new Vector3(20, 20, 20);
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numbermax; i++)
        {
            SpawnRandom();
            direction = Random.onUnitSphere;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandom()
    {
        // Générer une position aléatoire dans les limites définies
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        // Instancier l'objet à la position générée
        Instantiate(BoidPrefab, randomPosition, Quaternion.identity);
    }

}
