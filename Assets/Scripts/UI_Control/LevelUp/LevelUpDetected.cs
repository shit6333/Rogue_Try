using UnityEngine;
using UnityEngine.UI;

public class LevelUpDetected : MonoBehaviour
{
    public RectTransform LevelUpUI;
    public Button[] buttons;

    private int buttonCount = 0;    // ���s�ƶq
    private int previousLevel = 0;  // ���e������

    void Start()
    {
        previousLevel = GameManager.playerLevel;
        buttonCount = buttons.Length;
    }


    void Update()
    {
        // �ɯ�
        if(GameManager.playerLevel > previousLevel)
        {
            // UI set Activity
            LevelUpUI.gameObject.SetActive(true);
            // ���Ϳ�ܫ��s
            RandomGenerateBoost(new Vector3(-170, 41, 0));
            RandomGenerateBoost(new Vector3(0, 41, 0));
            RandomGenerateBoost(new Vector3(170, 41, 0));

            // �ɶ��Ȱ�
            if (Time.timeScale != 0) Time.timeScale = 0;
            // �]�m��e����
            previousLevel = GameManager.playerLevel;
        }
    }

    // ���ͫ��s
    private void RandomGenerateBoost( Vector3 spownPoint )
    {
        // TODO : �����H�� index �i�g����ƨӽվ���v
        int buttonIndex = Random.Range(0, buttonCount);
        // �H���ͦ����s
        Button btn = Instantiate(buttons[buttonIndex], 
                                 Vector3.zero, 
                                 Quaternion.identity, 
                                 LevelUpUI);
        btn.transform.localPosition = spownPoint;   // �]�w�۹��m
    }
}
