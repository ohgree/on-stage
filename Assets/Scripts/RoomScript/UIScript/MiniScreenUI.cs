using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniScreenUI : MonoBehaviour
{
    public GameObject mainProjector;
    public GameObject miniScreen;
    public GameObject miniScreenBackground;
    int screenIndex;

    void Start()
    {
        miniScreen.GetComponent<Image>().color = new Color(1,1,1,0);
        miniScreenBackground.GetComponentInParent<Image>().enabled = false;
        screenIndex = 0;
    }

    void Update()
    {
        ScreenManager SM = mainProjector.GetComponent<ScreenManager>();
        int tempIndex = SM.screenPage; 
        Image miniScreenImage = miniScreen.GetComponent<Image>();
        
        if(screenIndex == tempIndex)
            return;
        
        screenIndex = tempIndex;
        if(screenIndex == 0 ){
            miniScreenImage.color = new Color(1,1,1,0);
            miniScreenBackground.GetComponentInParent<Image>().enabled = false;
        }
        else{
            miniScreenImage.color = new Color(1,1,1, 0.7f);
            miniScreenBackground.GetComponentInParent<Image>().enabled = true;
        }
        miniScreenImage.sprite = mainProjector.GetComponent<SpriteRenderer>().sprite;

    }
}
