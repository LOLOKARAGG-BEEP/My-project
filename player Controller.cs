using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform shootPoint;
    public AudioClip bulletSound;
    public AudioClip missileSound;
    public AudioSource audioSource;
    private int currentMissiles = 5;

    void Start()
    {
        UIManager.Instance?.UpdateMissileCount(currentMissiles);
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -input * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1")) 
        {
            ShootBullet();
        }

        if (Input.GetMouseButtonDown(1) && currentMissiles > 0) 
        {
            ShootMissile();
            currentMissiles--;
            UIManager.Instance?.UpdateMissileCount(currentMissiles);
        }
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        if (bulletSound != null && audioSource != null)
            audioSource.PlayOneShot(bulletSound);
    }

    void ShootMissile()
    {
        Instantiate(missilePrefab, shootPoint.position, shootPoint.rotation);
        if (missileSound != null && audioSource != null)
            audioSource.PlayOneShot(missileSound);
    }
}
