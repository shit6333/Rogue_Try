using UnityEngine;
using UnityEngine.UI;

public class ExpBarControl : MonoBehaviour
{
    public Image bar { get; private set; }
    private void Start()
    {
        bar = GetComponent<Image>();
    }

    private void Update()
    {
        // ¸gÅç±ø±±¨î
        if(GameManager.playerLevel >= 0)
        {
            bar.fillAmount = GameManager.playerExp/GameManager.playerALevelExp;
        }
    }
}
