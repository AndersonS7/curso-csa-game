using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float  timeAmount;

    private bool detectingPlayer;
    private PlayerItens player;
    private PlayerAnim playerAnim;

    private float timeCount;
    private bool isBigining;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            isBigining = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
        }

        if (isBigining)
        {
            timeAmount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectingPlayer = false;
    }
}
