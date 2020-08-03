using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Animator settingsButtonsAnim;

    private bool hidden;
    private bool canTouchSettingsButtons;

    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicBtnSprites;

    [SerializeField]
    private Button fbBtn;

    [SerializeField]
    private Sprite[] fbSprites;

    [SerializeField]
    private GameObject infoPanel;

    [SerializeField]
    private Image infoImage;

    [SerializeField]
    private Sprite[] infoSprites;

    private int infoIndex;

    // Start is called before the first frame update
    void Start()
    {
        canTouchSettingsButtons = true;
        hidden = true;

        if (GameController.instance.isMusicOn)
        {
            musicButton.image.sprite = musicBtnSprites[1];
        }
        else
        {
            musicButton.image.sprite = musicBtnSprites[0];
        }

        infoIndex = 0;
        infoImage.sprite = infoSprites[infoIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingsButton()
    {
        StartCoroutine(DisableSettingsButtonWhilePlayingAnimation());
    }

    IEnumerator DisableSettingsButtonWhilePlayingAnimation()
    {
        if (canTouchSettingsButtons)
        {
            if (hidden)
            {
                canTouchSettingsButtons = false;
                settingsButtonsAnim.Play("SlideIn");
                hidden = false;
                yield return new WaitForSeconds(1.2f);
                canTouchSettingsButtons = true;
            }
            else
            {
                canTouchSettingsButtons = false;
                settingsButtonsAnim.Play("SlideOut");
                hidden = true;
                yield return new WaitForSeconds(1.2f);
                canTouchSettingsButtons = true;
            }
        }
    }

    public void MusicButton()
    {
        if(GameController.instance.isMusicOn)
        {
            musicButton.image.sprite = musicBtnSprites[0];
            GameController.instance.isMusicOn = false;
            GameController.instance.Save();
        }
        else
        {
            musicButton.image.sprite = musicBtnSprites[1];
            GameController.instance.isMusicOn = true;
            GameController.instance.Save();
        }
    }

    public void OpenInfoPanel()
    {
        infoPanel.SetActive(true);
    }
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
    public void NextInfo()
    {
        infoIndex++;

        if (infoIndex == infoSprites.Length)
        {
            infoIndex = 0;
        }

        infoImage.sprite = infoSprites[infoIndex];
    }
}
