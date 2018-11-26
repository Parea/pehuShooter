using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
    public int heartValue;
    private Done_GameController gameController;

    void OnTriggerExit (Collider other)
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        gameController.RemoveHeart(heartValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}