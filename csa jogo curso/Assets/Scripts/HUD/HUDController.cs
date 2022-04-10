using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;

    public List<Image> toolsUI = new List<Image>();

    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItens playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItens>();
        player = playerItems.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0;
        woodUIBar.fillAmount = 0;
        carrotUIBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.carrots/ playerItems.carrotsLimit;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
