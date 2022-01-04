using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateManager : Singleton<ChocolateManager>
{
    bool btnPressing;
    Vector3 positition;

    //public SpriteRenderer renderer;
   // public List<Sprite> dogdog;

    protected override void Awake(){}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseDragDect();
    }

    private void MouseDragDect()
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
                //renderer.sprite = dogdog[2];
                StartCoroutine(FindObjectOfType<ChocolateDog>().OnDrag());
            }
        }
    }
}
