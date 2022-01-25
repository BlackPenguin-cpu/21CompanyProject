using System.Collections;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    public Camera CAM;
    public GameObject cube;
    public bool isclick = false;
    public GameObject human;
    public GameObject BigLight;
    public GameObject Light;
    public Material HumanAlpha;
    public GameObject FunElephant;
    public float LimitSecond = 12;
    public bool TimerStop = false;
    private bool isEnd = true;
    void Start()
    {
        MeshRenderer mr;
        GameObject.Find("Cube").TryGetComponent(out mr);
        mr.sharedMaterial.color = Color.white;
    }

    void Update()
    {
        Cursor();
        if (TimerStop == false)
        {
            Timer();
        }

        if (isclick && isEnd)
        {
            GameWin();
            isEnd = false;
            isclick = false;
        }

        if (LimitSecond <= 0 && isEnd)
        {
            GameOver();
            isEnd = false;
        }
    }



    public IEnumerator GameClear()
    {
        Light.GetComponent<Light>().range = 0;
        BigLight.SetActive(true);
        MeshRenderer mr;
        GameObject.Find("Cube").TryGetComponent(out mr);
        yield return StartCoroutine(EColorChange(HumanAlpha, Color.clear));
        yield return new WaitForSeconds(2);
    }

    void Cursor()
    {
        Vector3 mouse = CAM.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        transform.position = mouse;

        RaycastHit2D[] hitobject = Physics2D.RaycastAll(mouse, Vector3.forward);
        foreach (var item in hitobject)
        {
            if (item.collider.gameObject.tag == "Human" && Input.GetMouseButtonUp(0))
            {
                human = item.collider.gameObject;
                isclick = true;
                TimerStop = true;
            }
        }

    }
    private IEnumerator EColorChange(Material img, Color newColor)
    {
        var wait = new WaitForSeconds(0.01f);
        while (Mathf.Abs(img.color.r - newColor.r)
            + Mathf.Abs(img.color.g - newColor.g)
            + Mathf.Abs(img.color.b - newColor.b)
            + Mathf.Abs(img.color.a - newColor.a) >= 0.05f)
        {
            img.color = Color.Lerp(img.color, newColor, Time.deltaTime * 5);
            yield return wait;
        }
        FunElephant.SetActive(true);
    }
    
    void Timer()
    {
        LimitSecond -= Time.deltaTime;
    }

    void GameWin()
    {
        StartCoroutine(GameManager.Instance.ChangeScene(true, GameClear()));
    }

    void GameOver()
    {
        StartCoroutine(GameManager.Instance.ChangeScene(false, 2f));
    }
}
