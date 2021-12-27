using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoGame()
    {
        
        Debug.Log("확인 gogo");

        //이부분 수정 필요           시작 함수를 따로 만들자
        GameManager.Instance.GameStart();
    }


}
