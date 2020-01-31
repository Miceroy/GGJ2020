using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// Main game controller.
/// </summary>
public class GameManager : MonoBehaviour
{
    public List<GameComponent> gameComponents = new List<GameComponent>();

    public void registerComponent(GameComponent newComponent)
    {
        gameComponents.Add(newComponent);
    }

    public void unregisterComponent(GameComponent componentToRemove)
    {
        gameComponents.Remove(componentToRemove);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
