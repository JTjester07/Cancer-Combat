using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructDelay = 5f;

    void Start()
    {
        Invoke("DestroyParent", selfDestructDelay);
    }

    void DestroyParent()
    {
        Destroy(gameObject);
    }
}