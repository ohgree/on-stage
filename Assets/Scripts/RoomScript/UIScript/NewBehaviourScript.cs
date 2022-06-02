
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Windows.Forms;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // InitializeComponent(); 

    }

    //public string ShowFileOpenDialog()
    public void ShowFileOpenDialog()
    {
        //파일오픈창 생성 및 설정
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "파일 오픈 예제창";
        ofd.FileName = "test";
        ofd.Filter = "그림 파일 (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

        //파일 오픈창 로드
        DialogResult dr = ofd.ShowDialog();
            
        //OK버튼 클릭시
        if (dr == DialogResult.OK)
        {
            //File명과 확장자를 가지고 온다.
            string fileName = ofd.SafeFileName;
            //File경로와 File명을 모두 가지고 온다.
            string fileFullName = ofd.FileName;
            //File경로만 가지고 온다.
            string filePath = fileFullName.Replace(fileName, "");

            //출력 예제용 로직
            //label1.Text = "File Name  : " + fileName;
            //label2.Text = "Full Name  : " + fileFullName;
            //label3.Text = "File Path  : " + filePath;
            //File경로 + 파일명 리턴
            //return fileFullName;
            return ;
        }
        //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
        else if (dr == DialogResult.Cancel)
        {
            return ;
        }

        return ;
    }
}