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
        
        Debug.Log("Ȯ�� gogo");
        
        //�� �ؿ� �ڵ忡 GoGame�� ����� �� �̸� ������ �װ����� �̵�!
        SceneManager.LoadScene("GoGame");
        
    }

  
}
