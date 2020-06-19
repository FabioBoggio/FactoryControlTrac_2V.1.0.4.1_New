
Imports System.Data.SqlClient
Imports System.IO

Module module_STORED_LBLPRINT
	'OTTIENE UNIVOCO
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
		Dim SqlConnection As New SqlConnection(var_TRESLA_SQL_CONN)
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

			Dim Parameters() As SqlParameter = {(New SqlParameter("@RETURN", SqlDbType.Int) With {.Direction = ParameterDirection.ReturnValue, .Value = 0}),
												(New SqlParameter("@univoco", SqlDbType.NChar, 8) With {.Direction = ParameterDirection.Output, .Value = ""}),
												(New SqlParameter("@incremento", SqlDbType.Int) With {.Direction = ParameterDirection.Input, .Value = Incremento})}
			' Add PARAMETERS
			Cmd.Parameters.AddRange(Parameters)

			' Run STORED
			Cmd.ExecuteNonQuery()

			' Function RESULT [@RETURN.Value]
			GetUnivocoAS400 = Parameters(0).Value   'PRETURN.Value

			' Handler RESULT
			If GetUnivocoAS400 = 0 Then
				' Get RESULTS [@risultato.Value]
				Univoco = Parameters(1).Value       'Punivoco.Value
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
		End Try
	End Function

	'STAMPA ETICHETTA
	Sub sub_LBL_PRINT()
		Dim var_STR_READ = ""
		Dim var_LBL_STR_CREATE = ""
		Dim var_LBL_STR_FINALE = ""
		Dim var_ZEBRA_LBL_PRN = var_LOCAL_INI_FILE.ReadString("ZebraFile", "Lbl_UL")
		Dim var_ZEBRA_SHARED = var_LOCAL_INI_FILE.ReadString("ZebraFile", "Prt_Shared")     'SE LOCALE
		Dim var_ZEBRA_IP_ADD = var_LOCAL_INI_FILE.ReadString("ZebraFile", "Prt_Ip")         'SE IN RETE
		Dim var_ZEBRA_LBL_TO_PRINT = ""

		With form_MAIN
			''SCRIVE FILE.BAT ZEBRA PER STAMPANTE LOCALE (NON USATO)
			'Dim var_FILE_BAT_STR = "copy " & My.Application.Info.DirectoryPath & "\" & "_Zebra_Lbl_To_Print.prn" & " \\" & var_TM_HOSTNAME & "\" & var_ZEBRA_SHARED
			'Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\" & "_FilePrint.bat", False)
			'	sw.WriteLine(var_FILE_BAT_STR)
			'End Using

			'==================================='
			'          IMPOSTA VARIABILI		'
			'==================================='
			'MSL
			Dim var_MSL = "MSL ."

			'PROCESSO
			Dim var_PROC = "TRAC_2 V." & Application.ProductVersion

			'ORDINE, BOLLA - Ord. & TIPO & NUM & RIGA & Doc. & NUM & DATA
			Dim _ORD = "Ord." & var_ORD_TIPO & "_" & var_ORD_NUM & "_" & var_ORD_RIGA & " " & "Doc." & Trim(Strings.Left(var_BOLLA_NUM, 8)) & "_" & var_BOLLA_DATA

			'RHOS
			Dim _MG_PR = ""
			If var_PR_MAG = "0" Then
				_MG_PR = "RoHS"
			Else
				_MG_PR = "."
			End If

			'TRIMESTRE
			Dim var_WK_TRIM = Strings.Left(var_WK_TRIM_SQL, 2) & "/" & Right(var_WK_TRIM_SQL, 2)

			'MEMORIZZA ETICHETTA NELL'ARRAY DA SERVER ORIGINE, NOME ETICHETTA DA INI LOCAL
			Dim arr_LBL_TEXT() As String = File.ReadAllLines(var_LOCAL_INI_FILE.ReadString("serverPATH", "serverORIG") & "\" & var_ZEBRA_LBL_PRN)

			'LEGGE TUTTE LE RIGHE ESCLUSA L'ULTIMA
			For i = 0 To arr_LBL_TEXT.Length - 2
				'ELIMINA "#"
				var_STR_READ = arr_LBL_TEXT(i).Replace("#", Nothing)

				'ASSEGNA VARIABILI AI CAMPI ETICHETTA
				var_STR_READ = var_STR_READ.Replace("_COD", .lbl_LASI_CODE_ANA.Text)
				var_STR_READ = var_STR_READ.Replace("_UL0", var_UL_SP)
				var_STR_READ = var_STR_READ.Replace("_UL1", var_UL_SP)
				var_STR_READ = var_STR_READ.Replace("_DES", .lbl_DES_ANA.Text)
				var_STR_READ = var_STR_READ.Replace("_SUP", .lbl_DES_SUP_ANA.Text)
				var_STR_READ = var_STR_READ.Replace("_TRIM", "TRIM " & var_WK_TRIM)         'TRIMESTRE TT/YY
				var_STR_READ = var_STR_READ.Replace("_WK", "WEEK .")                        'SETTIMANA WW/YY - USATA SOLO PER PCB TRAC_1
				var_STR_READ = var_STR_READ.Replace("_ROHS", _MG_PR)                        'ROHS
				var_STR_READ = var_STR_READ.Replace("_ORD", _ORD)                           'Ord. & TIPO & NUM & RIGA & Doc. & NUM & DATA
				var_STR_READ = var_STR_READ.Replace("_MSL", var_MSL)                        'MSL
				var_STR_READ = var_STR_READ.Replace("_PROC", var_PROC)                      'PROCESSO

				'CONCATENA STRINGA
				var_LBL_STR_CREATE = var_LBL_STR_CREATE & var_STR_READ & vbCr
			Next

			'LEGGE ULTIMA RIGA E COMPILA QUANTITA = 1'
			'^PQ3,0,1,Y^XZ
			Dim arr_LBL_STR_FINALE = Split(arr_LBL_TEXT(arr_LBL_TEXT.Length - 1), ",")
			arr_LBL_STR_FINALE(0) = Strings.Left(arr_LBL_STR_FINALE(0), 3) & "1"
			var_LBL_STR_FINALE = Strings.Join(arr_LBL_STR_FINALE, ",")

			'SCRIVE FILE STAMPANTE LOCALE (NON USATO)
			'Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\" & "_Zebra_Lbl_To_Print.prn", False)
			'    sw.WriteLine(var_LBL_STR_INIZIALE & var_LBL_STR_CREATE & var_LBL_STR_FINALE)
			'End Using

			'LANCIA STAMPA IN LOCALE (NON USATO)
			'Shell(My.Application.Info.DirectoryPath & "\_FilePrint.bat", vbNormalFocus)

			'COMPILA STRINGA STAMPANTE IN RETE
			var_ZEBRA_LBL_TO_PRINT = var_LBL_STR_CREATE & var_LBL_STR_FINALE

			'Exit Sub                'PROVVISORIO

			'LANCIA STAMPA IN RETE
			Try
				'Open Connection & Stream
				Dim tcpclient As New System.Net.Sockets.TcpClient
				tcpclient.Connect(var_ZEBRA_IP_ADD, 9100)
				Dim tcpwriter As New System.IO.StreamWriter(tcpclient.GetStream())

				'INVIA STRINGA A PRINTER
				tcpwriter.Write(var_ZEBRA_LBL_TO_PRINT)

				'scarica il buffer 
				tcpwriter.Flush()

				'chiude lo stream dati
				tcpwriter.Close()

				'chiude la connessione
				tcpclient.Close()

			Catch ex As Exception
				MessageBox.Show("ATTENZIONE: ERRORE STAMPANTE" & vbCr & vbCr & "ERRORE: " & ex.Message, "btn_LBL_PRINT_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End With
	End Sub

	'SCRIVE LOG SU SERVER
	Sub sub_LOG_SERVER_WRITE(Text)      'SCRIVE LOG SU SERVER
		' Il primo parametro è il percorso del file e il nome del file. (Evitare caratteri speciali \, /, etc.)
		' Il secondo parametro, True, specifica che il file verrà aperto in modalità di aggiunta,
		' se il file non esiste ne viene creato uno nuovo e il parametro non ha effetto.

		If File.Exists(var_SERVER_LOG_FILE) = False Then
			Using sw As StreamWriter = New StreamWriter(var_SERVER_LOG_FILE, False)
				sw.WriteLine("[====== Giornale del: " & Format(Now, "dd/MM/yyyy") & " ======]" & vbCrLf)
				sw.WriteLine(Text)
			End Using
		Else
			Using sw As StreamWriter = New StreamWriter(var_SERVER_LOG_FILE, True)
				sw.WriteLine(Text)
			End Using
		End If
	End Sub
End Module
