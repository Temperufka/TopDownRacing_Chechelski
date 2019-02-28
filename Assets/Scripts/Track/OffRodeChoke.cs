using UnityEngine;

public class OffRodeChoke : Boost
{
    protected override void OnBoost()
    {
        AddBoost();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ItemTags.PLAYER_TAG))
            ResetSpeed();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ItemTags.PLAYER_TAG))
            OnBoost();
    }


}
