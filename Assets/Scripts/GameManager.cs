using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player Variables")]
    public CarController carController;
    [SerializeField] private Transform playerStartPosition;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite[] teamSprites;

    [Header("UI Variables")]
    [SerializeField] private Text lapCounter;
    [SerializeField] private Text lapTimer;
    [SerializeField] private Text bestTimeLabel;
    [SerializeField] private GameObject StartRacePanel;
    [SerializeField] private GameObject RacePanel;
    [SerializeField] private GameObject FinishPanel;


    [Header(" ")]
    [SerializeField] private int trackNumber = 1;
    [SerializeField] private LapController lapController;

    private float timeCounter = 0f;
    private float bestLapTime = 0f;
   
    private bool raceStarted = false;

    public bool RaceStarted
    {
        get { return raceStarted; }
        set { raceStarted = value; }
    }



    private void Start()
    {
        SetupPlayer();
        bestLapTime = PlayerPrefsData.GetTrackRekord(trackNumber);
        bestTimeLabel.text = "Best Time : " + bestLapTime.ToString("F2");
       
    }

    private void Update()
    {
        if(RaceStarted)
            CountLapTime();      
    }

    public void SetLapCounter()
    {

        lapCounter.text = string.Format("Lap: {0}/{1}", lapController.currentLap, lapController.maxLapNumber);
    }

    public void OnRaceStart()
    {
        StartRacePanel.SetActive(false);
        RacePanel.SetActive(true);
        RaceStarted = true;
        SetLapCounter();
    }

    public bool CheckFinishRace()
    {
        if (lapController.currentLap >= lapController.maxLapNumber)
        {
            raceStarted = false;
            FinishPanel.SetActive(true);
            return true;
        }
        else
        {
            OnNextLap();
            return false;
        }
    }

    private void OnNextLap()
    {
        if (!lapController.IsLapFinished()) return;

        lapController.currentLap++;
        SetLapCounter();
        CheckBestTime();
        ResetLapTime();
       
    }
    private void CountLapTime()
    {
        timeCounter += Time.deltaTime;
        lapTimer.text = timeCounter.ToString("F2");
    }

    private void ResetLapTime()
    {
        timeCounter = 0;
    }

    private void CheckBestTime()
    {
        if(timeCounter < bestLapTime || bestLapTime == 0)
        {
            bestLapTime = timeCounter;
            bestTimeLabel.text = "Best Time : " + bestLapTime.ToString("F2");
            PlayerPrefsData.SaveNewLapRecord(trackNumber, bestLapTime);
        }
    }

    private void SetupPlayer()
    {
        carController.transform.position = playerStartPosition.position;
        playerSprite.sprite = teamSprites[PlayerPrefsData.GetSelectedTeam()];
    }

    public void TransferGameManager()
    {
        throw new System.NotImplementedException();
    }
}
