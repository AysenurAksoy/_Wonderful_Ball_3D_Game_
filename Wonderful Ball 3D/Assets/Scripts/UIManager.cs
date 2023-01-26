using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;
    private bool radialshine;

    public SoundManager sounds;
    
    
    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinishLine;

    public Animator LayoutAnimator;

    public Text coin_text; 

    //butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Background;
    public GameObject sound_Open;
    public GameObject sound_Closed;
    public GameObject vibration_Open;
    public GameObject vibration_Closed;
    public GameObject information;

    public GameObject intro_Hand;
    public GameObject taptomove_Text;
    public GameObject shop_Button;

    public GameObject RestartScreen;

    //Oyun sonu Ekrani
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject nothanks;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public Text achievedText;

    public void Start()
    {
        if(PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if(PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        CoinTextUpdate();
    }

    public void Update()
    {
        if (radialshine == true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f * Time.deltaTime));
        }

        FillRateImage.fillAmount = (Player.transform.position.z) / (FinishLine.transform.position.z);
    }
    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        taptomove_Text.SetActive(false);
        shop_Button.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Background.SetActive(false);
        sound_Open.SetActive(false);
        sound_Closed.SetActive(false);
        vibration_Open.SetActive(false);
        vibration_Closed.SetActive(false);
        information.SetActive(false);

    }

    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }
    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

    }

    public void NextScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

        
    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radialshine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true); 
        yield return new WaitForSecondsRealtime(0.8f);
        complete.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        sounds.CompleteSound();
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(3f);
        nothanks.SetActive(true);
    }

    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedText.gameObject.SetActive(true);
        for (int i = 0; i <= 800; i += 8)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.000001f);
        }
        rewarded.SetActive(false);
        nothanks.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);

      
        
        
    }

    //buton fonksiyonlarý
    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");

        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_Open.SetActive(true);
            sound_Closed.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_Open.SetActive(false);
            sound_Closed.SetActive(true);
            AudioListener.volume = 0;
        }
         if (PlayerPrefs.GetInt("Vibration")== 2)
        {
            vibration_Open.SetActive(false);
            vibration_Closed.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_Open.SetActive(true);
            vibration_Closed.SetActive(false);
        }
    }

    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");
    }

    public void Sound_Open()
    {
        sound_Open.SetActive(false);
        sound_Closed.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_Closed()
    {
        sound_Open.SetActive(true);
        sound_Closed.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);

    }

    public void Vibration_Open()
    {
        vibration_Open.SetActive(false);
        vibration_Closed.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);

    }

    public void Vibration_Closed()
    {
        vibration_Open.SetActive(true);
        vibration_Closed.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);

    }


    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
            {
                effectcontrol = 1;
            }
        }
      
        while (effectcontrol== 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if(whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }

        if(effectcontrol == 2)
        {
            Debug.Log("Efekt bitti");
        }

    }
}
