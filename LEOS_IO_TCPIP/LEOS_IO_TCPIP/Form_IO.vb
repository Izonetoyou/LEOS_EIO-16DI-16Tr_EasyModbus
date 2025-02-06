Imports EasyModbus  ' ใช้ไลบรารี EasyModbus

Public Class Form_IO
    Dim modbusClient As New ModbusClient("192.168.0.244", 502) ' IP และ Port ของ LEOS.IO
    Dim WithEvents Timer_Read As New Timer()
    Dim WithEvents Timer_ReadOutput As New Timer()

    Private Async Sub Form_IO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer_Read.Interval = 100 ' อ่านค่าทุก 0.1 วินาที
        Timer_ReadOutput.Interval = 100
    End Sub
    Private Sub bt_connect_Click(sender As Object, e As EventArgs) Handles bt_connect.Click
        Try
            modbusClient.Connect()
            Console.WriteLine("✅ เชื่อมต่อสำเร็จ")

            ' Start Timers after successful connection
            Timer_Read.Start()
            Timer_ReadOutput.Start()

            ' Disable connect button and enable disconnect button
            bt_connect.Enabled = False
            bt_disconnect.Enabled = True

            ' Update the button text
            bt_connect.Text = "Connecting..." ' Optionally set text to indicate connected status
            bt_disconnect.Text = "Disconnect"

        Catch ex As Exception
            Console.WriteLine("❌ เชื่อมต่อไม่สำเร็จ: " & ex.Message)
        End Try
    End Sub

    Private Sub bt_disconnect_Click(sender As Object, e As EventArgs) Handles bt_disconnect.Click
        Try
            ' Stop Timers before disconnecting
            Timer_Read.Stop()
            Timer_ReadOutput.Stop()

            modbusClient.Disconnect()
            Console.WriteLine("🔌 ตัดการเชื่อมต่อสำเร็จ")

            ' Enable connect button and disable disconnect button
            bt_connect.Enabled = True
            bt_disconnect.Enabled = False

            ' Update the button text back
            bt_connect.Text = "Connect"
            bt_disconnect.Text = "Disconnecting..."

        Catch ex As Exception
            Console.WriteLine("❌ ปิดการเชื่อมต่อล้มเหลว: " & ex.Message)
        End Try
    End Sub


    Private Async Sub Timer_Read_Tick(sender As Object, e As EventArgs) Handles Timer_Read.Tick
        Try
            ' อ่าน 16 Inputs จาก Address 0-15
            Dim inputs As Boolean() = modbusClient.ReadDiscreteInputs(0, 16)

            ' แสดงข้อมูลที่ Console
            Console.WriteLine($"📡 Input: {String.Join(" | ", inputs.Select(Function(b, i) $"IN{i}: {(If(b, 1, 0))}"))}")

            ' อัปเดตค่า LED ใน UI
            LEDIN1.FillColor = If(inputs(0), Color.LimeGreen, Color.Red)
            LEDIN2.FillColor = If(inputs(1), Color.LimeGreen, Color.Red)
            LEDIN3.FillColor = If(inputs(2), Color.LimeGreen, Color.Red)
            LEDIN4.FillColor = If(inputs(3), Color.LimeGreen, Color.Red)
            LEDIN5.FillColor = If(inputs(4), Color.LimeGreen, Color.Red)
            LEDIN6.FillColor = If(inputs(5), Color.LimeGreen, Color.Red)
            LEDIN7.FillColor = If(inputs(6), Color.LimeGreen, Color.Red)
            LEDIN8.FillColor = If(inputs(7), Color.LimeGreen, Color.Red)
            LEDIN9.FillColor = If(inputs(8), Color.LimeGreen, Color.Red)
            LEDIN10.FillColor = If(inputs(9), Color.LimeGreen, Color.Red)
            LEDIN11.FillColor = If(inputs(10), Color.LimeGreen, Color.Red)
            LEDIN12.FillColor = If(inputs(11), Color.LimeGreen, Color.Red)
            LEDIN13.FillColor = If(inputs(12), Color.LimeGreen, Color.Red)
            LEDIN14.FillColor = If(inputs(13), Color.LimeGreen, Color.Red)
            LEDIN15.FillColor = If(inputs(14), Color.LimeGreen, Color.Red)
            LEDIN16.FillColor = If(inputs(15), Color.LimeGreen, Color.Red)

        Catch ex As Exception
            Console.WriteLine("❌ อ่านค่า Input ล้มเหลว: " & ex.Message)
        End Try
    End Sub
    Private Sub Timer_ReadOutput_Tick(sender As Object, e As EventArgs) Handles Timer_ReadOutput.Tick
        Try
            ' Read 16 output coils (Address 0-15)
            Dim outputs As Boolean() = modbusClient.ReadCoils(0, 16) ' Correct function to read multiple coils

            ' Display output status in Console
            'Console.WriteLine($"📡 Output: {String.Join(" | ", outputs.Select(Function(b, i) $"OUT{i}: {(If(b, 1, 0))}"))}")

            ' Update button colors and text based on coil status
            bt_output01.BackColor = If(outputs(0), Color.LimeGreen, Color.Red)
            bt_output01.Text = If(outputs(0), "ON", "OFF")

            bt_output02.BackColor = If(outputs(1), Color.LimeGreen, Color.Red)
            bt_output02.Text = If(outputs(1), "ON", "OFF")

            bt_output03.BackColor = If(outputs(2), Color.LimeGreen, Color.Red)
            bt_output03.Text = If(outputs(2), "ON", "OFF")

            bt_output04.BackColor = If(outputs(3), Color.LimeGreen, Color.Red)
            bt_output04.Text = If(outputs(3), "ON", "OFF")

            bt_output05.BackColor = If(outputs(4), Color.LimeGreen, Color.Red)
            bt_output05.Text = If(outputs(4), "ON", "OFF")

            bt_output06.BackColor = If(outputs(5), Color.LimeGreen, Color.Red)
            bt_output06.Text = If(outputs(5), "ON", "OFF")

            bt_output07.BackColor = If(outputs(6), Color.LimeGreen, Color.Red)
            bt_output07.Text = If(outputs(6), "ON", "OFF")

            bt_output08.BackColor = If(outputs(7), Color.LimeGreen, Color.Red)
            bt_output08.Text = If(outputs(7), "ON", "OFF")

            bt_output09.BackColor = If(outputs(8), Color.LimeGreen, Color.Red)
            bt_output09.Text = If(outputs(8), "ON", "OFF")

            bt_output10.BackColor = If(outputs(9), Color.LimeGreen, Color.Red)
            bt_output10.Text = If(outputs(9), "ON", "OFF")

            bt_output11.BackColor = If(outputs(10), Color.LimeGreen, Color.Red)
            bt_output11.Text = If(outputs(10), "ON", "OFF")

            bt_output12.BackColor = If(outputs(11), Color.LimeGreen, Color.Red)
            bt_output12.Text = If(outputs(11), "ON", "OFF")

            bt_output13.BackColor = If(outputs(12), Color.LimeGreen, Color.Red)
            bt_output13.Text = If(outputs(12), "ON", "OFF")

            bt_output14.BackColor = If(outputs(13), Color.LimeGreen, Color.Red)
            bt_output14.Text = If(outputs(13), "ON", "OFF")

            bt_output15.BackColor = If(outputs(14), Color.LimeGreen, Color.Red)
            bt_output15.Text = If(outputs(14), "ON", "OFF")

            bt_output16.BackColor = If(outputs(15), Color.LimeGreen, Color.Red)
            bt_output16.Text = If(outputs(15), "ON", "OFF")

        Catch ex As Exception
            Console.WriteLine("❌ Failed to read output coils: " & ex.Message)
        End Try
    End Sub



    Private Sub bt_out_Click(sender As Object, e As EventArgs) Handles bt_output01.Click, bt_output02.Click, bt_output03.Click, bt_output04.Click, bt_output05.Click, bt_output06.Click, bt_output07.Click, bt_output08.Click, bt_output09.Click, bt_output10.Click, bt_output11.Click, bt_output12.Click, bt_output13.Click, bt_output14.Click, bt_output15.Click, bt_output16.Click
        Try
            Dim btn As Button = CType(sender, Button)
            Dim coilAddress As Integer = CInt(btn.Tag) ' ใช้ Tag ของปุ่มแทน Address ของ Coil

            If btn.Text = "OFF" Then
                modbusClient.WriteSingleCoil(coilAddress, True) ' ✅ เปิด Output ที่ Coil Address
                btn.Text = "ON"
                btn.BackColor = Color.LimeGreen
            Else
                modbusClient.WriteSingleCoil(coilAddress, False) ' ✅ ปิด Output ที่ Coil Address
                btn.Text = "OFF"
                btn.BackColor = Color.Red
            End If
        Catch ex As Exception
            Console.WriteLine("❌ เกิดข้อผิดพลาดในการเขียน Coil: " & ex.Message)
        End Try
    End Sub

End Class
