using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
            model.tokens++;

            // Dynamic Checkpoint Logic: Every 10 tokens
            if (model.tokens > 0 && model.tokens % 10 == 0)
            {
                // Spawn at player's current position
                SpawnDynamicCheckpoint(player.transform.position);
            }
        }

        void SpawnDynamicCheckpoint(Vector3 position)
        {
            // Create a new GameObject for the checkpoint
            GameObject cpObj = new GameObject($"DynamicCheckpoint_{model.tokens}");
            cpObj.transform.position = position;
            
            // Add the Checkpoint component and activate it immediately
            Checkpoint cp = cpObj.AddComponent<Checkpoint>();
            cp.ActivateImmediately();
        }
    }
}