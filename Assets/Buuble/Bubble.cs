using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spineBox;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.parent == _spineBox)
        {
            _player.ShrinkBubble();
        }
    }
}
