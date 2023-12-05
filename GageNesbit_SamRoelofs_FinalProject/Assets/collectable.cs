using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, 180.0f * Time.deltaTime);
    }
}
