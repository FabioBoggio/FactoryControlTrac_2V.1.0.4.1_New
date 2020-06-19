
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Threading.Thread
Imports Ini.Net

Module module_SUB_FUN


#Region " REGION VARIABILI"
	Public bit_FORM_LOAD = False
	Public bit_STOP_BGW = False
	Public bit_PN_DB_OK = False
	'Public var_ARRAY_ITEM
	Public var_TM_HOSTNAME
	Public var_WK_NUM = ""          '"ww/yy" SETTIMANA/ANNO CORRENTE
	Public var_WK_TRIM_SQL = ""     '"tt/yy" TRIMESTRE/ANNO CORRENTE

	'CAMPI ELENCO BOLLE
	Public var_REG_DATA
	Public var_BOLLA_NUM
	Public var_BOLLA_DATA
	Public var_FORN_COD
	Public var_FORN_DESC
	Public var_MOV_DATA

	'CAMPI DETTAGLI BOLLA
	Public var_ORD_TIPO
	Public var_ORD_NUM
	Public var_ORD_RIGA
	Public var_ART_COD
	Public var_ART_DESC
	Public var_QTY_RIGA
	Public var_PR_MAG

	Public var_UL_SP As String = ""
	Public var_MSG_SP As String = ""

	Public var_LVW_ITEM_INDEX

	Public var_LOG_PATH As String
	Public var_MIRROR_SQL_CONN
	Public var_TRESLA_SQL_CONN

	Public var_LOCAL_INI_FILE As IniFile
	Public var_SERVER_INI_PATH As String
	Public var_SERVER_INI_FILE As IniFile
	Public var_SERVER_LOG_FILE As String
	Public var_SERVER_HELP_FILE As String

	'SQL
	Public sql_CONN As New SqlConnection
	Public sql_CMD As New SqlCommand
	Public sql_READER As SqlDataReader

	'AS400 - JG
	Public var_AS_CONN As String
	Public sql_CON_AS As New SqlConnection
	Public sql_CMD_AS As New SqlCommand
	Public sql_READER_AS As SqlDataReader

	Public var_SER_RX_1
	Public arr_BARCODE(15)

	Public arr_PN_EQUIV(15, 1)      'ARRAY PN REGISTRATI IN EQUIVAENZE
	Public var_LASI_CODE_OLD
	Public var_PN_OLD
	Public var_LOT_OLD
	Public var_DATA_OLD
	Public var_QTY_OLD
	Public var_BIN_OLD

	Public var_STRING
#End Region

	'ELENCO BOLLE AL COLLAUDO, 'MENU' JG "MOVIMENTI DI COLLAUDO"
	Sub sub_AS_READER_BOLLE()
		With form_MAIN
			'AS CONNECTION
			sql_CON_AS.ConnectionString = var_MIRROR_SQL_CONN
			sql_CMD_AS.CommandType = CommandType.Text
			sql_CMD_AS.Connection = sql_CON_AS
			sql_CON_AS.Open()

			'MOVIMENTI DI COLLAUDO
			'[CQMOV01F].NRDCMQ      NUMERO BOLLA
			'[CQMOV01F].DTOPMQ      DATA REGISTRAZIONE
			'[CQMOV01F].DTMOMQ		DATA MOVIMENTO
			'[CQMOV01F].DTBOMQ      DATA BOLLA
			'[CQMOV01F].CDCFMQ      FORNITORE CODICE
			'[CQMOV01F].RIGAMQ      RIGA REGISTRAZIONE
			'[CQMOV01F].TORDMQ      TIPO ORDINE
			'[CQMOV01F].NRORMQ      NUMERO ORDINE
			'[CQMOV01F].NRRGMQ      RIGA ORDINE
			'[CGPCO00F].DSCOCP      FORNITORE DESCRIZIONE
			'[CQMOV01F].NROPMQ      NUMERO REGISTRAZIONE

			Dim index = 0
			'CARICA BOLLE E DECODIFICA FORNITORE
			sql_CMD_AS.CommandText = $"SELECT DISTINCT [CQMOV01F].NRDCMQ, [CQMOV01F].DTOPMQ, [CQMOV01F].DTBOMQ, [CQMOV01F].CDCFMQ, [CGPCO00F].DSCOCP, [CQMOV01F].DTMOMQ, [CQMOV01F].NROPMQ FROM {var_AS_CONN}.[CQMOV01F] INNER JOIN {var_AS_CONN}.[CGPCO00F] ON [CGPCO00F].CONTCP = [CQMOV01F].CDCFMQ ORDER BY [CQMOV01F].DTOPMQ, [CQMOV01F].NROPMQ ASC"

			sql_READER_AS = sql_CMD_AS.ExecuteReader()
			If sql_READER_AS.HasRows() Then
				While sql_READER_AS.Read
					var_BOLLA_NUM = Trim(sql_READER_AS.Item(0))
					var_REG_DATA = sql_READER_AS.Item(1)
					var_BOLLA_DATA = Trim(sql_READER_AS.Item(2))
					var_FORN_COD = Trim(sql_READER_AS.Item(3))
					var_FORN_DESC = Trim(sql_READER_AS.Item(4))
					var_MOV_DATA = sql_READER_AS.Item(5)

					.lvw_BOLLE.Items.Add(Date.ParseExact(var_REG_DATA, "yyyyMMdd", Nothing))                            'DATA REG.
					.lvw_BOLLE.Items(index).SubItems.Add(var_BOLLA_NUM)                                                 'BOLLA NUMERO
					.lvw_BOLLE.Items(index).SubItems.Add(Date.ParseExact(var_BOLLA_DATA, "yyyyMMdd", Nothing))          'BOLLA DATA
					.lvw_BOLLE.Items(index).SubItems.Add(var_FORN_COD)                                                  'FORN. COD.
					.lvw_BOLLE.Items(index).SubItems.Add(var_FORN_DESC)                                                 'FORN. DESC.
					.lvw_BOLLE.Items(index).SubItems.Add(var_MOV_DATA)                                                  'DATA MOVIMENTO (NON VISUALIZZATO)
					index = index + 1
				End While
			End If
			sql_READER_AS.Close()
			sql_CON_AS.Close()

			.lvw_BOLLE.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
			.lvw_BOLLE.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
		End With
	End Sub

	'DETTAGLIO RIGHE BOLLA
	Sub sub_AS_READER_BOLLE_DET(_NUM_DOC)
		With form_MAIN
			sql_CON_AS.ConnectionString = var_MIRROR_SQL_CONN
			sql_CMD_AS.CommandType = CommandType.Text
			sql_CMD_AS.Connection = sql_CON_AS
			sql_CON_AS.Open()

			'MOVIMENTI DI COLLAUDO
			''[CQMOV01F].NROPMQ    NUMERO REGISTRAZIONE
			''[CQMOV01F].RIGAMQ    RIGA REGISTRAZIONE
			'[CQMOV01F].NRDCMQ     NUMERO BOLLA

			'[CQMOV01F].TORDMQ      TIPO ORDINE
			'[CQMOV01F].NRORMQ      NUMERO ORDINE
			'[CQMOV01F].NRRGMQ      RIGA ORDINE
			'[CQMOV01F].CDARMQ      CODICE
			'[CQMOV01F].QTFTMQ      QTY

			'ANAGRAFICA
			'[MGART00F].CDARMA      CODICE
			'[MGART00F].DSARMA      DESCRIZIONE
			'[MGART00F].CDPRMA      PR MG

			'DETTAGLI RIGHE BOLLA DA CQMOV01F + PR MG E DESCRZIONE ARTICOLO DA MGART00F
			sql_CMD_AS.CommandText = $"Select [CQMOV01F].TORDMQ, [CQMOV01F].NRORMQ, [CQMOV01F].NRRGMQ, [CQMOV01F].CDARMQ, [MGART00F].DSARMA, [CQMOV01F].QTFTMQ, [MGART00F].CDPRMA FROM {var_AS_CONN}.[CQMOV01F] INNER JOIN {var_AS_CONN}.[MGART00F] ON [CQMOV01F].CDARMQ = [MGART00F].CDARMA WHERE [CQMOV01F].NRDCMQ = '{_NUM_DOC}' ORDER BY [CQMOV01F].NRORMQ, [CQMOV01F].NRRGMQ ASC"

			sql_READER_AS = sql_CMD_AS.ExecuteReader()
			Dim index = 0
			If sql_READER_AS.HasRows() Then
				While sql_READER_AS.Read
					var_ORD_TIPO = Trim(sql_READER_AS.Item(0))
					var_ORD_NUM = Trim(sql_READER_AS.Item(1))
					var_ORD_RIGA = Trim(sql_READER_AS.Item(2))
					var_ART_COD = Trim(CStr(sql_READER_AS.Item(3)))
					var_ART_DESC = Trim(CStr(sql_READER_AS.Item(4)))
					var_QTY_RIGA = CInt(sql_READER_AS.Item(5))
					var_PR_MAG = Trim(sql_READER_AS.Item(6))                                    'PR MG DA MGART00F (NON VISIBILE)

					.lvw_BOLLA_ITEM.Items.Add(var_ORD_TIPO)                                     'ORD.TIPO
					.lvw_BOLLA_ITEM.Items(index).SubItems.Add(var_ORD_NUM)                      'ORD.NUM.
					.lvw_BOLLA_ITEM.Items(index).SubItems.Add(var_ORD_RIGA)                     'ORD.RIGA
					.lvw_BOLLA_ITEM.Items(index).SubItems.Add(var_ART_COD)                      'ART.COD.
					.lvw_BOLLA_ITEM.Items(index).SubItems.Add(Strings.Left(var_ART_DESC, 30))   'ART.DESC. DA MGART00F
					.lvw_BOLLA_ITEM.Items(index).SubItems.Add(var_QTY_RIGA)                     'QTY RIGA BOLLA
					index = index + 1
				End While
			End If
			sql_READER_AS.Close()
			sql_CON_AS.Close()

			.lvw_BOLLA_ITEM.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
			.lvw_BOLLA_ITEM.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
		End With
	End Sub

	'CAMPI ANAGRAFICA DA MIRROR.MGART00F + MARCA
	Sub sub_SQL_READER_ANA(_ART_COD)
		With form_MAIN
			'_ART_COD = "880007"                     'PROVVISORIO

			sql_CON_AS.ConnectionString = var_MIRROR_SQL_CONN
			sql_CMD_AS.CommandType = CommandType.Text
			sql_CMD_AS.Connection = sql_CON_AS
			sql_CON_AS.Open()

			sql_CMD_AS.CommandText = $"Select [MGART00F].DSARMA, [MGART00F].DSSAMA, [MGART02F].CL09MD FROM {var_AS_CONN}.[MGART00F] INNER JOIN {var_AS_CONN}.[MGART02F] ON [MGART00F].CDARMA = [MGART02F].CDARMD WHERE [MGART00F].CDARMA = '{_ART_COD}'"

			Dim var_MARCA_COD = ""
			sql_READER_AS = sql_CMD_AS.ExecuteReader()
			If sql_READER_AS.Read() Then
				.lbl_LASI_CODE_ANA.Text = _ART_COD
				.lbl_DES_ANA.Text = Trim(sql_READER_AS.Item(0))
				.lbl_DES_SUP_ANA.Text = Trim(sql_READER_AS.Item(1))
				var_MARCA_COD = sql_READER_AS.Item(2)
			End If
			sql_READER_AS.Close()

			'DESCRIZIONE MARCA - JG TABELLA M2 - Descrizione classi dati tecnici
			Dim var_WHERE = "01XM" & var_MARCA_COD
			sql_CMD_AS.CommandText = $"SELECT F00002 FROM {var_AS_CONN}.[CSTAB] WHERE K00001 = '{var_WHERE}'"
			.lbl_MARCA_ANA.Text = Trim(sql_CMD_AS.ExecuteScalar)
			sql_READER_AS.Close()

			sql_CON_AS.Close()
		End With
	End Sub

	'VERIFICA CONGRUENZA DEI DATI
	Sub sub_DATA_PROC(_STR)             'LANCIATA DA "bgw_LOOP_SER_1_RunWorkerCompleted"
		With form_MAIN
			'var_ARRAY_ITEM = ""
			'SCANNERIZZA ARRAY
			'For i = 0 To UBound(arr_BARCODE)
			'If arr_BARCODE(i) <> "" Then
			'	var_ARRAY_ITEM = arr_BARCODE(i)
			'	fun_MARCHE_SEL(var_ARRAY_ITEM)
			'End If

			fun_MARCHE_SEL(_STR)

			'===================================================================='
			'    SE MARCA GENERICA PRECARICA DATA NEL CASO NON SIA PRESENTE      '
			'===================================================================='
			If .cbx_MARCA.SelectedIndex = 0 And .lbl_DATA_TAPE.Text = "" Then
				.lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
			End If

			'===================================================================='
			' CONTROLLA CORRISPONDENZA LOTTO CON PRECEDENTE ED EVITA LETTURA SQL '
			'===================================================================='
			If .lbl_LOT_TAPE.Text <> "" And .lbl_LOT_TAPE.Text = var_LOT_OLD Then
				.lbl_PN_TAPE.Text = var_PN_OLD
				.lbl_DATA_TAPE.Text = var_DATA_OLD
				.lbl_QTY_TAPE.Text = var_QTY_OLD
				.lbl_BIN_TAPE.Text = var_BIN_OLD

				.lbl_MSG_DB.Text = "LOTTO CORRISPONDENTE" & vbCrLf & "SALVATAGGIO" & vbCr & "EFFETTUATO"
				bit_PN_DB_OK = True
				GoTo USCITA
			End If

			'===================================================================='
			'              CONTROLLA COMPILAZIONE DATI PRINCIPALI                '
			'===================================================================='
			If .lbl_PN_TAPE.Text <> "" And .lbl_LOT_TAPE.Text <> "" And .lbl_QTY_TAPE.Text <> "" And .lbl_DATA_TAPE.Text <> "" Then
				'CONTROLLA DESCRIZIONE SUPPLEMENTARE ED EVITA LETTURA SQL
				Dim str_TRIM = Split(.lbl_DES_SUP_ANA.Text, "(")                                                    'PRENDE STRINGA FINO A PRIMA PARENTESI
				If fun_STR_FORMAT(str_TRIM(0)) = fun_STR_FORMAT(.lbl_PN_TAPE.Text) Then                             'CONFRONTA PN TAPE CON DESC.SUPPL. ELIMINANDO I CARATTERI SPECIALI
					.lbl_MSG_DB.Text = "DESC. SUPPLEMENTARE = P/N" & vbCrLf & "SALVATAGGIO" & vbCrLf & "EFFETTUATO"
					bit_PN_DB_OK = True
				Else
					'CARICA DATI DA SQL TABELLA EQUIVALENZE
					Call sub_SQL_READER_DB(fun_STR_FORMAT(.lbl_PN_TAPE.Text))                                       'PASSA PART NUMBER TAPE ESCLUSI CARATTERI SPECIALI
				End If
				GoTo USCITA
			End If

			'ASSEGNA COLORE ALLE LBL
			Call sub_LBL_UPDATE()  'ASSEGNA COLORE ALLE LBL
			'Next
			Exit Sub

USCITA:
			'SPEGNE bgw_LOOP_SER_1
			Call sub_BGW_OFF_ON(0)

			'ASSEGNA COLORE ALLE LBL
			Call sub_LBL_UPDATE()

			'SALVA IN TABELLA  EXTRA
			Call sub_DATA_SAVE()
		End With
	End Sub

	'CARICA DATI DA SQL TABELLA EQUIVALENZE
	Sub sub_SQL_READER_DB(_PART_NUMBER)
		With form_MAIN
			Try
				'CARICA PN E MARCA REGISTRATI IN TABELLA EQUIVALENZE
				sql_CONN.ConnectionString = var_TRESLA_SQL_CONN
				sql_CMD.Connection = sql_CONN
				sql_CMD.CommandType = CommandType.Text
				sql_CONN.Open()

				Array.Clear(arr_PN_EQUIV, 0, arr_PN_EQUIV.Length)                           'PULISCE ARRAY
				Dim var_PN_EQUIV_ID = ""
				Dim arr_INDEX = 0
				sql_CMD.CommandText = $"SELECT ID, PART_NUMBER_EQUIVAL, MARCA_FORNITORE FROM EQUIVALENZE WHERE CODICE_LASI = '{ .lbl_LASI_CODE_ANA.Text}'"
				sql_READER = sql_CMD.ExecuteReader()
				If sql_READER.HasRows = True Then
					Do While sql_READER.Read
						arr_PN_EQUIV(arr_INDEX, 0) = sql_READER.Item(1)                     'PN
						arr_PN_EQUIV(arr_INDEX, 1) = sql_READER.Item(2)                     'MARCA

						'MEMORIZZA ID SE PN PRESENTE
						If fun_STR_FORMAT(arr_PN_EQUIV(arr_INDEX, 0)) = _PART_NUMBER Then   'CONFRONTA PN TAPE ESCLUSI CARATTERI SPECIALI
							var_PN_EQUIV_ID = sql_READER.Item(0)
							'Exit Do
						End If

						arr_INDEX = arr_INDEX + 1
						If arr_INDEX > 15 Then Exit Do
					Loop
				End If
				sql_READER.Close()

				If var_PN_EQUIV_ID <> "" Then
					sql_CMD.CommandText = "SELECT CODICE_LASI, DELETED, DATA_CONVALIDA, MARCA_FORNITORE, PART_NUMBER_EQUIVAL FROM EQUIVALENZE WHERE ID = N'" & var_PN_EQUIV_ID & "'"
					sql_READER = sql_CMD.ExecuteReader

					If sql_READER.Read() Then
						.lbl_PN_DB.Text = sql_READER.Item(4).ToString
						.lbl_LASI_CODE_DB.Text = sql_READER.Item(0).ToString
						.lbl_CONV_DATA_DB.Text = Strings.Left(sql_READER.Item(2).ToString, 10)
						.lbl_MARCA_DB.Text = sql_READER.Item(3).ToString

						'SE CODICE COINCIDENTE, RECORD NON CANCELLATO, CONVALIDATO
						If .lbl_LASI_CODE_ANA.Text = .lbl_LASI_CODE_DB.Text And sql_READER.Item(1) = False And sql_READER.Item(2).ToString <> "" Then
							.lbl_CONV_DEL_DB.Text = "PRESENTE"
							.lbl_MSG_DB.Text = "P/N PRESENTE E VALIDATO"
							bit_PN_DB_OK = True
							Exit Sub
						End If

						'SE CODICE NON COINCIDENTE, RECORD NON CANCELLATO, CONVALIDATO
						If .lbl_LASI_CODE_ANA.Text <> .lbl_LASI_CODE_DB.Text And sql_READER.Item(1) = False And sql_READER.Item(2).ToString <> "" Then
							.lbl_CONV_DEL_DB.Text = "PRESENTE"
							.lbl_MSG_DB.Text = "P/N PRESENTE E VALIDATO" & vbCrLf & vbCrLf & "ATTENZIONE: CODICE NEL DB <> DA ANAGRAFICA"
							bit_PN_DB_OK = False
							Exit Sub
						End If

						If sql_READER.Item(1) = True Then
							.lbl_CONV_DEL_DB.Text = "ANNULLATO"
							.lbl_MSG_DB.Text = "P/N PRESENTE MA ANNULLATO"
							bit_PN_DB_OK = False
							Exit Sub
						End If

						If sql_READER.Item(1) = False And sql_READER.Item(2).ToString = "" Then
							.lbl_CONV_DEL_DB.Text = "PRESENTE"
							.lbl_MSG_DB.Text = "P/N PRESENTE MA NON VAILDATO"
							bit_PN_DB_OK = False
							Exit Sub
						End If
					End If
				Else
					.lbl_CONV_DEL_DB.Text = ""
					.lbl_MSG_DB.Text = "P/N NON PRESENTE"
					bit_PN_DB_OK = False
				End If

			Catch ex As Exception
				MessageBox.Show("ATTENZIONE: CONNESSIONE SQL NOK" & vbCr & ex.Message, "sub_SQL_READER_DB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

			Finally
				sql_READER.Close()
				sql_CONN.Close()
			End Try
		End With
	End Sub

	'SALVA IN GAPEL90F
	Sub sub_DATA_SAVE()
		With form_MAIN
			Try
				If bit_PN_DB_OK = True Then
					Call sub_BEEP()
					Sleep(100)
					Call sub_BEEP()
					Sleep(100)
					Call sub_BEEP()

					'RICHIAMO UL LASI DA JG
					Dim sp_RET = -2
					Dim INDEX = 0
					Do Until sp_RET = 0
						'sp_RET = 0 : var_UL_SP = "20028894"					'PROVVISORIO
						sp_RET = GetUnivocoAS400(1, var_UL_SP, var_MSG_SP)      'PROVVISORIO
						INDEX = INDEX + 1
						If INDEX = 5 Then
							MessageBox.Show("ATTENZIONE: ERRORE RICHIESTA UNIVOCO DA JG" & vbCr & vbCr & "ANNULLARE LETTURA E RITENTARE", "GetUnivocoAS400", MessageBoxButtons.OK, MessageBoxIcon.Error)
							Exit Sub
						End If
					Loop

					'ASSEGNA VALORI A BTN RISTAMPA
					.btn_RISTAMPA.Enabled = True
					.btn_RISTAMPA.Text = "RISTAMPA UL: " & var_UL_SP

					'ASSEGNA VALORI A LBL CONTEGGIO
					.lbl_QTY_READ.Text = CInt(.lbl_QTY_READ.Text) + CInt(.lbl_QTY_TAPE.Text)
					.lbl_QTY_ITEMS.Text = CInt(.lbl_QTY_ITEMS.Text) + 1

					Select Case CInt(.lbl_QTY_READ.Text)
						Case < CInt(.lbl_QTY_RIGA.Text)
							.lbl_QTY_READ.BackColor = Color.Tomato

						Case = CInt(.lbl_QTY_RIGA.Text)
							.lbl_QTY_READ.BackColor = Color.PaleGreen

						Case > CInt(.lbl_QTY_RIGA.Text)
							.lbl_QTY_READ.BackColor = Color.Gold
					End Select

					'ASSEGNA VALORI A LBL RESULT
					.cbx_MARCA.Enabled = False
					.lbl_MSG_DB.BackColor = Color.PaleGreen
					.lbl_MSG_DB.Image = My.Resources.Quality_ApprovatoTrasp

					'==================================='
					' IMPOSTA DATI PER TABELLA GAPEL90F '
					'==================================='
					Dim _PROFLO = Trim(Strings.Left(var_TM_HOSTNAME, 10))                                           '[PROFLO] VARCHAR (10) NOT NULL     NOME TM
					Dim _DT01LO = var_REG_DATA                                                                      '[DT01LO] DECIMAL (8)  NOT NULL     DATA RECORD
					Dim _DTMNLO = "0"                                                                               '[DTMNLO] DECIMAL (8)  NOT NULL     DATA (NON USATO)
					Dim _CDDTLO = "01"                                                                              '[CDDTLO] VARCHAR (2)  NOT NULL     DITTA
					Dim _CDARLO = .lbl_LASI_CODE_ANA.Text                                                           '[CDARLO] VARCHAR (18) NOT NULL     CODICE ARTICOLO
					Dim _DSARLO = .lbl_DES_ANA.Text                                                                 '[DSARLO] VARCHAR (40) Not NULL     DESCRIZIONE ARTICOLO
					Dim _DSSALO = .lbl_DES_SUP_ANA.Text                                                             '[DSSALO] VARCHAR (30) Not NULL     SUPPLEMENTARE ARTICOLO
					Dim _TDOCLO = var_ORD_TIPO                                                                      '[TDOCLO] VARCHAR (1)  Not NULL     TIPO ORDINE
					Dim _NRORLO = var_ORD_NUM                                                                       '[NRORLO] Decimal (7)  Not NULL     NUMERO ORDINE
					Dim _NRRGLO = var_ORD_RIGA                                                                      '[NRRGLO] Decimal (3)  Not NULL     RIGA ORDINE
					Dim _NRDCLO = Trim(Strings.Left(var_BOLLA_NUM, 7))                                              '[NRDCLO] VARCHAR (7)  Not NULL     BOLLA NUMERO
					Dim _MARCLO = .lbl_MARCA_ANA.Text                                                               '[MARCLO] VARCHAR (20) Not NULL     MARCA

					'CALCOLA TRIMESTRE 52 WK PER ANNO
					var_WK_TRIM_SQL = DatePart("ww", Date.ParseExact(var_REG_DATA, "yyyyMMdd", Nothing))
					Select Case var_WK_TRIM_SQL
						Case 0 To 13
							var_WK_TRIM_SQL = "01" & Format(Date.ParseExact(var_REG_DATA, "yyyyMMdd", Nothing), "yy")
						Case 14 To 26
							var_WK_TRIM_SQL = "02" & Format(Date.ParseExact(var_REG_DATA, "yyyyMMdd", Nothing), "yy")
						Case 27 To 39
							var_WK_TRIM_SQL = "03" & Format(Date.ParseExact(var_REG_DATA, "yyyyMMdd", Nothing), "yy")
						Case Else
							var_WK_TRIM_SQL = "04" & Format(Date.ParseExact(var_REG_DATA, "yyyyMMdd", Nothing), "yy")
					End Select
					Dim _MESELO = var_WK_TRIM_SQL                                                                   '[MESELO] VARCHAR (5)  Not NULL     TRIMESTRE (TTYY)
					Dim _DTBOLO = var_MOV_DATA                                                                      '[DTBOLO] NUMERIC (8)  Not NULL     MOVIMENTO DATA
					Dim _CONFLO = var_UL_SP                                                                         '[CONFLO] VARCHAR (8)  Not NULL     UNIVOCO

					'AGGIORNO DATABASE MIRROR TABELLA GAPEL90F (INSERT)
					sql_CMD.Connection = sql_CONN
					sql_CMD.CommandType = CommandType.Text
					sql_CONN.ConnectionString = var_MIRROR_SQL_CONN
					sql_CONN.Open()

					sql_CMD.CommandText = $"INSERT INTO GAPEL90F (PROFLO, DT01LO, DTMNLO, CDDTLO, CDARLO, DSARLO, DSSALO, TDOCLO, NRORLO, NRRGLO, NRDCLO, MARCLO, MESELO, DTBOLO, CONFLO) VALUES ('{_PROFLO}', '{_DT01LO}', '{_DTMNLO}', '{_CDDTLO}', '{_CDARLO}', '{_DSARLO}', '{_DSSALO}', '{_TDOCLO}', '{_NRORLO}', '{_NRRGLO}', '{_NRDCLO}', '{_MARCLO}', '{_MESELO}', '{_DTBOLO}', '{_CONFLO}')"
					sp_RET = sql_CMD.ExecuteNonQuery()     'PROVVISORIO
					sql_CONN.Close()

					'ACCENDE TIMER
					.tim_CONFERMA.Enabled = True            'PROVVISORIO

					'STAMPA ETICHETTA                      
					Call sub_LBL_PRINT()

					Sleep(2000)

					'AGGIORNO DATABASE TRESLA TABELLA EXTRA
					'PNBMAK - PART NUMBER TAPE
					'LTTMAK - LOTTO TAPE
					'QTAMAK - QTY TAPE
					'DMXMAK - NU
					'DATAMAK - DATA TAPE
					'FLAGTRAK = '1'

					sql_CMD.Connection = sql_CONN
					sql_CMD.CommandType = CommandType.Text
					sql_CONN.ConnectionString = var_TRESLA_SQL_CONN
					sql_CONN.Open()

					sql_CMD.CommandText = $"UPDATE EXTRA SET PNBMAK = '{ .lbl_PN_TAPE.Text}', LTTMAK = '{ .lbl_LOT_TAPE.Text }', QTAMAK = '{ .lbl_QTY_TAPE.Text}', DATAMAK = '{ .lbl_DATA_TAPE.Text }', FLAGTRAK = '{1}' WHERE UNIVOCO = '{var_UL_SP}'"
					sql_CMD.ExecuteNonQuery()              'PROVVISORIO

					var_LASI_CODE_OLD = .lbl_LASI_CODE_ANA.Text
					var_PN_OLD = .lbl_PN_TAPE.Text
					var_LOT_OLD = .lbl_LOT_TAPE.Text
					var_DATA_OLD = .lbl_DATA_TAPE.Text
					var_QTY_OLD = .lbl_QTY_TAPE.Text
					var_BIN_OLD = .lbl_BIN_TAPE.Text
				Else
					'ASSEGNA VALORI A BTN RISTAMPA
					.btn_READ.Enabled = True
					.btn_RISTAMPA.Enabled = False
					.btn_RISTAMPA.Text = "RISTAMPA"

					'ASSEGNA VALORI A LBL RESULT
					.lbl_MSG_DB.BackColor = Color.MistyRose
					.lbl_MSG_DB.Image = My.Resources.Quality_RejectedTrasp

					'GENERA LOG GIORNALIERO
					'GENERALI
					Call sub_LOG_SERVER_WRITE("[====== GENERALI ===========]")
					Call sub_LOG_SERVER_WRITE("VERS. : " & .Text & vbCrLf)

					'ANAGRAFICA
					Call sub_LOG_SERVER_WRITE("[====== ANAGRAFICA =========]")
					Call sub_LOG_SERVER_WRITE("CODICE: " & .lbl_LASI_CODE_ANA.Text)
					Call sub_LOG_SERVER_WRITE("DESCR.: " & .lbl_DES_ANA.Text)
					Call sub_LOG_SERVER_WRITE("SUPPL.: " & .lbl_DES_SUP_ANA.Text)
					Call sub_LOG_SERVER_WRITE("MARCA : " & .lbl_MARCA_ANA.Text & vbCrLf)

					'TAPE
					Call sub_LOG_SERVER_WRITE("[====== TAPE ===============]")
					Call sub_LOG_SERVER_WRITE("P/N   : " & .lbl_PN_TAPE.Text & vbCrLf)

					'EQIVALENZE
					Call sub_LOG_SERVER_WRITE("[====== DB EQIVALENZE ======]")
					Call sub_LOG_SERVER_WRITE("ALERT : " & Replace(.lbl_MSG_DB.Text, vbCrLf, " >> "))   'MESSAGGIO
					Call sub_LOG_SERVER_WRITE("CODICE: " & .lbl_LASI_CODE_DB.Text)                      'CODICE
					Call sub_LOG_SERVER_WRITE("STATUS: " & .lbl_CONV_DEL_DB.Text)                       'CONVALIDA
					Call sub_LOG_SERVER_WRITE("DATA  : " & .lbl_CONV_DATA_DB.Text)                      'DATA 
					Call sub_LOG_SERVER_WRITE("MARCA : " & .lbl_MARCA_DB.Text)                          'MARCA

					If arr_PN_EQUIV(0, 0) = "" Then
						Call sub_LOG_SERVER_WRITE("P/N   : NESSUNO")                                    'PN
					Else
						Call sub_LOG_SERVER_WRITE("P/N   :")
						Dim arr_INDEX = 0
						Do Until arr_PN_EQUIV(arr_INDEX, 0) = ""
							Call sub_LOG_SERVER_WRITE(arr_PN_EQUIV(arr_INDEX, 0) & " (" & arr_PN_EQUIV(arr_INDEX, 1) & ")")
							arr_INDEX = arr_INDEX + 1
							If arr_INDEX > 15 Then Exit Do
						Loop
					End If
					Call sub_LOG_SERVER_WRITE("[-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.]" & vbCrLf)

					'MANDA MAIL
					Dim var_TEXT = "In allegato, annulla e sostituisce ogni versione precedente." & vbCrLf & vbCrLf & "Questa email è stata creata automaticamente da 'database@famag.it'" & vbCrLf & "Non rispondere a questo messaggio."
					sub_SEND_MAIL("Factory Control Trac_2 - Logfile del: " & Format(Now, "dd/MM/yyyy - HH:mm"), var_TEXT, var_MAIL_DEST, var_MAIL_CC, var_SERVER_LOG_FILE)
				End If

			Catch ex As Exception
				MessageBox.Show("ATTENZIONE: CONNESSIONE SQL NOK" & vbCr & ex.Message, "sub_DATA_SAVE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

			Finally
				sql_CONN.Close()
			End Try
		End With
	End Sub

	'BGW ON/OFF
	Sub sub_BGW_OFF_ON(_INDEX)
		With form_MAIN
			Select Case _INDEX
				Case 0                                          'SPEGNE BGW
					.pbx_BCR_ON.Enabled = False

					'SPEGNE BGW
					bit_STOP_BGW = True
					Do Until .bgw_LOOP_SER_1.IsBusy = False
						Application.DoEvents()
					Loop

					'PULISCE BUFFER ARRAY & LABEL
					If .com_DMR_1.IsOpen = True Then
						var_SER_RX_1 = ""
						.com_DMR_1.DiscardInBuffer()
					End If

					Array.Clear(arr_BARCODE, 0, arr_BARCODE.Length)

				Case 1                                         'ACCENDE BGW
					.pbx_BCR_ON.Enabled = True

					'ACCENDE BGW
					bit_STOP_BGW = False
					.bgw_LOOP_SER_1.RunWorkerAsync()
			End Select
		End With
	End Sub

	'AGGIORNA LABEL
	Sub sub_LBL_UPDATE()
		With form_MAIN
			'gbx_ANAG
			If .lbl_LASI_CODE_ANA.Text <> "" Then .lbl_LASI_CODE_ANA_0.BackColor = Color.Lime
			If .lbl_DES_ANA.Text <> "" Then .lbl_DES_ANA_0.BackColor = Color.Lime
			If .lbl_DES_SUP_ANA.Text <> "" Then .lbl_DES_SUP_ANA_0.BackColor = Color.Lime
			If .lbl_MARCA_ANA.Text <> "" Then .lbl_MARCA_ANA_0.BackColor = Color.Lime

			'gbx_TAPE
			If .lbl_PN_TAPE.Text <> "" Then .lbl_PN_TAPE_0.BackColor = Color.Lime
			If .lbl_LOT_TAPE.Text <> "" Then .lbl_LOT_TAPE_0.BackColor = Color.Lime
			If .lbl_DATA_TAPE.Text <> "" Then .lbl_DATA_TAPE_0.BackColor = Color.Lime
			If .lbl_QTY_TAPE.Text <> "" Then .lbl_QTY_TAPE_0.BackColor = Color.Lime
			If .lbl_BIN_TAPE.Text <> "" Then .lbl_BIN_TAPE_0.BackColor = Color.Lime

			'gbx_DATABASE
			If .lbl_LASI_CODE_DB.Text <> "" Then .lbl_LASI_CODE_DB_0.BackColor = Color.Lime
			If .lbl_PN_DB.Text <> "" Then .lbl_PN_DB_0.BackColor = Color.Lime
			If .lbl_CONV_DEL_DB.Text = "PRESENTE" And .lbl_CONV_DATA_DB.Text <> "" Then
				.lbl_CONV_DB_0.BackColor = Color.Lime
			End If

			If .lbl_MARCA_DB.Text <> "" Then .lbl_MARCA_DB_0.BackColor = Color.Lime
		End With
	End Sub

	'PULISCE LABEL
	Sub sub_DATA_CLEAN(_index)
		With form_MAIN
			If .com_DMR_1.IsOpen Then
				var_SER_RX_1 = ""
				.com_DMR_1.DiscardInBuffer()
				Array.Clear(arr_BARCODE, 0, arr_BARCODE.Length)
			End If

			'ASSEGNA VALORI A LBL RESULT
			.tbx_ARRAY_BC.Clear()
			.lbl_MSG_DB.Text = "" : .lbl_MSG_DB.BackColor = SystemColors.ControlLight
			.lbl_MSG_DB.Image = Nothing

			'gbx_ANAG
			If _index = 0 Then
				.cbx_MARCA.Enabled = False

				'VALORI OLD
				var_LASI_CODE_OLD = ""
				var_PN_OLD = ""
				var_LOT_OLD = ""
				var_DATA_OLD = ""
				var_QTY_OLD = ""
				var_BIN_OLD = ""

				'ASSEGNA VALORI A BTN RISTAMPA
				.btn_READ.Enabled = False
				.btn_RISTAMPA.Enabled = False : .btn_RISTAMPA.Text = "RISTAMPA"

				'ASSEGNA VALORI A LBL CONTEGGIO
				.lbl_QTY_RIGA.Text = 0
				.lbl_QTY_READ.Text = 0 : .lbl_QTY_READ.BackColor = SystemColors.ControlLight
				.lbl_QTY_ITEMS.Text = 0

				'gbx_ANAGRAFICA
				.lbl_LASI_CODE_ANA.Text = "" : .lbl_LASI_CODE_ANA_0.BackColor = SystemColors.ControlLight
				.lbl_DES_ANA.Text = "" : .lbl_DES_ANA_0.BackColor = SystemColors.ControlLight
				.lbl_DES_SUP_ANA.Text = "" : .lbl_DES_SUP_ANA_0.BackColor = SystemColors.ControlLight
				.lbl_MARCA_ANA.Text = "" : .lbl_MARCA_ANA_0.BackColor = SystemColors.ControlLight
			End If

			'gbx_TAPE
			.lbl_PN_TAPE.Text = "" : .lbl_PN_TAPE_0.BackColor = SystemColors.ControlLight
			.lbl_LOT_TAPE.Text = "" : .lbl_LOT_TAPE_0.BackColor = SystemColors.ControlLight
			.lbl_DATA_TAPE.Text = "" : .lbl_DATA_TAPE_0.BackColor = SystemColors.ControlLight
			.lbl_QTY_TAPE.Text = "" : .lbl_QTY_TAPE_0.BackColor = SystemColors.ControlLight
			.lbl_BIN_TAPE.Text = "" : .lbl_BIN_TAPE_0.BackColor = SystemColors.ControlLight

			'gbx_DATABASE
			.lbl_LASI_CODE_DB.Text = "" : .lbl_LASI_CODE_DB_0.BackColor = SystemColors.ControlLight
			.lbl_PN_DB.Text = "" : .lbl_PN_DB_0.BackColor = SystemColors.ControlLight
			bit_PN_DB_OK = False : .lbl_CONV_DB_0.BackColor = SystemColors.ControlLight

			'gbx_CONVALIDA
			.lbl_CONV_DEL_DB.Text = ""
			.lbl_CONV_DATA_DB.Text = ""
			.lbl_MARCA_DB.Text = "" : .lbl_MARCA_DB_0.BackColor = SystemColors.ControlLight
		End With
	End Sub

	'ELIMINA SPAZI, "_" E CARATTERI SPECIALI ESCLUSO "." & CONVERTE IN MAIUSCOLO
	Function fun_STR_FORMAT(_STR)
		If _STR <> "" Then
			_STR = Replace(_STR, " ", "")                       'ELIMINA " "
			_STR = Replace(_STR, "_", "")                       'ELIMINA "_"
			_STR = Replace(_STR, ",", ".")                      'RIMPIAZZA "," CON "."
			_STR = Regex.Replace(_STR, "[^\w\.]", "").ToUpper   'ELIMINA CARATTERI SPECIALI ESCLUSO "." E CONVERTE IN MAIUSCOLO
			Return _STR
		Else
			Return ""
		End If
	End Function

	Sub sub_CLICK()
		My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.WaitToComplete)
	End Sub

	Sub sub_BEEP()
		My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
	End Sub
End Module
