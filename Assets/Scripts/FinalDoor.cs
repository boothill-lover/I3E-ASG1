using UnityEngine;
using TMPro;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private TMP_Text scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        victoryUI.SetActive(true);

        scoreText.text = "you win! congratulations score: " + GameManager.totalScore;
    }
}