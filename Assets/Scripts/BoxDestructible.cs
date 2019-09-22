using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestructible : MonoBehaviour
{
    public TextMesh number;
    public int numberToDestroy = 1;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentNumber();
    }

    void SetCurrentNumber()
    {
        number.text = numberToDestroy.ToString();
    }

    public void DecrementOrDestroy()
    {
        numberToDestroy -= 1;
        SetCurrentNumber();
        if(numberToDestroy == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            DecrementOrDestroy();
        }
    }

}
