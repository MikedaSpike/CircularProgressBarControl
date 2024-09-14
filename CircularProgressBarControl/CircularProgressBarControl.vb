Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Resources
Imports System.Windows.Forms

Public Class CircularProgressBarControl
    Inherits Control

    Private _progress As Integer = 0
    Private _lineThickness As Integer = 10
    Private _lineColor As Color = Color.Blue
    Private _innerCircleColor As Color = Color.White
    Private _fontStyle As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _displayText As String = "0%"
    Private _displayDuration As Integer = 2000 ' Duration in milliseconds
    Private _cancelled As Boolean = False
    Private hideTimer As System.Windows.Forms.Timer

    Public Property Progress As Integer
        Get
            Return _progress
        End Get
        Set(value As Integer)
            If value <> _progress Then
                If value < 0 Then value = 0
                If value > 100 Then value = 100
                _progress = value
                _displayText = $"{_progress}%"
                Me.Invalidate()
                Me.Refresh() ' Force the control to repaint immediately
                If _progress >= 100 Then
                    StartHideTimer()
                End If
            End If
        End Set
    End Property


    Public Property LineThickness As Integer
        Get
            Return _lineThickness
        End Get
        Set(value As Integer)
            _lineThickness = value
            Me.Invalidate()
        End Set
    End Property

    Public Property LineColor As Color
        Get
            Return _lineColor
        End Get
        Set(value As Color)
            _lineColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property InnerCircleColor As Color
        Get
            Return _innerCircleColor
        End Get
        Set(value As Color)
            _innerCircleColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property DisplayFont As Font
        Get
            Return _fontStyle
        End Get
        Set(value As Font)
            _fontStyle = value
            Me.Invalidate()
        End Set
    End Property

    Public Property DisplayDuration As Integer
        Get
            Return _displayDuration
        End Get
        Set(value As Integer)
            _displayDuration = value
        End Set
    End Property

    Public Property Cancelled As Boolean
        Get
            Return _cancelled
        End Get
        Set(ByVal value As Boolean)
            _cancelled = value
            If _cancelled Then
                _displayText = "Cancelled"
                StartHideTimer()
            End If
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Draw the inner circle first, slightly smaller than the progress bar
        Dim innerCircleMargin As Integer = _lineThickness / 2
        Using brush As New SolidBrush(_innerCircleColor)
            Dim innerRect As New Rectangle(innerCircleMargin, innerCircleMargin, Me.Width - 2 * innerCircleMargin, Me.Height - 2 * innerCircleMargin)
            e.Graphics.FillEllipse(brush, innerRect)
        End Using

        ' Draw the progress arc on top of the inner circle
        Using path As New GraphicsPath()
            path.AddArc(CSng(_lineThickness / 2), CSng(_lineThickness / 2), CSng(Me.Width - _lineThickness), CSng(Me.Height - _lineThickness), -90, 360 * (_progress / 100.0F))
            Using pen As New Pen(_lineColor, _lineThickness) With {.StartCap = LineCap.Round, .EndCap = LineCap.Round}
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using

        ' Draw the text on top of everything
        Using brush As New SolidBrush(Me.ForeColor)
            Dim fontSize As Single = _fontStyle.Size
            Dim textSize As SizeF = e.Graphics.MeasureString(_displayText, _fontStyle)
            While textSize.Width > Me.Width - _lineThickness * 2 AndAlso fontSize > 1
                fontSize -= 1
                textSize = e.Graphics.MeasureString(_displayText, New Font(_fontStyle.FontFamily, fontSize, _fontStyle.Style))
            End While
            Dim textPoint As New PointF((Me.Width - textSize.Width) / 2, (Me.Height - textSize.Height) / 2)
            e.Graphics.DrawString(_displayText, New Font(_fontStyle.FontFamily, fontSize, _fontStyle.Style), brush, textPoint)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
        ' Do not paint background to keep transparency
    End Sub

    Private Sub StartHideTimer()
        If hideTimer Is Nothing Then
            hideTimer = New System.Windows.Forms.Timer()
            AddHandler hideTimer.Tick, AddressOf HideControl
        End If
        hideTimer.Interval = _displayDuration
        hideTimer.Start()
    End Sub

    Private Sub HideControl(sender As Object, e As EventArgs)
        Me.Visible = False
        hideTimer.Stop()
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
    End Sub
End Class
