using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuController : MonoBehaviour
{
    public static ShopMenuController instance;

    public Text coinText, scoreText, buyArrowsText, watchVideoText;

    public Button weaponsTabBtn, specialTabBtn, earnCoinsTabBtn, yesBtn;

    public GameObject weaponItemsPanel, specialItemsPanel, earnCoinsItemsPanel, coinShopPanel, buyArrowsPanel;

    private void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        InitializeShopMenuController();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void BuyDoubleArrows()
    {

    }

    void InitializeShopMenuController()
    {
        coinText.text = GameController.instance.coins.ToString();
        scoreText.text = GameController.instance.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCoinShop()
    {
        coinShopPanel.SetActive(true);
    }

    public void CloseCoinShop()
    {
        coinShopPanel.SetActive(false);
    }

    public void OpenWeaponItemsPanel()
    {

    }
}
