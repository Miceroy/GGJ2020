using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this class as a base class for each component
/// </summary>
public class GameComponent : MonoBehaviour
{
    void Awake()
    {
        getGameManager().registerComponent(this);
    }

    ~GameComponent()
    {
        getGameManager().unregisterComponent(this);
    }

    public GameManager getGameManager()
    {
        Debug.AssertFormat(GameObject.FindGameObjectWithTag("GameController"), "GameController not found from scene");
        GameManager manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Debug.AssertFormat(manager, "GameManager not found from GameController");
        return manager;
    }
}
