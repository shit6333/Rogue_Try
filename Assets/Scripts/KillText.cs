using UnityEngine;
using TMPro;

public class KillText : MonoBehaviour
{
    public TMP_Text killText ;
    private void FixedUpdate()
    {
        killText.text = GameManager.score.ToString();
    }


}
