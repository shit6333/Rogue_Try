using UnityEngine;
using UnityEngine.UI;

public class PowerUpSetting : MonoBehaviour
{
    public RectTransform levelUI;
    public float shootSpeedUp = 0.2f;
    public float moveSpeedUp = 0.2f;
    public float increaseMaxHp = 1;
    public float restoreHp = 1;
    public float powerUp = 0.2f;

    public void ShootSpeedUp()
    {
        if (GameManager.playerShootTime > 0.1)
        {
            GameManager.playerShootTime -= shootSpeedUp;
        }
        
        if( GameManager.playerShootTime < 0.1)
        {
            GameManager.playerShootTime = 0.1f;
        }

        BackToGame();
    }

    public void MoveSpeedUp()
    {
        GameManager.moveSpeed += moveSpeedUp;
        BackToGame();
    }

    public void IncreaseMaxHp()
    {
        GameManager.playerMaxHp += increaseMaxHp;
        GameManager.playerHp += increaseMaxHp;
        BackToGame();
    }

    public void RestoreHp()
    {
        if(GameManager.playerHp < GameManager.playerMaxHp)
        {
            GameManager.playerHp += restoreHp;
            if(GameManager.playerHp > GameManager.playerMaxHp)
                GameManager.playerHp = GameManager.playerMaxHp;
        }

        BackToGame();
    }

    public void PowerUp()
    {
        GameManager.playerPowerMultiply += powerUp;
        BackToGame();
    }
    // ===========================================================================
    // �h�XUI
    private void BackToGame()
    {
        // �R�����s����
        GameObject[] childButtons = GameObject.FindGameObjectsWithTag("PowerUpBtn");
        int btnLenght = childButtons.Length;
        for (int i = 0; i < btnLenght; i++)
        {
            GameObject.Destroy(childButtons[i]);
        }

        // �ɶ��^�_
        Time.timeScale = 1;
    }
}
