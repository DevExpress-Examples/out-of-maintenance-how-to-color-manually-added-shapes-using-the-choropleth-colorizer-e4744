Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap
Imports DevExpress.Utils

Namespace Manual_Colorization
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Const areaValueAttrName As String = "AreaValue"
		Private Const polygonNameAttrName As String = "PolygonName"

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a map control, set its dock style and add it to the form.
			Dim map As New MapControl()
			map.Dock = DockStyle.Fill
			Me.Controls.Add(map)

			' Create a vector items layer and add it to the map.
			Dim itemsLayer As New VectorItemsLayer()
			map.Layers.Add(itemsLayer)

			' Create the first triangle.
			Dim polygon1 As MapPolygon = CreatePolygon(800, "Small triangle", New GeoPoint() { New GeoPoint(0, 0), New GeoPoint(0, 40), New GeoPoint(40, 0), New GeoPoint(0, 0) })
			itemsLayer.Items.Add(polygon1)

			' Create the second triangle.
			Dim polygon2 As MapPolygon = CreatePolygon(1800, "Large triangle", New GeoPoint() { New GeoPoint(0, 0), New GeoPoint(0, -60), New GeoPoint(-60, 0), New GeoPoint(0, 0) })
			itemsLayer.Items.Add(polygon2)

			' Create a colorizer.
			itemsLayer.Colorizer = CreateChoroplethColorizer()

			' Specify the tooltip content.
			map.ToolTipController = New ToolTipController() With {.AllowHtmlText = True}
			itemsLayer.ToolTipPattern = "{" & polygonNameAttrName & "}=<b>{" & areaValueAttrName & "}</b>"
		End Sub


		Private Function CreatePolygon(ByVal areaValue As Double, ByVal polygonName As String, ByVal points() As GeoPoint) As MapPolygon
			Dim item As New MapPolygon()

			For Each point As GeoPoint In points
				item.Points.Add(point)
			Next point

			item.Attributes.Add(New MapItemAttribute() With {.Name = areaValueAttrName, .Type = GetType(Double), .Value = areaValue})

			item.Attributes.Add(New MapItemAttribute() With {.Name = polygonNameAttrName, .Type = GetType(String), .Value = polygonName})

			Return item
		End Function


		Private Function CreateChoroplethColorizer() As ChoroplethColorizer
			' Create a choropleth colorizer.
			Dim colorizer As New ChoroplethColorizer()

			' Specify the attribute that provides data values for the colorizer.
			colorizer.ValueProvider = New ShapeAttributeValueProvider() With {.AttributeName = areaValueAttrName}

			' Specify range stops for the colorizer.
			colorizer.RangeStops.AddRange(New List(Of Double) (New Double() {0, 1000, 2000}))

			' Specify colors for the colorizer.
			colorizer.Colors.AddRange(New List(Of Color) (New Color() {Color.Yellow, Color.Red}))

			Dim legend As New ColorScaleLegend()
			legend.Header = "Area"
			colorizer.Legend = legend

			Return colorizer
		End Function
	End Class

End Namespace
