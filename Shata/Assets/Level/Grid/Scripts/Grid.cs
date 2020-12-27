using Level.Cell;

namespace Level.Grid
{
    public class Grid
    {
        private CellBase[] map;

        private int width;
        
        private int height;
        
        public CellBase[] Map => map;

        public int Width => width;

        public int Height => height;
        
        public int Size => height * width;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.map = new CellBase[height * width];
        }

        public void SetCellBase(int id, CellBase cellBase)
        {
            map[id] = cellBase;
        }

        public CellBase GetCellBase(int id)
        {
            return map[id];
        }
        
        public void SetNeigbours(int width, int currentWidth, int currentHeight, int i)
        {
            if (currentWidth > 0)
            {
                GetCellBase(i).addNeigbour(GetCellBase(i-1), HexDirection.W);
                GetCellBase(i-1).addNeigbour(GetCellBase(i), HexDirection.E);
            }
                    
            if (currentHeight > 0) {
                if ((currentHeight & 1) == 0) {
                    GetCellBase(i).addNeigbour(GetCellBase(i - width), HexDirection.SE);
                    GetCellBase(i - width).addNeigbour(GetCellBase(i), HexDirection.NW);
                    if (currentWidth > 0) {
                        GetCellBase(i).addNeigbour(GetCellBase(i - width - 1), HexDirection.SW);
                        GetCellBase(i - width - 1).addNeigbour(GetCellBase(i), HexDirection.NE);
                    }
                }
                else {
                    GetCellBase(i).addNeigbour(GetCellBase(i - width), HexDirection.SW);
                    GetCellBase(i - width).addNeigbour(GetCellBase(i), HexDirection.NE);
                    if (currentWidth < width - 1) {
                        GetCellBase(i).addNeigbour(GetCellBase(i - width + 1), HexDirection.SE);
                        GetCellBase(i - width + 1).addNeigbour(GetCellBase(i), HexDirection.NW);
                    }
                }
            }
        }
    }
}
