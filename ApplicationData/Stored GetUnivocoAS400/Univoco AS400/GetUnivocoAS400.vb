    Function GetUnivocoAS400(ByVal Incremento As Integer, ByRef Univoco As String, ByRef MsgError As String) As Integer

        ' --------------------------------------------------------------------
        ' Recupero Univoco da AS400 [Call STORED "Track_GetUnivocoAS400"
        ' --------------------------------------------------------------------

        '   @univoco    nchar(8) output
        '   @incremento Integer  input

        ' --------------------------------------------------------------------
        ' [INP] Incremento      = Numero Univoci da Risevare
        ' [OUT] Univoco         = Univoco Generato da AS400
        '
        ' Return VALUE          = 0 Function OK
        '                       = -1 Errore RETURN STORED  [MessageBOX]
        '                       = -2 Errore FUN INDEFINITO [MessageBOX]
        ' --------------------------------------------------------------------

        ' Declare VARS
        Dim SqlConnection As New SqlConnection("Connect Timeout=10;Password=masteradmin;Persist Security Info=True;User ID=sa;Initial Catalog=LasiTRESLA;Data Source=" & SQLDataSource)
        Dim Cmd As New SqlCommand

        ' Default RESULT
        GetUnivocoAS400 = -2

        Try
            ' Open CONNECTION
            SqlConnection.Open()

            ' Set PROPERTIES
            Cmd.Connection = SqlConnection
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandTimeout = 10
            Cmd.CommandText = "[dbo].[track_GetUnivocoAS400]"

            Dim Parameters() As SqlParameter = {(New SqlParameter("@RETURN", SqlDbType.Int) With {.Direction = ParameterDirection.ReturnValue, .Value = 0}), _
                                                (New SqlParameter("@univoco", SqlDbType.NChar, 8) With {.Direction = ParameterDirection.Output, .Value = ""}), _
                                                (New SqlParameter("@incremento", SqlDbType.Int) With {.Direction = ParameterDirection.Input, .Value = Incremento})}
            ' Add PARAMETERS
            Cmd.Parameters.AddRange(Parameters)

            ' Run STORED
            Cmd.ExecuteNonQuery()

            ' Function RESULT [@RETURN.Value]
            GetUnivocoAS400 = Parameters(0).Value 'PRETURN.Value

            ' Handler RESULT
            If GetUnivocoAS400 = 0 Then
                ' Get RESULTS [@risultato.Value]
                Univoco = Parameters(1).Value 'Punivoco.Value
                MsgError = "Function OK"
            Else
                ' Set RESULTS NULL
                Univoco = ""
                MsgError = "Errore " & GetUnivocoAS400.ToString
                MsgBox("Errore GetUnivocoAS400 " + MsgError, MsgBoxStyle.Information)
                GetUnivocoAS400 = -1
            End If


        Catch
            ' System Error MESSAGE
            MsgBox("Errore GetUnivocoAS400 " + Err.Description, MsgBoxStyle.Information)
            MsgError = Err.Description

        Finally
            ' Close and Nil CONNECTION
            SqlConnection.Close()
            SqlConnection = Nothing
        End Try

        ' --------------------------------------------------------------------
        ' Function END
        ' --------------------------------------------------------------------

    End Function
