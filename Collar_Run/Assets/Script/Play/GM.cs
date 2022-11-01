using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    
    #region 싱글톤
    private static GM _instance = null;

    public static GM Instance
    {
        get
        {
            if (_instance == null) { }
            return _instance;
        }
    }

    private GM() { }
    #endregion

    public GameObject player;

	public float speed;
    public int colorMax = 0;
    public int score;
    Text scoreText;

    public int burningNum;
    public float burningTime;
    public float burningTimeSave;
    public bool burningState;
    GameObject burningGauge;
    
	public int left_Button;
	public int right_Button;

	Vector2 ray;
	RaycastHit2D hit;
    
    void Awake () {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        ColorSetting ();
	}

    private void Start()
    {
        burningTime = 5.0f;
        burningTimeSave = 0f;

        player = GameObject.FindWithTag("Player");
        burningGauge = GameObject.FindWithTag("Burning");
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
    }

    void Update () {
        SpeedLimit();

        if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			hit = Physics2D.Raycast (ray, Vector2.zero);

			if (hit.collider != null) {

				if (hit.collider.gameObject.tag == "BG_Item") 
				{
                    hit.collider.gameObject.GetComponent<HitObject>().Action();
				}
				else if(hit.collider.gameObject.tag == "BG_Obj" && burningNum >=1)
				{
					score += 1;
					burningNum -= 1;
				    hit.collider.gameObject.GetComponent<SpriteChange>().touchCheck = true;
					}
				}
				}

        if(burningNum <=5)
        {
            burningGauge.transform.localScale = new Vector2(0.2f * burningNum, 1);
        }

        scoreText.text = "그림 : " + score;

        Burning();
    }
    
    public void SpeedLimit()
    {
        if (speed >= 8.0f)
        {
            speed = 8.0f;
        }
        else if (speed <= 2.0f)
        {
            speed = 2.0f;
        }
    }

    //랜덤박스에 의해 버튼색이 변할때 사용
	public void ColorSetting()
	{
		left_Button = Random.Range (0, colorMax);
		right_Button = Random.Range (0, colorMax);
		if (left_Button == right_Button) {
			right_Button = left_Button - 1;
			if(right_Button < 0)
			{
				right_Button = colorMax - 1;
			}
		}
	}

    public void Burning()
    {
        if(burningState)
        {
            player.GetComponent<Player>().playerState = 10;
            speed += Time.deltaTime;
            burningTimeSave += Time.deltaTime;

            if(burningTimeSave >= burningTime)
            {
                burningState = false;
                burningTimeSave = 0;
                player.GetComponent<Player>().playerState = left_Button;
            }
        }
    }
}
