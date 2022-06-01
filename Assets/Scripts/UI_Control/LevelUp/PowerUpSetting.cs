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
    public float swordLengthen = 0.5f;
    public float swordRatateSpeedUp = 1.5f;

    // �i�s�W������ --------------------------------
    public GameObject swordPrefab;


    public void ShootSpeedUp()
    {
        GameManager.swordRotateSpeed *= swordRatateSpeedUp; // �C����t�׼W�[

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

    // �W�[�C����
    public void SwordLevelUp()
    {
        // �C���Ŭ� 0
        if(GameManager.swordLevel == 0)
        {
            Instantiate(swordPrefab, GameManager.player.transform.position, Quaternion.identity);
            GameManager.swordLevel++;
        }
        else
        {
            GameObject sword = GameObject.FindGameObjectWithTag("Sword");
            sword.transform.localScale = new Vector3(1, sword.transform.localScale.y + swordLengthen, 1);
            GameManager.swordLevel++;
        }

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
