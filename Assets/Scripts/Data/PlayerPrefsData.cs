using UnityEngine;

public static class PlayerPrefsData 
{
    private const string SELECTED_TEAM_KEY = "SelectedTeam";

    private static string TRACK_RECORD_KEY = "LapRecord";

    public static void SaveNewLapRecord(int trackNumber, float value)
    {
        TRACK_RECORD_KEY = TRACK_RECORD_KEY + trackNumber;
        PlayerPrefs.SetFloat(TRACK_RECORD_KEY, value);
        PlayerPrefs.Save();
    }

    public static float GetTrackRekord(int trackNumber)
    {
        return PlayerPrefs.GetFloat(TRACK_RECORD_KEY + trackNumber, 0.00f);
    }

    public static void SaveSelectedTeam(int teamID)
    {
        PlayerPrefs.SetInt(SELECTED_TEAM_KEY, teamID);
        PlayerPrefs.Save();
    }

    public static int GetSelectedTeam()
    {
        return PlayerPrefs.GetInt(SELECTED_TEAM_KEY,0);
    }

}
