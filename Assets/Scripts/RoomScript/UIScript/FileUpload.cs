using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Windows.Forms;
using System.IO;

public class FileUpload : MonoBehaviour
{
    public void ShowFileOpenDialog()
    {
        OpenFileDialog Fileopen = new OpenFileDialog();
        Fileopen.Title = "File Uploader";
        Fileopen.Filter = "PPT, PDF 파일 (*.pdf, *.ppt, *pptx)|*.pdf; *.ppt; *pptx;| 그림 파일 (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";
        /*
            UnityEngine.Application.dataPath : Asset까지의 dataPath string으로 반환
            filePath = 내가 열 파일 디렉토리의 절대경로
            fileFullPath = 내가 열 파일의 절대경로
        */
        
        DialogResult dr = Fileopen.ShowDialog();
        Debug.Log("Showing Dialog");

        if (dr == DialogResult.OK) {//ok 버튼 클릭시
            string fileName = Fileopen.SafeFileName; // name.extender
            string fileFullName = Fileopen.FileName; // path/name.extender
            string filePath = fileFullName.Replace(fileName, ""); // path
            Debug.Log("filePath : " + filePath);
            Debug.Log("fileFullName : " + fileFullName);
            File.Copy(fileFullName, UnityEngine.Application.dataPath + "/Images/" + fileName);
        }
    }
}