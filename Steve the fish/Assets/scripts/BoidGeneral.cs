using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class BoidGeneral : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float numbermax;
    [SerializeField] private GameObject BoidPrefab;
    [SerializeField] private float CohesionVal; //boids proche entre eux
    [SerializeField] private float Separation; //boids eloignés
    [SerializeField] private float Alignement; // boids se suivant plus ou moins

    //[SerializeField] private float Acceleration;

    public Vector3 spawnAreaMin = new Vector3(-20, -20, -20);
    public Vector3 spawnAreaMax = new Vector3(20, 20, 20);
    public Vector3 direction;
    public List<GameObject> Boids;
    public Vector3 sumBoidPosition;
    public Vector3 CenterOfMass;
    public float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numbermax; i++)
        {
            SpawnRandom();
            direction = Random.onUnitSphere;
            Boids.Add(BoidPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = 0;
        Cohesion();
        Deplacement(time);
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

    void Deplacement(float deltaTime)
    {
        BoidPrefab.transform.position += ( speed * deltaTime) * CenterOfMass;
    }

    void Cohesion()
    {
        foreach (GameObject BoidPrefab in Boids)
        {
            var BoidTransform = BoidPrefab.transform;
            sumBoidPosition += BoidTransform.position;
        }

        CenterOfMass = sumBoidPosition / numbermax * CohesionVal;
    }

}
