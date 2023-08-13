using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(0, 290f) * Time.deltaTime;       
    }
}
