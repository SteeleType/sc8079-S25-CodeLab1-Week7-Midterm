using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public static GameManager instance;

    public TextMeshProUGUI timer;

    public float intTimer = 50;

    public float IntTimer
    {
        set
        {
            intTimer = value; 
        }
        get
        {
            return intTimer;
        }
    }
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intTimer = 200;
        //start of the singleton to keep the audio not start in a new place on repeat. 
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this);
            
            audioSource = GetComponent<AudioSource>();
        
            audioSource.clip = audioClip;
    
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

   

    // Update is called once per frame
    void Update()
    {
        intTimer -= Time.deltaTime;
        timer.text = intTimer.ToString("Time to Hell: " + "0.00");
        //basic reset command
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<ASCIILevelLoader>().CurrentLevel = 0;
            intTimer = 200;
        }
        
        if (intTimer <= 0)
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<ASCIILevelLoader>().CurrentLevel = 7;
            timer.text = "Hell Time: NOW!";
        }
    }
}
