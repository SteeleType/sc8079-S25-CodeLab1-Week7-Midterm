using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public static ASCIILevelLoader levelLoader;
    void OnCollisionEnter(Collision other)
    {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<ASCIILevelLoader>().LoadLevel();
    }
}
