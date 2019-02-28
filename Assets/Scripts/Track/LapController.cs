using System.Linq;
using UnityEngine;

public class LapController : MonoBehaviour
{
  
    [SerializeField] private Checkpoint[] checkpoints;

    [HideInInspector]
    public int currentLap = 0;

    public int maxLapNumber = 3;

    public void ResetCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].isChecked = false;
        }
    }

    public bool IsLapFinished()
    {
        if (checkpoints.All(x => x.isChecked))
        {
            ResetCheckpoints();
            return true;
        }
        return false;
        
    }
}
