using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Windows.Forms;
using System.IO;

public class FileUpload : MonoBehaviour
{
    public GameObject SM;

    public void ShowFileOpenDialog()
    {
        OpenFileDialog Fileopen = new OpenFileDialog();
        Fileopen.Title = "File Uploader";
        Fileopen.Filter = "PPT, PDF 파일 (*.pdf, *.ppt, *pptx)|*.pdf; *.ppt; *pptx;| 그림 파일 (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";
        
        DialogResult dr = Fileopen.ShowDialog();
        
        if (dr == DialogResult.OK) {//ok 버튼 클릭시
            string fileName = Fileopen.SafeFileName;
            SM.GetComponent<ScreenManager>().OnFileUpload(fileName);
        }
    }
}