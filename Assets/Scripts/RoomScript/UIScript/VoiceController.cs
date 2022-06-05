using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Realtime;
using Photon.Chat;
public class VoiceController : MonoBehaviourPun
{
    // Start is called before the first frame update
    public GameObject button;
    public GameObject voiceManager;
    bool isMute = false;
    
    
    public void OnClickMuteAll(){
        voiceManager.GetComponent<Recorder>().TransmitEnabled = isMute;
        isMute = !isMute;
    }
}
