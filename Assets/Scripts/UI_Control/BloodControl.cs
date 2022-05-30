using UnityEngine;
using UnityEngine.UI;

public class BloodControl : MonoBehaviour
{
    public Image bar { get; private set; }
    private void Start()
    {
        bar = GetComponent<Image>();
    }

    private void Update()
    {
        // ¦å±ø±±¨î
        if(GameManager.playerHp >= 0)
            bar.fillAmount = GameManager.playerHp / GameManager.playerMaxHp ;
    }
}
