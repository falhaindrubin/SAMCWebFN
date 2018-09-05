Imports System.IO

Public Class ModUtility

    Public Shared Function CSQLQuote(ByVal value As String) As String
        Dim strTemp As String = value
        strTemp = Replace(strTemp, "\", "")
        strTemp = Replace(strTemp, "'", "\'")
        strTemp = Replace(strTemp, """", "\""")
        Return strTemp
    End Function

    Public Shared Function IsEmptyString(ByVal Value As Object) As Boolean
        'NULL OR EMPTY are considered EmptyString
        If IsDBNull(Value) Then
            Return True
        ElseIf Value Is Nothing Then
            Return True
        ElseIf Value.ToString = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    'Public Shared Function CStrNull(ByVal Value As Object, Optional ByVal type As String = "") As String
    '    'Convert EMPTY STRING to NULL
    '    'Return IIf(IsDBNull(Value), "", CStr(Value))
    '    Return IIf(IsEmptyString(Value), "NULL", CStr(Value))
    'End Function

    Public Shared Function CStrNull(ByVal Value As Object) As String

        If Not IsDBNull(Value) Then
            Return CStr(Value)
        Else
            Return ""
        End If
        'Return IIf(IsDBNull(Value) = True, "", CStr(Value))
    End Function

    Public Shared Function CSQLDate(ByVal value As Object) As String
        Return "'" & Format(value, "yyyy-MM-dd") & "'"
    End Function

    Public Shared Function CSQLTime(ByVal value As Object) As String
        Return "'" & Format(value, "HH:mm:ss") & "'"
    End Function

    Public Shared Function CSQLDateTime(ByVal value As Object) As String
        Return "'" & Format(value, "yyyy-MM-dd HH:mm:ss") & "'"
    End Function

    Public Function CSQLString(ByVal Value As String) As String
        Return IIf(IsDBNull(Value), "NULL", "'" & CSQLQuote(Value) & "'")
    End Function

    Public Shared Function JSMsgDisplay(ByVal Message As String, Optional ByVal URL As String = "") As String

        Dim sb As StringBuilder
        Dim strJSMsgPrompt As String

        sb = New StringBuilder
        With sb
            .Append("<script type='text/javascript'>")
            .Append("window.onload=function(){alert('" & Message & "')")

            If URL <> "" Then
                .Append(";window.location='" & URL & "';")
            End If

            .Append("}")
            .Append("</script>")
        End With

        strJSMsgPrompt = sb.ToString
        Return strJSMsgPrompt

    End Function

    Public Shared Sub WriteErrLog(ByVal strModule As String, ByVal strErrMsg As String)
        Dim attempt As Integer = 0
        While attempt < 3
            Try
                'AppDomain.CurrentDomain.BaseDirectory 
                'Dim sw As New StreamWriter(Path.Combine(Application.StartupPath, "QueriesError" & Format(Now, "yyyyMMdd") & ".log"), True)
                Dim sw As New StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Event" & Format(Now, "yyyyMMdd") & ".log"), True)
                sw.Write(vbCrLf & "*** " & Now() & " ***")
                sw.Write(vbCrLf & "Module :" & strModule)
                sw.Write(vbCrLf & "Error :" & strErrMsg & vbCrLf)
                sw.Close()
            Catch ex As Exception
                attempt += 1
                Continue While
            End Try
            Exit While
        End While
    End Sub

    Public Shared Function WebVersioning() As String

        Dim WebAssembly As String
        Dim Version As String = ""

        Try
            WebAssembly = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
            Version = "Online PO v" & WebAssembly

        Catch ex As Exception

        End Try

        Return Version

    End Function

    'Public Function IsEmptyString(ByVal Value) As Boolean
    '    'NULL OR EMPTY are considered EmptyString
    '    If IsDBNull(Value) Then
    '        Return True
    '    ElseIf Value Is Nothing Then
    '        Return True
    '    ElseIf Value.ToString = "" Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

End Class

