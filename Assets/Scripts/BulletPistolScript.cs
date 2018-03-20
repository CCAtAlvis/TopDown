using UnityEngine;

public class BulletPistolScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;

    private float TTL;

    // Update is called once per frame
    void Update ()
    {
        transform.position += transform.forward * 3f * Time.deltaTime;
        TTL += Time.deltaTime;

        if (TTL > 5f)
        {
            Destroy(this.gameObject);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Enemy" || other.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
    }
}
