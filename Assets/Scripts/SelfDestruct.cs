using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructDelay = 2f;

    void Start()
    {
        Invoke("DestroyParent", selfDestructDelay);
    }

    void DestroyParent()
    {
        Destroy(gameObject);
    }
}