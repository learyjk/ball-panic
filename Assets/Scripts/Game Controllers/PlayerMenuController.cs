using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    public Text scoreText, coinText;

    //track players unlocked
    public bool[] players;

    //track unlocked weapons
    public bool[] weapons;

    //Price tag image over locked players
    public Image[] priceTags;

    //Indicates which player is selected
    public Image[] weaponIcons;

    //store weapon selection sprites
    public Sprite[] weaponArrows;

    //keep track which weapon is selected
    public int selectedWeapon;

    public int selectedPlayer;

    public GameObject buyPlayerPanel;

    public Button yesBtn;

    public Text buyPlayerText;

    public GameObject coinShop;


    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerMenuController();
    }

    void InitializePlayerMenuController()
    {
        scoreText.text = GameController.instance.highScore.ToString();
        coinText.text = GameController.instance.coins.ToString();

        players = GameController.instance.players;
        weapons = GameController.instance.weapons;
        selectedWeapon = GameController.instance.selectedWeapon;
        selectedPlayer = GameController.instance.selectedPlayer;

        for (int i = 0; i < weaponIcons.Length; i++)
        {
            //deactivate all because it indicates player selection
            weaponIcons[i].gameObject.SetActive(false);
        }
        for (int i = 1; i < players.Length; i++)
        {
            if (players[i] == true) // player is unlocked.
            {
                priceTags[i - 1].gameObject.SetActive(false);
            }
        }

        //Indicate selected player
        weaponIcons[selectedPlayer].gameObject.SetActive(true);
        weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];


    }

    public void Player1Button()
    {
        if (selectedPlayer != 0)
        {
            selectedPlayer = 0;
            selectedWeapon = 0;

            weaponIcons[selectedPlayer].gameObject.SetActive(true);
            weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];

            for (int i = 0; i < weaponIcons.Length; i++)
            {
                if (i == selectedPlayer)
                    continue; //skips rest of loop and reiterate.

                weaponIcons[i].gameObject.SetActive(false);
            }

            GameController.instance.selectedPlayer = selectedPlayer;
            GameController.instance.selectedWeapon = selectedWeapon;
            GameController.instance.Save();
        }
        else
        {
            selectedWeapon++;

            if (selectedWeapon == weapons.Length)
            {
                selectedWeapon = 0;
            }

            bool foundWeapon = true;

            while (foundWeapon)
            {
                if (weapons[selectedWeapon] == true) //weapon is unlocked
                {
                    weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];
                    GameController.instance.selectedWeapon = selectedWeapon;
                    GameController.instance.Save();
                    foundWeapon = false;
                }
                else
                {
                    selectedWeapon++;

                    if (selectedWeapon == weapons.Length)
                    {
                        selectedWeapon = 0;
                    }
                }
            }
        }
    }

    public void PiratePlayerButton()
    {
        if (players[1] == true) //This player is unlocked.
        {
            if (selectedPlayer != 1)
            {
                selectedPlayer = 1;
                selectedWeapon = 0;

                weaponIcons[selectedPlayer].gameObject.SetActive(true);
                weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];

                for (int i = 0; i < weaponIcons.Length; i++)
                {
                    if (i == selectedPlayer)
                        continue; //skips rest of loop and reiterate.

                    weaponIcons[i].gameObject.SetActive(false);
                }

                GameController.instance.selectedPlayer = selectedPlayer;
                GameController.instance.selectedWeapon = selectedWeapon;
                GameController.instance.Save();
            }
            else
            {
                selectedWeapon++;

                if (selectedWeapon == weapons.Length)
                {
                    selectedWeapon = 0;
                }

                bool foundWeapon = true;

                while (foundWeapon)
                {
                    if (weapons[selectedWeapon] == true) //weapon is unlocked
                    {
                        weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];
                        GameController.instance.selectedWeapon = selectedWeapon;
                        GameController.instance.Save();
                        foundWeapon = false;
                    }
                    else
                    {
                        selectedWeapon++;

                        if (selectedWeapon == weapons.Length)
                        {
                            selectedWeapon = 0;
                        }
                    }
                }
            }
        }
        else
        {
            //try to buy this player
            if (GameController.instance.coins >= 7000)
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do you want to purchase the player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(1));
            }
            else
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You don't have enough coins! Purchase coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => openCoinShop());

            }
        }
    }

    public void ZombiePlayerButton()
    {
        if (players[2] == true) //This player is unlocked.
        {
            if (selectedPlayer != 2)
            {
                selectedPlayer = 2;
                selectedWeapon = 0;

                weaponIcons[selectedPlayer].gameObject.SetActive(true);
                weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];

                for (int i = 0; i < weaponIcons.Length; i++)
                {
                    if (i == selectedPlayer)
                        continue; //skips rest of loop and reiterate.

                    weaponIcons[i].gameObject.SetActive(false);
                }

                GameController.instance.selectedPlayer = selectedPlayer;
                GameController.instance.selectedWeapon = selectedWeapon;
                GameController.instance.Save();
            }
            else
            {
                selectedWeapon++;

                if (selectedWeapon == weapons.Length)
                {
                    selectedWeapon = 0;
                }

                bool foundWeapon = true;

                while (foundWeapon)
                {
                    if (weapons[selectedWeapon] == true) //weapon is unlocked
                    {
                        weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];
                        GameController.instance.selectedWeapon = selectedWeapon;
                        GameController.instance.Save();
                        foundWeapon = false;
                    }
                    else
                    {
                        selectedWeapon++;

                        if (selectedWeapon == weapons.Length)
                        {
                            selectedWeapon = 0;
                        }
                    }
                }
            }
        }
        else
        {
            //try to buy this player
            if (GameController.instance.coins >= 7000)
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do you want to purchase the player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(2));
            }
            else
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You don't have enough coins! Purchase coins?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => openCoinShop());

            }
        }
    }

    public void HomosapienPlayerButton()
    {
        if (players[3] == true) //This player is unlocked.
        {
            if (selectedPlayer != 3)
            {
                selectedPlayer = 3;
                selectedWeapon = 0;

                weaponIcons[selectedPlayer].gameObject.SetActive(true);
                weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];

                for (int i = 0; i < weaponIcons.Length; i++)
                {
                    if (i == selectedPlayer)
                        continue; //skips rest of loop and reiterate.

                    weaponIcons[i].gameObject.SetActive(false);
                }

                GameController.instance.selectedPlayer = selectedPlayer;
                GameController.instance.selectedWeapon = selectedWeapon;
                GameController.instance.Save();
            }
            else
            {
                selectedWeapon++;

                if (selectedWeapon == weapons.Length)
                {
                    selectedWeapon = 0;
                }

                bool foundWeapon = true;

                while (foundWeapon)
                {
                    if (weapons[selectedWeapon] == true) //weapon is unlocked
                    {
                        weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];
                        GameController.instance.selectedWeapon = selectedWeapon;
                        GameController.instance.Save();
                        foundWeapon = false;
                    }
                    else
                    {
                        selectedWeapon++;

                        if (selectedWeapon == weapons.Length)
                        {
                            selectedWeapon = 0;
                        }
                    }
                }
            }
        }
        else
        {
            //try to buy this player
            if (GameController.instance.coins >= 7000)
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do you want to purchase the player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(3));
            }
            else
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You don't have enough coins! Purchase coins?";
                yesBtn.onClick.RemoveAllListeners();
                //yesBtn.onClick.AddListener(() => BuyPlayer(1));

            }
        }
    }

    public void JokerPlayerButton()
    {
        if (players[4] == true) //This player is unlocked.
        {
            if (selectedPlayer != 4)
            {
                selectedPlayer = 4;
                selectedWeapon = 0;

                weaponIcons[selectedPlayer].gameObject.SetActive(true);
                weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];

                for (int i = 0; i < weaponIcons.Length; i++)
                {
                    if (i == selectedPlayer)
                        continue; //skips rest of loop and reiterate.

                    weaponIcons[i].gameObject.SetActive(false);
                }

                GameController.instance.selectedPlayer = selectedPlayer;
                GameController.instance.selectedWeapon = selectedWeapon;
                GameController.instance.Save();
            }
            else
            {
                selectedWeapon++;

                if (selectedWeapon == weapons.Length)
                {
                    selectedWeapon = 0;
                }

                bool foundWeapon = true;

                while (foundWeapon)
                {
                    if (weapons[selectedWeapon] == true) //weapon is unlocked
                    {
                        weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];
                        GameController.instance.selectedWeapon = selectedWeapon;
                        GameController.instance.Save();
                        foundWeapon = false;
                    }
                    else
                    {
                        selectedWeapon++;

                        if (selectedWeapon == weapons.Length)
                        {
                            selectedWeapon = 0;
                        }
                    }
                }
            }
        }
        else
        {
            //try to buy this player
            if (GameController.instance.coins >= 7000)
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do you want to purchase the player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(4));
            }
            else
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You don't have enough coins! Purchase coins?";
                yesBtn.onClick.RemoveAllListeners();
                //yesBtn.onClick.AddListener(() => BuyPlayer(1));

            }
        }
    }

    public void SpartanPlayerButton()
    {
        if (players[5] == true) //This player is unlocked.
        {
            if (selectedPlayer != 5)
            {
                selectedPlayer = 5;
                selectedWeapon = 0;

                weaponIcons[selectedPlayer].gameObject.SetActive(true);
                weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];

                for (int i = 0; i < weaponIcons.Length; i++)
                {
                    if (i == selectedPlayer)
                        continue; //skips rest of loop and reiterate.

                    weaponIcons[i].gameObject.SetActive(false);
                }

                GameController.instance.selectedPlayer = selectedPlayer;
                GameController.instance.selectedWeapon = selectedWeapon;
                GameController.instance.Save();
            }
            else
            {
                selectedWeapon++;

                if (selectedWeapon == weapons.Length)
                {
                    selectedWeapon = 0;
                }

                bool foundWeapon = true;

                while (foundWeapon)
                {
                    if (weapons[selectedWeapon] == true) //weapon is unlocked
                    {
                        weaponIcons[selectedPlayer].sprite = weaponArrows[selectedWeapon];
                        GameController.instance.selectedWeapon = selectedWeapon;
                        GameController.instance.Save();
                        foundWeapon = false;
                    }
                    else
                    {
                        selectedWeapon++;

                        if (selectedWeapon == weapons.Length)
                        {
                            selectedWeapon = 0;
                        }
                    }
                }
            }
        }
        else
        {
            //try to buy this player
            if (GameController.instance.coins >= 7000)
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "Do you want to purchase the player?";
                yesBtn.onClick.RemoveAllListeners();
                yesBtn.onClick.AddListener(() => BuyPlayer(5));
            }
            else
            {
                buyPlayerPanel.SetActive(true);
                buyPlayerText.text = "You don't have enough coins! Purchase coins?";
                yesBtn.onClick.RemoveAllListeners();
                //yesBtn.onClick.AddListener(() => BuyPlayer(1));

            }
        }
    }

    public void DontBuyPlayerOrCoins()
    {
        buyPlayerPanel.SetActive(false);
    }

    public void GotoLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void openCoinShop()
    {
        if (buyPlayerPanel.activeInHierarchy)
        {
            buyPlayerPanel.SetActive(false);
        }
        coinShop.SetActive(true);
    }

    public void CloseCoinShop()
    {
        coinShop.SetActive(false);
    }

    public void BuyPlayer(int index)
    {
        GameController.instance.players[index] = true;
        GameController.instance.coins -= 7000;
        GameController.instance.Save();
        InitializePlayerMenuController(); //removes the pricetag from the purchased player

        buyPlayerPanel.SetActive(false);
    }
}
