Public Class Form1
    Dim score As Integer


    Dim direction As Integer

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Follow(PictureBox2)
        Label1.Text = score

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
    Sub shawdows(p As PictureBox, x As Integer, y As Integer)
        p.Location = New Point(p.Location.X + x, p.Location.Y + y)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.R
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
                Me.Refresh()
            Case Keys.T
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                Me.Refresh()
            Case Keys.Up
                MoveTo(PictureBox1, 0, -5)
            Case Keys.Down
                MoveTo(PictureBox1, 0, 5)
            Case Keys.Left
                MoveTo(PictureBox1, -5, 0)
            Case Keys.Right
                MoveTo(PictureBox1, 5, 0)
            Case Keys.Space
                CreateNew("Bullet", win2, PictureBox1.Location)
            Case Else
        End Select
    End Sub



    Public Sub Follow(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X >= PictureBox1.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y <= PictureBox1.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, 0, y)
    End Sub

    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub




    Function Collision(p As PictureBox, t As String)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If p.Bounds.IntersectsWith(obj.Bounds) And (obj.Name.ToUpper.EndsWith(t.ToUpper) Or obj.Name.ToUpper.StartsWith(t.ToUpper)) Then
                col = True
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t

    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If direction < 0 Then


        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox1" And Collision(p, "Win", other) Then
            Me.PictureBox7.Visible = True

            other.visible = False
            Return

        End If
    End Sub
    Sub CreateNew(name As String, pic As PictureBox, location As Point)
        Dim p As New PictureBox
        p.Location = location
        p.Image = pic.Image
        p.BackColor = pic.BackColor
        p.Name = name
        p.Width = pic.Width
        p.Height = pic.Height
        p.SizeMode = PictureBoxSizeMode.StretchImage
        Controls.Add(p)

    End Sub
    Function getObject(p As String) As PictureBox
        For Each c In Controls
            If c.name.toupper.ToString.Contains(p.ToUpper) Then
                Return c
            End If
        Next
        Return Nothing


    End Function
    Function Collision(p As String, t As String, Optional ByRef other As Object = vbNull)
        For Each c In Controls
            If c.name.toupper.ToString.Contains(p.ToUpper) Then
                Return Collision(c, t, other)
            End If

        Next
        Return Nothing
    End Function

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    End Sub
End Class