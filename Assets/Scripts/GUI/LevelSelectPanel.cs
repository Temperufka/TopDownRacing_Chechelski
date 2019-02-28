using UnityEngine;
using UnityEngine.UI;

public class LevelSelectPanel : MonoBehaviour
{
    [SerializeField] private Image selectedTeamImage;

    private void OnEnable()
    {
        selectedTeamImage.sprite = SelectTeamElement.selectedTeamImage;
    }

}
