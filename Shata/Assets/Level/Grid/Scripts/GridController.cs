using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Grid
{

    public class GridController : MonoBehaviour
    {
        [SerializeField] GameObject cellPrefab;

        //TODO: I think that maybe we can store a custom object, maybe something less consuming
        GameObject[] grid;

        const int gridHeight = 50;
        const int gridWidth  = 50;

        const float hexRadius = 0.866025404f;
        
        void Awake()
        {
            grid = new GameObject[gridHeight * gridWidth];
            
            for (int z = 0, i = 0; z < gridHeight; z++) {
                for (int x = 0; x < gridWidth; x++) {
                    initHex(x, z, i++);
                }
            }
        }
        
        void initHex (int x, int z, int i) {
            Vector3 position;
            int evenRow = z % 2; //1 or 0
            position.x = x + 0.5f * evenRow;
            position.y = 0f;
            position.z = z * hexRadius;
    
            GameObject cell = grid[i] = Instantiate<GameObject>(cellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
        }
    }
}
