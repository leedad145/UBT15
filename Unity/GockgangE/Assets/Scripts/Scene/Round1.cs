using UnityEngine;
public class Round1 : MonoBehaviour
{
    [SerializeField] Transform MobSpawnPoint1;
    [SerializeField] Transform MobSpawnPoint2;
    void Start()
    {
        GameManager.Instance.InitAfterLoad();

        GameManager.Instance.SpawnMob(GameManager.Instance.GoblinPrefab, MobSpawnPoint1.position);
        GameManager.Instance.SpawnMob(GameManager.Instance.FlyingEyePrefab, MobSpawnPoint1.position);

        GameManager.Instance.SpawnMob(GameManager.Instance.GoblinPrefab, MobSpawnPoint2.position);
        GameManager.Instance.SpawnMob(GameManager.Instance.GoblinPrefab, MobSpawnPoint2.position);
        GameManager.Instance.SpawnMob(GameManager.Instance.FlyingEyePrefab, MobSpawnPoint2.position);
        GameManager.Instance.SpawnMob(GameManager.Instance.FlyingEyePrefab, MobSpawnPoint2.position);
    }
}