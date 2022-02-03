using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    private Vector2 StartTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 EndTouchPosition;
    private bool stopTouch = false;
    private bool SagaMiSolaMi;
    public float SwipeRange;
    public float tapRange;
    private Vector3 desiredPosition;
    Vector2 Distance;
    float lineSayac = 1;
    Vector3 Movement;
    Rigidbody rb;
    public float Ilerihiz;
    public float YatayHiz;
    public Material[] KarakterMaterial;
    public ScoreManager ScoreManager;
    public GameObject RestartPanel;
    Vector3 Konum;
    public coinManager coinManager;

    public AudioClip ElmasClip;
    void Start()
    {     
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //haraket.MovePosition(haraket.position + Movement * hiz * UstHiz * Time.fixedDeltaTime);
        rb.velocity = Movement * YatayHiz;

    }
   
    void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Distance = currentTouchPosition - StartTouchPosition;
            if (!stopTouch)
            {
                if (Distance.x < -SwipeRange)
                {
                    StartCoroutine(lineSayacDegistirme(-1));

                    if (lineSayac == -1)
                    {
                        lineSayac = 0;
                    }
                   
                    if (lineSayac == 0)
                    {
                        Konum = Vector3.Lerp(transform.position, new Vector3(-3f, transform.position.y, transform.position.z), Time.deltaTime);
                        transform.position = new Vector3(Mathf.Clamp(Konum.x, -0.27f, 0.27f), Konum.y, Konum.z);
                    }

                }
                else if (Distance.x > SwipeRange)
                {
                    StartCoroutine(lineSayacDegistirme(1));
                    if (lineSayac == 3)
                    {
                        lineSayac = 2;
                    }

                    if (lineSayac == 2)
                    {
                        Konum = Vector3.Lerp(transform.position, new Vector3(3f, transform.position.y, transform.position.z), Time.deltaTime);
                        transform.position = new Vector3(Mathf.Clamp(Konum.x, -0.27f, 0.27f), Konum.y, Konum.z);
                    }
                }
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            EndTouchPosition = Input.GetTouch(0).position;
            Distance = EndTouchPosition - StartTouchPosition;
            StartTouchPosition = Input.GetTouch(0).position;
        }
    }

    void Update()
    {
        KarakterHareket();
        //SagaSolaHareket();
        Swipe();
    }
    private void OnTriggerEnter(Collider other) //Karakterin çarpýþma olaylarý
    {  

        //karakterin renk deðiþimi
        if(other.tag == "RenkCizgisiPink") //Renk çizgisi pembe ise karakter pembe olur.
        {
            gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = KarakterMaterial[2];
            PlayerPrefs.SetInt("RenkCizgisi", 2);
            
        }
        else if(other.tag == "RenkCizgisiBlue")//Renk çizgisi mavi ise karakter mavi olur.
        {
            gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = KarakterMaterial[0];
            PlayerPrefs.SetInt("RenkCizgisi", 0);
        }
        else if (other.tag == "RenkCizgisiOrange")//Renk çizgisi turuncu ise karakter turuncu olur.
        {
            gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = KarakterMaterial[1];
            PlayerPrefs.SetInt("RenkCizgisi", 1);
        }


        //Elmas toplama, skor arttýrma, coin arttýrma olaylarý.
        if (other.tag == "PinkDiamond")
        {          
            if (PlayerPrefs.GetInt("RenkCizgisi")==2)
            {
                ScoreManager.Score += 1;
                coinManager.coinArttýrma(1);
                if (PlayerPrefs.GetFloat("MusicPref") == 0)
                {
                    GetComponent<AudioSource>().volume = 0;
                    Debug.Log(GetComponent<AudioSource>().volume);
                }
                else
                {
                    GetComponent<AudioSource>().volume = 0.2f;
                    GetComponent<AudioSource>().PlayOneShot(ElmasClip);
                    Debug.Log(GetComponent<AudioSource>().volume);
                }
            }
            else
            {
                Handheld.Vibrate();
                PlayerPrefs.SetInt("Dead", 1);
                Destroy(gameObject);
                RestartPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (other.tag == "BlueDiamond" )
        {
            if (PlayerPrefs.GetInt("RenkCizgisi") == 0)
            {
                ScoreManager.Score += 1;
                coinManager.coinArttýrma(1);
                if (PlayerPrefs.GetFloat("MusicPref") == 0)
                {
                    GetComponent<AudioSource>().volume = 0;
                    Debug.Log(GetComponent<AudioSource>().volume);                    
                }
                else
                {                    
                    GetComponent<AudioSource>().volume = 0.2f;
                    GetComponent<AudioSource>().PlayOneShot(ElmasClip);
                    Debug.Log(GetComponent<AudioSource>().volume);
                }
                
            }
            else
            {
                Handheld.Vibrate();
                PlayerPrefs.SetInt("Dead", 1);
                Destroy(gameObject);
                RestartPanel.SetActive(true);
                Time.timeScale = 0;

            }
        }

        if (other.tag == "OrangeDiamond" )
        {
            if (PlayerPrefs.GetInt("RenkCizgisi") == 1)
            {
                ScoreManager.Score += 1;
                coinManager.coinArttýrma(1);
                if (PlayerPrefs.GetFloat("MusicPref") == 0)
                {
                    GetComponent<AudioSource>().volume = 0;
                    GetComponent<AudioSource>().PlayOneShot(ElmasClip);
                    Debug.Log(GetComponent<AudioSource>().volume);
                }
                else
                {
                    GetComponent<AudioSource>().volume = 0.2f;
                    GetComponent<AudioSource>().PlayOneShot(ElmasClip);
                    Debug.Log(GetComponent<AudioSource>().volume);
                }
            }
            else
            {

                Handheld.Vibrate();
                PlayerPrefs.SetInt("Dead", 1);
                Destroy(gameObject);
                RestartPanel.SetActive(true);
                Time.timeScale = 0;

            }
        }

    }
   

    public void SagaSolaHareket()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left*YatayHiz * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector3.right * YatayHiz * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.45f, 0.45f),transform.position.y, transform.position.z);

    }
    
    
    public void KarakterHareket()
    {

        //rb.AddForce(new Vector3(transform.position.x, transform.position.y, Ilerihiz));
        //rb.velocity = new Vector3(0, 0, Ilerihiz);
        transform.position += new Vector3(0, 0, Ilerihiz*Time.deltaTime);
    }

    IEnumerator lineSayacDegistirme(float sayac)
    {
        lineSayac += sayac;
        yield break;
    }
}
