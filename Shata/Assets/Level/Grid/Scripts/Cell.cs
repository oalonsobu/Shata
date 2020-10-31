
namespace Level.Grid
{
    //Cell information not related with unity behaviours. More like an aggregated/container 
    public class Cell
    {
        private CellTypeInterface _cellCellType;
        
        public Cell(CellTypeInterface ct) {
            _cellCellType = ct;
        }

        public CellTypeInterface CellCellType {
            get => _cellCellType;
        }
    }
}
