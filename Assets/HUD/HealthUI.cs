using UnityEngine;
using UnityEngine.UI;

public class HealthUI: MonoBehaviour
{
    private Player player;
    public Text text;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        Debug.Log(player==null);
    }

    // private void Update()
    // {
    //     var temp = $"{player.health:0.00}%";
    //     text.text = temp;
    // }
}