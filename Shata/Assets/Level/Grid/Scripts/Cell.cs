
namespace Level.Grid
{
    //Cell information not related with unity behaviours. More like an aggregated/container 
    public class Cell
    {
        private TypeInterface cellType;
        
        public Cell(TypeInterface ct) {
            cellType = ct;
        }

        public TypeInterface CellType {
            get => cellType;
            //set => cellType = value;
        }
    }
}
