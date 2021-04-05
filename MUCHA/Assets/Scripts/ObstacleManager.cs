using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs1;

    private Transform playerTransform;
    private float spawnZ = 5.0f;
    private float obstacleLenght = 10.0f;
    private int amnObstaclesOnScreen = 6;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;

   
    private List<GameObject> activeObstacles;

    // Start is called before the first frame update
    void Start()
    {

        activeObstacles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnObstaclesOnScreen; i++)
        {
            SpawnObstacle();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnObstaclesOnScreen * obstacleLenght))
        {
            SpawnObstacle();
            DeleteObstacle();
        }

    }

    private void SpawnObstacle(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(obstaclePrefabs1[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += obstacleLenght;
        activeObstacles.Add(go);
    }

    private void DeleteObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);

    }

    private int RandomPrefabIndex()
    {
        if (obstaclePrefabs1.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, obstaclePrefabs1.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;

    }


}

