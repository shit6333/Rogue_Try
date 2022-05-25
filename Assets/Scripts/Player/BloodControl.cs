using UnityEngine;
using UnityEngine.UI;

public class BloodControl : MonoBehaviour
{
    public Image bar { get; private set; }
    private void Start()
    {
        bar = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        // ¦å±ø±±¨î
        if(GameManager.playerHp >= 0)
            bar.fillAmount = (float)GameManager.playerHp / (float)GameManager.playerMaxHp ;
    }
}
