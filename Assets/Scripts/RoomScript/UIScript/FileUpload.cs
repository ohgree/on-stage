using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Windows.Forms;

public class FileUpload : MonoBehaviour
{
    public void ShowFileOpenDialog()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "File Uploader";
        ofd.Filter = "그림 파일 (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

        DialogResult dr = ofd.ShowDialog();
        
        if (dr == DialogResult.OK) {
            string fileName = ofd.SafeFileName; // name.extender
            string fileFullName = ofd.FileName; // path/name.extender
            string filePath = fileFullName.Replace(fileName, ""); // path
        }
        else if (dr == DialogResult.Cancel) {
            //
        }
    }
}