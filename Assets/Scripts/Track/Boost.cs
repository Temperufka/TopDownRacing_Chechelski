using System.Collections;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    [SerializeField] protected float boostSpeed = 10f;
    private WaitForSeconds boostDuration = new WaitForSeconds(2f);

    protected abstract void OnTriggerEnter2D(Collider2D collision);
    protected abstract void OnBoost();
    
    protected virtual void OnLimitedTimeBoost()
    {
        StartCoroutine(StartBoost());
    }

    protected virtual void ResetSpeed()
    {
        ScriptData.gameManager.carController.Speed = CarController.maxSpeed;
    }

    protected virtual void AddBoost()
    {
        ScriptData.gameManager.carController.Speed = boostSpeed;
    }
    private IEnumerator StartBoost()
    {
        AddBoost();
        yield return boostDuration;
        ResetSpeed();
    }
   

}
