using UnityEngine;
using UnityEngine.UI;

public class HealthUI: MonoBehaviour
{
    private Player player;
    public Image FillAmountImage;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        Debug.Log(player==null);
    }

    private void Update()
    {
        var playerHealth = player.health;
        FillAmountImage.fillAmount = playerHealth / 100;
    }
}