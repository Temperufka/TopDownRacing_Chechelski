using UnityEngine;
using UnityEngine.UI;

public class SelectTeamElement : MonoBehaviour
{
    public static int currentTeamID;
    public static Sprite selectedTeamImage;
    public TeamData teamData;

    [SerializeField] private Text teamNameLabel;

    private void Start()
    {
        teamNameLabel.text = teamData.teamName;
        GetComponent<Button>().onClick.AddListener(() => OnTeamSelect());
    }

    private void OnTeamSelect()
    {
        selectedTeamImage = teamData.teamImage;
        currentTeamID = teamData.selectedTeamID;
        PlayerPrefsData.SaveSelectedTeam(currentTeamID);
        GUIController.instance.OpenNextPanel();
    }
}
