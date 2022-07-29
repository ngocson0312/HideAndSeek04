using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHexagon : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int coinsToSpawnCount;
    private void Start()
    {
        SpawnCoins();

    }

    //duyệt để spawn ra coin
    public void SpawnCoins()
    {
        for (int i = 0; i < coinsToSpawnCount; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

    }


    // tính toán điểm sẽ spawn ra coin
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x + 5f, collider.bounds.max.x - 5f),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z + 4f, collider.bounds.max.z - 4f)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1f;
        return point;
    }
}
