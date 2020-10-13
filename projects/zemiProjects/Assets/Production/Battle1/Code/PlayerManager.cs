using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager> {

    //各種ステータス宣言
    public int AutoHealCount = 0;
    public int ManualHealCount = 0;
    public int CurrentPlayerHp;
    public int CurrentPlayerLv;
    public int CurrentPlayerAttack;
    public int CurrentPlayerabilitycount;
    public int StandbyPlayerHp;
    public int StandbyPlayerLv;
    public int StandbyPlayerAttack;
    public int StandbyPlayerabilitycount;
    public int SwapHp;
    public int SwapLv;
    public int SwapAttack;
    public int Swapabilitycount;
    public int LiliaHp;
    public int LiliaLv;
    public int LiliaAttack;
    public int LiliaAbilityCount;
    public int YuhHp;
    public int YuhLv;
    public int YuhAttack;
    public int YuhAbilityCount;
    public bool ToChange = false;
    public bool isYuhAbilityTriggered = false;
    //カットイン変数の定義
    private Animator anim;
    GameObject hpGauge;
    public Sprite GaugeGreen;
    public Sprite GaugeYellow;
    public Sprite GaugeRed;

    // Start is called before the first frame update
    void Start()
    {
        //カットインコンポーネント取得
        this.anim = GetComponent<Animator>();
        //リリア
        LiliaHp = 500;
        LiliaLv = 1;
        LiliaAttack = 120;
        LiliaAbilityCount = 0;

        //ユウ
        YuhHp = 400;
        YuhLv = 1;
        YuhAttack = 100;
        YuhAbilityCount = 0;

        CurrentPlayerHp = LiliaHp;
        CurrentPlayerLv = LiliaLv;
        CurrentPlayerAttack = LiliaAttack;
        CurrentPlayerabilitycount = LiliaAbilityCount;
        StandbyPlayerHp = YuhHp;
        StandbyPlayerLv = YuhLv;
        StandbyPlayerAttack = YuhAttack;
        StandbyPlayerabilitycount = YuhAbilityCount;

        //HPゲージ初期化
        this.hpGauge = GameObject.Find ("hpGauge");

    }
    //プレイヤー入れ替え
    public void PlayerSwap () {
        SwapHp = CurrentPlayerHp;
        SwapLv = CurrentPlayerLv;
        SwapAttack = CurrentPlayerAttack;
        Swapabilitycount = CurrentPlayerabilitycount;

        CurrentPlayerHp = StandbyPlayerHp;
        CurrentPlayerLv = StandbyPlayerLv;
        CurrentPlayerAttack = StandbyPlayerAttack;
        CurrentPlayerabilitycount = StandbyPlayerabilitycount;

        StandbyPlayerHp = SwapHp;
        StandbyPlayerLv = SwapLv;
        StandbyPlayerAttack = SwapAttack;
        StandbyPlayerabilitycount = Swapabilitycount;

        redrawHpgauge ();
    }
    //被弾処理
    public void DecreaseHp (int enemyattack) {
        //被弾時にコンボ値を変更できるようにする
        CurrentPlayerHp -= enemyattack;
        if (GameDirector.Instance.ToSpecialAttack == true) {
            GameDirector.Instance.ToSpecialAttack = false;
        }

        if (CurrentPlayerHp < 0 && StandbyPlayerHp < 0) {
            if (AutoHealCount < 0) {
                //自動回復発動
                if (PlayerManager.Instance.ToChange == false) {
                    PlayerManager.Instance.CurrentPlayerHp = PlayerManager.Instance.LiliaHp / 2;
                    PlayerManager.Instance.StandbyPlayerHp = PlayerManager.Instance.YuhHp / 2;
                    //カットイン処理
                    anim.SetTrigger("Space");
                }
                else
                {
                    PlayerManager.Instance.CurrentPlayerHp = PlayerManager.Instance.LiliaHp / 2;
                    PlayerManager.Instance.StandbyPlayerHp = PlayerManager.Instance.YuhHp / 2;
                    //カットイン処理
                    anim.SetTrigger("Space");
                }

            }
        } else {
            //ゲームオーバー
           FadeManager.Instance.LoadScene(gameover2,2.0f) SoundManager.Instance.PlaySeByName("Hidan_Player");
        }
        redrawHpgauge ();
    }

    //HPゲージ再描画
    public void redrawHpgauge () {
        float currentHp = 0.0f;
        float MaxHp = 0.0f;
        float hpGaugeFill = 0.0f;
        Image GaugeImage;
        GaugeImage = this.hpGauge.GetComponent<Image> ();

        currentHp = (float) CurrentPlayerHp;
        if (ToChange == false) {
            MaxHp = LiliaHp;
        } else {
            MaxHp = YuhHp;
        }
        hpGaugeFill = currentHp / MaxHp;
        Debug.Log (hpGaugeFill);
        GaugeImage.fillAmount = hpGaugeFill;

        if (hpGaugeFill >= 0.5f) {
            GaugeImage.sprite = GaugeGreen;
        } else if (hpGaugeFill >= 0.25f) {
            GaugeImage.sprite = GaugeYellow;
        } else {
            GaugeImage.sprite = GaugeRed;
            SoundManager.Instance.PlaySeByName("HPalert");
        }
    }
}