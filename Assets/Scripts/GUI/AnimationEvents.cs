using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void OnRaceStart()
    {
        GameManager.instance.OnRaceStart();
    }
}
