using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using Newtonsoft.Json;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }


            if (Input.GetKey(KeyCode.F9))
            {
                SaveManager.Load();
            }
        }
        private void Start()
        {
            MapLoader.LoadMap();
            Application.targetFrameRate = 60;
        }
    }
}
