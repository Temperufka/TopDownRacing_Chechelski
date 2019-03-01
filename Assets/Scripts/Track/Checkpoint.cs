using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isChecked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ItemTags.PLAYER_TAG))
        {
            isChecked = true;
            ScriptData.gameManager.CheckFinishRace();

        }
    }


}
