
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;
using DevExpress.Utils;

namespace Manual_Colorization {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        const string areaValueAttrName = "AreaValue";
        const string polygonNameAttrName = "PolygonName";

        private void Form1_Load(object sender, EventArgs e) {
            // Create a map control, set its dock style and add it to the form.
            MapControl map = new MapControl();
            map.Dock = DockStyle.Fill;
            this.Controls.Add(map);

            // Create a vector items layer and add it to the map.
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            map.Layers.Add(itemsLayer);

            // Create the first triangle.
            MapPolygon polygon1 = CreatePolygon(800, "Small triangle",
                new GeoPoint[] { new GeoPoint(0, 0), new GeoPoint(0, 40), new GeoPoint(40, 0), new GeoPoint(0, 0) });
            itemsLayer.Items.Add(polygon1);

            // Create the second triangle.
            MapPolygon polygon2 = CreatePolygon(1800, "Large triangle",
                new GeoPoint[] { new GeoPoint(0, 0), new GeoPoint(0, -60), new GeoPoint(-60, 0), new GeoPoint(0, 0) });
            itemsLayer.Items.Add(polygon2);

            // Create a colorizer.
            itemsLayer.Colorizer = CreateChoroplethColorizer();

            // Specify the tooltip content.
            map.ToolTipController = new ToolTipController() { AllowHtmlText = true };
            itemsLayer.ToolTipPattern = "{" + polygonNameAttrName + "}=<b>{" + areaValueAttrName + "}</b>";
        }


        private MapPolygon CreatePolygon(double areaValue, string polygonName, GeoPoint[] points) {
            MapPolygon item = new MapPolygon();

            foreach (GeoPoint point in points) {
                item.Points.Add(point);
            }

            item.Attributes.Add(new MapItemAttribute() { Name = areaValueAttrName, Type = typeof(double), Value = areaValue });

            item.Attributes.Add(new MapItemAttribute() { Name = polygonNameAttrName, Type = typeof(string), Value = polygonName });

            return item;
        }


        private ChoroplethColorizer CreateChoroplethColorizer() {
            // Create a choropleth colorizer.
            ChoroplethColorizer colorizer = new ChoroplethColorizer();

            // Specify the attribute that provides data values for the colorizer.
            colorizer.ValueProvider = new ShapeAttributeValueProvider() { AttributeName = areaValueAttrName };

            // Specify range stops for the colorizer.
            colorizer.RangeStops.AddRange(new List<double> { 0, 1000, 2000 });

            // Specify colors for the colorizer.
            colorizer.Colors.AddRange(new List<Color> { Color.Yellow, Color.Red });

            ColorScaleLegend legend = new ColorScaleLegend();
            legend.Header = "Area";
            colorizer.Legend = legend;

            return colorizer;
        }
    }

}
