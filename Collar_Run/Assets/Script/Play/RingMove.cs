using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RingMove : MonoBehaviour {

    float distance;

    void Update () {
        distance = transform.GetComponent<RectTransform>().anchoredPosition.x;

        if (distance >= -300)
        {
            transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        else
        {
            transform.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(Time.deltaTime * GM.Instance.speed, 0);
        }
        
	}
}
