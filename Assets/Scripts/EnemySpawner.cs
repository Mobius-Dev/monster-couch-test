using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _enemyAmount;

    private void Start()
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            Instantiate(_enemyPrefab, GetRandomSpawnPoint(GameManager.Instance.LevelBounds), Quaternion.identity, transform);
        }
    }

    private Vector2 GetRandomSpawnPoint(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
