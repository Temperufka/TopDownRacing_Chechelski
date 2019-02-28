using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D carRigidBody;
    [SerializeField] private GameObject skidmarkPrefab;
    private GameObject currentSkidmark;

    [SerializeField] private float speed = 10f;
    
    private float steeringForce = -200f;

    public static float maxSpeed = 10f;
    private const float driftFactor = 0.9f;
    private const float breakingSpeedRelease = 2f;
    

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Awake()
    {
        Assert.IsNotNull(carRigidBody);
    }


    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (!GameManager.instance.RaceStarted) return;

        carRigidBody.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if (Input.GetAxis("Vertical") > 0)
        {
            carRigidBody.AddForce(transform.up * Speed);
        }
        if (Input.GetAxis("Vertical") < 0 || Input.GetKey(KeyCode.Space))
        {
            carRigidBody.AddForce(transform.up * (-Speed / breakingSpeedRelease));
            EnableSkidmark();
        }
        else
            DisableSkidmark();

        float tf = Mathf.Lerp(0, steeringForce, carRigidBody.velocity.magnitude / breakingSpeedRelease);
        carRigidBody.angularVelocity = Input.GetAxis("Horizontal") * tf;
    }


    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(carRigidBody.velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(carRigidBody.velocity, transform.right);
    }

    private void EnableSkidmark()
    {
        if (currentSkidmark != null) return;

        currentSkidmark = Instantiate(skidmarkPrefab, transform);
    }

    private void DisableSkidmark()
    {
        if (currentSkidmark == null) return;

        currentSkidmark.GetComponent<Skidmark>().OnDisableSkidmark();
        currentSkidmark = null;
    }

}
