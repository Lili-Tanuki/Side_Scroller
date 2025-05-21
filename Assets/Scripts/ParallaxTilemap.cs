using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxTilemap : MonoBehaviour
{
    private Vector2 startPos;
    private float length;
    private Camera cam;

    [Tooltip ("0 = move with camera, 1 = , no movement")]
   public float ParallaxAmountX;
   public float ParallaxAmountY;
   public bool loop = true;

   private TilemapRenderer tilemapRenderer;
   private Bounds tilemapBounds;
   public Vector2 camStartPos;

    void Start()
    {
        cam = Camera.main;
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapBounds = tilemapRenderer.localBounds;

        startPos = transform.position;
        //camStartPos = cam.transform.postion;
        length = tilemapBounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceX = (cam.transform.position.x - camStartPos.x) * ParallaxAmountX;
        float distanceY = (cam.transform.position.y - camStartPos.y) * ParallaxAmountY;

        transform.position = new Vector2(startPos.x + distanceX, startPos.y + distanceY);

        float movementX = (cam.transform.position.x - camStartPos.x) * (1 - ParallaxAmountX);
        
        if (loop)
        {
            if (movementX > startPos.x + length)
            {
                startPos.x += length;
            }
            else if (movementX < startPos.x - length)
            {
                startPos.x -= length;
            }
        }
    }
}
