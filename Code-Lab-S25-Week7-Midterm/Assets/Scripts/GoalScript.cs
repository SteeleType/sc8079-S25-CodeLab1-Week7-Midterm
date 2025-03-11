using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public int randomLevel;

    public int RandomLevel
    {
        set
        {
            randomLevel = value;
            randomLevel = Random.Range(0, 7);
            
        }
        get
        {
            randomLevel = Random.Range(0, 7);
            return randomLevel;
        }
    }
    void OnTriggerEnter(Collider other)
    {

        randomLevel = Random.Range(0, 7);
        if (other.CompareTag("Player")){
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<ASCIILevelLoader>().CurrentLevel = randomLevel;
            Debug.Log("You hit it!  ");
        }
        
    }
}
