using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EmojiMenuTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject emojiSelectMenu;
    public GameObject emojiSelectEnableButton;
    bool visible;
    int emojiIndex;
    void Start()
    {
        visible = false;
        emojiSelectEnableButton.SetActive(!visible);
        emojiSelectMenu.SetActive(visible);
    }
    // Update is called once per frame
    public void OnClickEmojiSelectEnableButton(){
        visible = true;
        emojiSelectMenu.SetActive(visible);
    }

    public void OnClickEmojiButton01(){
        emojiIndex = 0;
        Debug.Log("Emoji index =" + emojiIndex);
    }
    public void OnClickEmojiButton02(){
        emojiIndex = 1;
        Debug.Log("Emoji index =" + emojiIndex);
    }
    public void OnClickEmojiButton03(){
        emojiIndex = 2;
        Debug.Log("Emoji index =" + emojiIndex);
    }
    public void OnClickEmojiButton04(){
        emojiIndex = 3;
        Debug.Log("Emoji index =" + emojiIndex);
    }
    public void OnClickEmojiButton05(){
        emojiIndex = 4;
        Debug.Log("Emoji index =" + emojiIndex);
    }
    public void OnClickEmojiButton06(){
        emojiIndex = 5;
        Debug.Log("Emoji index =" + emojiIndex);
    }

    public void OnClickCancelButton(){
        visible = false;
        emojiSelectMenu.SetActive(visible);
        emojiSelectEnableButton.SetActive(!visible);   
    }
}
