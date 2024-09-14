# CircularProgressBarControl
A custom circular progress bar control for Windows Forms applications.

# Features
- Customizable line thickness, colors, and font style
- Displays progress percentage
- Hides automatically after reaching 100% with a delay
- **New:** Cancelled property to cancel the progress bar

# Getting Started
Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later

# Installation
1. Download the latest DLL from the release page.
2. Add the DLL to your Visual Studio Toolbox:
    - Open your project in Visual Studio.
    - Open the Toolbox.
    - Right-click on the Toolbox and select Add Tab. Name the new tab (e.g., “Custom Controls”).
    - Right-click on the new tab and select Choose Items….
    - In the Choose Toolbox Items window, click the Browse button and navigate to the location of the DLL file.
    - Select the DLL file and click OK. The CircularProgressBarControl should now appear in your Toolbox.

# Usage
1. Add the control to your form:
    - Open the form designer.
    - Drag and drop the CircularProgressBarControl from the Toolbox onto your form.
2. Customize the control:
    - Use the Properties window to set the desired properties.

# Properties
- Progress (Integer): Gets or sets the progress value (0-100).
- LineThickness (Integer): Gets or sets the thickness of the progress line.
- LineColor (Color): Gets or sets the color of the progress line.
- InnerCircleColor (Color): Gets or sets the color of the inner circle.
- DisplayFont (Font): Gets or sets the font style of the displayed text.
- DisplayDuration (Integer): Gets or sets the duration (in milliseconds) for which the control remains visible after reaching 100%. If set to 0, the control will not hide automatically.
- **Cancelled (Boolean)**: Gets or sets the state of the progress bar to indicate cancellation. 
# Example
```
Dim progressBar As New CircularProgressBarControl()
progressBar.Progress = 75
progressBar.LineThickness = 15
progressBar.LineColor = Color.Green
progressBar.InnerCircleColor = Color.LightGray
progressBar.DisplayFont = New Font("Verdana", 14, FontStyle.Italic)
progressBar.DisplayDuration = 3000
progressBar.Size = New Size(200, 200)
progressBar.Location = New Point(50, 50)
Me.Controls.Add(progressBar)

```
![75](https://github.com/user-attachments/assets/07947085-9545-42f9-ad93-822743b339b6)

# Example with Progress Counter
```
Imports System.Threading

Public Class Form1
    Private WithEvents progressBar As New CircularProgressBarControl.CircularProgressBarControl()

    Public Sub New()
        InitializeComponent()
        InitializeProgressBar()
        Me.Show()
        StartProgress()
    End Sub

    Private Sub InitializeProgressBar()
        progressBar.Progress = 0
        progressBar.LineThickness = 15
        progressBar.LineColor = Color.Green
        progressBar.InnerCircleColor = Color.LightGray
        progressBar.DisplayFont = New Font("Verdana", 14, FontStyle.Italic)
        progressBar.DisplayDuration = 3000
        progressBar.Size = New Size(200, 200)
        progressBar.Location = New Point(50, 50)
        Me.Controls.Add(progressBar)
    End Sub

    Private Sub StartProgress()
        For i As Integer = 0 To 100
            progressBar.Progress = i
            Thread.Sleep(100) ' Delay for 100 milliseconds
        Next
    End Sub
End Class
```
![progressbar](https://github.com/user-attachments/assets/b9fc7209-9e20-4d6c-98cb-eba1a5c428aa)

#Example with Cancelled Property
```
Imports System.Threading


Public Class Form1
    Private WithEvents progressBar As New CircularProgressBarControl.CircularProgressBarControl()

    Public Sub New()
        InitializeComponent()
        InitializeProgressBar()
        Me.Show()
        StartProgress()
    End Sub

    Private Sub InitializeProgressBar()
        progressBar.Progress = 0
        progressBar.LineThickness = 15
        progressBar.LineColor = Color.Green
        progressBar.InnerCircleColor = Color.LightGoldenrodYellow
        progressBar.DisplayFont = New Font("Verdana", 14, FontStyle.Italic)
        progressBar.DisplayDuration = 3000
        progressBar.Size = New Size(200, 200)
        progressBar.Location = New Point(50, 50)
        Me.Controls.Add(progressBar)
    End Sub


    Private Sub StartProgress()
        For i As Integer = 0 To 100
            If i = 50 Then progressBar.Cancelled = True : Exit For
            progressBar.Progress = i
            Thread.Sleep(100) ' Delay for 100 milliseconds
        Next

    End Sub
End Class

```

![Cancell](https://github.com/user-attachments/assets/0f19289d-8d8c-461c-a4c2-7ff67ecf79a1)


# License
This project is licensed under the MIT License - see the LICENSE file for details.
