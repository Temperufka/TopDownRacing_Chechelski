using UnityEngine;

public class Water : Boost
{
    private float upStreamSpeed = 5f;
    private float downStreamSpeed = 15;
    private bool isOnTrigger = false;

    private Transform playerTransform;

    protected override void OnBoost()
    {
        AddBoost();
    }

    private void Update()
    {
        if (!isOnTrigger) return;

        boostSpeed = GetTransformDirection(playerTransform) ? downStreamSpeed : upStreamSpeed;
        OnBoost();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ItemTags.PLAYER_TAG))
        {
            playerTransform = collision.transform;
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ItemTags.PLAYER_TAG))
        {
            ResetSpeed();
            isOnTrigger = false;
        }
    }

    private bool GetTransformDirection(Transform detectedTransform)
    {
        var dir = detectedTransform.TransformDirection(transform.position);
        return (dir.x < 0);
    }
}
