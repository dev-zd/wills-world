using Platformer.Core;
using Platformer.Model;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Updates the player's spawn point when activated.
    /// Can be used as a trigger on the map OR spawned dynamically.
    /// </summary>
    public class Checkpoint : MonoBehaviour
    {
        public bool isActivated = false;
        private PlatformerModel _model;

        void Awake()
        {
            _model = Simulation.GetModel<PlatformerModel>();
        }

        // Called when spawned dynamically by coin collection
        public void ActivateImmediately()
        {
            if (isActivated) return;
            
            // Build the visual flag since we don't have a sprite asset
            CreateFlagVisual();
            
            // Set as active
            ActivateCheckpoint();
            
            // Show UI Popup
            CheckpointUI.Show();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.GetComponent<PlayerController>();
            if (player != null && !isActivated)
            {
                ActivateCheckpoint();
                CheckpointUI.Show();
            }
        }

        void ActivateCheckpoint()
        {
            isActivated = true;
            
            if (_model != null)
            {
                // Create a dedicated spawn point object at this location
                GameObject newSpawn = new GameObject("CurrentCheckpoint_Spawn");
                newSpawn.transform.position = transform.position;
                _model.spawnPoint = newSpawn.transform;
            }
            
            Debug.Log($"Checkpoint Activated at {transform.position}");
        }

        private void CreateFlagVisual()
        {
            // 1. Pole (Cylinder/Cube)
            GameObject pole = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pole.transform.SetParent(transform, false);
            pole.transform.localPosition = new Vector3(0, 1f, 0); // Move up so base is at 0
            pole.transform.localScale = new Vector3(0.1f, 2f, 0.1f);
            
            // Color it grey
            var poleRenderer = pole.GetComponent<Renderer>();
            poleRenderer.material.color = Color.gray;
            Destroy(pole.GetComponent<BoxCollider>()); // Remove physics

            // 2. Flag (Triangle/Cube rotated)
            GameObject flag = GameObject.CreatePrimitive(PrimitiveType.Cube);
            flag.transform.SetParent(transform, false);
            flag.transform.localPosition = new Vector3(0.5f, 1.8f, 0);
            flag.transform.localScale = new Vector3(0.8f, 0.5f, 0.1f);
            
            // Color it Green
            var flagRenderer = flag.GetComponent<Renderer>();
            flagRenderer.material.color = Color.green;
            Destroy(flag.GetComponent<BoxCollider>()); // Remove physics
        }
    }
}
