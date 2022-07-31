using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        float x = Random.Range(-8, 8);
        float y = Random.Range(-4, 4);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            RandomizePosition();
        }
    }
}
