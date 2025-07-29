using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}//