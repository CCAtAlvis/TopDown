using UnityEngine;

public class BulletPistolScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    public float TTL;

    private float bulletPlayerAngle;
    private GameObject bulletSpawnPoint;
    private MeshRenderer bulletRenderer;

    void Start()
    {
        bulletSpawnPoint = GameObject.FindGameObjectWithTag("Player");
        bulletRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        TTL -= Time.deltaTime;

        if (TTL <= 0f)
        {
            Destroy(this.gameObject);
        }

        bulletPlayerAngle = Vector3.Angle(bulletSpawnPoint.transform.forward , transform.forward);
        if (bulletPlayerAngle < 25f)
        {
            bulletRenderer.enabled = true;
        }
        else
        {
            bulletRenderer.enabled = false;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        Debug.Log(other.tag);

        if (other.tag == "Enemy" || other.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
