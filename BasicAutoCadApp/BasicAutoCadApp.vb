Public Class BasicAutoCadApp

    'Project Variables
    Dim g1, g2 As Graphics
    Dim dColor As Color
    Dim dPen As Pen
    Dim dBrush As Brush
    Dim dFont As Font
    Dim size_h, size_w, dsize As Integer
    Dim selShape, selItem As String
    Dim lp1, lp2, p1, p2 As Point

    Dim currBmp As Bitmap
    Dim currImg As Image
    Dim flagImg, flagPaint, flagFill, flagP1 As Boolean


    'AutoCad Project Variables
    Dim compList As ArrayList
    Dim rotation As Integer = 0
    Dim selectedShape As Integer = -1


    Dim flagSelect, flagCopy, flagPaste, flagCut As Boolean
    Dim currShape As shapeX = Nothing

    Dim zoom As Double = 1.0
    Dim flagZoom As Boolean = False
    Dim IC_Start As Integer = 30
    Dim dText As String = ""
    Dim currFile As String = ""
    Dim nl As String = Chr(13) + Chr(10)




    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        start()
    End Sub

    ' ***************** Main Code **********************
    Private Sub start()

        Dim pw As Integer = Panel1.Width
        Dim ph As Integer = Panel1.Height

        currBmp = New Bitmap(pw, ph)
        g2 = Graphics.FromImage(currBmp)
        g1 = Panel1.CreateGraphics()

        dsize = 50 : size_h = 50 : size_w = 50

        penSize.Value = 1

        dColor = Color.Black
        dBrush = New SolidBrush(dColor)
        dPen = New Pen(dBrush, 1)
        flagPaint = False
        flagFill = False
        flagP1 = True
        selShape = "Rectangle"
        createDropDown()
        dFont = txtInput.Font
        clearScreen()
        startAutoCad()
    End Sub
    Private Sub createDropDown()
        cbox1.Items.Clear()
        cbox1.Items.Add("Drawing")
        cbox1.Items.Add("Rectangle (p1,p2)")
        cbox1.Items.Add("Ellipse (p1,p2)")
        cbox1.Items.Add("Square")
        cbox1.Items.Add("Rectangle (H)")
        cbox1.Items.Add("Rectangle (V)")
        cbox1.Items.Add("Circle")
        cbox1.Items.Add("Line")
        cbox1.Items.Add("Text")
        cbox1.Items.Add("Erase")
        cbox1.Items.Add("Erase Range")
        cbox1.SelectedIndex = 0
        setShape()

    End Sub
    Private Sub setShape()
        selItem = cbox1.SelectedItem.ToString()

        size_w = dsize : size_h = dsize
        selShape = selItem
        flagP1 = True
        lblStatus.Text = "Selected Shape: " + selShape

        MoveGraphics()
        rotation = 0
        flagSelect = False
        setEdit("")

    End Sub

    Private Sub pExit()
        Me.Dispose()
        Me.Close()
    End Sub



    Private Sub resizePanel()

        Try

            Dim tmp As Bitmap = currBmp
            Dim pw, ph As Integer
            pw = currBmp.Width
            ph = currBmp.Height

            If (ph < Panel1.Height) Then ph = Panel1.Height
            If (pw < Panel1.Width) Then pw = Panel1.Width

            currBmp = New Bitmap(pw, ph)
            g2 = Graphics.FromImage(currBmp)
            g1 = Panel1.CreateGraphics()

            clearPanel()
            g2.DrawImage(tmp, New Point(0, 0))
            MoveGraphics()
        Catch ex As Exception
        End Try
        'MessageBox.Show("Window Resized!"):
    End Sub
    Private Function CopyBitmap(srcBitmap As Bitmap, section As Rectangle) As Bitmap

        'Routine from MSDN
        ' Create the new bitmap and associated graphics object
        Dim bmp As Bitmap = New Bitmap(section.Width, section.Height)
        Dim g3 As Graphics = Graphics.FromImage(bmp)

        ' Draw the specified section of the source bitmap to the new one
        g3.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel)

        ' Clean up
        g3.Dispose()

        ' Return the bitmap
        Return bmp
    End Function

    Private Sub MoveGraphics()
        g1.DrawImage(currBmp, 0, 0)
        If (flagZoom = True) Then showZoom()
    End Sub
    Private Sub setPaste()
        selShape = "Paste Image"
        flagP1 = True
        lblStatus.Text = "Selected Shape: " + selShape
        Try
            flagImg = True
            currImg = Clipboard.GetImage()
        Catch ex As Exception
            flagImg = False
        End Try
    End Sub



    ' ************* Panel Mouse Events *****************
    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick
        addShapeX(e.X, e.Y) 'Testing
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
    End Sub
    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave
        MoveGraphics()
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        showShapeX(e.X, e.Y)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
    End Sub

    ' *********** Buttons and Menus Events **************
    Private Sub button_Click(sender As Object, e As EventArgs) Handles btnCut.Click, btnPaste.Click, btnFont.Click, btnCopy.Click, btnColor.Click, btnExit.Click, btnRotate.Click, btnClear.Click
        Dim txt As String = sender.ToString()
        Dim i, l As Integer
        l = txt.Length
        i = txt.LastIndexOf(":") + 2
        Dim str As String = txt.Substring(i)
        Select Case (str)
            Case "Exit" : pExit() : Exit Select

            Case "Color"
                changeColor()
                Exit Select
            Case "Font"
                changeFont()
                Exit Select
            Case "Cut"
                setEdit("Cut")
                Exit Select

            Case "Copy"
                setEdit("Copy")
                Exit Select

            Case "Paste"
                setEdit("Paste")
                Exit Select

            Case "Clear"
                clearScreen()
                Exit Select

            Case "Rotate"
                rotation = rotation + 1
                If rotation > 3 Then rotation = 0

                Exit Select

        End Select
    End Sub

    Private Sub Menu_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub ShapDropDown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbox1.SelectedIndexChanged
        setShape()
    End Sub


    Private Sub penSize_ValueChanged(sender As Object, e As EventArgs) Handles penSize.ValueChanged
        Dim ps As Integer = Convert.ToInt32(penSize.Value)
        dPen = New Pen(dColor, ps)

    End Sub


    Private Sub NewFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFileToolStripMenuItem.Click
        CurrFile = ""
        clearScreen()
    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub SaveFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveFileToolStripMenuItem.Click
        SaveFile()
    End Sub

    Private Sub SaveFileAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveFileAsToolStripMenuItem.Click
        SaveAs()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        pExit()
    End Sub


    Private Sub clearMenu_Click(sender As Object, e As EventArgs)
        clearScreen()
    End Sub

    Private Sub Panel1_Resize(sender As Object, e As EventArgs) Handles Panel1.Resize
        resizePanel()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim msg As String = ""
        msg = msg + "Basic AutoCad Program " + Chr(13)
        msg = msg + "Made as Part of a Training Program " + Chr(13)
        msg = msg + "By Paulo Ramos @ Aug/2016 " + Chr(13)
        MessageBox.Show(msg, "Basic Paint Program")

    End Sub

    Private Sub ExportAsImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportAsImageToolStripMenuItem.Click
        SaveAsImage()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        setEdit("Cut")
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        setEdit("Copy")
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        setEdit("Paste")
    End Sub

    Private Sub ChangeFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeFontToolStripMenuItem.Click
        changeFont()
    End Sub

    Private Sub ChangeColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeColorToolStripMenuItem.Click
        changeColor()
    End Sub

    Private Sub ZoomINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomINToolStripMenuItem.Click
        zoomIN()
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        zoomOut()
    End Sub

    Private Sub ListComponentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListComponentsToolStripMenuItem.Click
        listAllComponents()
    End Sub

    '**************************************************************************************************
    '****************************** [AUTOCAD CODE ]****************************************************
    '**************************************************************************************************
    Private Sub startAutoCad()

        compList = New ArrayList()
        createDropDownAutoCad()

    End Sub
    Private Sub createDropDownAutoCad()
        cbox1.Items.Clear()
        cbox1.Items.Add("Line")
        cbox1.Items.Add("Rectangle")
        cbox1.Items.Add("Circle")
        cbox1.Items.Add("Text")
        cbox1.Items.Add("***************")
        cbox1.Items.Add("Wire")
        cbox1.Items.Add("Resistor")
        cbox1.Items.Add("Capacitor")
        cbox1.Items.Add("Electrolytic Capacitor")
        cbox1.Items.Add("Diode")
        cbox1.Items.Add("LED")
        cbox1.Items.Add("LDR")

        cbox1.Items.Add("Transistor NPN")
        cbox1.Items.Add("Transistor PNP")
        cbox1.Items.Add("Variable Resistor")
        cbox1.Items.Add("Variable Capacitor")

        cbox1.Items.Add("Positive")
        cbox1.Items.Add("Negative")
        cbox1.Items.Add("Ground")
        cbox1.Items.Add("Battery")
        cbox1.Items.Add("Speaker")
        cbox1.Items.Add("Connector")
        cbox1.Items.Add("Dot")

        cbox1.Items.Add("Inductor 2 pins")
        cbox1.Items.Add("Inductor 3 pins")
        cbox1.Items.Add("Small Inductor")
        cbox1.Items.Add("Relay")
        cbox1.Items.Add("Transformer")
        cbox1.Items.Add("RF Coil")




        cbox1.Items.Add("***************")
        cbox1.Items.Add("IC 2 pins")
        cbox1.Items.Add("IC 4 pins")
        cbox1.Items.Add("IC 6 pins")
        cbox1.Items.Add("IC 8 pins")
        cbox1.Items.Add("IC 10 pins")
        cbox1.Items.Add("IC 12 pins")
        cbox1.Items.Add("IC 14 pins")
        cbox1.Items.Add("IC 16 pins")
        cbox1.Items.Add("IC 18 pins")
        cbox1.Items.Add("IC 20 pins")
        cbox1.Items.Add("IC 22 pins")
        cbox1.Items.Add("IC 24 pins")
        cbox1.Items.Add("IC 26 pins")
        cbox1.Items.Add("IC 28 pins")
        cbox1.Items.Add("IC 30 pins")
        cbox1.Items.Add("IC 32 pins")
        cbox1.Items.Add("IC 34 pins")
        cbox1.Items.Add("IC 36 pins")
        cbox1.Items.Add("IC 38 pins")
        cbox1.Items.Add("IC 40 pins")
        cbox1.Items.Add("IC 42 pins")
        cbox1.Items.Add("IC 44 pins")
        cbox1.Items.Add("IC 46 pins")
        cbox1.Items.Add("IC 48 pins")
        cbox1.Items.Add("IC 50 pins")
        cbox1.Items.Add("***************")

        cbox1.SelectedIndex = 0
        setShape()
    End Sub

    Private Sub drawComponentX(g As Graphics, str As String, x As Integer, y As Integer, rot As Integer)

        Dim dx1, dy1, dx2, dy2, x1, y1, x2, y2, n, ctr, i, a1, a2 As Integer
        Dim px1, px2 As Point
        Dim sp As String = "L"


        Dim strx() As String = str.Replace(" ", "").Split(":")
        n = Convert.ToInt32(strx(0))

        ctr = 1
        If n = 0 Then Return
        For i = 0 To n - 1
            '---------------- Reading the String -------------------------------
            sp = strx(ctr + 0)
            dx1 = Convert.ToInt32(strx(ctr + 1)) : dy1 = Convert.ToInt32(strx(ctr + 2))
            dx2 = Convert.ToInt32(strx(ctr + 3)) : dy2 = Convert.ToInt32(strx(ctr + 4))
            ctr = ctr + 5
            '---------------- Rotation -----------------------------------------
            x1 = x + dx1 : y1 = y + dy1 : x2 = x + dx2 : y2 = y + dy2 : a1 = 270 : a2 = 90 'default
            If (rot = 1) Then x1 = x + dy1 : y1 = y + dx1 : x2 = x + dy2 : y2 = y + dx2 : a1 = 180 : a2 = 0
            If (rot = 2) Then x1 = x - dx1 : y1 = y - dy1 : x2 = x - dx2 : y2 = y - dy2 : a1 = 90 : a2 = 270
            If (rot = 3) Then x1 = x - dy1 : y1 = y - dx1 : x2 = x - dy2 : y2 = y - dx2 : a1 = 0 : a2 = 180
            '--------------- px2 always > px1 ----------------------------------
            px2 = New Point(x2, y2) : px1 = New Point(x1, y1) 'Default
            If (y2 > y1 And x2 > x1) Then px2 = New Point(x2, y2) : px1 = New Point(x1, y1)
            If (y2 > y1 And x1 > x2) Then px2 = New Point(x1, y2) : px1 = New Point(x2, y1)
            If (y1 > y2 And x1 > x2) Then px2 = New Point(x1, y1) : px1 = New Point(x2, y2)
            If (y1 > y2 And x2 > x1) Then px2 = New Point(x2, y1) : px1 = New Point(x1, y2)
            If (sp.Equals("L")) Then px2 = New Point(x2, y2) : px1 = New Point(x1, y1)

            Dim pen As Pen = dPen
            '--------------- Basic Shapes ---------------------------------------
            If (sp.Equals("L")) Then g.DrawLine(pen, px1.X, px1.Y, px2.X, px2.Y) 'Line
            If (sp.Equals("R")) Then g.DrawRectangle(pen, px1.X, px1.Y, px2.X - px1.X, px2.Y - px1.Y) 'Rectangle
            If (sp.Equals("C")) Then g.DrawEllipse(pen, px1.X, px1.Y, px2.X - px1.X, px2.Y - px1.Y) 'Circle
            If (sp.Equals("A")) Then g.DrawArc(pen, px1.X, px1.Y, px2.X - px1.X, px2.Y - px1.Y, a1, 180)
            If (sp.Equals("IA")) Then g.DrawArc(pen, px1.X, px1.Y, px2.X - px1.X, px2.Y - px1.Y, a2, 180)
            '--------------------------------------------------------------------
        Next
    End Sub
    Private Sub clearScreen()
        g2.Clear(panel1.BackColor)
        Try
            compList.Clear()
        Catch ex As Exception
        End Try
        MoveGraphics() 'Moves g2(BitMap) to g1(Panel)
    End Sub
    Private Sub clearPanel()
        g2.Clear(panel1.BackColor)
    End Sub

    Private Sub updateScreen()
        clearPanel()
        Dim t As shapeX
        Dim bklp1 As Point = lp1 'backup
        For i = 0 To compList.Count() - 1
            t = compList(i)
            drawComponent(g2, t.shape, t.x, t.y, t.rot, t.lpx, False, t.txt)
        Next
        MoveGraphics()
        lp1 = bklp1 'Restore
    End Sub

    Private Sub showShapeX(x As Integer, y As Integer)
        Dim comp As Integer = cbox1.SelectedIndex
        dText = txtInput.Text.ToString()
        MoveGraphics()

        If (flagCopy = True Or flagCut = True) Then Return
        If (flagPaste = True And selectedShape <> -1) Then
            Dim t As shapeX
            t = currShape
            dColor = Color.Blue
            drawComponent(g1, t.shape, x, y, t.rot, t.lpx, False, t.txt)
            dColor = Color.Black
        Else
            drawComponent(g1, comp, x, y, rotation, lp1, flagP1, dText)
        End If
    End Sub


    Private Sub addShapeX(x As Integer, y As Integer)
        Dim comp As Integer = cbox1.SelectedIndex
        If (flagPaste = True And selectedShape <> -1) Then
            Dim t As shapeX = New shapeX(currShape.shape, x, y, currShape.rot)
            t.lpx = currShape.lpx : t.txt = currShape.txt
            compList.Add(t) : updateScreen()
            pasteShape() : flagPaste = False : selectedShape = -1 : flagSelect = False : Return
        End If
        If (flagSelect = True) Then SelectShape(x, y)
        If (flagCopy = True And selectedShape <> -1) Then copyShape() : Return
        If (flagCut = True And selectedShape <> -1) Then cutShape() : Return


        If (comp = 0 Or comp = 1 Or comp = 2 Or comp = 5) Then
            If (flagP1 = True) Then
                lp1 = New Point(x, y) : flagP1 = False
            Else
                Dim t As shapeX = New shapeX(comp, x, y, rotation)
                t.lpx = lp1
                compList.Add(t)
                updateScreen()
                flagP1 = True
            End If
        Else
            Dim t As shapeX = New shapeX(comp, x, y, rotation)
            If (comp = 3) Then t.txt = txtInput.Text
            compList.Add(t)
            updateScreen()
        End If

    End Sub
    Private Sub drawComponent(g As Graphics, comp As Integer, x As Integer, y As Integer, rot As Integer, lpz As Point, flagPt As Boolean, lText As String)
        Dim str As String = ""
        Dim dx, dy As Integer

        If (comp = 0 Or comp = 1 Or comp = 2 Or comp = 5) Then
            If (flagPt = False) Then
                dx = lpz.X - x : dy = lpz.Y - y
                Dim strXY As String = Convert.ToString(dx) + ":" + Convert.ToString(dy) + ":"
                If ((lpz.X - x <> 0) Or (lpz.Y - y <> 0)) Then

                    If (comp = 0) Then str = "1:L:0:0:" + strXY 'Line
                    If (comp = 1) Then str = "1:R:0:0:" + strXY 'Rectangle
                    If (comp = 2) Then str = "1:C:0:0:" + strXY 'Circle

                    If (comp = 5) Then
                        Dim strXY1 As String = Convert.ToString(dx - 1) + ":" + Convert.ToString(dy - 1) + ":"
                        Dim strXY2 As String = Convert.ToString(dx + 1) + ":" + Convert.ToString(dy + 1) + ":"
                        str = "3: R:-1:-1:1:1: L:0:0:" + strXY + " R:" + strXY1 + strXY2
                    End If 'Wire
                End If
            End If
        End If 'Wire	
        If (comp = 6) Then str = "3: L:0:0:12:0: R:12:4:36:-4: L:36:0:48:0:" 'Resistor
        If (comp = 7) Then str = "4: L:0:0:12:0: L:12:8:12:-8: L:18:8:18:-8: L:18:0:30:0:" 'Capacitor
        If (comp = 8) Then str = "7: L:0:0:12:0: L:10:8:10:-8: L:12:8:12:-8: L:18:8:18:-8: L:18:0:30:0: L:20:-4:26:-4: L:23:-2:23:-8:" 'Electrolytic Capacitor
        If (comp = 9) Then str = "6: L:0:0:12:0: L:12:6:12:-6: L:12:6:24:0: L:12:-6:24:0: L:24:6:24:-6: L:24:0:36:0:" 'Diode
        If (comp = 10) Then str = "12: L:0:0:12:0: L:12:6:12:-6: L:12:6:24:0: L:12:-6:24:0: L:24:6:24:-6: L:24:0:36:0:  L:28:-6:34:-12: L:31:-12:34:-12: L:34:-12:34:-9: L:36:-6:42:-12: L:39:-12:42:-12: L:42:-12:42:-9:" 'LED
        If (comp = 11) Then str = "9: L:0:0:12:0: R:12:4:36:-4: L:36:0:48:0:  L:12:-18:18:-12: L:15:-12:18:-12: L:18:-12:18:-15:  L:18:-18:24:-12: L:21:-12:24:-12: L:24:-12:24:-15:" 'LDR
        If (comp = 12) Then str = "8: C:8:16:36:-16: L:0:0:18:0: L:18:12:18:-12: L:18:4:40:12: L:18:-4:40:-12: L:26:4:23:10: L:23:10:35:10: L:26:4:35:10:  " 'NPN Transistor
        If (comp = 13) Then str = "8: C:8:16:36:-16: L:0:0:18:0: L:18:12:18:-12: L:18:4:40:12: L:18:-4:40:-12:  L:19:-4:25:-10: L:19:-4:27:-4:  L:27:-4:25:-10:" 'PNP Transistor

        If (comp = 14) Then str = "6: L:0:0:12:0: R:12:4:36:-4: L:36:0:48:0:  L:18:12:30:-12: L:30:-12:26:-10: L:31:-12:31:-8:" 'Variable Resistor
        If (comp = 15) Then str = "7: L:0:0:12:0: L:12:8:12:-8: L:18:8:18:-8: L:18:0:30:0: L:6:12:24:-12:  L:24:-12:20:-10: L:25:-12:25:-8:" ' Variable Capacitor

        If (comp = 16) Then str = "4: L:12:1:30:1: L:12:0:30:0: L:21:-9:21:9: L:22:-9:22:9:" 'Positive
        If (comp = 17) Then str = "2: L:12:1:30:1: L:12:0:30:0: " 'Negative
        If (comp = 18) Then str = "4: L:0:0:0:12: L:-12:12:12:12: L:-8:18:8:18:  L:-4:24:4:24:" 'Ground
        If (comp = 19) Then str = "9: L:0:0:0:12: L:-12:12:12:12: L:-8:18:8:18:  L:-12:24:12:24: L:-8:30:8:30: L:0:30:0:42: L:4:6:10:6: L:7:3:7:9:  L:4:36:10:36:" 'Battery
        If (comp = 20) Then str = "4: R:0:0:12:24: L:12:24:24:36: L:12:0:24:-12: L:24:-12:24:36:" 'IC X

        If (comp = 21) Then str = "1: C:0:0:8:8: " 'Connector
        If (comp = 22) Then str = "1: R:0:0:3:3: " 'Dot

        If (comp = 23) Then str = "6: A:0:0:18:12:  A:0:12:18:24:  A:0:24:18:36:  A:0:36:18:48: L:0:0:12:0: L:0:48:12:48: " 'Inductor 2 pins
        If (comp = 24) Then str = "7: A:0:0:18:12:  A:0:12:18:24:  A:0:24:18:36:  A:0:36:18:48:  L:0:0:12:0: L:0:48:12:48: L:0:24:12:24: " 'Inductor 3 pins
        If (comp = 25) Then str = "4: A:0:0:18:12:  A:0:12:18:24:  L:0:0:12:0: L:0:24:12:24: " 'Small inductor
        If (comp = 26) Then str = "11: A:0:0:18:12:  A:0:12:18:24:  A:0:24:18:36:  A:0:36:18:48: L:0:0:12:0: L:0:48:12:48:  L:24:0:24:48: C:36:0:42:8:   C:36:24:42:16:   C:36:48:42:40:  L:36:24:30:3:" 'Relay
        If (comp = 27) Then
            str = "15: A:0:0:18:12:  A:0:12:18:24:  A:0:24:18:36:  A:0:36:18:48: L:0:0:12:0: L:0:48:12:48:  L:24:0:24:48: L:30:0:30:48: "
            str = str + " IA:36:0:54:12:  IA:36:12:54:24:  IA:36:24:54:36:  IA:36:36:54:48:  L:46:0:58:0: L:46:48:58:48: L:46:24:58:24: "
        End If 'Transformer
        If (comp = 28) Then
            str = "18: A:0:0:18:12:  A:0:12:18:24:  A:0:24:18:36:  A:0:36:18:48: L:0:0:12:0: L:0:48:12:48:  L:24:0:24:48: L:30:0:30:48: "
            str = str + " IA:36:0:54:12:  IA:36:12:54:24:  IA:36:24:54:36:  IA:36:36:54:48:  L:46:0:58:0: L:46:48:58:48: L:46:24:58:24: "
            str = str + " L:20:52:35:-4:  L:35:-4:31:0: L:35:-4:37:0: "
        End If 'RF Coil


        If (comp >= IC_Start) Then drawIC(comp - (IC_Start - 1), g, x, y, rot) 'IC X

        If (comp = 3) Then
            If (lText.Length > 0) Then
                Dim p2 As Point = New Point(x, y) : g.DrawString(lText, dFont, dBrush, p2)
            End If
        End If
        If (str.Length > 0) Then drawComponentX(g, str, x, y, rot)

    End Sub


    Private Sub drawIC(n As Integer, g As Graphics, x As Integer, y As Integer, rot As Integer)
        Dim i, lx, ly, dx, dy, d, pin, fct, dt, x1, x2, y1, y2 As Integer
        Dim stn As String

        Dim pen As Pen = dPen


        'Draw Terminals and Numbers
        dx = 12 : dy = 15

        d = 8 : dt = 8
        If (n > 4) Then dt = 16
        If (n > 4) Then dx = 16

        pin = 1
        lx = x : ly = y + dy
        If (rot = 0 Or rot = 2) Then lx = x : ly = y + dy
        If (rot = 1 Or rot = 3) Then lx = x + dx : ly = y
        'n = 2:
        For i = 0 To n - 1 'Left
            stn = Convert.ToString(pin).Replace(" ", "") : pin = pin + 1
            dt = stn.Length * 8
            If (rot = 0 Or rot = 2) Then
                lx = x
                g.DrawLine(pen, lx, ly - 4, lx + d, ly - 4) 'Line#1
                Dim p2 As Point = New Point(lx + d + 3, ly - 12) : g.DrawString(stn, dFont, dBrush, p2)


                ly = ly + dy
            End If
            If (rot = 1 Or rot = 3) Then
                ly = y
                g.DrawLine(pen, lx - 4, ly, lx - 4, ly + d) 'Line#1
                Dim p2 As Point = New Point(lx - dt, ly + d * 2 - 12 + 3) : g.DrawString(stn, dFont, dBrush, p2)
                lx = lx + dy
            End If
        Next

        If (rot = 0 Or rot = 2) Then ly = ly - dy
        If (rot = 1 Or rot = 3) Then lx = lx - dy

        For i = 0 To n - 1 'Right
            stn = Convert.ToString(pin).Replace(" ", "") : pin = pin + 1
            dt = stn.Length * 8

            If (rot = 0 Or rot = 2) Then
                lx = x + dx * 3
                g.DrawLine(pen, lx, ly - 4, lx + d, ly - 4) 'Line#1
                Dim p2 As Point = New Point(lx - dt - 3, ly - 12) : g.DrawString(stn, dFont, dBrush, p2)
                ly = ly - dy
            End If
            If (rot = 1 Or rot = 3) Then
                ly = y + dx * 3
                g.DrawLine(pen, lx - 4, ly, lx - 4, ly + d) 'Line#1
                Dim p2 As Point = New Point(lx - dt, ly - 12 - 4) : g.DrawString(stn, dFont, dBrush, p2)
                lx = lx - dy
            End If
        Next

        'Draw Rectangle
        '---------------- Rotation -----------------------------------------
        If (rot = 0 Or rot = 2) Then g.DrawRectangle(pen, x + d, y, dx * 3 - d, dy * (n) + d) 'Rectangle
        If (rot = 1 Or rot = 3) Then g.DrawRectangle(pen, x, y + d, dy * (n) + d, dx * 3 - d) 'Rectangle
    End Sub

    '************************Edit Options: Copy, Cut and Paste **************************
    Private Sub SelectShape(x As Integer, y As Integer)
        Dim t As shapeX
        Dim rx1, rx2, ry1, ry2, comp, rg As Integer
        selectedShape = -1
        For i = 0 To compList.Count() - 1

            t = compList(i)
            comp = t.shape
            If (comp = 0 Or comp = 1 Or comp = 2 Or comp = 5) Then
            Else
                If (t.rot = 0) Then t.lpx.X = t.x + 40 : t.lpx.Y = t.y + 20
                If (t.rot = 1) Then t.lpx.X = t.x + 20 : t.lpx.Y = t.y + 40
                If (t.rot = 2) Then t.lpx.X = t.x - 40 : t.lpx.Y = t.y - 20
                If (t.rot = 3) Then t.lpx.X = t.x - 20 : t.lpx.Y = t.y - 40
            End If


            If (t.x > t.lpx.X) Then rx2 = t.x : rx1 = t.lpx.X Else rx1 = t.x : rx2 = t.lpx.X
            If (t.y > t.lpx.Y) Then ry2 = t.y : ry1 = t.lpx.Y Else ry1 = t.y : ry2 = t.lpx.Y

            'drawComponent(g2, t.shape, t.x, t.y, t.rot, t.lpx, false, t.txt):
            rg = 4
            If (x >= rx1 - rg And x <= rx2 + rg And y >= ry1 - rg And y <= ry2 + rg) Then selectedShape = i : currShape = compList(i) : Exit For
        Next
        'selectedShape = 2:
        MoveGraphics()
        showSelectedShape()
        If (selectedShape <> -1) Then flagSelect = False
    End Sub
    Private Sub showSelectedShape()
        If (selectedShape <> -1) Then
            Try
                Dim t As shapeX
                t = compList(selectedShape)
                dColor = Color.Blue
                drawComponent(g1, t.shape, t.x, t.y, t.rot, t.lpx, False, t.txt)
                dColor = Color.Black
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub copyShape()
        If (selectedShape <> -1) Then
            currShape = compList(selectedShape)
            updateScreen()
            setEdit("Paste")
        End If
    End Sub
    Private Sub cutShape()
        If (selectedShape <> -1) Then
            currShape = compList(selectedShape)
            compList.RemoveAt(selectedShape)
            updateScreen()
            setEdit("Paste")
        End If
    End Sub
    Private Sub pasteShape()
        setEdit("")
        setShape()
    End Sub
    Private Sub setEdit(opt As String)
        flagPaste = False : flagCut = False : flagCopy = False : flagSelect = False
        If (opt = "Cut") Then
            selShape = "Cut Image"
            flagCut = True
            flagSelect = True
        End If
        If (opt = "Copy") Then
            selShape = "Copy Image"
            flagCopy = True
            flagSelect = True
        End If
        If (opt = "Paste" And selectedShape <> -1) Then
            selShape = "Paste Image"
            flagPaste = True
            flagSelect = True
        End If
        flagP1 = True

        lblStatus.Text = "Selected Shape: " + selShape
    End Sub
    '*******************************List all Components**********************************

    Private Sub listAllComponents()

        Dim x, y, i, ck, rot, fct As Integer
        x = 25 : y = 20
        rot = rotation
        clearScreen()


        txtInput.Text = "Text"
        For i = 0 To cbox1.Items.Count() - 1
            cbox1.SelectedIndex = i
            lp1 = New Point(x + 45, y + 45)
            flagP1 = False
            rotation = rot

            ck = compList.Count
            addShapeX(x, y) 'Testing
            If (compList.Count() > ck) Then 'Valid Component
                fct = 0
                If (i >= IC_Start) Then
                    fct = i - (IC_Start - 2)
                    y = y + 16 * fct
                Else
                    y = y + 70
                End If
                If (y >= 440) Then x = x + 70 : y = 20
            End If
            If (i >= (IC_Start + 8)) Then Exit For

        Next
        txtInput.Text = ""
        cbox1.SelectedIndex = 0

    End Sub
    Private Sub changeColor()
        Dim cd As ColorDialog = New ColorDialog()
        If (cd.ShowDialog() = DialogResult.OK) Then
            dColor = cd.Color
            Dim ps As Integer = Convert.ToInt32(penSize.Value)
            dPen = New Pen(dColor, ps)
            dBrush = New SolidBrush(dColor)
            btnColor.ForeColor = cd.Color
        End If
    End Sub
    Private Sub changeFont()
        Dim fd As FontDialog = New FontDialog()
        If (fd.ShowDialog() = DialogResult.OK) Then
            dFont = fd.Font
            txtInput.Font = fd.Font
            txtInput.Font = New Font(txtInput.Font.FontFamily, 10)
        End If
    End Sub

    '*************************(FILES: OPEN, SAVE, SAVE AS, CLOSE)************************
    Private Sub SaveAsImage()

        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.InitialDirectory = "C:\temp"
        'sfd.DefaultExt = "Bitmaps | *.bmp | All Files | *.*":
        sfd.FileName = "C:\temp\csharp1.bmp"
        If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            currFile = sfd.FileName
            Try
                currBmp.Save(currFile, System.Drawing.Imaging.ImageFormat.Bmp)
                MessageBox.Show("File '" + currFile + "' Saved!", "Save File")
            Catch ex As Exception
                MessageBox.Show("Error Saving Bitmap to File '" + currFile + "\nError: " + ex.Message, "Save File Error")
            End Try
        End If
    End Sub

    Private Sub SaveFile()
        If (currFile = "" Or currFile = Nothing) Then
            SaveAs()
            Return
        End If
        saveSchFile()
    End Sub

    Private Sub SaveAs()
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.InitialDirectory = "C:\\temp"
        'sfd.DefaultExt = "Bitmaps | *.bmp | All Files | *.*":
        sfd.FileName = "C:\\temp\\csharp1.bmp"
        If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            currFile = sfd.FileName
            saveSchFile()
        End If
    End Sub

    Private Sub OpenFile()
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.InitialDirectory = "C:\\temp"
        ofd.DefaultExt = "Bitmaps | *.bmp | All Files | *.*"
        If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            currFile = ofd.FileName
            openSchFile()
        End If
    End Sub

    Private Sub saveSchFile()
        Dim cFile As String = currFile
        If (currFile = "") Then Return

        Try
            Dim file1 As System.IO.StreamWriter = New System.IO.StreamWriter(cFile)

            file1.Write("AutoCad-ProjectFile:" + nl)

            Dim t As shapeX
            For i = 0 To compList.Count - 1
                t = compList(i)
                file1.Write("Data:" + nl + " " + t.shape.ToString() + " " + t.x.ToString() + " " + t.y.ToString() + " " + t.rot.ToString() + " " + t.lpx.X.ToString() + " " + t.lpx.Y.ToString() + " " + nl)
                If (t.txt.Length > 0) Then file1.Write("Text:" + nl + " " + t.txt + " " + nl)
                'If (t.fnt <> Nothing) Then file1.Write("Font:" + nl + " " + +t.fnt.ToString() + " " + nl)
            Next


            file1.Write("End:" + nl)
            file1.Close()
            MessageBox.Show("File Saved!", "Basic AutoCad")

        Catch e As Exception
            MessageBox.Show("Error: " + e.Message, "Save File Error")
        End Try

    End Sub


    Private Sub openSchFile()
        If (currFile = "" Or currFile = Nothing) Then
            MsgBox("Select a Valid File!", "Open File Error")
            Return
        End If

        clearScreen()
        ' ****************** Opening the File ******************
        Dim cFile As String = ""
        Dim tmpf As String = ""
        cFile = currFile
        Dim t As shapeX
        ' printf("\n%s\n", cFile):
        Dim shape, x, y, x2, y2, rot, ctx As Integer
        ctx = 0
        Try

            Dim file2 As System.IO.StreamReader = New System.IO.StreamReader(cFile)
            While (file2.Peek() >= 0)
                tmpf = file2.ReadLine()

                If (tmpf.Equals("Data:")) Then
                    Dim pr() As String = file2.ReadLine().Split(" ")
                    shape = Convert.ToInt32(pr(1))
                    x = Convert.ToInt32(pr(2))
                    y = Convert.ToInt32(pr(3))
                    rot = Convert.ToInt32(pr(4))
                    x2 = Convert.ToInt32(pr(5))
                    y2 = Convert.ToInt32(pr(6))
                    t = New shapeX(shape, x, y, rot)
                    t.lpx.X = x2 : t.lpx.Y = y2
                    compList.Add(t)
                    ctx = ctx + 1
                End If
                If (tmpf.Equals("Text:")) Then
                    tmpf = file2.ReadLine()
                    compList(ctx - 1).txt = tmpf
                End If
                If (tmpf.Equals("Font:")) Then
                    tmpf = file2.ReadLine()
                    'compList(ctx-1).fnt = Font.creat
                End If
                If (tmpf.Equals("End:")) Then
                    MessageBox.Show("** End of File **", "Open File")
                    Exit While
                End If

            End While
            file2.Close()

        Catch e As Exception
            MessageBox.Show("Error: " + e.Message, "Open File Error")
        End Try
        updateScreen()

    End Sub


    '************************** Zoom IN and Zoom OUT *****************************************
    Private Sub showZoom()
        Dim newSize As Size = New Size(Convert.ToInt32(currBmp.Width * zoom), Convert.ToInt32(currBmp.Height * zoom))
        Dim bmp As Bitmap = New Bitmap(currBmp, newSize)
        g1.DrawImage(bmp, 0, 0)
    End Sub
    Private Sub zoomIN()
        zoom += 0.25F
        flagZoom = True
        showZoom()
    End Sub
    Private Sub zoomOut()
        zoom = 1.0F
        flagZoom = False
    End Sub
    '*************************************************************************************


    '**************************************************************************************************
End Class


Class shapeX
    Public shape, x, y, rot As Integer

    Public lpx As Point = New Point(0, 0)
    Public txt As String = ""
    Public fnt As Font = Nothing
    Sub New(shape1 As Integer, x1 As Integer, y1 As Integer, rot1 As Integer)
        shape = shape1
        x = x1
        y = y1
        rot = rot1
    End Sub
End Class
