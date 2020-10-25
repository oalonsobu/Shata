using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Grid
{

    public interface TypeInterface
    {

        void getAllowedBuildings();
        string getDesription();
        string getComment();
        string getTitle();
    }
}
