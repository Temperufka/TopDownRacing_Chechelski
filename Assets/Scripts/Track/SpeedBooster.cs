using UnityEngine;

public class SpeedBooster : Boost
{
    protected override void OnBoost()
    {
        OnLimitedTimeBoost();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ItemTags.PLAYER_TAG))
            OnBoost();

    }
}
