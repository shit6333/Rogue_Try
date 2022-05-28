using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    public TMP_Text levelText;
    private void Update()
    {
        levelText.text = ((int)GameManager.playerLevel).ToString();
    }
}
