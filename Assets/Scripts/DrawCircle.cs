using UnityEngine;
using System.Collections;

public class DrawCircle : MonoBehaviour
{
    public int segments;
    public float radius;
    public float maxRadius;
    public float speed;
    LineRenderer line;
    SphereCollider myCollider;
    public float force = 5f;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        myCollider = transform.GetComponent<SphereCollider>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }


    void CreatePoints()
    {
        float x;
        float y = 0f;
        float z;

        float angle = 0f;
        float opacity = 1 - (radius / maxRadius);

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle);
            z = Mathf.Cos(Mathf.Deg2Rad * angle);
            line.SetWidth(0.5f, 0.5f);
            line.material = new Material(Shader.Find("Particles/Alpha Blended"));
            line.material.SetColor("_TintColor", new Color(1, 1, 1, opacity));
            line.SetPosition(i, new Vector3(x, y, z) * radius);
            angle += (360f / segments);

            if (opacity <= 0)
                Destroy(gameObject);
        }
    }

    void Update()
    {
        if (radius < maxRadius)
        {
            radius += speed * Time.deltaTime;
            CreatePoints();
            myCollider.radius = radius;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Token")
        {
            Debug.Log("radius: " + (maxRadius - radius)*4);
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Debug.Log("explosion:" + force + "/" + explosionPos + "/" + radius + "/" + ForceMode.Impulse);
                    rb.AddExplosionForce(force, explosionPos, radius, 0, ForceMode.Impulse);
                }

            }
        }
    }
}
