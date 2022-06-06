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

    public void OnClickEmojiButton(int index) {
        emojiIndex = index;
        Debug.Log("Emoji index =" + emojiIndex);
    }

    public void OnClickCancelButton(){
        visible = false;
        emojiSelectMenu.SetActive(visible);
        emojiSelectEnableButton.SetActive(!visible);   
    }
}
