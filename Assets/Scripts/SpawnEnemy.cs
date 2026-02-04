using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public float Interval;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), Interval, Interval);
    }

    private void Spawn()
    {
        float randomx;

        Vector3 maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 minPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        randomx = Random.Range(minPosition.x, maxPosition.x);

        Vector3 spawnPosition = new Vector3(randomx, transform.position.y, 0f);

        Enemy enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
