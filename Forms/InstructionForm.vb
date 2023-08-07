Imports System.IO

Public Class InstructionForm
    'Configuration Path
    Private ReadOnly checkerName As String = GetIniValue("SETUP", "checkerName", $"{currentDirectory}/ConfigFiles/comConfig.ini")
    Private ReadOnly ictLogPath As String = GetIniValue("SETUP", "ictLog", $"{currentDirectory}/ConfigFiles/comConfig.ini")
    Private ReadOnly testDataPath As String = GetIniValue("SETUP", "testDataPath", $"{currentDirectory}/ConfigFiles/comConfig.ini")
    Private ReadOnly output1Path As String = GetIniValue("SETUP", "output1", $"{currentDirectory}/ConfigFiles/comConfig.ini")
    Private ReadOnly output2Path As String = GetIniValue("SETUP", "output2", $"{currentDirectory}/ConfigFiles/comConfig.ini")
    Private ReadOnly plasmaFilePath As String = GetIniValue("SETUP", "plasmaFile", $"{currentDirectory}/ConfigFiles/comConfig.ini")
    Private ReadOnly canisPath As String = GetIniValue("SETUP", "canisPath", $"{currentDirectory}/ConfigFiles/comConfig.ini")

    'File Path
    Private ReadOnly picturePath As String = $"{currentDirectory}/PicFolder"
    Private ReadOnly sequencePath As String = $"{currentDirectory}/SequenceFiles"

    'Controllers
    Private orderController As OrderController
    Private sequenceController As SequenceController

    'Initial Value
    Private model As String = ""
    Private partOrder As String = ""
    Private pbaModel As String = ""
    Private sequenceNumberCurrent As Integer = 0

    Private Sub InstructionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        StartPosition = FormStartPosition.Manual
        Location = New Point(Screen.PrimaryScreen.WorkingArea.Left, Screen.PrimaryScreen.WorkingArea.Bottom - Height)
        InitializeForm()
        LoadInspector()
    End Sub

    Private Sub CanisSerialNumberTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles canisSerialNumberTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            canisSerialNumberTxt.Text = canisSerialNumberTxt.Text.Replace("@", "")
            'Delete the ICT log to ensure the log output is not duplicated and is good.
            If File.Exists(ictLogPath) Then
                File.Delete(ictLogPath)
            End If

            Dim canisSerialNumber As String = canisSerialNumberTxt.Text.ToUpper().Trim()

            If canisSerialNumber.Length <> 10 Then
                ErrorAlert("Invalid canis serial number")
                Exit Sub
            End If

            Dim canisProductionCode As String = canisSerialNumber.Substring(0, 2)
            Dim canisYear As String = canisSerialNumber.Substring(2, 1)
            Dim canisMonth As String = canisSerialNumber.Substring(3, 1)
            Dim canisDay As String = canisSerialNumber.Substring(4, 2)

            Dim canisSerialNumberFileName As String = orderController.GetCanisFileName(canisProductionCode, canisYear, canisMonth, canisDay)
            Dim canisData As CanisSerialNumberModel = orderController.SearchCanisSerialNumber(canisPath, canisSerialNumberFileName, canisSerialNumber)

            If canisData Is Nothing Then
                ErrorAlert("Canis serial number not found!")
                canisSerialNumberTxt.Text = ""
                Exit Sub
            End If

            canisSerialNumberTxt.Enabled = False

            GetInstructions()
        End If
    End Sub

    Private Sub NextBtn_Click(sender As Object, e As EventArgs) Handles NextBtn.Click
        sequenceNumberCurrent += 1
        GetInstruction()
    End Sub

    Private Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        sequenceNumberCurrent -= 1
        GetInstruction()
    End Sub

    Private Sub EndBtn_Click(sender As Object, e As EventArgs) Handles EndBtn.Click
        If sequenceNumberCurrent = sequenceController.sequenceList.ToArray.Length - 1 Then
            If inspectorCmb.Text = "" Then
                ErrorAlert("Please select inspector!")
                Exit Sub
            End If
            WriteLog()
            InitializeForm()
        Else
            InitializeForm()
        End If
    End Sub

    Private Sub InitializeForm()
        orderController = New OrderController()
        sequenceController = New SequenceController()

        model = ""
        partOrder = ""
        pbaModel = ""
        sequenceNumberCurrent = 0

        BackBtn.Visible = False
        NextBtn.Visible = False
        EndBtn.Visible = False
        EndBtn.Text = "END"

        canisSerialNumberTxt.Enabled = True
        canisSerialNumberTxt.Text = ""
        canisSerialNumberTxt.Focus()

        instructionPic.Image = Image.FromFile($"{picturePath}/CanisSerial.jpg")
        instructionTxt.Text = "Please Scan The Canis Serial Number"

        If File.Exists(ictLogPath) Then
            File.Delete(ictLogPath)
        End If
    End Sub
    Private Sub LoadInspector()
        Dim inspectors As String() = File.ReadAllLines($"{currentDirectory}/ConfigFiles/inspector.txt")
        For Each inspector As String In inspectors
            inspectorCmb.Items.Add(inspector.Trim())
        Next
    End Sub

    Private Sub GetInstructions()
        Dim sequenceList As List(Of SequenceModel)
        Dim sequenceFilePath As String

        Dim prefixSequenceFileName As String = "comTS"
        Dim extensionSequenceFileName As String = ".csv"

        'The third-party program cannot write "*" and /," so we must convert it.
        If orderController.canisSerialNumber.Model.Split("/").Length > 1 Then
            If orderController.canisSerialNumber.Model.Split("/")(1) = "ZCT" Then
                model = orderController.canisSerialNumber.Model.Replace("*A", "").Replace("/", "-")
            Else
                model = orderController.canisSerialNumber.Model.Replace("*A", "").Split("/")(0)
            End If

            partOrder = model
            model = model.Split("-")(0)
        Else
            model = orderController.canisSerialNumber.Model.Replace("*A", "").Replace("/", "-")
            partOrder = model
        End If

        'Check if the model functions as a PBA or not.
        pbaModel = GetIniValue("MODEL", partOrder, $"{currentDirectory}/ConfigFiles/modelPbaList.ini").Trim()
        If String.IsNullOrEmpty(pbaModel) Then
            pbaModel = partOrder
        End If

        sequenceFilePath = $"{sequencePath}/{prefixSequenceFileName}{model}{extensionSequenceFileName}"
        sequenceList = sequenceController.GetSequence(sequenceFilePath)

        If sequenceList Is Nothing OrElse sequenceList.Count = 0 Then
            ErrorAlert("Sequence empty! Please contact engineering!")
            InitializeForm()
            Exit Sub
        End If

        ChangeInstruction(0)
    End Sub

    Private Sub GetInstruction()
        ChangeInstruction(sequenceNumberCurrent)
    End Sub

    Private Sub ChangeInstruction(sequenceNumber)
        If sequenceNumber = 0 Then
            NextBtn.Visible = True
            EndBtn.Visible = True
            BackBtn.Visible = False
            EndBtn.Text = "END"
        ElseIf sequenceNumber = sequenceController.sequenceList.ToArray().Length - 1 Then
            BackBtn.Visible = True
            NextBtn.Visible = False
            EndBtn.Visible = True
            EndBtn.Text = "Finish"
        Else
            BackBtn.Visible = True
            NextBtn.Visible = True
            EndBtn.Visible = True
            EndBtn.Text = "END"
        End If

        instructionTxt.Text = sequenceController.sequenceList(sequenceNumber).Instruction

        If Not File.Exists(Path.Combine(picturePath, model, sequenceController.sequenceList(sequenceNumber).PictureName)) Then
            ErrorAlert("Picture not found! please contact engineering!")
            InitializeForm()
        End If

        instructionPic.Image = Image.FromFile(Path.Combine(picturePath, model, sequenceController.sequenceList(sequenceNumber).PictureName))
    End Sub

    Private Sub WriteLog()
        If Not File.Exists(ictLogPath) Then
            ErrorAlert("Log not found! please contact engineering!")
            Exit Sub
        End If

        Dim logRows As String() = File.ReadAllLines(ictLogPath)

        Dim status As String = "FAIL"
        Dim modelFunction As String = ""

        Dim newLogFiles As New List(Of String())
        Dim newLogRows As New List(Of String)

        'In the log file, the second line shows the model and test results.
        ' "GO" is describe test PASS
        ' "NG" is describe test FAIL
        For Each logRow As String In logRows

            Dim logArr As String() = logRow.Split(",")
            Dim newLogLine As String = logRow

            If logArr.Length = 13 Then
                Dim dataModel As String() = logArr(0).Replace("""", "").Split(" ").Where(Function(str) Not String.IsNullOrEmpty(str)).ToArray()
                modelFunction = dataModel(dataModel.Length - 1).Trim()

                'Check the result of test
                If logArr(1).Replace("""", "") = "GO" Then
                    status = "PASS"
                Else
                    status = "FAIL"
                End If

                'Compare the tested third-party model and scanned models.
                If modelFunction = pbaModel Then
                    newLogLine = newLogLine.Replace(modelFunction, orderController.canisSerialNumber.Model)
                Else
                    status = "FAIL"
                    ErrorAlert("ICT model not match!")
                    InitializeForm()
                    Exit Sub
                End If

            End If

            newLogRows.Add(newLogLine)

            If logArr.Length = 1 And logArr(0).Replace("""", "") = "EOF" Then
                newLogFiles.Add(newLogRows.ToArray())
                newLogRows.Clear()
            End If
        Next

        Dim currentDateTime = Date.Now()

        Dim currentYear As String = currentDateTime.Year
        Dim currentMonth As String = currentDateTime.Month.ToString("00")
        Dim currentDay As String = currentDateTime.Day.ToString("00")
        Dim currentHour As String = currentDateTime.Hour.ToString("00")
        Dim currentMinute As String = currentDateTime.Minute.ToString("00")
        Dim currentSecond As String = currentDateTime.Second.ToString("00")

        'ENC-ZCT_C3ZG07243S_20230710101355_PASS.LOG
        Dim newFileNames As String = $"{partOrder}_{orderController.canisSerialNumber.SerialNumber}_{currentYear}{currentMonth}{currentDay}{currentHour}{currentMinute}{currentSecond}_{status}.LOG"

        'newLogFiles.ToArray().Length - 1) is get the latest log file
        WriteLogFile(Path.Combine(output1Path, newFileNames), newLogFiles(newLogFiles.ToArray().Length - 1))
        WriteLogFile(Path.Combine(output2Path, newFileNames), newLogFiles(newLogFiles.ToArray().Length - 1))

        'Write test data for product traceability system tracking
        Using Writer As New StreamWriter(Path.Combine(testDataPath, $"{orderController.canisSerialNumber.SerialNumber}.txt"), False)
            Writer.WriteLine($"{orderController.canisSerialNumber.SerialNumber},{orderController.canisSerialNumber.Model},,,,,,{currentDateTime:d/M/yyyy hh:mm:ss tt},,,,,{inspectorCmb.Text},YMB,{checkerName},{status},")
        End Using

        InformationAlert("Log Transfered")

        File.Delete(ictLogPath)
    End Sub

    Private Sub WriteLogFile(logPath As String, logDatas As String())
        Using Writer As New StreamWriter(logPath, False)
            For Each logData In logDatas
                Writer.WriteLine(logData)
            Next
        End Using
    End Sub

End Class
