using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Grid
{

    public interface BuildingInterface
    {
        string getPrice();
        string getDesription();
        string getComment();
        string getTitle();
    }
}
