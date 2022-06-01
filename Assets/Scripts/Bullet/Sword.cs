using UnityEngine;

public class Sword : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float swordPower = 1f;

    private Vector3 rotateAxis = Vector3.zero;

    private void Start()
    {
        transform.position = GameManager.player.transform.position;
        GameManager.swordPower = swordPower * GameManager.playerPowerMultiply; // �]�w�C���O�q
        rotateAxis.z = -1;  // �����V
        GameManager.swordRotateSpeed = rotateSpeed; // �]�w����t��
    }
    private void FixedUpdate()
    {
        transform.position = GameManager.player.transform.position;
        transform.Rotate(rotateAxis * GameManager.swordRotateSpeed* Time.fixedDeltaTime);
    }
}
