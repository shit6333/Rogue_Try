using UnityEngine;
using UnityEngine.UI;

public class PowerUpSetting : MonoBehaviour
{
    public RectTransform levelUI;
    public float speedUp = 0.2f;
    public void ShootSpeedUp()
    {
        if (GameManager.playerShootTime > 0)
        {
            GameManager.playerShootTime -= speedUp;
        }

        BackToGame();
    }


    // ===========================================================================
    private void BackToGame()
    {
        // 刪除按鈕物件
        GameObject[] childButtons = GameObject.FindGameObjectsWithTag("PowerUpBtn");
        int btnLenght = childButtons.Length;
        for (int i = 0; i < btnLenght; i++)
        {
            GameObject.Destroy(childButtons[i]);
        }

        // 時間回復
        Time.timeScale = 1;
    }
}
