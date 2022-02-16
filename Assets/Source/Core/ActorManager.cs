using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.U2D;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Main class for Actor management - spawning, destroying, detecting at positions, etc
    /// </summary>
    public class ActorManager : MonoBehaviour
    {
        private Dictionary<string, int> playerStats;
        private Dictionary<string, int> playerInventory ;
        public HashSet<Actor> AllActors { get { return _allActors; } }
        private const int DefId = -5;
        /// <summary>
        ///     ActorManager singleton
        /// </summary>
        public static ActorManager Singleton { get; private set; }
        public static int RandomNumber()
        {
            int randNumber = Random.Range(0, 100);
            return randNumber;
        }

        public void SavePlayerInventory()
        {
            Player playerActor = (Player)GetActorAt(GetPlayerPosition());
            playerStats = playerActor.GetStats();
            playerInventory = playerActor.inventory;
        }

        public void LoadPlayerInventory()
        {
            Player playerActor = (Player)GetActorAt(GetPlayerPosition());
            playerActor.inventory = playerInventory;
            ApplySavedStatsToPlayer(playerActor);
        }

        private void ApplySavedStatsToPlayer(Player player)
        {
            foreach (var stat in playerStats)
            {
                switch (stat.Key)
                {
                    case "Health":
                        player.Health = stat.Value;
                        break;
                    case "Strength":
                        player.Strength = stat.Value;
                        break;
                    case "Shield":
                        player.Shield = stat.Value;
                        break;
                    case "ExpCount":
                        player.ExpCount = stat.Value;
                        break;
                    case "ExpNeeded":
                        player.ExpNeeded = stat.Value;
                        break;
                    case "MaxHealth":
                        player.MaxHealth = stat.Value;
                        break;
                }
            }
        }

        private SpriteAtlas _spriteAtlas;
        private HashSet<Actor> _allActors;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;

            _allActors = new HashSet<Actor>();
            _spriteAtlas = Resources.Load<SpriteAtlas>("Spritesheet");
        }

        /// <summary>
        ///     Returns actor present at given position (returns null if no actor is present)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Actor GetActorAt((int x, int y) position)
        {
            return _allActors.FirstOrDefault(actor => actor.Detectable && actor.Position == position);
        }

        public (int x, int y) GetPlayerPosition()
        {
            (int x, int y) position = default;
            foreach (Actor actor in _allActors)
            {
                if (actor is Player)
                {
                    return actor.Position;
                }
            }
            return position;
        }

        /// <summary>
        ///     Returns actor of specific subclass present at given position (returns null if no actor is present)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <returns></returns>
        public T GetActorAt<T>((int x, int y) position) where T : Actor
        {
            return _allActors.FirstOrDefault(actor => actor.Detectable && actor is T && actor.Position == position) as T;
        }

        /// <summary>
        ///     Unregisters given actor (use when killing/destroying)
        /// </summary>
        /// <param name="actor"></param>
        public void DestroyActor(Actor actor)
        {
            _allActors.Remove(actor);
            Destroy(actor.gameObject);
        }

        /// <summary>
        ///     Used for cleaning up the scene before loading a new map
        /// </summary>
        public void DestroyAllActors()
        {
            var actors = _allActors.ToArray();

            foreach (var actor in actors)
                DestroyActor(actor);
        }

        /// <summary>
        ///     Returns sprite with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sprite GetSprite(int id)
        {
            return _spriteAtlas.GetSprite($"kenney_transparent_{id}");
        }

        /// <summary>
        ///     Spawns given Actor type at given position
        /// </summary>
        /// <typeparam name="T">Actor type</typeparam>
        /// <param name="position">Position</param>
        /// <param name="actorName">Actor's name (optional)</param>
        /// <returns></returns>
        public T Spawn<T>((int x, int y) position, int id = DefId, string actorName = null) where T : Actor
        {
            return Spawn<T>(position.x, position.y, id, actorName);
        }

        /// <summary>
        ///     Spawns given Actor type at given position
        /// </summary>
        /// <typeparam name="T">Actor type</typeparam>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="actorName">Actor's name (optional)</param>
        /// <returns></returns>
        public T Spawn<T>(int x, int y, int id, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            go.name = actorName ?? component.DefaultName;
            component.Position = (x, y);
            component.SetSprite(id);

            _allActors.Add(component);

            return component;
        }
    }
}
