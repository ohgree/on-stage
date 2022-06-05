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

    int[] prevPage = {0, 0, 1, 2, 3, 4};
    int[] nextPage = {1, 2, 3, 4, 5, 5};

    //int[] prevPage = {0, 1, 2, 2, 3, 4};
    //int[] nextPage = {0, 1, 3, 4, 5, 5};

    void Start() {
        screenPage = 0;

        filePage = new Dictionary<string, int >();
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

    private void ChangeTexture(int index) {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[index];

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        int height = sprite.texture.height;
        transform.localScale = Vector3.one * (900f / height);
        
        screenPage = index;
    }

    void Update() {
        /*if(!PhotonNetwork.IsMasterClient) {
            return;
        }*/
    
        int changePage = screenPage;
        if(Input.GetButtonDown("Slide Prev"))
            changePage = prevPage[screenPage];
        else if(Input.GetButtonDown("Slide Next"))
            changePage = nextPage[screenPage];
        
        if(changePage != screenPage)
            ChangeTexture(changePage);
    }
}
