using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Wait,Playing,End}
public class AdManager : MonoBehaviour
{
    //References
    public static AdManager _Instance;
    public AdDataRotator adRotator;
    public AdController adController;

    public bool useTimedAds;
    public Vector2 adsClamp;
    public float offset;
    private float lastTimeAdsShown;

    public GameState currentGameState;
    private void Awake()
    {
        if (!_Instance) _Instance = this;
        else if (_Instance != this) Destroy(this.gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        if (adRotator == null)
            adRotator = this.GetComponentInChildren<AdDataRotator>();
        
        if (adController == null)
            adController = this.GetComponentInChildren<AdController>();


        offset = Random.Range(adsClamp.x, adsClamp.y);
        lastTimeAdsShown += (Time.time+offset);
        startPlay();
        adController.setMidInterAdUnitId(getMiddleInterData());
        adController.LoadAd();
        adController.ShowAdInterAd();
        Invoke("firstGameInvoke",5f);
    }
    private void firstGameInvoke()
    {
        adController.ShowAdInterAd();

    }
    // Update is called once per frame
    void Update()
    {
        if (useTimedAds && isPlaying())
        {
            if (Time.time > lastTimeAdsShown)
            {
                offset = Random.Range(adsClamp.x,adsClamp.y);
                lastTimeAdsShown = (Time.time + offset);
                adController.ShowAdInterAd();
                adController.setMidInterAdUnitId(getMiddleInterData());
                adController.LoadAd();

            }
        }
    }
    public string getMiddleInterData()
    {
        return adRotator.getMiddleInterData();
    }
    public string getLevelStartInterData()
    {
        return adRotator._getLevelStartInter();
    }
    public string getLevelLooseInterData()
    {
        return adRotator._getLevelLooseInter();
    }
    public string getLevelWinInterData()
    {
        return adRotator._getLevelWinInter();
    }
    public void showMidInterAd()
    {
        adController.ShowAdInterAd();
        adController.setMidInterAdUnitId(getMiddleInterData());
        adController.LoadAd();
    }
    public void showLevelStartInter()
    {
       
        adController.setMidInterAdUnitId(getLevelStartInterData());
        adController.LoadAd();

        adController.ShowAdInterAd();
    }
    public void showLevelLooseInter()
    {
        adController.setMidInterAdUnitId(getLevelLooseInterData());
        adController.LoadAd();
        adController.ShowAdInterAd();
    }
    public void showLevelWinInter()
    {
        adController.setMidInterAdUnitId(getLevelWinInterData());
        adController.LoadAd();
        adController.ShowAdInterAd();
    }
    public void startPlay()
    {
        currentGameState = GameState.Playing;
    }
    public void endPlaying()
    {
        currentGameState = GameState.End;

    }
    public bool isPlaying()
    {
        return currentGameState == GameState.Playing;
    }
   
}
