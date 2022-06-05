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

    //int[] prevPage = {0, 0, 1, 2, 3, 4};
    //int[] nextPage = {1, 2, 3, 4, 5, 5};

    int[] prevPage = {0, 1, 2, 2, 3, 4};
    int[] nextPage = {0, 1, 3, 4, 5, 5};

    void Start() {
        screenPage = 0;
        ChangeTexture(0);

        filePage = new Dictionary<string, int>();
        filePage["empty.jpg"] = 0;
        filePage["sample_image.jpg"] = 1;
        filePage["sample_ppt.ppt"] = 2;
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
        if(Input.GetButtonDown("Slide Prev"))
            changePage = prevPage[screenPage];
        else if(Input.GetButtonDown("Slide Next"))
            changePage = nextPage[screenPage];
        
        if(changePage != screenPage)
            ChangeTexture(changePage);
    }
}
