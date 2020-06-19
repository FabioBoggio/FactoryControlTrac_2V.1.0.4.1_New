
Imports Ini.Net
Imports System.IO
Imports System.Net
Imports System.Threading.Thread

Public Class form_MAIN
#Region " REGION FORM MAIN"
    Private Sub form_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'IMPOSTA VARIABILI LETTURA/SCRITTURA FILE INI (As iniFile)
        var_LOCAL_INI_FILE = New IniFile(My.Application.Info.DirectoryPath & "\" & "INI_LOCAL.ini")
        var_SERVER_INI_FILE = New IniFile(var_LOCAL_INI_FILE.ReadString("serverPATH", "serverSQL") & "\" & "INI_SERVER.ini")

        'VERIFICA CONNESSIONE DI RETE
        If My.Computer.Network.IsAvailable = True Then          'True se connesso in rete
            Try
                var_TM_HOSTNAME = Dns.GetHostName()
                Dim pc_IP_ADD
                pc_IP_ADD = Dns.GetHostEntry(var_TM_HOSTNAME).AddressList()
                For Each Address In Dns.GetHostEntry(var_TM_HOSTNAME).AddressList()
                    If Convert.ToInt32(Address.AddressFamily) = 2 Then
                        pc_IP_ADD = Address.ToString
                        lbl_IP_ADD.BackColor = Color.LightGreen
                        lbl_IP_ADD.Text = "IP: " & pc_IP_ADD
                        Exit For
                    End If
                Next

            Catch ex As Exception
                lbl_IP_ADD.BackColor = Color.Tomato
                MessageBox.Show("ATTENZIONE: IP ADDRESS NON RILEVATO" & vbCr & ex.Message, "form_MAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        Else
            lbl_IP_ADD.BackColor = Color.Tomato
            MessageBox.Show("ATTENZIONE: COMPUTER NON CONNESSO", "form_MAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        '+++++++++ VERIFICA AGGIORNAMENTI 2.0 +++++++++'
        Dim str_FILE_CMD = "AggiornaVersione.cmd"                                                               'NOME FILE .CMD
        Dim str_FILE_NAME = IO.Path.GetFileName(Application.ExecutablePath)                                     'PATH FILE OLD IN LOCALE
        Dim str_PATH_ORIG = var_LOCAL_INI_FILE.ReadString("serverPATH", "serverORIG")                           'PATH FILE NEW SU SERVER
        Dim str_PATH_DEST = My.Application.Info.DirectoryPath                                                   'FOLDER IN LOCALE
        Dim str_NEW_REV = FileVersionInfo.GetVersionInfo(str_PATH_ORIG & "\" & str_FILE_NAME).ProductVersion    'LEGGE VERSIONE NEW FILE
        Dim str_CMD = My.Application.Info.DirectoryPath & "\" & str_FILE_CMD & " " & str_FILE_NAME & " " & str_PATH_ORIG & " " & str_PATH_DEST

        'ENTRA SOLO SE NON IN DEBUG - "AggiornaVersione.cmd" V.2.0 del 09/11/2019
        If Debugger.IsAttached = False Then
            If Application.ProductVersion <> str_NEW_REV Then
                Sleep(2000)
                Shell(str_CMD, vbNormalFocus)
                Exit Sub
            End If
        End If
        Me.Text = Me.Text & " - V." & Application.ProductVersion
        '++++++++++++++++++++++++++++++++++++++++++++++'

        var_AS_CONN = var_SERVER_INI_FILE.ReadString("connectSQL", "serverAS400_SRL")
        var_MIRROR_SQL_CONN = var_SERVER_INI_FILE.ReadString("connectSQL", "mirrorSQL_SRL")
        var_TRESLA_SQL_CONN = var_SERVER_INI_FILE.ReadString("connectSQL", "lasiTRESLA_SRL")
        var_SERVER_LOG_FILE = My.Application.Info.DirectoryPath & var_LOCAL_INI_FILE.ReadString("serverPATH", "serverLOG") & "\" & "Log-" & Format(Date.Today, "yyyy.MM.dd") & ".txt"
        var_SERVER_HELP_FILE = var_LOCAL_INI_FILE.ReadString("serverPATH", "serverHELP")

        var_MAIL_DEST = var_LOCAL_INI_FILE.ReadString("mail_ADD", "mail_DEST")
        var_MAIL_CC = var_LOCAL_INI_FILE.ReadString("mail_ADD", "mail_CC")

        Dim var_MSG = "--> SQL MIRROR"
        Try 'TESTA LA CONNESSIONE AI DATABASE
            sql_CMD.Connection = sql_CONN
            sql_CMD.CommandType = CommandType.Text
            sql_CONN.ConnectionString = var_MIRROR_SQL_CONN
            sql_CONN.Open()
            If sql_CONN.State = 1 Then sql_CONN.Close()

            var_MSG = "--> SQL TRESLA"
            sql_CONN.ConnectionString = var_TRESLA_SQL_CONN
            sql_CONN.Open()
            If sql_CONN.State = 1 Then sql_CONN.Close()
        Catch ex As Exception
            MessageBox.Show("ATTENZIONE: CONNESSIONE AL SERVER SQL NON RIUSCITA" & vbCr & vbCr & var_MSG & vbCr & vbCr & ex.Message, "form_MAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        'CALCOLA NUMERO SETTIMANA CORRENTE
        var_WK_NUM = DatePart("ww", Now)
        If var_WK_NUM < 10 Then
            var_WK_NUM = "0" & var_WK_NUM & Format(Now, "yy")
        Else
            var_WK_NUM = var_WK_NUM & Format(Now, "yy")
        End If

        'CARICA COM BCR
        Try
            If var_LOCAL_INI_FILE.ReadString("Com", "Com_dmr_1") <> "" Then
                lbl_COM_1.Text = "PORT: " & var_LOCAL_INI_FILE.ReadString("Com", "Com_dmr_1")
                com_DMR_1.PortName = var_LOCAL_INI_FILE.ReadString("Com", "Com_dmr_1")
                com_DMR_1.Open()
                lbl_COM_1.BackColor = Color.LightGreen
            Else
                lbl_COM_1.BackColor = Color.Tomato
                MessageBox.Show("ATTENZIONE: SERIALE DMR NON DISPONIBILE" & vbCrLf & vbCrLf & "AGGIORNARE FILE INI.LOCAL E RIAVVIARE", "form_MAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("ATTENZIONE: ERRORE LETTORE BARCODE" & vbCr & vbCr & ex.Message, "form_MAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

#Region " REGION MARCHE"
        'CARICA COMBO BOX MARCA - JG TABELLA M2 - Descrizione classi dati tecnici
        '====================================================================='
        '!!! SE SI MODIFICANO LE DESCRIZIONI MODIFICARE ANCHE MODULO MARCHE !!!
        '!!!        FARE RICERCA CON TESTO PER ALTRI PUNTI DEL CODICE       !!!
        '====================================================================='
        cbx_MARCA.Items.Add("GENERICO")
        cbx_MARCA.Items.Add("ALLEGRO")
        cbx_MARCA.Items.Add("ALPHA & OMEGA")
        cbx_MARCA.Items.Add("BI")
        cbx_MARCA.Items.Add("BOURNS")
        cbx_MARCA.Items.Add("CHANG")
        cbx_MARCA.Items.Add("C&K")
        cbx_MARCA.Items.Add("CREE")
        cbx_MARCA.Items.Add("DELTA")
        cbx_MARCA.Items.Add("DOMINANT")
        cbx_MARCA.Items.Add("DIOTEC")
        cbx_MARCA.Items.Add("DIODES")
        cbx_MARCA.Items.Add("E&E")
        cbx_MARCA.Items.Add("EPCOS")
        cbx_MARCA.Items.Add("EVERLIGHT")
        cbx_MARCA.Items.Add("IMS")
        cbx_MARCA.Items.Add("ISSI")
        cbx_MARCA.Items.Add("ITT")
        cbx_MARCA.Items.Add("JOHANSON")
        cbx_MARCA.Items.Add("HKC")
        cbx_MARCA.Items.Add("KAMAYA")
        cbx_MARCA.Items.Add("KEMET")
        cbx_MARCA.Items.Add("KINGBRIGHT")
        cbx_MARCA.Items.Add("LITEON")
        cbx_MARCA.Items.Add("LITTLEFUSE")
        cbx_MARCA.Items.Add("MURATA")
        cbx_MARCA.Items.Add("MICREL")
        cbx_MARCA.Items.Add("MICROCHIP")
        cbx_MARCA.Items.Add("MICRON")
        cbx_MARCA.Items.Add("MINIBRIDGE")
        cbx_MARCA.Items.Add("NICHICON")
        cbx_MARCA.Items.Add("NXP")
        cbx_MARCA.Items.Add("NXP_DM")
        cbx_MARCA.Items.Add("OMRON")
        cbx_MARCA.Items.Add("OSRAM")
        cbx_MARCA.Items.Add("PANJIT")
        cbx_MARCA.Items.Add("RENESAS")
        cbx_MARCA.Items.Add("ROHM")
        cbx_MARCA.Items.Add("ROYALOHM")
        cbx_MARCA.Items.Add("SAMSUNG")
        cbx_MARCA.Items.Add("SAMWHA")
        cbx_MARCA.Items.Add("SEOUL")
        cbx_MARCA.Items.Add("STANLEY")
        cbx_MARCA.Items.Add("ST MICRO")
        cbx_MARCA.Items.Add("STACKPOLE")
        cbx_MARCA.Items.Add("TAIYO YUDEN")
        cbx_MARCA.Items.Add("TAITIEN")
        cbx_MARCA.Items.Add("TDK")
        cbx_MARCA.Items.Add("TYCO/ETE")
        cbx_MARCA.Items.Add("TEXAS/NATIONAL")
        cbx_MARCA.Items.Add("TVS")
        cbx_MARCA.Items.Add("UBLOX")
        cbx_MARCA.Items.Add("XILINX")
        cbx_MARCA.Items.Add("VIKING")
        cbx_MARCA.Items.Add("VISHAY")

        cbx_MARCA.SelectedIndex = 0
#End Region

        bit_FORM_LOAD = True
    End Sub

    Private Sub form_MAIN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Call sub_BGW_OFF_ON(0)
        com_DMR_1.Dispose()
    End Sub
#End Region

    'BTN HELP
    Private Sub btn_HELP_Click_1(sender As Object, e As EventArgs) Handles btn_HELP.Click
        Call sub_CLICK()
        Process.Start(var_SERVER_HELP_FILE & "\" & "Help.txt")
    End Sub

    'BTN RISTAMPA LBL
    Private Sub btn_RISTAMPA_Click(sender As Object, e As EventArgs) Handles btn_RISTAMPA.Click
        Call sub_LBL_PRINT()
    End Sub

    'BTN CARICO BOLLE
    Private Sub btn_BOLLE_LOAD_Click(sender As Object, e As EventArgs) Handles btn_BOLLE_LOAD.Click
        Call sub_CLICK()
        lvw_BOLLE.Items.Clear()
        lvw_BOLLA_ITEM.Items.Clear()
        Call sub_AS_READER_BOLLE()
    End Sub

    'SELEZIONE IN TABELLA LISTA BOLLE
    Private Sub lvw_BOLLE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvw_BOLLE.SelectedIndexChanged
        If lvw_BOLLE.SelectedItems.Count > 0 Then
            'SCRIVE DATI DOCUMENTO
            var_REG_DATA = Format(Date.ParseExact(lvw_BOLLE.SelectedItems(0).Text, "dd/MM/yyyy", Nothing), "yyyyMMdd")
            var_BOLLA_NUM = Trim(lvw_BOLLE.SelectedItems(0).SubItems(1).Text)
            var_BOLLA_DATA = lvw_BOLLE.SelectedItems(0).SubItems(2).Text
            var_MOV_DATA = lvw_BOLLE.SelectedItems(0).SubItems(5).Text

            lbl_BOLLA_ITEM.Text = "BOLLA NR. " & var_BOLLA_NUM & " DEL " & var_BOLLA_DATA

            var_BOLLA_DATA = Format(Date.ParseExact(lvw_BOLLE.SelectedItems(0).SubItems(2).Text, "dd/MM/yyyy", Nothing), "dd/MM/yy")

            'SELEZIONA RIGA
            lvw_BOLLE.Items(lvw_BOLLE.SelectedIndices(0)).BackColor = Color.PaleGreen
            lvw_BOLLE.Items(lvw_BOLLE.SelectedIndices(0)).Selected = False

            lvw_BOLLA_ITEM.Items.Clear()

            Call sub_AS_READER_BOLLE_DET(var_BOLLA_NUM)   'PASSA NUMERO BOLLA
        End If
    End Sub

    'SELEZIONE IN TABELLA ITEM BOLLA
    Private Sub lvw_BOLLA_ITEM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvw_BOLLA_ITEM.SelectedIndexChanged
        If lvw_BOLLA_ITEM.SelectedItems.Count > 0 Then
            Call sub_DATA_CLEAN(0)
            Call sub_BGW_OFF_ON(1)

            cbx_MARCA.Enabled = True

            var_LVW_ITEM_INDEX = lvw_BOLLA_ITEM.SelectedIndices(0)
            lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).BackColor = Color.PaleGreen
            lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).Selected = False

            var_ORD_TIPO = lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).Text
            var_ORD_NUM = lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).SubItems(1).text
            var_ORD_RIGA = lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).SubItems(2).text

            'LEGGE DATI ANAGRAFICA
            Call sub_SQL_READER_ANA(lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).SubItems(3).text)  'PASSA CODICE ARTICOLO

            lbl_QTY_RIGA.Text = lvw_BOLLA_ITEM.Items(var_LVW_ITEM_INDEX).SubItems(5).text       'PASSA QTY PER RIGA BOLLA
            tab_CONTROL.SelectedTab = pan_SLAVE
        End If
    End Sub

    'bgw_LOOP_SER_1 WORK
    Private Sub bgw_LOOP_SER_1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_LOOP_SER_1.DoWork
        Sleep(100)
        If com_DMR_1.BytesToRead > 0 Then
            var_SER_RX_1 = com_DMR_1.ReadTo(vbCr)
        Else
            var_SER_RX_1 = ""
        End If
    End Sub

    'bgw_LOOP_SER_1 COMPLETED
    Private Sub bgw_LOOP_SER_1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_LOOP_SER_1.RunWorkerCompleted
        'VERIFICA CHE NON CI SIA UN DOPPIONE ED ESCE DA SUB
        For i = 0 To UBound(arr_BARCODE)
            If arr_BARCODE(i) = var_SER_RX_1 Then
                GoTo USCITA
            End If
        Next

        'AGGIORNA ARRAY AL PRIMO POSTO VUOTO
        For i = 0 To UBound(arr_BARCODE)
            If arr_BARCODE(i) = "" Then
                arr_BARCODE(i) = var_SER_RX_1
                tbx_ARRAY_BC.AppendText("(1." & Len(var_SER_RX_1) & ") " & vbTab & var_SER_RX_1 & vbCrLf)
                Exit For
            End If
        Next

        Call sub_DATA_PROC(var_SER_RX_1)

USCITA:
        'Call sub_DATA_PROC()

        If bit_STOP_BGW = False Then
            bgw_LOOP_SER_1.RunWorkerAsync()
        End If
    End Sub

    'SELEZIONE MAIN PAGE
    Private Sub pan_SLAVE_Leave(sender As Object, e As EventArgs) Handles pan_SLAVE.Leave
        Call sub_BGW_OFF_ON(0)
        Call sub_DATA_CLEAN(0)
    End Sub

    'COMBO MARCA
    Private Sub cbx_MARCA_MouseClick(sender As Object, e As MouseEventArgs) Handles cbx_MARCA.MouseClick
        Call sub_CLICK()
        If bit_STOP_BGW = False Then
            Call sub_BGW_OFF_ON(0)
        End If
    End Sub

    Private Sub cbx_MARCA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_MARCA.SelectedIndexChanged
        If bit_FORM_LOAD = True Then
            Call sub_DATA_CLEAN(1)
            If bit_STOP_BGW = True Then
                Call sub_BGW_OFF_ON(1)
            End If
        End If
    End Sub

    'PULSANTE READ O BARSPACE
    Private Sub form_MAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'NEL FORM IMPOSTARE "Key Preview" = True
        If e.KeyCode = Keys.Space And btn_READ.Enabled = True Then
            Call sub_CLICK()
            btn_READ.Enabled = False
            Call sub_BGW_OFF_ON(1)
            Call sub_DATA_CLEAN(1)
        End If
    End Sub
    Private Sub btn_READ_Click(sender As Object, e As EventArgs) Handles btn_READ.Click
        Call sub_CLICK()
        btn_READ.Enabled = False
        Call sub_BGW_OFF_ON(1)
        Call sub_DATA_CLEAN(1)
    End Sub

    Private Sub tim_CONFERMA_Tick(sender As Object, e As EventArgs) Handles tim_CONFERMA.Tick
        tim_CONFERMA.Enabled = False
        Call sub_BGW_OFF_ON(1)
        Call sub_DATA_CLEAN(1)
    End Sub
End Class
