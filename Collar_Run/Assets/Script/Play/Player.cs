using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public int playerState;
	
	public float HP;
	public float maxHP;

    GameObject hpBar;

    int aniNum;
    string aniString;
    List<Sprite> runImage = new List<Sprite>();

    float aniTime;
    float saveTime;

    void Start () {
		transform.GetComponent<Rigidbody2D> ().WakeUp ();
        hpBar = GameObject.FindWithTag("HP");

        aniTime = 1.0f;
        saveTime = 0;

        ImageLoad();
    }
	
	void Update () {

		if(HP>maxHP)
		{
			HP = maxHP;
		}

        if (HP > 0)
        {
            hpBar.GetComponent<RectTransform>().localScale = new Vector3(HP / maxHP, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = Vector3.zero;
            Application.LoadLevel("Result");
        }

        ImageLoad();
        RunAni();
    }

    public void ImageLoad()
    {
        switch (playerState)
        {
            case 0:
                aniString = "Red";
                break;

            case 1:
                aniString = "Blue";
                break;

            case 2:
                aniString = "Yellow";
                break;

            case 3:
                aniString = "Green";
                break;

            case 10:
                aniString = "Rainbow";
                break;

            default:
                aniString = "Black";
                break;
        }

        Sprite[] imageLoad = Resources.LoadAll<Sprite>("Player_" + aniString);
        runImage.Clear();
        runImage.AddRange(imageLoad);
        transform.GetComponent<SpriteRenderer>().sprite = runImage[aniNum];
    }

    void RunAni()
    {
        saveTime += Time.deltaTime;
        if(saveTime > aniTime/runImage.Count)
        {
            saveTime = 0;
            aniNum += 1;
            transform.GetComponent<SpriteRenderer>().sprite = runImage[aniNum];
        }
        if(aniNum >= runImage.Count - 1)
        {
            aniNum = 0;
        }
    }
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("crayon"))
		{
            other.GetComponent<HitObject>().Action();
		}
	}
}
