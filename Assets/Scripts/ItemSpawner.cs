using UnityEngine;

[RequireComponent (typeof(TimeAgent))]

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item toSpawn;
    [SerializeField] int count;
    [SerializeField] float spread = 0.7f;
    [SerializeField] float probability = 0.5f;

    //for random probability spawning of items 
    private void Start()
    {
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += Spawn;
    }

    //spawning object on the ground
    void Spawn()
    {
        if (UnityEngine.Random.value < probability)
        {
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            ItemSpawnManager.instance.SpawnItem(position, toSpawn, count);
        }
    }
}
