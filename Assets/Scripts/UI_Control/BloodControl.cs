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
        // �������
        if(GameManager.playerHp >= 0)
            bar.fillAmount = (float)GameManager.playerHp / (float)GameManager.playerMaxHp ;
    }
}
