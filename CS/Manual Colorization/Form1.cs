
using DevExpress.Utils;
using DevExpress.XtraMap;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manual_Colorization {
    public partial class Form1 : Form {
        const string areaValueAttrName = "AreaValue";
        const string polygonNameAttrName = "PolygonName";

        public Form1() {
            InitializeComponent();

            InitializeMap();
        }

        void InitializeMap() {
            // Create a map control and add it to the form.
            MapControl map = new MapControl() { Dock = DockStyle.Fill };
            this.Controls.Add(map);

            // Create a layer to display vector data.
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            map.Layers.Add(itemsLayer);

            // Generate a data storage for the layer.
            itemsLayer.Data = CreateData();

            // Create a colorizer for the layer.
            itemsLayer.Colorizer = CreateColorizer();

            // Create a legend for the layer.
            map.Legends.Add(CreateLegend(itemsLayer));

            // Specify tooltips for the map.
            map.ToolTipController = new ToolTipController() { AllowHtmlText = true };
        }

        private MapItemStorage CreateData() {
            MapItemStorage storage = new MapItemStorage();

            // Create the first triangle.
            storage.Items.Add(
                CreatePolygon(800, "Small triangle",
                    new GeoPoint[] { 
                        new GeoPoint(0, 0), new GeoPoint(0, 40), 
                        new GeoPoint(40, 0), new GeoPoint(0, 0) 
                    }
                 )
             );

            // Create the second triangle.
            storage.Items.Add(
                CreatePolygon(1800, "Large triangle",
                    new GeoPoint[] { 
                        new GeoPoint(0, 0), new GeoPoint(0, -60), 
                        new GeoPoint(-60, 0), new GeoPoint(0, 0) 
                    }
                )
             );

            return storage;
        }

        #region #CreatePolygon
        private MapPolygon CreatePolygon(double areaValue, string polygonName, GeoPoint[] points) {
            MapPolygon item = new MapPolygon();

            item.Attributes.Add(new MapItemAttribute() {
                Name = areaValueAttrName,
                Type = typeof(double),
                Value = areaValue
            });
            item.Attributes.Add(new MapItemAttribute() {
                Name = polygonNameAttrName,
                Type = typeof(string),
                Value = polygonName
            });

            item.ToolTipPattern = "{" + polygonNameAttrName + "}=<b>{" + areaValueAttrName + "}</b>";

            foreach (GeoPoint point in points) {
                item.Points.Add(point);
            }

            return item;
        }
        #endregion #CreatePolygon

        private MapColorizer CreateColorizer() {
            ChoroplethColorizer colorizer = new ChoroplethColorizer();
            colorizer.ValueProvider = new ShapeAttributeValueProvider {
                AttributeName = areaValueAttrName
            };

            colorizer.RangeStops.AddRange(new List<double> { 0, 1000, 2000 });
            colorizer.ColorItems.AddRange(new List<ColorizerColorItem> {
                new ColorizerColorItem(Color.Yellow),
                new ColorizerColorItem(Color.Red)
            });

            return colorizer;
        }

        private MapLegendBase CreateLegend(MapItemsLayerBase layer) {
            ColorScaleLegend legend = new ColorScaleLegend();
            legend.Header = "Area";
            legend.Layer = layer;
            return legend;
        }
    }

}
