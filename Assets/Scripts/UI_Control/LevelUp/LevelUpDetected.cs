using UnityEngine;
using UnityEngine.UI;

public class LevelUpDetected : MonoBehaviour
{
    public RectTransform LevelUpUI;
    public Button[] buttons;

    private int buttonCount = 0;    // 按鈕數量
    private int previousLevel = 0;  // 之前的等級

    void Start()
    {
        previousLevel = GameManager.playerLevel;
        buttonCount = buttons.Length;
    }


    void Update()
    {
        // 升級
        if(GameManager.playerLevel > previousLevel)
        {
            // UI set Activity
            LevelUpUI.gameObject.SetActive(true);
            // 產生選擇按鈕
            RandomGenerateBoost(new Vector3(-170, 41, 0));
            RandomGenerateBoost(new Vector3(0, 41, 0));
            RandomGenerateBoost(new Vector3(170, 41, 0));

            // 時間暫停
            if (Time.timeScale != 0) Time.timeScale = 0;
            // 設置當前等級
            previousLevel = GameManager.playerLevel;
        }
    }

    // 產生按鈕
    private void RandomGenerateBoost( Vector3 spownPoint )
    {
        // TODO : 之後隨機 index 可寫成函數來調整機率
        int buttonIndex = Random.Range(0, buttonCount);
        // 隨機生成按鈕
        Button btn = Instantiate(buttons[buttonIndex], 
                                 Vector3.zero, 
                                 Quaternion.identity, 
                                 LevelUpUI);
        btn.transform.localPosition = spownPoint;   // 設定相對位置
    }
}
