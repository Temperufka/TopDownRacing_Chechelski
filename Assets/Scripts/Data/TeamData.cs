using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Teams/TeamData", order = 1)]
public class TeamData : ScriptableObject
{
    public int selectedTeamID = 0;
    public string teamName = string.Empty;
    public Sprite teamImage;
}
