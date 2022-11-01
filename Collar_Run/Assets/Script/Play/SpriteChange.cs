using UnityEngine;
using System.Collections;

public class SpriteChange : MonoBehaviour {

	public Sprite nonColorImage;
	public Sprite colorImage;
	public bool touchCheck;
	float alpha;
	SpriteRenderer sprite_render;

	// Use this for initialization
	void Start () {
        touchCheck = false;
        alpha = 0;
        sprite_render = transform.GetComponent<SpriteRenderer>();
		sprite_render.sprite = nonColorImage;
	}
	
	// Update is called once per frame
	void Update () {

        if(alpha >= 1.0f)
        {
            touchCheck = false;
        }

		if(touchCheck)
		{
			sprite_render.sprite = colorImage;
            alpha += 0.5f * Time.deltaTime;
            sprite_render.color = new Color(1,1,1,alpha);
	}
	}
}
