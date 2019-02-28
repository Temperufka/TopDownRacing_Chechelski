using UnityEngine;

public class Skidmark : MonoBehaviour
{
    private float skidmarkLifeTime = 2f;

    public void OnDisableSkidmark()
    {
        transform.parent = null;
        Destroy(gameObject, skidmarkLifeTime);
    }
}
