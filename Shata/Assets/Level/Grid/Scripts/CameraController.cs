using Unity.Collections;
using UnityEngine;

namespace Level.Grid
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] [Range(15f,30f)] private float zoomSpeed = 15f;
        [SerializeField] [Range(10,40)]   private float moveSpeed;
        
        //Ideally, readonly
        [SerializeField]                  private float yMax = 13f;
        [SerializeField]                  private float yMin = 1f;
        [SerializeField]                  private float currentZoomRatio = 0f;
        
        private void Update()
        {
            float yDelta = Input.GetAxis("Mouse ScrollWheel");
            if (yDelta != 0f) {
                AdjustZoom(yDelta);
            }
            
            float xDelta = Input.GetAxis("Horizontal");
            float zDelta = Input.GetAxis("Vertical");
            if (xDelta != 0f || zDelta != 0f) {
                AdjustPosition(xDelta, zDelta);
            }
        }
        
        void AdjustZoom (float yDelta) {
            Vector3 direction = transform.rotation * new Vector3(0f, 0f, yDelta).normalized;
            float speed = zoomSpeed * Time.deltaTime;
            float currentZoom = 0;
            
            Vector3 position = transform.localPosition;
            position += direction * speed;
            currentZoom = position.y;
            if (currentZoom < yMax && currentZoom > yMin)
            {
                currentZoomRatio = (currentZoom - yMin) / (yMax - yMin); //needed later again
                transform.localPosition = position;
                float angle = Mathf.Lerp(30, 75, currentZoomRatio);
                transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
            }
        }
        
        void AdjustPosition (float xDelta, float zDelta) {
            Vector3 direction = new Vector3(xDelta, 0f, zDelta).normalized;
            //Smooth the movement
            float damping = Mathf.Max(Mathf.Abs(xDelta), Mathf.Abs(zDelta));
            float speed = moveSpeed * Time.deltaTime * damping;
            
            Vector3 position = transform.localPosition;
            position += direction * speed;
            transform.localPosition = position;
        }
    }
}