using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CameraControl_AZ : MonoBehaviour
    {
        public float damping = 1.5f; // movement speed 
        public Vector2 offset = new Vector2(0f, 0f); // special effect if you want the character to be not in center of screen
        public bool faceLeft; // mirror reflection of OFFSET along the y axis 
        private Transform player;
        private int lastX;

        void Start()
        {
            offset = new Vector2(Mathf.Abs(offset.x), offset.y);
            FindPlayer(faceLeft);
        }

        public void FindPlayer(bool playerFaceLeft)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
                lastX = Mathf.RoundToInt(player.position.x);
                if (playerFaceLeft)
                {
                    transform.position = new Vector3(player.position.x - offset.x,
                    player.position.y + offset.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(player.position.x + offset.x,
                    player.position.y + offset.y, transform.position.z);
                }
            }
            else
            {
                Debug.LogError("Player GameObject with tag 'Player' not found!");
            }
        }

        void Update()
        {
            if (player != null)
            {
                int currentX = Mathf.RoundToInt(player.position.x);
                if (currentX > lastX) faceLeft = false;
                else if (currentX < lastX) faceLeft = true;
                lastX = Mathf.RoundToInt(player.position.x);

                Vector3 target;
                if (faceLeft)
                {
                    target = new Vector3(player.position.x - offset.x,
                    player.position.y + offset.y, transform.position.z);
                }
                else
                {
                    target = new Vector3(player.position.x + offset.x,
                    player.position.y + offset.y, transform.position.z);
                }
                Vector3 currentPosition = Vector3.Lerp(transform.position, target,
                damping * Time.deltaTime);
                transform.position = currentPosition;
            }
        }
    }
}