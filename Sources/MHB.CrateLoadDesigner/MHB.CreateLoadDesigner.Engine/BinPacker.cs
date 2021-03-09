#region Using directives
using System.Collections.Generic;
using RectangleBinPack;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public static class BinPacker
    {
        public static bool Pack(int binWidth, int binHeight, List<RectSize> rectSizes, ref List<Rect> rects, ref double occupancy, ref string algorithm)
        {
            var binPackPairs = new BinPackPair[]
                {
                    new BinPackPair()
                    {
                        BinPack = new ShelfBinPack() { UseWasteMap = true },
                        Option = new ShelfBinPack.Option() { Method = ShelfBinPack.ShelfChoiceHeuristic.ShelfBestAreaFit },
                        Algorithm = "Shelf"
                    },
                    new BinPackPair()
                    {
                        BinPack = new ShelfNextFitBinPack() { },
                        Option = new OptionNone(),
                        Algorithm = "ShelfNextFit"
                    },
                    new BinPackPair()
                    {
                        BinPack = new GuillotineBinPack(),
                        Option = new GuillotineBinPack.Option() { Merge = true,
                        FreeRectChoice = GuillotineBinPack.FreeRectChoiceHeuristic.RectBestAreaFit,
                        GuillotineSplit = GuillotineBinPack.GuillotineSplitHeuristic.SplitMaximizeArea },
                        Algorithm = "Guillotine"
                    },
                    new BinPackPair()
                    {
                        BinPack = new MaxRectsBinPack(),
                        Option = new MaxRectsBinPack.Option() { Method = MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestAreaFit },
                        Algorithm = "MaxRects"
                    }
                };

            foreach (var binpackpair in binPackPairs)
            {
                bool success = true;
                rects.Clear();

                GenericBinPack binPack = binpackpair.BinPack;
                binPack.Init(binWidth, binHeight);
                foreach (var rectSize in rectSizes)
                {
                    Rect rect = binPack.Insert(rectSize, binpackpair.Option);
                    if (0 == rect.Height)
                    {
                        success = false;
                        break;
                    }
                    else
                        rects.Add(rect);
                }
                if (success == true)
                {
                    occupancy = binPack.Occupancy;
                    algorithm = binpackpair.Algorithm;
                    return true;
                }
            }
            // failure
            return false;
        }
    }

    public class BinPackPair
    { 
        public GenericBinPack BinPack { get; set; }
        public GenericOption Option { get; set; }
        public string Algorithm { get; set; }
    }
}
