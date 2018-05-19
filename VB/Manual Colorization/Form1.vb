Imports DevExpress.Utils
Imports DevExpress.XtraMap
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Namespace Manual_Colorization
    Partial Public Class Form1
        Inherits Form

        Private Const areaValueAttrName As String = "AreaValue"
        Private Const polygonNameAttrName As String = "PolygonName"

        Public Sub New()
            InitializeComponent()

            InitializeMap()
        End Sub

        Private Sub InitializeMap()
            ' Create a map control and add it to the form.
            Dim map As New MapControl() With {.Dock = DockStyle.Fill}
            Me.Controls.Add(map)

            ' Create a layer to display vector data.
            Dim itemsLayer As New VectorItemsLayer()
            map.Layers.Add(itemsLayer)

            ' Generate a data storage for the layer.
            itemsLayer.Data = CreateData()

            ' Create a colorizer for the layer.
            itemsLayer.Colorizer = CreateColorizer()

            ' Create a legend for the layer.
            map.Legends.Add(CreateLegend(itemsLayer))

            ' Specify tooltips for the map.
            map.ToolTipController = New ToolTipController() With {.AllowHtmlText = True}
        End Sub

        Private Function CreateData() As MapItemStorage
            Dim storage As New MapItemStorage()

            ' Create the first triangle.
            storage.Items.Add(CreatePolygon(800, "Small triangle", New GeoPoint() { _
                New GeoPoint(0, 0), _
                New GeoPoint(0, 40), _
                New GeoPoint(40, 0), _
                New GeoPoint(0, 0) _
            }))

            ' Create the second triangle.
            storage.Items.Add(CreatePolygon(1800, "Large triangle", New GeoPoint() { _
                New GeoPoint(0, 0), _
                New GeoPoint(0, -60), _
                New GeoPoint(-60, 0), _
                New GeoPoint(0, 0) _
            }))

            Return storage
        End Function

        #Region "#CreatePolygon"
        Private Function CreatePolygon(ByVal areaValue As Double, ByVal polygonName As String, ByVal points() As GeoPoint) As MapPolygon
            Dim item As New MapPolygon()

            item.Attributes.Add(New MapItemAttribute() With {.Name = areaValueAttrName, .Type = GetType(Double), .Value = areaValue})
            item.Attributes.Add(New MapItemAttribute() With {.Name = polygonNameAttrName, .Type = GetType(String), .Value = polygonName})

            item.ToolTipPattern = "{" & polygonNameAttrName & "}=<b>{" & areaValueAttrName & "}</b>"

            For Each point As GeoPoint In points
                item.Points.Add(point)
            Next point

            Return item
        End Function
        #End Region ' #CreatePolygon

        Private Function CreateColorizer() As MapColorizer
            Dim colorizer As New ChoroplethColorizer()
            colorizer.ValueProvider = New ShapeAttributeValueProvider With {.AttributeName = areaValueAttrName}

            colorizer.RangeStops.AddRange(New List(Of Double) From {0, 1000, 2000})
            colorizer.ColorItems.AddRange(New List(Of ColorizerColorItem) From { _
                New ColorizerColorItem(Color.Yellow), _
                New ColorizerColorItem(Color.Red) _
            })

            Return colorizer
        End Function

        Private Function CreateLegend(ByVal layer As MapItemsLayerBase) As MapLegendBase
            Dim legend As New ColorScaleLegend()
            legend.Header = "Area"
            legend.Layer = layer
            Return legend
        End Function
    End Class

End Namespace
