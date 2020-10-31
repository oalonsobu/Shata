using UnityEngine;

namespace Level.Grid
{

    public interface CellTypeInterface
    {

        void getAllowedBuildings();
        GameObject getBasePrefab();
        string getDesription();
        string getComment();
        string getTitle();
    }
}
