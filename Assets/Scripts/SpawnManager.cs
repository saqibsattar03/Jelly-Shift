using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject [] hurdlePrefab; 
    [SerializeField] GameObject player;
    private float spawnDistance = 10.0f;
    float temp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHurdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnHurdle()
    {
        Vector3 playerPos = player.transform.position;
        Debug.Log("Player Position" + playerPos);
        Vector3 playerDirection = player.transform.forward;
        Debug.Log(playerDirection);
        Quaternion playerRotation = player.transform.rotation;
        
        int randomNumber = Random.Range( 0, hurdlePrefab.Length);
        if (randomNumber == 0)
        {
            temp = 0;
        }
        else 
        {
            temp = 1.5f;
        }
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        spawnDistance += 20.0f;
        Instantiate(hurdlePrefab[randomNumber], new Vector3(hurdlePrefab[randomNumber].transform.position.x, hurdlePrefab[randomNumber].transform.position.y + temp,player.transform.position.z + spawnDistance), playerRotation);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(SpawnHurdle());

    }
}
