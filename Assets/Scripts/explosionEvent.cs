using UnityEngine;
using System.Collections;


public class explosionEvent : MonoBehaviour
{

    public float force;
    public float radius;
    public float life = 0f;
    public string exclusion;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life<=0f)
            Destroy(gameObject);
        else
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                if (exclusion != null && hit.name != exclusion)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        //Debug.Log("exploding with force: " + force);
                        rb.AddExplosionForce(force, explosionPos, radius, 0, ForceMode.Impulse);
                    }
                }

            }
        }

        life -= 1 * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }
}

