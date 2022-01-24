using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateManager : MinigameManager
{
    bool btnPressing;
    Vector3 positition;

    public SpriteRenderer renderer;
    public List<Sprite> DogSprites;

    public bool isGameOver;

    private void Awake()
    {
        switch (GameManager.Instance.Level)
        {
            case 1:
                TimerTime = 10;
                break;
            case 2:
                TimerTime = 8;
                break;
            default:
                TimerTime = 5;
                break;
        }
    }
    private void Start()
    {

    }

    void Update()
    {
        MouseDragDect();
    }

    private void MouseDragDect()
    {
        if (!isGameOver)
        {

            if (Input.GetMouseButtonDown(0))
            {
                btnPressing = true;
                positition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (positition.x - 2 > Input.mousePosition.x)
                {
                    renderer.sprite = DogSprites[2];
                    SoundManager.Instance.PlaySound("dog");
                    StartCoroutine(FindObjectOfType<ChocolateDog>().OnDrag());

                }

            }
        }
    }

    public override IEnumerator GameOver()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator GameClear()
    {
        throw new System.NotImplementedException();
    }
}
