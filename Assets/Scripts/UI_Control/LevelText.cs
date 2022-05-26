using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    public TMP_Text levelText;
    private void FixedUpdate()
    {
        levelText.text = ((int)GameManager.playerLevel).ToString();
    }
}
