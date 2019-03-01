using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void OnRaceStart()
    {
        ScriptData.gameManager.OnRaceStart();
    }
}
