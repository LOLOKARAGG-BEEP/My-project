using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float explosionRadius = 1.5f;
    private Transform target;

    void Start()
    {
        GameObject targetObj = GameObject.FindGameObjectWithTag("Enemy");
        if (targetObj != null) target = targetObj.transform;
    }

    void Update()
    {
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().TakeDamage(5);
                }
            }
            Destroy(gameObject);
        }
    }
}
//