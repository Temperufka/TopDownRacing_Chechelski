using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        CameraFollow();        
    }

    private void CameraFollow()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
    }
}
