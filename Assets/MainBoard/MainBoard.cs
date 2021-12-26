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
        
        //이 밑에 코드에 GoGame를 지우고 씬 이름 넣으면 그곳으로 이동!
        SceneManager.LoadScene("GoGame");
        
    }

  
}
