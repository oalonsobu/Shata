﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Level.Building;
using Level.Grid;
using Level.Resource;

namespace Level.Cell
{
    public class CellBase
    {
        public CellBase[] Neighbour { get; } = new CellBase[6];
        public CellTypeInterface CellType { get; set; }
        public Building.Building CurrentBuilding { get; set; } = new None();

        public int Id { get; }
        public Vector3 Position { get; }

        public CellBase(int id, Vector3 position, CellTypeInterface cellType)
        {
            Id = id;
            Position = position;
            CellType = cellType;
        }
        
        public CellBase(int id, Vector3 position)
        {
            Id = id;
            Position = position;
        }

        public void addNeigbour(CellBase cellBase, HexDirection dir)
        {
            Neighbour[(int)dir] = cellBase;
        }
        
        public CellBase getNeigbour(HexDirection dir)
        {
            return Neighbour[(int)dir];
        }
        
        public void setCurrentBuilding(Building.Building building)
        {
            CurrentBuilding = building;
        }
        
        public bool isEmptyCell()
        {
            return CurrentBuilding is None;
        }
    }
}
