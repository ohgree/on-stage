using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour {
  public Sprite[] sprites;
  private int index;

  private void ChangeTexture(int index) {
    if (index < 0 || sprites.Length <= index) {
      return;
    }
    SpriteRenderer renderer = GetComponent<SpriteRenderer>();
    renderer.sprite = sprites[index];

    Sprite sprite = GetComponent<SpriteRenderer>().sprite;
    int height = sprite.texture.height;
    transform.localScale = Vector3.one * (900f / height);
    this.index = index;
  }

  // Start is called before the first frame update
  void Start() {
    ChangeTexture(0);
  }

  // Update is called once per frame
  void Update() {
    int newIndex = this.index;
    newIndex += Input.GetButtonDown("Slide Next") ? 1 : 0;
    newIndex -= Input.GetButtonDown("Slide Prev") ? 1 : 0;
    ChangeTexture(newIndex);
  }
}
