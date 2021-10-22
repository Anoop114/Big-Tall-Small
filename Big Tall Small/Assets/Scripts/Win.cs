using UnityEngine;

public class Win : MonoBehaviour
{
    [Header("Reference")]
    public GameObject uiCard;
    public PlayerMovnment player;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Win"))
        {
            player.winCount = player.winCount-1;
            uiCard.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
