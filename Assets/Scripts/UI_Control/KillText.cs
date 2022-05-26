using UnityEngine;
using TMPro;

public class KillText : MonoBehaviour
{
    public TMP_Text killText ;
    private void FixedUpdate()
    {
        killText.text = ((int)GameManager.score).ToString();
    }


}
