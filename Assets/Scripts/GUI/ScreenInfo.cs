using UnityEngine;
using TMPro;

public class ScreenInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text playerLivesText;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text pointsAtLoseMenu;
   
    void Update()
    {
        playerLivesText.text = $"{ObjectRespawner.objectLives}";
        pointsText.text = $"{GameManager.currentPoints}";
        pointsAtLoseMenu.text = $"Score: {GameManager.currentPoints}";
    }
}
