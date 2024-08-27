# CircularProgressBarControl
A custom circular progress bar control for Windows Forms applications.

# Features
- Customizable line thickness, colors, and font style
- Displays progress percentage
- Hides automatically after reaching 100% with a delay

# Getting Started
Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later

# Installation
1. Download the DLL:
    - Build the project to generate the DLL file or download from the .
2. Add the DLL to your Visual Studio project:
    - Open your project in Visual Studio.
    - In the Solution Explorer, right-click on your project and select Add > Reference....
    - In the Reference Manager, click the Browse button and navigate to the location of the DLL file.
    - Select the DLL file and click Add.

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

# Example
```
Dim progressBar As New CircularProgressBarControl()
progressBar.Progress = 75
progressBar.LineThickness = 15
progressBar.LineColor = Color.Green
progressBar.InnerCircleColor = Color.LightGray
progressBar.DisplayFont = New Font("Verdana", 14, FontStyle.Italic)
progressBar.DisplayDuration = 3000
Me.Controls.Add(progressBar)

```
# Example with Progress Counter
```
Imports System.Threading

Public Class Form1
    Private WithEvents progressBar As New CircularProgressBarControl()

    Public Sub New()
        InitializeComponent()
        InitializeProgressBar()
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

# License
This project is licensed under the MIT License - see the LICENSE file for details.
