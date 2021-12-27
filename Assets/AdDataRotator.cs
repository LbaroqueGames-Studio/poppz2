using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdDataRotator : MonoBehaviour
{
    public string[] interRotatedData;
    public string levelStartInter;
    public string levelWinInter;
    public string levelLooseInter;
    private int lastIndex;
  
  
    // Start is called before the first frame update
    void Start()
    {
        lastIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string _getLevelStartInter()
    {
        return levelStartInter;
    }
    public string _getLevelWinInter()
    {
        return levelWinInter;
    }
    public string _getLevelLooseInter()
    {
        return levelLooseInter;
    }
    public string getMiddleInterData()
    {
        int lenght = interRotatedData.Length;
        int index=randomIndex(0,lenght);
        while (index == lastIndex)
        {
            index= randomIndex(0, lenght);
        }
        lastIndex = index;
        print("current Ad Placement Index" + lastIndex);
        return interRotatedData[lastIndex];
    }
    public int randomIndex(int start , int end)
    {
        return Random.Range(start,end);
    }
}
