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

    // 可新增的物件 --------------------------------
    public GameObject swordPrefab;


    public void ShootSpeedUp()
    {
        GameManager.swordRotateSpeed *= swordRatateSpeedUp; // 劍旋轉速度增加

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

    // 增加劍等級
    public void SwordLevelUp()
    {
        // 劍等級為 0
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
    // 退出UI
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
