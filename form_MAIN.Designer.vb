<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_MAIN
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_MAIN))
        Me.lbl_FC = New System.Windows.Forms.Label()
        Me.com_DMR_1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgw_LOOP_SER_1 = New System.ComponentModel.BackgroundWorker()
        Me.tab_CONTROL = New System.Windows.Forms.TabControl()
        Me.pan_MAIN = New System.Windows.Forms.TabPage()
        Me.lbl_IP_ADD = New System.Windows.Forms.Label()
        Me.lbl_COM_1 = New System.Windows.Forms.Label()
        Me.lbl_BOLLA_ITEM = New System.Windows.Forms.Label()
        Me.lvw_BOLLA_ITEM = New System.Windows.Forms.ListView()
        Me.ORD_TIPO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ORD_NUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ORD_RIGA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RG_COD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RG_DES = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RG_QTY = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_BOLLE_LOAD = New System.Windows.Forms.Button()
        Me.lvw_BOLLE = New System.Windows.Forms.ListView()
        Me.REG_DATA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DOC_NUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DOC_DATA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FORN_COD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FORN_DES = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pan_SLAVE = New System.Windows.Forms.TabPage()
        Me.btn_RISTAMPA = New System.Windows.Forms.Button()
        Me.lbl_QTY_ITEMS = New System.Windows.Forms.Label()
        Me.btn_HELP = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_QTY_RIGA = New System.Windows.Forms.Label()
        Me.lbl_QTY_READ = New System.Windows.Forms.Label()
        Me.pan_DATABASE = New System.Windows.Forms.Panel()
        Me.pan_DATABASE_1 = New System.Windows.Forms.Panel()
        Me.lbl_MARCA_DB_0 = New System.Windows.Forms.Label()
        Me.lbl_PN_DB_0 = New System.Windows.Forms.Label()
        Me.lbl_LASI_CODE_DB_0 = New System.Windows.Forms.Label()
        Me.lbl_LASI_CODE_DB = New System.Windows.Forms.Label()
        Me.lbl_PN_DB = New System.Windows.Forms.Label()
        Me.lbl_CONV_DB_0 = New System.Windows.Forms.Label()
        Me.lbl_CONV_DEL_DB = New System.Windows.Forms.Label()
        Me.lbl_MARCA_DB = New System.Windows.Forms.Label()
        Me.lbl_CONV_DATA_DB = New System.Windows.Forms.Label()
        Me.pan_TAPE = New System.Windows.Forms.Panel()
        Me.pan_TAPE_1 = New System.Windows.Forms.Panel()
        Me.lbl_PN_TAPE_0 = New System.Windows.Forms.Label()
        Me.lbl_LOT_TAPE_0 = New System.Windows.Forms.Label()
        Me.lbl_QTY_TAPE_0 = New System.Windows.Forms.Label()
        Me.lbl_DATA_TAPE_0 = New System.Windows.Forms.Label()
        Me.lbl_QTY_TAPE = New System.Windows.Forms.Label()
        Me.lbl_PN_TAPE = New System.Windows.Forms.Label()
        Me.lbl_BIN_TAPE_0 = New System.Windows.Forms.Label()
        Me.lbl_LOT_TAPE = New System.Windows.Forms.Label()
        Me.lbl_DATA_TAPE = New System.Windows.Forms.Label()
        Me.lbl_BIN_TAPE = New System.Windows.Forms.Label()
        Me.lbl_DATABASE = New System.Windows.Forms.Label()
        Me.lbl_TAPE = New System.Windows.Forms.Label()
        Me.lbl_ANAG = New System.Windows.Forms.Label()
        Me.btn_READ = New System.Windows.Forms.Button()
        Me.lbl_MSG_DB = New System.Windows.Forms.Label()
        Me.tbx_ARRAY_BC = New System.Windows.Forms.TextBox()
        Me.cbx_MARCA = New System.Windows.Forms.ComboBox()
        Me.pan_ANAG = New System.Windows.Forms.Panel()
        Me.pan_ANAG_1 = New System.Windows.Forms.Panel()
        Me.lbl_MARCA_ANA = New System.Windows.Forms.Label()
        Me.lbl_MARCA_ANA_0 = New System.Windows.Forms.Label()
        Me.lbl_DES_ANA_0 = New System.Windows.Forms.Label()
        Me.lbl_LASI_CODE_ANA = New System.Windows.Forms.Label()
        Me.lbl_DES_SUP_ANA = New System.Windows.Forms.Label()
        Me.lbl_DES_SUP_ANA_0 = New System.Windows.Forms.Label()
        Me.lbl_DES_ANA = New System.Windows.Forms.Label()
        Me.lbl_LASI_CODE_ANA_0 = New System.Windows.Forms.Label()
        Me.pbx_BCR_ON = New System.Windows.Forms.PictureBox()
        Me.pbx_LOGO = New System.Windows.Forms.PictureBox()
        Me.pbx_LOGO_DMR = New System.Windows.Forms.PictureBox()
        Me.tim_CONFERMA = New System.Windows.Forms.Timer(Me.components)
        Me.tab_CONTROL.SuspendLayout()
        Me.pan_MAIN.SuspendLayout()
        Me.pan_SLAVE.SuspendLayout()
        Me.pan_DATABASE.SuspendLayout()
        Me.pan_DATABASE_1.SuspendLayout()
        Me.pan_TAPE.SuspendLayout()
        Me.pan_TAPE_1.SuspendLayout()
        Me.pan_ANAG.SuspendLayout()
        Me.pan_ANAG_1.SuspendLayout()
        CType(Me.pbx_BCR_ON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_LOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_LOGO_DMR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_FC
        '
        Me.lbl_FC.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_FC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_FC.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_FC.Location = New System.Drawing.Point(72, 8)
        Me.lbl_FC.Name = "lbl_FC"
        Me.lbl_FC.Size = New System.Drawing.Size(1120, 56)
        Me.lbl_FC.TabIndex = 240
        Me.lbl_FC.Text = "FACTORY CONTROL TRACEABILITY_2"
        Me.lbl_FC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'com_DMR_1
        '
        Me.com_DMR_1.BaudRate = 115200
        Me.com_DMR_1.PortName = "COM3"
        Me.com_DMR_1.ReadTimeout = 1000
        Me.com_DMR_1.WriteTimeout = 1000
        '
        'bgw_LOOP_SER_1
        '
        '
        'tab_CONTROL
        '
        Me.tab_CONTROL.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tab_CONTROL.Controls.Add(Me.pan_MAIN)
        Me.tab_CONTROL.Controls.Add(Me.pan_SLAVE)
        Me.tab_CONTROL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_CONTROL.Location = New System.Drawing.Point(8, 72)
        Me.tab_CONTROL.Name = "tab_CONTROL"
        Me.tab_CONTROL.SelectedIndex = 0
        Me.tab_CONTROL.Size = New System.Drawing.Size(1312, 640)
        Me.tab_CONTROL.TabIndex = 243
        '
        'pan_MAIN
        '
        Me.pan_MAIN.BackColor = System.Drawing.SystemColors.Control
        Me.pan_MAIN.Controls.Add(Me.lbl_IP_ADD)
        Me.pan_MAIN.Controls.Add(Me.lbl_COM_1)
        Me.pan_MAIN.Controls.Add(Me.lbl_BOLLA_ITEM)
        Me.pan_MAIN.Controls.Add(Me.lvw_BOLLA_ITEM)
        Me.pan_MAIN.Controls.Add(Me.btn_BOLLE_LOAD)
        Me.pan_MAIN.Controls.Add(Me.lvw_BOLLE)
        Me.pan_MAIN.Location = New System.Drawing.Point(4, 37)
        Me.pan_MAIN.Name = "pan_MAIN"
        Me.pan_MAIN.Padding = New System.Windows.Forms.Padding(3)
        Me.pan_MAIN.Size = New System.Drawing.Size(1304, 599)
        Me.pan_MAIN.TabIndex = 0
        Me.pan_MAIN.Text = "MAIN PAGE"
        '
        'lbl_IP_ADD
        '
        Me.lbl_IP_ADD.BackColor = System.Drawing.Color.Tomato
        Me.lbl_IP_ADD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_IP_ADD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IP_ADD.Location = New System.Drawing.Point(1128, 40)
        Me.lbl_IP_ADD.Name = "lbl_IP_ADD"
        Me.lbl_IP_ADD.Size = New System.Drawing.Size(168, 24)
        Me.lbl_IP_ADD.TabIndex = 256
        Me.lbl_IP_ADD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_COM_1
        '
        Me.lbl_COM_1.BackColor = System.Drawing.Color.Tomato
        Me.lbl_COM_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_COM_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_COM_1.Location = New System.Drawing.Point(1128, 8)
        Me.lbl_COM_1.Name = "lbl_COM_1"
        Me.lbl_COM_1.Size = New System.Drawing.Size(168, 24)
        Me.lbl_COM_1.TabIndex = 255
        Me.lbl_COM_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_BOLLA_ITEM
        '
        Me.lbl_BOLLA_ITEM.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_BOLLA_ITEM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_BOLLA_ITEM.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BOLLA_ITEM.Location = New System.Drawing.Point(608, 8)
        Me.lbl_BOLLA_ITEM.Name = "lbl_BOLLA_ITEM"
        Me.lbl_BOLLA_ITEM.Size = New System.Drawing.Size(512, 56)
        Me.lbl_BOLLA_ITEM.TabIndex = 254
        Me.lbl_BOLLA_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvw_BOLLA_ITEM
        '
        Me.lvw_BOLLA_ITEM.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvw_BOLLA_ITEM.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
        Me.lvw_BOLLA_ITEM.AutoArrange = False
        Me.lvw_BOLLA_ITEM.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ORD_TIPO, Me.ORD_NUM, Me.ORD_RIGA, Me.RG_COD, Me.RG_DES, Me.RG_QTY})
        Me.lvw_BOLLA_ITEM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_BOLLA_ITEM.FullRowSelect = True
        Me.lvw_BOLLA_ITEM.GridLines = True
        Me.lvw_BOLLA_ITEM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvw_BOLLA_ITEM.HideSelection = False
        Me.lvw_BOLLA_ITEM.LabelWrap = False
        Me.lvw_BOLLA_ITEM.Location = New System.Drawing.Point(608, 72)
        Me.lvw_BOLLA_ITEM.MultiSelect = False
        Me.lvw_BOLLA_ITEM.Name = "lvw_BOLLA_ITEM"
        Me.lvw_BOLLA_ITEM.ShowGroups = False
        Me.lvw_BOLLA_ITEM.Size = New System.Drawing.Size(688, 520)
        Me.lvw_BOLLA_ITEM.TabIndex = 232
        Me.lvw_BOLLA_ITEM.UseCompatibleStateImageBehavior = False
        Me.lvw_BOLLA_ITEM.View = System.Windows.Forms.View.Details
        '
        'ORD_TIPO
        '
        Me.ORD_TIPO.Text = "TIPO"
        Me.ORD_TIPO.Width = 70
        '
        'ORD_NUM
        '
        Me.ORD_NUM.Text = "ORDINE"
        Me.ORD_NUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ORD_NUM.Width = 91
        '
        'ORD_RIGA
        '
        Me.ORD_RIGA.Text = "RIGA"
        Me.ORD_RIGA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ORD_RIGA.Width = 77
        '
        'RG_COD
        '
        Me.RG_COD.Text = "CODICE"
        Me.RG_COD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RG_COD.Width = 90
        '
        'RG_DES
        '
        Me.RG_DES.Text = "DESCRIZIONE"
        Me.RG_DES.Width = 136
        '
        'RG_QTY
        '
        Me.RG_QTY.Text = "QTY"
        Me.RG_QTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_BOLLE_LOAD
        '
        Me.btn_BOLLE_LOAD.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_BOLLE_LOAD.Location = New System.Drawing.Point(8, 8)
        Me.btn_BOLLE_LOAD.Name = "btn_BOLLE_LOAD"
        Me.btn_BOLLE_LOAD.Size = New System.Drawing.Size(592, 56)
        Me.btn_BOLLE_LOAD.TabIndex = 233
        Me.btn_BOLLE_LOAD.Text = "CARICA BOLLE"
        Me.btn_BOLLE_LOAD.UseVisualStyleBackColor = False
        '
        'lvw_BOLLE
        '
        Me.lvw_BOLLE.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvw_BOLLE.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
        Me.lvw_BOLLE.AutoArrange = False
        Me.lvw_BOLLE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.REG_DATA, Me.DOC_NUM, Me.DOC_DATA, Me.FORN_COD, Me.FORN_DES})
        Me.lvw_BOLLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_BOLLE.FullRowSelect = True
        Me.lvw_BOLLE.GridLines = True
        Me.lvw_BOLLE.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvw_BOLLE.HideSelection = False
        Me.lvw_BOLLE.LabelWrap = False
        Me.lvw_BOLLE.Location = New System.Drawing.Point(8, 72)
        Me.lvw_BOLLE.MultiSelect = False
        Me.lvw_BOLLE.Name = "lvw_BOLLE"
        Me.lvw_BOLLE.ShowGroups = False
        Me.lvw_BOLLE.Size = New System.Drawing.Size(592, 520)
        Me.lvw_BOLLE.TabIndex = 231
        Me.lvw_BOLLE.UseCompatibleStateImageBehavior = False
        Me.lvw_BOLLE.View = System.Windows.Forms.View.Details
        '
        'REG_DATA
        '
        Me.REG_DATA.Text = "REG. DATA"
        Me.REG_DATA.Width = 137
        '
        'DOC_NUM
        '
        Me.DOC_NUM.Text = "DOC. NUM."
        Me.DOC_NUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DOC_NUM.Width = 95
        '
        'DOC_DATA
        '
        Me.DOC_DATA.Text = "DOC. DATA"
        Me.DOC_DATA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DOC_DATA.Width = 109
        '
        'FORN_COD
        '
        Me.FORN_COD.Text = "FORN. COD."
        Me.FORN_COD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FORN_COD.Width = 117
        '
        'FORN_DES
        '
        Me.FORN_DES.Text = "FORN. DESC."
        Me.FORN_DES.Width = 210
        '
        'pan_SLAVE
        '
        Me.pan_SLAVE.BackColor = System.Drawing.SystemColors.Control
        Me.pan_SLAVE.Controls.Add(Me.btn_RISTAMPA)
        Me.pan_SLAVE.Controls.Add(Me.lbl_QTY_ITEMS)
        Me.pan_SLAVE.Controls.Add(Me.btn_HELP)
        Me.pan_SLAVE.Controls.Add(Me.Label4)
        Me.pan_SLAVE.Controls.Add(Me.Label2)
        Me.pan_SLAVE.Controls.Add(Me.Label13)
        Me.pan_SLAVE.Controls.Add(Me.lbl_QTY_RIGA)
        Me.pan_SLAVE.Controls.Add(Me.lbl_QTY_READ)
        Me.pan_SLAVE.Controls.Add(Me.pan_DATABASE)
        Me.pan_SLAVE.Controls.Add(Me.pan_TAPE)
        Me.pan_SLAVE.Controls.Add(Me.lbl_DATABASE)
        Me.pan_SLAVE.Controls.Add(Me.lbl_TAPE)
        Me.pan_SLAVE.Controls.Add(Me.lbl_ANAG)
        Me.pan_SLAVE.Controls.Add(Me.btn_READ)
        Me.pan_SLAVE.Controls.Add(Me.lbl_MSG_DB)
        Me.pan_SLAVE.Controls.Add(Me.tbx_ARRAY_BC)
        Me.pan_SLAVE.Controls.Add(Me.cbx_MARCA)
        Me.pan_SLAVE.Controls.Add(Me.pan_ANAG)
        Me.pan_SLAVE.Location = New System.Drawing.Point(4, 37)
        Me.pan_SLAVE.Name = "pan_SLAVE"
        Me.pan_SLAVE.Padding = New System.Windows.Forms.Padding(3)
        Me.pan_SLAVE.Size = New System.Drawing.Size(1304, 599)
        Me.pan_SLAVE.TabIndex = 1
        Me.pan_SLAVE.Text = "SLAVE PAGE"
        '
        'btn_RISTAMPA
        '
        Me.btn_RISTAMPA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_RISTAMPA.Enabled = False
        Me.btn_RISTAMPA.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RISTAMPA.Location = New System.Drawing.Point(472, 489)
        Me.btn_RISTAMPA.Name = "btn_RISTAMPA"
        Me.btn_RISTAMPA.Size = New System.Drawing.Size(280, 40)
        Me.btn_RISTAMPA.TabIndex = 297
        Me.btn_RISTAMPA.Text = "RISTAMPA"
        Me.btn_RISTAMPA.UseVisualStyleBackColor = False
        '
        'lbl_QTY_ITEMS
        '
        Me.lbl_QTY_ITEMS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_QTY_ITEMS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_QTY_ITEMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_QTY_ITEMS.Location = New System.Drawing.Point(1016, 408)
        Me.lbl_QTY_ITEMS.Name = "lbl_QTY_ITEMS"
        Me.lbl_QTY_ITEMS.Size = New System.Drawing.Size(112, 24)
        Me.lbl_QTY_ITEMS.TabIndex = 331
        Me.lbl_QTY_ITEMS.Text = "0"
        Me.lbl_QTY_ITEMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_HELP
        '
        Me.btn_HELP.BackColor = System.Drawing.Color.DarkCyan
        Me.btn_HELP.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_HELP.Location = New System.Drawing.Point(1136, 376)
        Me.btn_HELP.Name = "btn_HELP"
        Me.btn_HELP.Size = New System.Drawing.Size(160, 56)
        Me.btn_HELP.TabIndex = 295
        Me.btn_HELP.Text = "HELP"
        Me.btn_HELP.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(1016, 376)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 24)
        Me.Label4.TabIndex = 330
        Me.Label4.Text = "QTY ITEMS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(896, 376)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 24)
        Me.Label2.TabIndex = 329
        Me.Label2.Text = "QTY READ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Window
        Me.Label13.Location = New System.Drawing.Point(776, 376)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 24)
        Me.Label13.TabIndex = 328
        Me.Label13.Text = "QTY BOLLA"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_QTY_RIGA
        '
        Me.lbl_QTY_RIGA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_QTY_RIGA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_QTY_RIGA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_QTY_RIGA.Location = New System.Drawing.Point(776, 408)
        Me.lbl_QTY_RIGA.Name = "lbl_QTY_RIGA"
        Me.lbl_QTY_RIGA.Size = New System.Drawing.Size(112, 24)
        Me.lbl_QTY_RIGA.TabIndex = 294
        Me.lbl_QTY_RIGA.Text = "0"
        Me.lbl_QTY_RIGA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_QTY_READ
        '
        Me.lbl_QTY_READ.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_QTY_READ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_QTY_READ.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_QTY_READ.Location = New System.Drawing.Point(896, 408)
        Me.lbl_QTY_READ.Name = "lbl_QTY_READ"
        Me.lbl_QTY_READ.Size = New System.Drawing.Size(112, 24)
        Me.lbl_QTY_READ.TabIndex = 292
        Me.lbl_QTY_READ.Text = "0"
        Me.lbl_QTY_READ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pan_DATABASE
        '
        Me.pan_DATABASE.BackColor = System.Drawing.SystemColors.Window
        Me.pan_DATABASE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pan_DATABASE.Controls.Add(Me.pan_DATABASE_1)
        Me.pan_DATABASE.Location = New System.Drawing.Point(40, 376)
        Me.pan_DATABASE.Name = "pan_DATABASE"
        Me.pan_DATABASE.Size = New System.Drawing.Size(728, 168)
        Me.pan_DATABASE.TabIndex = 290
        '
        'pan_DATABASE_1
        '
        Me.pan_DATABASE_1.BackColor = System.Drawing.SystemColors.Control
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_MARCA_DB_0)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_PN_DB_0)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_LASI_CODE_DB_0)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_LASI_CODE_DB)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_PN_DB)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_CONV_DB_0)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_CONV_DEL_DB)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_MARCA_DB)
        Me.pan_DATABASE_1.Controls.Add(Me.lbl_CONV_DATA_DB)
        Me.pan_DATABASE_1.Location = New System.Drawing.Point(8, 8)
        Me.pan_DATABASE_1.Name = "pan_DATABASE_1"
        Me.pan_DATABASE_1.Size = New System.Drawing.Size(712, 152)
        Me.pan_DATABASE_1.TabIndex = 286
        '
        'lbl_MARCA_DB_0
        '
        Me.lbl_MARCA_DB_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_MARCA_DB_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MARCA_DB_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MARCA_DB_0.Location = New System.Drawing.Point(264, 8)
        Me.lbl_MARCA_DB_0.Name = "lbl_MARCA_DB_0"
        Me.lbl_MARCA_DB_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_MARCA_DB_0.TabIndex = 296
        Me.lbl_MARCA_DB_0.Text = "MARCA"
        Me.lbl_MARCA_DB_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_PN_DB_0
        '
        Me.lbl_PN_DB_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_PN_DB_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_PN_DB_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PN_DB_0.Location = New System.Drawing.Point(8, 56)
        Me.lbl_PN_DB_0.Name = "lbl_PN_DB_0"
        Me.lbl_PN_DB_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_PN_DB_0.TabIndex = 290
        Me.lbl_PN_DB_0.Text = "P/N"
        Me.lbl_PN_DB_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_LASI_CODE_DB_0
        '
        Me.lbl_LASI_CODE_DB_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_LASI_CODE_DB_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LASI_CODE_DB_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LASI_CODE_DB_0.Location = New System.Drawing.Point(8, 8)
        Me.lbl_LASI_CODE_DB_0.Name = "lbl_LASI_CODE_DB_0"
        Me.lbl_LASI_CODE_DB_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_LASI_CODE_DB_0.TabIndex = 289
        Me.lbl_LASI_CODE_DB_0.Text = "CODE"
        Me.lbl_LASI_CODE_DB_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_LASI_CODE_DB
        '
        Me.lbl_LASI_CODE_DB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_LASI_CODE_DB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LASI_CODE_DB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LASI_CODE_DB.Location = New System.Drawing.Point(104, 8)
        Me.lbl_LASI_CODE_DB.Name = "lbl_LASI_CODE_DB"
        Me.lbl_LASI_CODE_DB.Size = New System.Drawing.Size(152, 40)
        Me.lbl_LASI_CODE_DB.TabIndex = 287
        Me.lbl_LASI_CODE_DB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_PN_DB
        '
        Me.lbl_PN_DB.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lbl_PN_DB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_PN_DB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PN_DB.Location = New System.Drawing.Point(104, 56)
        Me.lbl_PN_DB.Name = "lbl_PN_DB"
        Me.lbl_PN_DB.Size = New System.Drawing.Size(600, 40)
        Me.lbl_PN_DB.TabIndex = 281
        Me.lbl_PN_DB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_CONV_DB_0
        '
        Me.lbl_CONV_DB_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_CONV_DB_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CONV_DB_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CONV_DB_0.Location = New System.Drawing.Point(8, 104)
        Me.lbl_CONV_DB_0.Name = "lbl_CONV_DB_0"
        Me.lbl_CONV_DB_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_CONV_DB_0.TabIndex = 284
        Me.lbl_CONV_DB_0.Text = "CONV."
        Me.lbl_CONV_DB_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_CONV_DEL_DB
        '
        Me.lbl_CONV_DEL_DB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_CONV_DEL_DB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CONV_DEL_DB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CONV_DEL_DB.Location = New System.Drawing.Point(104, 104)
        Me.lbl_CONV_DEL_DB.Name = "lbl_CONV_DEL_DB"
        Me.lbl_CONV_DEL_DB.Size = New System.Drawing.Size(152, 40)
        Me.lbl_CONV_DEL_DB.TabIndex = 286
        Me.lbl_CONV_DEL_DB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_MARCA_DB
        '
        Me.lbl_MARCA_DB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_MARCA_DB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MARCA_DB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MARCA_DB.Location = New System.Drawing.Point(360, 8)
        Me.lbl_MARCA_DB.Name = "lbl_MARCA_DB"
        Me.lbl_MARCA_DB.Size = New System.Drawing.Size(344, 40)
        Me.lbl_MARCA_DB.TabIndex = 277
        Me.lbl_MARCA_DB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_CONV_DATA_DB
        '
        Me.lbl_CONV_DATA_DB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_CONV_DATA_DB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CONV_DATA_DB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CONV_DATA_DB.Location = New System.Drawing.Point(264, 104)
        Me.lbl_CONV_DATA_DB.Name = "lbl_CONV_DATA_DB"
        Me.lbl_CONV_DATA_DB.Size = New System.Drawing.Size(152, 40)
        Me.lbl_CONV_DATA_DB.TabIndex = 285
        Me.lbl_CONV_DATA_DB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pan_TAPE
        '
        Me.pan_TAPE.BackColor = System.Drawing.SystemColors.Window
        Me.pan_TAPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pan_TAPE.Controls.Add(Me.pan_TAPE_1)
        Me.pan_TAPE.Location = New System.Drawing.Point(40, 192)
        Me.pan_TAPE.Name = "pan_TAPE"
        Me.pan_TAPE.Size = New System.Drawing.Size(728, 168)
        Me.pan_TAPE.TabIndex = 289
        '
        'pan_TAPE_1
        '
        Me.pan_TAPE_1.BackColor = System.Drawing.SystemColors.Control
        Me.pan_TAPE_1.Controls.Add(Me.lbl_PN_TAPE_0)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_LOT_TAPE_0)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_QTY_TAPE_0)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_DATA_TAPE_0)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_QTY_TAPE)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_PN_TAPE)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_BIN_TAPE_0)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_LOT_TAPE)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_DATA_TAPE)
        Me.pan_TAPE_1.Controls.Add(Me.lbl_BIN_TAPE)
        Me.pan_TAPE_1.Location = New System.Drawing.Point(8, 8)
        Me.pan_TAPE_1.Name = "pan_TAPE_1"
        Me.pan_TAPE_1.Size = New System.Drawing.Size(712, 152)
        Me.pan_TAPE_1.TabIndex = 286
        '
        'lbl_PN_TAPE_0
        '
        Me.lbl_PN_TAPE_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_PN_TAPE_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_PN_TAPE_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PN_TAPE_0.Location = New System.Drawing.Point(8, 8)
        Me.lbl_PN_TAPE_0.Name = "lbl_PN_TAPE_0"
        Me.lbl_PN_TAPE_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_PN_TAPE_0.TabIndex = 242
        Me.lbl_PN_TAPE_0.Text = "P/N"
        Me.lbl_PN_TAPE_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_LOT_TAPE_0
        '
        Me.lbl_LOT_TAPE_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_LOT_TAPE_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LOT_TAPE_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LOT_TAPE_0.Location = New System.Drawing.Point(8, 56)
        Me.lbl_LOT_TAPE_0.Name = "lbl_LOT_TAPE_0"
        Me.lbl_LOT_TAPE_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_LOT_TAPE_0.TabIndex = 244
        Me.lbl_LOT_TAPE_0.Text = "LOTTO"
        Me.lbl_LOT_TAPE_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_QTY_TAPE_0
        '
        Me.lbl_QTY_TAPE_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_QTY_TAPE_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_QTY_TAPE_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_QTY_TAPE_0.Location = New System.Drawing.Point(264, 104)
        Me.lbl_QTY_TAPE_0.Name = "lbl_QTY_TAPE_0"
        Me.lbl_QTY_TAPE_0.Size = New System.Drawing.Size(64, 40)
        Me.lbl_QTY_TAPE_0.TabIndex = 252
        Me.lbl_QTY_TAPE_0.Text = "QTY"
        Me.lbl_QTY_TAPE_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_DATA_TAPE_0
        '
        Me.lbl_DATA_TAPE_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_DATA_TAPE_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DATA_TAPE_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DATA_TAPE_0.Location = New System.Drawing.Point(8, 104)
        Me.lbl_DATA_TAPE_0.Name = "lbl_DATA_TAPE_0"
        Me.lbl_DATA_TAPE_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_DATA_TAPE_0.TabIndex = 253
        Me.lbl_DATA_TAPE_0.Text = "DATA"
        Me.lbl_DATA_TAPE_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_QTY_TAPE
        '
        Me.lbl_QTY_TAPE.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_QTY_TAPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_QTY_TAPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_QTY_TAPE.Location = New System.Drawing.Point(336, 104)
        Me.lbl_QTY_TAPE.Name = "lbl_QTY_TAPE"
        Me.lbl_QTY_TAPE.Size = New System.Drawing.Size(136, 40)
        Me.lbl_QTY_TAPE.TabIndex = 248
        Me.lbl_QTY_TAPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_PN_TAPE
        '
        Me.lbl_PN_TAPE.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lbl_PN_TAPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_PN_TAPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PN_TAPE.Location = New System.Drawing.Point(104, 8)
        Me.lbl_PN_TAPE.Name = "lbl_PN_TAPE"
        Me.lbl_PN_TAPE.Size = New System.Drawing.Size(600, 40)
        Me.lbl_PN_TAPE.TabIndex = 241
        Me.lbl_PN_TAPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_BIN_TAPE_0
        '
        Me.lbl_BIN_TAPE_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_BIN_TAPE_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_BIN_TAPE_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BIN_TAPE_0.Location = New System.Drawing.Point(480, 104)
        Me.lbl_BIN_TAPE_0.Name = "lbl_BIN_TAPE_0"
        Me.lbl_BIN_TAPE_0.Size = New System.Drawing.Size(64, 40)
        Me.lbl_BIN_TAPE_0.TabIndex = 275
        Me.lbl_BIN_TAPE_0.Text = "BIN"
        Me.lbl_BIN_TAPE_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_LOT_TAPE
        '
        Me.lbl_LOT_TAPE.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_LOT_TAPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LOT_TAPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LOT_TAPE.Location = New System.Drawing.Point(104, 56)
        Me.lbl_LOT_TAPE.Name = "lbl_LOT_TAPE"
        Me.lbl_LOT_TAPE.Size = New System.Drawing.Size(600, 40)
        Me.lbl_LOT_TAPE.TabIndex = 243
        Me.lbl_LOT_TAPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_DATA_TAPE
        '
        Me.lbl_DATA_TAPE.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_DATA_TAPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DATA_TAPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DATA_TAPE.Location = New System.Drawing.Point(104, 104)
        Me.lbl_DATA_TAPE.Name = "lbl_DATA_TAPE"
        Me.lbl_DATA_TAPE.Size = New System.Drawing.Size(152, 40)
        Me.lbl_DATA_TAPE.TabIndex = 250
        Me.lbl_DATA_TAPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_BIN_TAPE
        '
        Me.lbl_BIN_TAPE.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_BIN_TAPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_BIN_TAPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BIN_TAPE.Location = New System.Drawing.Point(552, 104)
        Me.lbl_BIN_TAPE.Name = "lbl_BIN_TAPE"
        Me.lbl_BIN_TAPE.Size = New System.Drawing.Size(152, 40)
        Me.lbl_BIN_TAPE.TabIndex = 276
        Me.lbl_BIN_TAPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_DATABASE
        '
        Me.lbl_DATABASE.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_DATABASE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DATABASE.Location = New System.Drawing.Point(8, 376)
        Me.lbl_DATABASE.Name = "lbl_DATABASE"
        Me.lbl_DATABASE.Size = New System.Drawing.Size(24, 168)
        Me.lbl_DATABASE.TabIndex = 288
        Me.lbl_DATABASE.Text = "D" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "T" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "B" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "S" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "E"
        Me.lbl_DATABASE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TAPE
        '
        Me.lbl_TAPE.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_TAPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TAPE.Location = New System.Drawing.Point(8, 192)
        Me.lbl_TAPE.Name = "lbl_TAPE"
        Me.lbl_TAPE.Size = New System.Drawing.Size(24, 168)
        Me.lbl_TAPE.TabIndex = 287
        Me.lbl_TAPE.Text = "T" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "P" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "E"
        Me.lbl_TAPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ANAG
        '
        Me.lbl_ANAG.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_ANAG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ANAG.Location = New System.Drawing.Point(8, 8)
        Me.lbl_ANAG.Name = "lbl_ANAG"
        Me.lbl_ANAG.Size = New System.Drawing.Size(24, 168)
        Me.lbl_ANAG.TabIndex = 286
        Me.lbl_ANAG.Text = "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "N" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "G" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "R" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "F" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "I" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A"
        Me.lbl_ANAG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_READ
        '
        Me.btn_READ.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_READ.Enabled = False
        Me.btn_READ.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_READ.Location = New System.Drawing.Point(40, 552)
        Me.btn_READ.Name = "btn_READ"
        Me.btn_READ.Size = New System.Drawing.Size(728, 40)
        Me.btn_READ.TabIndex = 284
        Me.btn_READ.Text = "NUOVA LETTURA (BARSPACE)"
        Me.btn_READ.UseVisualStyleBackColor = False
        '
        'lbl_MSG_DB
        '
        Me.lbl_MSG_DB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_MSG_DB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MSG_DB.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MSG_DB.Location = New System.Drawing.Point(776, 440)
        Me.lbl_MSG_DB.Name = "lbl_MSG_DB"
        Me.lbl_MSG_DB.Size = New System.Drawing.Size(520, 152)
        Me.lbl_MSG_DB.TabIndex = 278
        Me.lbl_MSG_DB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbx_ARRAY_BC
        '
        Me.tbx_ARRAY_BC.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tbx_ARRAY_BC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ARRAY_BC.Location = New System.Drawing.Point(776, 48)
        Me.tbx_ARRAY_BC.Multiline = True
        Me.tbx_ARRAY_BC.Name = "tbx_ARRAY_BC"
        Me.tbx_ARRAY_BC.ReadOnly = True
        Me.tbx_ARRAY_BC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbx_ARRAY_BC.Size = New System.Drawing.Size(520, 312)
        Me.tbx_ARRAY_BC.TabIndex = 275
        '
        'cbx_MARCA
        '
        Me.cbx_MARCA.CausesValidation = False
        Me.cbx_MARCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_MARCA.Enabled = False
        Me.cbx_MARCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_MARCA.Location = New System.Drawing.Point(776, 8)
        Me.cbx_MARCA.MaxDropDownItems = 15
        Me.cbx_MARCA.Name = "cbx_MARCA"
        Me.cbx_MARCA.Size = New System.Drawing.Size(520, 33)
        Me.cbx_MARCA.TabIndex = 274
        '
        'pan_ANAG
        '
        Me.pan_ANAG.BackColor = System.Drawing.SystemColors.Window
        Me.pan_ANAG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pan_ANAG.Controls.Add(Me.pan_ANAG_1)
        Me.pan_ANAG.Location = New System.Drawing.Point(40, 8)
        Me.pan_ANAG.Name = "pan_ANAG"
        Me.pan_ANAG.Size = New System.Drawing.Size(728, 168)
        Me.pan_ANAG.TabIndex = 285
        '
        'pan_ANAG_1
        '
        Me.pan_ANAG_1.BackColor = System.Drawing.SystemColors.Control
        Me.pan_ANAG_1.Controls.Add(Me.lbl_MARCA_ANA)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_MARCA_ANA_0)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_DES_ANA_0)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_LASI_CODE_ANA)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_DES_SUP_ANA)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_DES_SUP_ANA_0)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_DES_ANA)
        Me.pan_ANAG_1.Controls.Add(Me.lbl_LASI_CODE_ANA_0)
        Me.pan_ANAG_1.Location = New System.Drawing.Point(8, 8)
        Me.pan_ANAG_1.Name = "pan_ANAG_1"
        Me.pan_ANAG_1.Size = New System.Drawing.Size(712, 152)
        Me.pan_ANAG_1.TabIndex = 286
        '
        'lbl_MARCA_ANA
        '
        Me.lbl_MARCA_ANA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_MARCA_ANA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MARCA_ANA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MARCA_ANA.Location = New System.Drawing.Point(360, 8)
        Me.lbl_MARCA_ANA.Name = "lbl_MARCA_ANA"
        Me.lbl_MARCA_ANA.Size = New System.Drawing.Size(344, 40)
        Me.lbl_MARCA_ANA.TabIndex = 269
        Me.lbl_MARCA_ANA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_MARCA_ANA_0
        '
        Me.lbl_MARCA_ANA_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_MARCA_ANA_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MARCA_ANA_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MARCA_ANA_0.Location = New System.Drawing.Point(264, 8)
        Me.lbl_MARCA_ANA_0.Name = "lbl_MARCA_ANA_0"
        Me.lbl_MARCA_ANA_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_MARCA_ANA_0.TabIndex = 270
        Me.lbl_MARCA_ANA_0.Text = "MARCA"
        Me.lbl_MARCA_ANA_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_DES_ANA_0
        '
        Me.lbl_DES_ANA_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_DES_ANA_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DES_ANA_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DES_ANA_0.Location = New System.Drawing.Point(8, 56)
        Me.lbl_DES_ANA_0.Name = "lbl_DES_ANA_0"
        Me.lbl_DES_ANA_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_DES_ANA_0.TabIndex = 268
        Me.lbl_DES_ANA_0.Text = "DESC."
        Me.lbl_DES_ANA_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_LASI_CODE_ANA
        '
        Me.lbl_LASI_CODE_ANA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_LASI_CODE_ANA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LASI_CODE_ANA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LASI_CODE_ANA.Location = New System.Drawing.Point(104, 8)
        Me.lbl_LASI_CODE_ANA.Name = "lbl_LASI_CODE_ANA"
        Me.lbl_LASI_CODE_ANA.Size = New System.Drawing.Size(152, 40)
        Me.lbl_LASI_CODE_ANA.TabIndex = 246
        Me.lbl_LASI_CODE_ANA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_DES_SUP_ANA
        '
        Me.lbl_DES_SUP_ANA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_DES_SUP_ANA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DES_SUP_ANA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DES_SUP_ANA.Location = New System.Drawing.Point(104, 104)
        Me.lbl_DES_SUP_ANA.Name = "lbl_DES_SUP_ANA"
        Me.lbl_DES_SUP_ANA.Size = New System.Drawing.Size(600, 40)
        Me.lbl_DES_SUP_ANA.TabIndex = 247
        Me.lbl_DES_SUP_ANA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_DES_SUP_ANA_0
        '
        Me.lbl_DES_SUP_ANA_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_DES_SUP_ANA_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DES_SUP_ANA_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DES_SUP_ANA_0.Location = New System.Drawing.Point(8, 104)
        Me.lbl_DES_SUP_ANA_0.Name = "lbl_DES_SUP_ANA_0"
        Me.lbl_DES_SUP_ANA_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_DES_SUP_ANA_0.TabIndex = 265
        Me.lbl_DES_SUP_ANA_0.Text = "SUPP."
        Me.lbl_DES_SUP_ANA_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_DES_ANA
        '
        Me.lbl_DES_ANA.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_DES_ANA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DES_ANA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DES_ANA.Location = New System.Drawing.Point(104, 56)
        Me.lbl_DES_ANA.Name = "lbl_DES_ANA"
        Me.lbl_DES_ANA.Size = New System.Drawing.Size(600, 40)
        Me.lbl_DES_ANA.TabIndex = 266
        Me.lbl_DES_ANA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_LASI_CODE_ANA_0
        '
        Me.lbl_LASI_CODE_ANA_0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_LASI_CODE_ANA_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LASI_CODE_ANA_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LASI_CODE_ANA_0.Location = New System.Drawing.Point(8, 8)
        Me.lbl_LASI_CODE_ANA_0.Name = "lbl_LASI_CODE_ANA_0"
        Me.lbl_LASI_CODE_ANA_0.Size = New System.Drawing.Size(88, 40)
        Me.lbl_LASI_CODE_ANA_0.TabIndex = 267
        Me.lbl_LASI_CODE_ANA_0.Text = "CODE"
        Me.lbl_LASI_CODE_ANA_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx_BCR_ON
        '
        Me.pbx_BCR_ON.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pbx_BCR_ON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbx_BCR_ON.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbx_BCR_ON.Enabled = False
        Me.pbx_BCR_ON.Image = Global.FactoryControlTrac_2.My.Resources.Resources.Icon_DataMatrix
        Me.pbx_BCR_ON.Location = New System.Drawing.Point(1200, 8)
        Me.pbx_BCR_ON.Name = "pbx_BCR_ON"
        Me.pbx_BCR_ON.Size = New System.Drawing.Size(56, 56)
        Me.pbx_BCR_ON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx_BCR_ON.TabIndex = 291
        Me.pbx_BCR_ON.TabStop = False
        '
        'pbx_LOGO
        '
        Me.pbx_LOGO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pbx_LOGO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbx_LOGO.Image = Global.FactoryControlTrac_2.My.Resources.Resources.Logo3D
        Me.pbx_LOGO.Location = New System.Drawing.Point(8, 8)
        Me.pbx_LOGO.Name = "pbx_LOGO"
        Me.pbx_LOGO.Size = New System.Drawing.Size(56, 56)
        Me.pbx_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx_LOGO.TabIndex = 242
        Me.pbx_LOGO.TabStop = False
        '
        'pbx_LOGO_DMR
        '
        Me.pbx_LOGO_DMR.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pbx_LOGO_DMR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbx_LOGO_DMR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbx_LOGO_DMR.Enabled = False
        Me.pbx_LOGO_DMR.Image = Global.FactoryControlTrac_2.My.Resources.Resources.Icon_Barcode_Trasp
        Me.pbx_LOGO_DMR.Location = New System.Drawing.Point(1264, 8)
        Me.pbx_LOGO_DMR.Name = "pbx_LOGO_DMR"
        Me.pbx_LOGO_DMR.Size = New System.Drawing.Size(56, 56)
        Me.pbx_LOGO_DMR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx_LOGO_DMR.TabIndex = 241
        Me.pbx_LOGO_DMR.TabStop = False
        '
        'tim_CONFERMA
        '
        Me.tim_CONFERMA.Interval = 5000
        '
        'form_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1326, 716)
        Me.Controls.Add(Me.pbx_BCR_ON)
        Me.Controls.Add(Me.tab_CONTROL)
        Me.Controls.Add(Me.pbx_LOGO)
        Me.Controls.Add(Me.pbx_LOGO_DMR)
        Me.Controls.Add(Me.lbl_FC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "form_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FC TRACEABILITY_2"
        Me.tab_CONTROL.ResumeLayout(False)
        Me.pan_MAIN.ResumeLayout(False)
        Me.pan_SLAVE.ResumeLayout(False)
        Me.pan_SLAVE.PerformLayout()
        Me.pan_DATABASE.ResumeLayout(False)
        Me.pan_DATABASE_1.ResumeLayout(False)
        Me.pan_TAPE.ResumeLayout(False)
        Me.pan_TAPE_1.ResumeLayout(False)
        Me.pan_ANAG.ResumeLayout(False)
        Me.pan_ANAG_1.ResumeLayout(False)
        CType(Me.pbx_BCR_ON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_LOGO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_LOGO_DMR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbx_LOGO_DMR As PictureBox
    Friend WithEvents lbl_FC As Label
    Friend WithEvents pbx_LOGO As PictureBox
    Friend WithEvents com_DMR_1 As IO.Ports.SerialPort
    Friend WithEvents bgw_LOOP_SER_1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents tab_CONTROL As TabControl
    Friend WithEvents pan_MAIN As TabPage
    Friend WithEvents pan_SLAVE As TabPage
    Friend WithEvents lvw_BOLLA_ITEM As ListView
    Friend WithEvents lvw_BOLLE As ListView
    Friend WithEvents btn_BOLLE_LOAD As Button
    Friend WithEvents cbx_MARCA As ComboBox
    Friend WithEvents tbx_ARRAY_BC As TextBox
    Friend WithEvents lbl_BOLLA_ITEM As Label
    Friend WithEvents lbl_LASI_CODE_ANA As Label
    Friend WithEvents lbl_DES_SUP_ANA As Label
    Friend WithEvents lbl_DES_SUP_ANA_0 As Label
    Friend WithEvents lbl_DES_ANA As Label
    Friend WithEvents lbl_LASI_CODE_ANA_0 As Label
    Friend WithEvents lbl_MARCA_DB As Label
    Friend WithEvents lbl_PN_TAPE_0 As Label
    Friend WithEvents lbl_LOT_TAPE_0 As Label
    Friend WithEvents lbl_DATA_TAPE_0 As Label
    Friend WithEvents lbl_PN_TAPE As Label
    Friend WithEvents lbl_LOT_TAPE As Label
    Friend WithEvents lbl_BIN_TAPE As Label
    Friend WithEvents lbl_DATA_TAPE As Label
    Friend WithEvents lbl_BIN_TAPE_0 As Label
    Friend WithEvents lbl_QTY_TAPE As Label
    Friend WithEvents lbl_QTY_TAPE_0 As Label
    Friend WithEvents lbl_MSG_DB As Label
    Friend WithEvents lbl_CONV_DEL_DB As Label
    Friend WithEvents lbl_CONV_DATA_DB As Label
    Friend WithEvents lbl_CONV_DB_0 As Label
    Friend WithEvents lbl_PN_DB As Label
    Friend WithEvents lbl_LASI_CODE_DB As Label
    Friend WithEvents lbl_LASI_CODE_DB_0 As Label
    Friend WithEvents lbl_PN_DB_0 As Label
    Friend WithEvents lbl_DES_ANA_0 As Label
    Friend WithEvents pbx_BCR_ON As PictureBox
    Friend WithEvents btn_READ As Button
    Friend WithEvents lbl_DATABASE As Label
    Friend WithEvents lbl_TAPE As Label
    Friend WithEvents lbl_ANAG As Label
    Friend WithEvents pan_ANAG As Panel
    Friend WithEvents pan_ANAG_1 As Panel
    Friend WithEvents pan_TAPE As Panel
    Friend WithEvents pan_TAPE_1 As Panel
    Friend WithEvents pan_DATABASE As Panel
    Friend WithEvents pan_DATABASE_1 As Panel
    Friend WithEvents lbl_IP_ADD As Label
    Friend WithEvents lbl_COM_1 As Label
    Friend WithEvents tim_CONFERMA As Timer
    Friend WithEvents ORD_TIPO As ColumnHeader
    Friend WithEvents ORD_NUM As ColumnHeader
    Friend WithEvents ORD_RIGA As ColumnHeader
    Friend WithEvents RG_COD As ColumnHeader
    Friend WithEvents RG_DES As ColumnHeader
    Friend WithEvents RG_QTY As ColumnHeader
    Friend WithEvents REG_DATA As ColumnHeader
    Friend WithEvents DOC_NUM As ColumnHeader
    Friend WithEvents DOC_DATA As ColumnHeader
    Friend WithEvents FORN_COD As ColumnHeader
    Friend WithEvents FORN_DES As ColumnHeader
    Friend WithEvents btn_HELP As Button
    Friend WithEvents lbl_MARCA_ANA As Label
    Friend WithEvents lbl_MARCA_ANA_0 As Label
    Friend WithEvents lbl_MARCA_DB_0 As Label
    Friend WithEvents lbl_QTY_RIGA As Label
    Friend WithEvents lbl_QTY_READ As Label
    Friend WithEvents lbl_QTY_ITEMS As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btn_RISTAMPA As Button
End Class
