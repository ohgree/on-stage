using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ScreenManager : MonoBehaviourPunCallbacks, IPunObservable {
    public int screenPage;
    
    Dictionary<string, int> filePage;
    public Sprite[] sprites;
    /*
        0 : black
        1 : image
        2~5 : ppt
    */

    bool[] leftEnd;
    bool[] rightEnd;

    void Start() {
        screenPage = 0;
        ChangeTexture(0);

        filePage = new Dictionary<string, int>();
        filePage["empty.jpg"] = 0;
        filePage["Logo.png"] = 1;
        filePage["EvenBetter.ppt"] = 2;
        
        leftEnd = new bool[34];
        rightEnd = new bool[34];
        leftEnd[0] = leftEnd[1] = leftEnd[2] = true;
        rightEnd[0] = rightEnd[1] = rightEnd[33] = true;

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting) {
            stream.SendNext(screenPage);
        }
        else {
            int receivePage = (int)stream.ReceiveNext();
            if(receivePage != screenPage)
                ChangeTexture(receivePage);
        }
    }

    void ChangeTexture(int index) {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[index];

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        int height = sprite.texture.height;
        transform.localScale = Vector3.one * (900f / height);
        
        screenPage = index;
    }

    public void OnFileUpload(string fileName) {
        if(!filePage.ContainsKey(fileName)) {
            return;
        }

        int newPage = filePage[fileName];

        if(newPage != screenPage)
            ChangeTexture(newPage);
    }

    void Update() {    
        int changePage = screenPage;
        if(Input.GetButtonDown("Slide Prev") && !leftEnd[screenPage])
            changePage--;
        else if(Input.GetButtonDown("Slide Next") && !rightEnd[screenPage])
            changePage++;
        
        if(changePage != screenPage)
            ChangeTexture(changePage);
    }
}
