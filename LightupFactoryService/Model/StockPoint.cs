using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightupFactoryService.Model
{
    /// <summary>
    /// 库存点，支持父子级建模；
    /// 2021-8-24，刘涛
    /// </summary>
    public class StockPoint:TableMaster
    {
        public string StockPointId { get; set; }
        public string StockName { get; set; }
        public string dimensionUnit { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Draw_Background { get; set; }
        public string Draw_SVG { get; set; }
        public string Draw_Xposition { get; set; }
        public string Draw_YPosition { get; set; }
        public string Area { get; set; }
        public string areaUnit { get; set; }
        public string Volume { get; set; }
        public string VolumeUnit { get; set; }
        public string Description { get; set; }
        public string ParentId { get; set; }
        public string WarehouseId { get; set; }
        public string isPhatom { get; set; }

    }
}
