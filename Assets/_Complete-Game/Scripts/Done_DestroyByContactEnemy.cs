using UnityEngine;
using System.Collections;

public class Done_DestroyByContactEnemy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int heartValue;
    private Done_GameController gameController;
    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Boundary" || other.tag == "Enemy")
        //{
        //    return;
        //}

        //if (explosion != null)
        //{
        //    Instantiate(explosion, transform.position, transform.rotation);


        //}

        ////if (other.tag == "Player")
        ////{
        ////    if (gameController.heart == 0)
        ////    {
        ////        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        ////        gameController.GameOver();

        ////    }
        ////}
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        gameController.RemoveHeart(heartValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}