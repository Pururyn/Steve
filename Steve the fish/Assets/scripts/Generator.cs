using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Generator : MonoBehaviour
{

    [SerializeField] private float numbermax;
    [SerializeField] private GameObject BoidPrefab;

    public Vector3 spawnAreaMin = new Vector3(-20, -20, -20);
    public Vector3 spawnAreaMax = new Vector3(20, 20, 20);
    public Vector3 direction;
    public List<GameObject> Boids;

    void Start()
    {
        for (int i = 0; i < numbermax; i++)
        {
            SpawnRandom();
            direction = Random.onUnitSphere;
            Boids.Add(BoidPrefab);
        }
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
