﻿'Martin Duong
'CIS 1051 Section 02
'Munchin' Monkeys
'2021

Public Class Form1
    'Creating Variables:
    Dim dx As Integer
    Dim dy As Integer
    Dim x1Banana As Integer
    Dim x2Banana As Integer
    Dim x3Banana As Integer
    Dim x4Banana As Integer
    Dim x5Banana As Integer
    Dim x6Banana As Integer
    Dim x7Snake As Integer
    Dim x8Snake As Integer
    Dim x9Powerup As Integer

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Key Presses Down; Speed (dx,dy) changes depending on keys
        If Timer4.Enabled = False Then
            If e.KeyCode = Keys.Right Then
                dx = 15
                dy = 0
            ElseIf e.KeyCode = Keys.Up Then
                dx = 0
                dy = -15
            ElseIf e.KeyCode = Keys.Down Then
                dx = 0
                dy = 15
            ElseIf e.KeyCode = Keys.Left Then
                dx = -15
                dy = 0
            End If
        End If
        If Timer4.Enabled = True Then
            If e.KeyCode = Keys.Right Then
                dx = 30
                dy = 0
            ElseIf e.KeyCode = Keys.Up Then
                dx = 0
                dy = -30
            ElseIf e.KeyCode = Keys.Down Then
                dx = 0
                dy = 30
            ElseIf e.KeyCode = Keys.Left Then
                dx = -30
                dy = 0
            End If

        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        'Key Releases; Speed (dx,dy) reverts back to (0,0)
        dx = 0
        dy = 0
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        BtnStart.Enabled = False
        BtnSetting.Enabled = False
        BtnStart.Visible = False
        BtnSetting.Visible = False
        Timer3.Enabled = True
        LBTitle.Visible = False
        LBInstructions.Visible = False
        LBTimerText.Visible = True
        LBTimer.Visible = True
        LBScoreText.Visible = True
        LBScore.Visible = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'MONKEY/BANANA/SNAKE/POWERUP MOVEMENT; BOUNDARIES/INTERSECTIONS ; TIMER HITS 60
        'PowerUp Movement
        PBPowerup.Top = PBPowerup.Top + x9Powerup
        If LBPowerup.Text >= 30 Then
            PBPowerup.Visible = True
            PBPowerup.Enabled = True
        End If
        If LBPowerup.Text < 30 Then
            PBPowerup.Visible = False
            PBPowerup.Enabled = False
            PBPowerup.Top = 0
            PBPowerup.Left = Int(Rnd() * (Me.Width - 140))
        End If
        'Monkey Movement
        PBMonkey.Left = PBMonkey.Left + dx
        PBMonkey.Top = PBMonkey.Top + dy
        'Banana Movement
        PBBanana1.Visible = True
        PBBanana1.Top = PBBanana1.Top + x1Banana
        If PBBanana1.Top > (Me.Height + 100) Then
            PBBanana1.Top = 0
            PBBanana1.Left = Int(Rnd() * (Me.Width - 140))
            x1Banana = Int(Rnd() * 11) + 5
        End If
        PBBanana2.Visible = True
        PBBanana2.Top = PBBanana2.Top + x2Banana
        If PBBanana2.Top > (Me.Height + 100) Then
            PBBanana2.Top = 0
            PBBanana2.Left = Int(Rnd() * (Me.Width - 140))
            x2Banana = Int(Rnd() * 11) + 5
        End If
        PBBanana3.Visible = True
        PBBanana3.Top = PBBanana3.Top + x3Banana
        If PBBanana3.Top > (Me.Height + 100) Then
            PBBanana3.Top = 0
            PBBanana3.Left = Int(Rnd() * (Me.Width - 140))
            x3Banana = Int(Rnd() * 11) + 5
        End If
        PBBanana4.Visible = True
        PBBanana4.Top = PBBanana4.Top + x4Banana
        If PBBanana4.Top > (Me.Height + 100) Then
            PBBanana4.Top = 0
            PBBanana4.Left = Int(Rnd() * (Me.Width - 140))
            x4Banana = Int(Rnd() * 11) + 5
        End If
        PBBanana5.Visible = True
        PBBanana5.Top = PBBanana5.Top + x5Banana
        If PBBanana5.Top > (Me.Height + 100) Then
            PBBanana5.Top = 0
            PBBanana5.Left = Int(Rnd() * (Me.Width - 140))
            x5Banana = Int(Rnd() * 11) + 5
        End If
        PBBanana6.Visible = True
        PBBanana6.Top = PBBanana6.Top + x6Banana
        If PBBanana6.Top > (Me.Height + 100) Then
            PBBanana6.Top = 0
            PBBanana6.Left = Int(Rnd() * (Me.Width - 140))
            x6Banana = Int(Rnd() * 11) + 5
        End If
        'Snake Movement
        PBSnake1.Visible = True
        PBSnake2.Visible = True
        PBSnake1.Top = PBSnake1.Top + x7Snake
        PBSnake2.Top = PBSnake2.Top + x8Snake
        If PBSnake1.Top > (Me.Height + 100) Then
            PBSnake1.Top = 0
            PBSnake1.Left = Int(Rnd() * (Me.Width - 140))
            x7Snake = Int(Rnd() * 9) + 5
        End If
        If PBSnake2.Top > (Me.Height + 100) Then
            PBSnake2.Top = 0
            PBSnake2.Left = Int(Rnd() * (Me.Width - 140))
            x8Snake = Int(Rnd() * 9) + 5
        End If
        'Detect Collision (Powerup)
        If PBMonkey.Bounds.IntersectsWith(PBPowerup.Bounds) Then
            Timer4.Enabled = True
            LBPowerup.Text = 0
            PBPowerup.Enabled = False
            PBPowerup.Visible = False
            PBPowerup.Top = 0

        End If
        'Detect Collision (Banana)
        If PBMonkey.Bounds.IntersectsWith(PBBanana1.Bounds) Then
            LBScore.Text += 1
            PBBanana1.Top = 0
            PBBanana1.Left = Int(Rnd() * (Me.Width - 140))
        End If
        If PBMonkey.Bounds.IntersectsWith(PBBanana2.Bounds) Then
            LBScore.Text += 1
            PBBanana2.Top = 0
            PBBanana2.Left = Int(Rnd() * (Me.Width - 140))
        End If
        If PBMonkey.Bounds.IntersectsWith(PBBanana3.Bounds) Then
            LBScore.Text += 1
            PBBanana3.Top = 0
            PBBanana3.Left = Int(Rnd() * (Me.Width - 140))
        End If
        If PBMonkey.Bounds.IntersectsWith(PBBanana4.Bounds) Then
            LBScore.Text += 1
            PBBanana4.Top = 0
            PBBanana4.Left = Int(Rnd() * (Me.Width - 140))
        End If
        If PBMonkey.Bounds.IntersectsWith(PBBanana5.Bounds) Then
            LBScore.Text += 1
            PBBanana5.Top = 0
            PBBanana5.Left = Int(Rnd() * (Me.Width - 140))
        End If
        If PBMonkey.Bounds.IntersectsWith(PBBanana6.Bounds) Then
            LBScore.Text += 1
            PBBanana6.Top = 0
            PBBanana6.Left = Int(Rnd() * (Me.Width - 140))
        End If
        'Detect Collison (Snake)
        If PBMonkey.Bounds.IntersectsWith(PBSnake1.Bounds) Or
        PBMonkey.Bounds.IntersectsWith(PBSnake2.Bounds) Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            LBScore.Visible = False
            LBScoreText.Visible = False
            LBTimer.Visible = False
            LBTimerText.Visible = False
            PBBanana1.Visible = False
            PBBanana2.Visible = False
            PBBanana3.Visible = False
            PBBanana4.Visible = False
            PBBanana5.Visible = False
            PBBanana6.Visible = False
            PBMonkey.Visible = False
            PBSnake1.Visible = False
            PBSnake2.Visible = False
            LbResult.Text = "Game Over! Your score was " + LBScore.Text + ", Would you want to play again?"
            LbResult.Visible = True
            BtnNo.Enabled = True
            BtnNo.Visible = True
            BtnYes.Enabled = True
            BtnYes.Visible = True
        End If

        'Timer Runs Out (60 Seconds)
        If LBTimer.Text = 0 Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            LBScore.Visible = False
            LBScoreText.Visible = False
            LBTimer.Visible = False
            LBTimerText.Visible = False
            PBBanana1.Visible = False
            PBBanana2.Visible = False
            PBBanana3.Visible = False
            PBBanana4.Visible = False
            PBBanana5.Visible = False
            PBBanana6.Visible = False
            PBMonkey.Visible = False
            PBSnake1.Visible = False
            PBSnake2.Visible = False
            LbResult.Text = "Game Over! Your score was " + LBScore.Text + ", Would you want to play again?"
            LbResult.Visible = True
            BtnNo.Enabled = True
            BtnNo.Visible = True
            BtnYes.Enabled = True
            BtnYes.Visible = True
        End If
        'Boarders
        If PBMonkey.Left < 0 Then
            PBMonkey.Location = New Point(0, PBMonkey.Top)
        End If
        If PBMonkey.Top < 0 Then
            PBMonkey.Location = New Point(PBMonkey.Left, 0)
        End If
        If (PBMonkey.Left + PBMonkey.Width) > Me.Width Then
            PBMonkey.Location = New Point(Me.Width - PBMonkey.Width, PBMonkey.Top)
        End If
        If (PBMonkey.Top + PBMonkey.Height) > Me.Height Then
            PBMonkey.Location = New Point(PBMonkey.Left, Me.Height - PBMonkey.Height)
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting Audio
        My.Computer.Audio.Play(My.Resources.Jungle_Audio, AudioPlayMode.BackgroundLoop)
        'Setting Variables
        x1Banana = 5
        x2Banana = 6
        x3Banana = 9
        x4Banana = 3
        x5Banana = 9
        x6Banana = 15
        x7Snake = 5
        x8Snake = 5
        x9Powerup = 9
        'Border Setup
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'TIME OF RACE
        LBTimer.Text = (LBTimer.Text - 1)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        LBCountdown.Text += 1
        '3 Show
        If LBCountdown.Text = 2 Then
            LBNumber3.Visible = True
        End If
        '3 UnShow & 2 Show
        If LBCountdown.Text = 3 Then
            LBNumber3.Visible = False
            LBNumber2.Visible = True
        End If
        '2 UnShow & 1 Show
        If LBCountdown.Text = 4 Then
            LBNumber2.Visible = False
            LBNumber1.Visible = True
        End If
        '1 Unshow & Begin Show
        If LBCountdown.Text = 5 Then
            LBNumber1.Visible = False
            LBBegin.Visible = True
        End If
        If LBCountdown.Text = 6 Then
            LBBegin.Visible = False
        End If
        If LBCountdown.Text > 7 Then
            Timer1.Enabled = True
            Timer2.Enabled = True
            LBPowerup.Text += 1
        End If
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        LBSpeed.Text += 1
        If LBSpeed.Text >= 15 Then
            Timer4.Enabled = False
            LBSpeed.Text = 0
        End If

    End Sub
    Private Sub BtnSetting_Click(sender As Object, e As EventArgs) Handles BtnSetting.Click
        My.Computer.Audio.Stop()
        BtnSetting.Visible = False
        BtnSetting.Enabled = False
        BtnSettingMute.Visible = True
        BtnSettingMute.Enabled = True
    End Sub

    Private Sub BtnSettingMute_Click(sender As Object, e As EventArgs) Handles BtnSettingMute.Click
        My.Computer.Audio.Play(My.Resources.Jungle_Audio, AudioPlayMode.BackgroundLoop)
        BtnSettingMute.Visible = False
        BtnSettingMute.Enabled = False
        BtnSetting.Visible = True
        BtnSetting.Enabled = True
    End Sub

    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        Application.Restart()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles BtnNo.Click
        End
    End Sub


End Class
'Citation
'https://www.youtube.com/watch?v=cvjEMguH1dI
'https://stackoverflow.com/questions/17989232/autochange-location-of-element-in-windows-forms-application
'https://stackoverflow.com/questions/8657991/can-you-run-a-vb-application-in-full-screen/42754756
'https://social.msdn.microsoft.com/Forums/vstudio/en-US/a02e57a5-af75-4862-ac4b-fdc18b5e01ac/how-to-get-the-width-of-form?forum=csharpgeneral
'https://social.msdn.microsoft.com/Forums/vstudio/en-US/69bd7d54-8fcb-481e-8722-6d9ebb26f26e/stopping-pictures-moving-off-the-form-?forum=vbgeneral

'Images & Sound Used
'https://www.vecteezy.com/free-vector/volume-icon (Volume)
'https://icon-icons.com/icon/volume-mute-sound-speaker-audio/122269 (Volume Mute)
'http://clipart-library.com/bannanna-animated-cliparts.html (Banana)
'https://www.clipartkey.com/search/cute-monkeys/ (Monkey)
'https://www.alamy.com/stock-photo/snake-cartoon.html (Snake)
'https://www.onlinewebfonts.com/icon/81086 (Speed)
'https://www.shutterstock.com/search/mountain+jungle+mist (Jungle)
'https://www.youtube.com/watch?v=paBPiWpedWo&t=858s (Audio)