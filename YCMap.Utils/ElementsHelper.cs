using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YCMap.Utils
{
    public class ElementsHelper
    {
        public static IFillShapeElement GetRectangleElement(IGeometry geometry)
        {
            IRectangleElement rectangleElement = new RectangleElementClass();
            IElement element = rectangleElement as IElement;

            //设置元素Geometry为当前范围
            element.Geometry = geometry;

            //创建红色矩形框符号，先线符号然后面符号
            ILineSymbol outline = GetSimpleLineSymbol(2, GetRgbaColor(255, 0, 0, 255));
            IFillSymbol fillSymbol = GetSimpleFillSymbol(outline, GetRgbaColor(255, 0, 0, 0));

            //设置元素Symbol
            IFillShapeElement fillShapeElement = element as IFillShapeElement;
            fillShapeElement.Symbol = fillSymbol;
            return fillShapeElement;
        }

        public static IFillSymbol GetSimpleFillSymbol(ILineSymbol outline, IColor color)
        {
            IFillSymbol fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = color;//透明
            fillSymbol.Outline = outline;
            return fillSymbol;
        }

        public static ILineSymbol GetSimpleLineSymbol(Double width, IColor color)
        {
            ILineSymbol lineSymbol = new SimpleLineSymbolClass();
            lineSymbol.Width = width;
            lineSymbol.Color = color;//红线
            return lineSymbol;
        }

        public static IRgbColor GetRgbaColor(Byte red, Byte green, Byte blue, Byte alpha)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = red;
            color.Green = green;
            color.Blue = blue;
            color.Transparency = alpha;
            return color;
        }
    }
}
