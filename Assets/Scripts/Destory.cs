using UnityEngine;

public class Destory : MonoBehaviour
{
    public float destoryTime = 2f;
    public void Start()
    {
        GameObject.Destroy(this.gameObject, destoryTime);
    }
}
