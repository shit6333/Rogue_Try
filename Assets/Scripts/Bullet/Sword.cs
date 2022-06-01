using UnityEngine;

public class Sword : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float swordPower = 1f;

    private Vector3 rotateAxis = Vector3.zero;

    private void Start()
    {
        transform.position = GameManager.player.transform.position;
        GameManager.swordPower = swordPower * GameManager.playerPowerMultiply; // 設定劍的力量
        rotateAxis.z = -1;  // 旋轉方向
        GameManager.swordRotateSpeed = rotateSpeed; // 設定旋轉速度
    }
    private void FixedUpdate()
    {
        transform.position = GameManager.player.transform.position;
        transform.Rotate(rotateAxis * GameManager.swordRotateSpeed* Time.fixedDeltaTime);
    }
}
