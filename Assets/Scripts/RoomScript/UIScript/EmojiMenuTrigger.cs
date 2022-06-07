using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EmojiMenuTrigger : MonoBehaviour
{
    public GameObject emojiSelectMenu;
    public GameObject emojiSelectEnableButton;
    bool visible;
    void Start()
    {
        visible = false;
        emojiSelectEnableButton.SetActive(!visible);
        emojiSelectMenu.SetActive(visible);
    }
    public void OnClickEmojiSelectEnableButton(){
        visible = true;
        emojiSelectMenu.SetActive(visible);
    }

    public void OnClickEmojiButton(int index) {
        Debug.Log("Emoji index =" + index);
    }

    public void OnClickCancelButton(){
        visible = false;
        emojiSelectMenu.SetActive(visible);
        emojiSelectEnableButton.SetActive(!visible);   
    }
}
