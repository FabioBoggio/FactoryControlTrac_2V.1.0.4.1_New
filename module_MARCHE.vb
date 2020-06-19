
Module module_MARCHE
    Function fun_MARCHE_SEL(var_SER_RX)
        With form_MAIN
            Try
                Select Case .cbx_MARCA.Text
                    Case "GENERICO"
                        Select Case Strings.Left(var_SER_RX, 1).ToUpper 'CONTROLLA PRIMO CARATTERE
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)

                            Case "L"                                    'SPECIFICO AVX
                                If Len(var_SER_RX) < 10 Then
                                    .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 2)
                                End If

                            Case "D"
                                .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 2)
                        End Select

                        Select Case Strings.Left(var_SER_RX, 2).ToUpper 'CONTROLLA PRIMI 2 CARATTERI
                            Case "1P", "6P"
                                If Len(var_SER_RX) < 40 Then            'IF LEN PER FILTRARE DM "PANJIT" CHE INIZIA CON "1P"
                                    .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                                End If
                            Case "1T"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                            Case "1D", "9D"
                                .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 3)
                        End Select

                        Select Case Strings.Left(var_SER_RX, 3).ToUpper 'CONTROLLA PRIMI 3 CARATTERI
                            Case "10D", "11D", "16D"
                                .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 4)
                            Case "3N1"
                                var_STRING = Split(var_SER_RX, " ")
                                .lbl_PN_TAPE.Text = Mid(var_STRING(0), 4)
                                .lbl_QTY_TAPE.Text = var_STRING(1)
                            Case "3N2"
                                var_STRING = Split(var_SER_RX, " ")
                                .lbl_LOT_TAPE.Text = var_STRING(1)
                                .lbl_DATA_TAPE.Text = var_STRING(2)
                        End Select
                        Return True

                    Case "ALLEGRO"
                        If Len(var_SER_RX) > 100 And Len(var_SER_RX) < 170 Then
                            var_STRING = Split(var_SER_RX, "@")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 2)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(5), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(7), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(8), 4)
                        End If

                        If Len(var_SER_RX) >= 170 Then
                            var_STRING = Split(var_SER_RX, "@")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 2)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(13), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(15), 3)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(7), 3)
                        End If
                        Return True

                    Case "ALPHA & OMEGA"
                        If Len(var_SER_RX) > 50 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(3), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(6), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(4), 3)
                        End If
                        Return True

                    Case "BI", "BOURNS"
                        If Len(var_SER_RX) > 25 Then
                            var_STRING = Split(var_SER_RX, "+")

                            .lbl_PN_TAPE.Text = Mid(var_STRING(0), 2)
                            .lbl_QTY_TAPE.Text = CInt(Mid(var_STRING(1), 2))
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(3), 3)
                        End If
                        Return True

                    Case "CHANG"
                        If Len(var_SER_RX) > 10 Then
                            var_STRING = Split(var_SER_RX, "*")
                            .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                            .lbl_PN_TAPE.Text = var_STRING(0)
                            .lbl_QTY_TAPE.Text = var_STRING(2)
                            .lbl_LOT_TAPE.Text = var_STRING(1)
                        End If
                        Return True

                    Case "C&K"
                        .lbl_QTY_TAPE.Text = 0
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Select Case Len(var_SER_RX)
                            Case > 8        'PART NUMBER
                                .lbl_PN_TAPE.Text = var_SER_RX
                            Case < 8        'LOTTO
                                .lbl_LOT_TAPE.Text = var_SER_RX
                        End Select
                        Return True

                    Case "DELTA"
                        If var_SER_RX.Length > 30 Then
                            var_STRING = Split(var_SER_RX, ";")

                            .lbl_PN_TAPE.Text = var_STRING(1)
                            .lbl_LOT_TAPE.Text = var_STRING(0)
                            .lbl_QTY_TAPE.Text = CInt(var_STRING(3))
                            .lbl_DATA_TAPE.Text = var_STRING(4)
                        End If
                        Return True

                    Case "E&E"
                        Select Case Strings.Left(var_SER_RX, 1).ToUpper 'CONTROLLA PRIMO CARATTERE
                            Case "D"
                                .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "M"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "L"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 2)
                        End Select
                        Return True

                    Case "EPCOS"
                        If Strings.Left(var_SER_RX, 1) = "T" And Len(var_SER_RX) > 15 Then
                            var_STRING = Split(var_SER_RX, "Q")
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(0), 2)
                            .lbl_QTY_TAPE.Text = var_STRING(1)
                        End If

                        Select Case Strings.Left(var_SER_RX, 2)
                            Case "1P"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)

                            Case "9K"
                                var_STRING = Split(var_SER_RX, "D")
                                .lbl_DATA_TAPE.Text = var_STRING(1)
                        End Select
                        Return True

                    Case "EVERLIGHT"
                        If Len(var_SER_RX) > 100 Then
                            var_STRING = Split(var_SER_RX, ";")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(3), 6)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(4), 5)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(6), 5)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(8), 7)
                        End If
                        Return True

                    Case "DIOTEC"
                        var_STRING = Split(var_SER_RX, ":")
                        Select Case var_STRING.Length
                            Case 2
                                .lbl_DATA_TAPE.Text = var_STRING(0)
                                .lbl_LOT_TAPE.Text = var_STRING(1)
                            Case 3
                                .lbl_PN_TAPE.Text = var_STRING(0)
                                .lbl_QTY_TAPE.Text = var_STRING(1)
                        End Select
                        Return True

                    Case "DIODES"
                        Select Case Len(var_SER_RX)
                            Case < 6       'QUANTITA'
                                .lbl_QTY_TAPE.Text = CInt(var_SER_RX)
                                'Case 6 To 14    'PART NUMBER
                                '    .lbl_PN.Text = var_SER_RX
                                'Case > 14       'DATA/LOTTO
                                '    .lbl_LOT.Text = Strings.Mid(var_SER_RX, 6)
                                '    .lbl_DATA.Text = Strings.Left(var_SER_RX, 4)
                            Case >= 6
                                If Mid(var_SER_RX, 5, 1) = "-" Then
                                    .lbl_LOT_TAPE.Text = Strings.Mid(var_SER_RX, 6)
                                    .lbl_DATA_TAPE.Text = Strings.Left(var_SER_RX, 4)
                                Else
                                    .lbl_PN_TAPE.Text = var_SER_RX
                                End If

                        End Select
                        Return True

                    Case "DOMINANT"
                        If Len(var_SER_RX) > 30 Then
                            var_STRING = Split(var_SER_RX, "@")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(1), 2)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(0), 2)
                            .lbl_QTY_TAPE.Text = CInt(Mid(var_STRING(4), 2))
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(5), 2)
                            .lbl_BIN_TAPE.Text = Mid(var_STRING(3), 2)
                        End If
                        Return True

                    Case "IMS"
                        If Len(var_SER_RX) > 60 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            .lbl_PN_TAPE.Text = Mid(var_STRING(1), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(5), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(4), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(3), 3)
                        End If
                        Return True

                    Case "ISSI"
                        If Len(var_SER_RX) > 60 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(4), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(5), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(6), 3)
                        End If
                        Return True

                    Case "ITT"
                        Select Case Strings.Left(var_SER_RX, 1)
                            Case "V"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "K"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "Z"
                                .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 2)
                        End Select
                        Return True

                    Case "JOHANSON"
                        var_STRING = Split(var_SER_RX, ";")
                        If var_STRING.Length > 1 Then
                            .lbl_PN_TAPE.Text = var_STRING(1)
                            .lbl_QTY_TAPE.Text = var_STRING(2)
                            .lbl_LOT_TAPE.Text = var_STRING(4)
                            .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        End If
                        Return True

                    Case "HKC"
                        .lbl_QTY_TAPE.Text = 0
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Select Case Len(var_SER_RX)
                            Case 12 To 16   'PART NUMBER
                                .lbl_PN_TAPE.Text = var_SER_RX
                            Case > 16       'LOTTO
                                .lbl_LOT_TAPE.Text = var_SER_RX
                        End Select
                        Return True

                    Case "KAMAYA"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Select Case Strings.Left(var_SER_RX, 1).ToUpper 'CONTROLLA PRIMO CARATTERE
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                        End Select

                        Select Case Strings.Left(var_SER_RX, 2).ToUpper 'CONTROLLA PRIMI 2 CARATTERI
                            Case "1T"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                            Case "1P"
                                If var_STRING.Length > 12 Then
                                    .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                                End If
                        End Select
                        Return True

                    Case "KEMET"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Select Case Strings.Left(var_SER_RX, 1).ToUpper 'CONTROLLA PRIMO CARATTERE
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "P"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 2)
                        End Select

                        Select Case Strings.Left(var_SER_RX, 2).ToUpper 'CONTROLLA PRIMI 2 CARATTERI
                            Case "1T"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        End Select
                        Return True

                    Case "KINGBRIGHT"
                        If Len(var_SER_RX) > 35 Then
                            var_STRING = Split(var_SER_RX, " ")
                            .lbl_PN_TAPE.Text = var_STRING(0)
                            .lbl_LOT_TAPE.Text = var_STRING(6)
                            .lbl_QTY_TAPE.Text = CInt(Replace(var_STRING(2), ",", ""))
                            .lbl_DATA_TAPE.Text = var_STRING(8)
                            .lbl_BIN_TAPE.Text = var_STRING(4)
                        End If
                        Return True

                    Case "LITEON"
                        If Len(var_SER_RX) > 50 Then
                            var_STRING = Split(var_SER_RX, ";")
                            .lbl_PN_TAPE.Text = var_STRING(2)
                            .lbl_QTY_TAPE.Text = var_STRING(4)
                            .lbl_DATA_TAPE.Text = var_STRING(7)
                            .lbl_LOT_TAPE.Text = var_STRING(3)
                        End If
                        Return True

                    Case "LITTLEFUSE"
                        If Len(var_SER_RX) = 4 Then
                            .lbl_DATA_TAPE.Text = var_SER_RX
                        End If

                        Select Case Strings.Left(var_SER_RX, 1).ToUpper
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            Case "P"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 2)
                                '.lbl_DATA.Text = Mid(var_SER_RX, 2)
                        End Select

                        Select Case Strings.Left(var_SER_RX, 2).ToUpper
                            Case "1P"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                            Case "1T"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        End Select
                        Return True

                    Case "MURATA"
                        If Len(var_SER_RX) > 30 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            If var_STRING.Length > 1 Then
                                .lbl_PN_TAPE.Text = Mid(var_STRING(5), 3)
                                .lbl_QTY_TAPE.Text = Mid(var_STRING(7), 2)
                                .lbl_LOT_TAPE.Text = Mid(var_STRING(8), 3)
                                .lbl_DATA_TAPE.Text = Mid(var_STRING(17), 3)
                            End If
                        Else
                            If Strings.Left(var_SER_RX, 1) = "Q" Then .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            If Strings.Left(var_SER_RX, 2) = "1P" Then .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                            If Strings.Left(var_SER_RX, 2) = "1T" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                            If Strings.Left(var_SER_RX, 3) = "10D" Then .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 4)
                        End If
                        Return True

                    Case "MICREL"
                        If Len(var_SER_RX) > 50 Then
                            var_STRING = Split(var_SER_RX, ",")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(0), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(3), 2)
                            .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(1), 3)
                        End If
                        Return True

                    Case "MICROCHIP"
                        If Len(var_SER_RX) > 40 Then
                            var_STRING = Split(var_SER_RX, ",")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(0), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(3), 2)
                            .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(1), 3)
                        End If
                        Return True

                    Case "MICRON"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        If IsNumeric(var_SER_RX) Then .lbl_QTY_TAPE.Text = var_SER_RX
                        If Strings.Left(var_SER_RX, 2) = "1P" Then .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                        If Strings.Left(var_SER_RX, 2) = "1T" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        Return True

                    Case "MINIBRIDGE"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        If Len(var_SER_RX) = 12 Then .lbl_PN_TAPE.Text = var_SER_RX
                        If Len(var_SER_RX) = 7 Then .lbl_LOT_TAPE.Text = var_SER_RX
                        If Len(var_SER_RX) = 5 Then .lbl_QTY_TAPE.Text = CInt(var_SER_RX)
                        'If Len(var_SER_RX) = 8 And var_SER_RX <> .lbl_UL.Text Then .lbl_DATA.Text = var_SER_RX
                        Return True

                    Case "NICHICON"
                        If Strings.Left(var_SER_RX, 1) = "Q" Then .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                        If Strings.Left(var_SER_RX, 1) = "K" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 2)
                        If Strings.Left(var_SER_RX, 1) = "L" Then .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 2)
                        If Strings.Left(var_SER_RX, 2) = "1P" Then .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                        Return True

                    Case "NXP"
                        If Len(var_SER_RX) < 100 Then
                            If Strings.Left(var_SER_RX, 1) = "Q" Then .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            If Strings.Left(var_SER_RX, 2) = "1T" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                            If Strings.Left(var_SER_RX, 2) = "9D" Then .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 3)
                            If Strings.Left(var_SER_RX, 2) = "1P" Then .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                        End If
                        Return True

                    Case "NXP_DM"
                        If Len(var_SER_RX) > 100 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 4)            'ELIMINA 30P
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(3), 2)           'ELIMINA Q
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(4), 3)          'ELIMINA 9D
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(5), 3)           'ELIMINA 1T
                        End If
                        Return True

                    Case "PANJIT"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        If Len(var_SER_RX) > 30 And Len(var_SER_RX) <= 45 Then
                            var_STRING = Split(var_SER_RX, ";")
                            .lbl_PN_TAPE.Text = var_STRING(1)
                            .lbl_LOT_TAPE.Text = var_STRING(0)
                            .lbl_QTY_TAPE.Text = var_STRING(5)
                        End If

                        If Len(var_SER_RX) > 45 Then
                            var_STRING = Split(var_SER_RX, ";")
                            If var_STRING.Length > 1 Then
                                .lbl_PN_TAPE.Text = Mid(var_STRING(0), 3)
                                .lbl_LOT_TAPE.Text = Mid(var_STRING(2), 3)
                                .lbl_QTY_TAPE.Text = Mid(var_STRING(3), 2)
                            End If
                        End If
                        Return True

                    Case "SAMSUNG"
                        If Len(var_SER_RX) > 30 Then
                            var_STRING = Split(var_SER_RX, "/")
                            If var_STRING.Length > 1 Then
                                .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                                .lbl_LOT_TAPE.Text = var_STRING(0)
                                .lbl_PN_TAPE.Text = var_STRING(1)
                                .lbl_QTY_TAPE.Text = CInt(var_STRING(3))
                            End If
                        Else
                            If Strings.Left(var_SER_RX, 1) = "Q" Then .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)
                            If Strings.Left(var_SER_RX, 2) = "9D" Then .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 3)
                            If Strings.Left(var_SER_RX, 2) = "1P" Then .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                            If Strings.Left(var_SER_RX, 2) = "1T" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        End If
                        Return True

                    Case "SAMWHA"
                        var_STRING = Split(var_SER_RX, "!")
                        If var_STRING.Length > 1 Then
                            .lbl_PN_TAPE.Text = var_STRING(2)
                            .lbl_LOT_TAPE.Text = var_STRING(3)
                            .lbl_QTY_TAPE.Text = CInt(var_STRING(4))
                            .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        End If
                        Return True

                    Case "TYCO/ETE"
                        Select Case Len(var_SER_RX)
                            Case < 6
                                .lbl_QTY_TAPE.Text = var_SER_RX
                            Case 6 To 9
                                .lbl_DATA_TAPE.Text = var_SER_RX
                                .lbl_LOT_TAPE.Text = var_SER_RX
                            Case 10 To 18
                                If Mid(var_SER_RX, 1, 2) = "1P" Then
                                    .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3, Len(var_SER_RX))
                                Else
                                    .lbl_PN_TAPE.Text = var_SER_RX
                                End If
                        End Select
                        Return True

                    Case "TAIYO YUDEN"
                        Select Case Len(var_SER_RX)
                            Case 25
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 4, 16)

                            Case 31
                                .lbl_LOT_TAPE.Text = Strings.Left(var_SER_RX, 10)
                                .lbl_QTY_TAPE.Text = CInt(Mid(var_SER_RX, 14, 7))
                                .lbl_DATA_TAPE.Text = CInt(Mid(var_SER_RX, 21, 4))
                        End Select
                        Return True

                    Case "TAITIEN"
                        If Len(var_SER_RX) > 30 Then
                            var_STRING = Split(var_SER_RX, ";")
                            .lbl_PN_TAPE.Text = var_STRING(1)
                            .lbl_LOT_TAPE.Text = var_STRING(0)
                            .lbl_QTY_TAPE.Text = CInt(var_STRING(2))
                            .lbl_DATA_TAPE.Text = var_STRING(3)
                        End If
                        Return True

                    Case "TDK"
                        Select Case Strings.Left(var_SER_RX, 1).ToUpper
                            Case "Q"
                                .lbl_QTY_TAPE.Text = Mid(var_SER_RX, 2)

                            Case "T"
                                .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 2)

                            Case "P"
                                .lbl_PN_TAPE.Text = Mid(var_SER_RX, 2)
                        End Select

                        Select Case Strings.Left(var_SER_RX, 2).ToUpper
                            Case "1T"
                                .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        End Select
                        Return True

                    Case "TVS"
                        If Len(var_SER_RX) > 70 And Len(var_SER_RX) < 100 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(5), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(4), 4)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(6), 3)
                        End If
                        Return True

                    Case "SEOUL"
                        Select Case Len(var_SER_RX)
                            Case < 6        'QUANTITA'
                                .lbl_QTY_TAPE.Text = var_SER_RX
                            Case 6 To 7     'BINCODE
                                .lbl_BIN_TAPE.Text = var_SER_RX
                            Case 8 To 12    'PART NUMBER (8 CHR)
                                If Strings.Left(var_SER_RX, 1).ToUpper = "S" Then   'ESCLUDE ID LASI CHE HA 8 CHR
                                    .lbl_PN_TAPE.Text = var_SER_RX
                                End If
                            Case > 15       'LOTTO/DATA
                                .lbl_LOT_TAPE.Text = var_SER_RX
                                .lbl_DATA_TAPE.Text = Strings.Left(var_SER_RX, 5)
                        End Select
                        Return True

                    Case "CREE"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Select Case Len(var_SER_RX)
                            Case < 6        'QUANTITA'
                                .lbl_QTY_TAPE.Text = var_SER_RX
                            Case 9 To 11    'LOTTO
                                .lbl_LOT_TAPE.Text = var_SER_RX
                            Case > 15       'PART NUMBER/BIN
                                .lbl_PN_TAPE.Text = var_SER_RX
                                .lbl_BIN_TAPE.Text = Strings.Right(var_SER_RX, 8)
                        End Select
                        Return True

                    Case "RENESAS"
                        var_STRING = Replace(var_SER_RX, "(", "!")
                        var_STRING = Replace(var_STRING, ")", "!")
                        var_STRING = Split(var_STRING, "!")
                        If var_STRING.Length > 1 Then
                            .lbl_QTY_TAPE.Text = var_STRING(5)
                            .lbl_DATA_TAPE.Text = var_STRING(9)
                            .lbl_PN_TAPE.Text = var_STRING(31)
                            .lbl_LOT_TAPE.Text = var_STRING(39)
                        End If
                        Return True

                    Case "STANLEY"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Select Case Len(var_SER_RX)
                            Case < 6        'QUANTITA'
                                .lbl_QTY_TAPE.Text = var_SER_RX
                            Case 9 To 17    'LOTTO
                                .lbl_LOT_TAPE.Text = var_SER_RX
                                .lbl_BIN_TAPE.Text = Strings.Left(Strings.Right(var_SER_RX, 5), 3)
                            Case > 17       'PART NUMBER
                                .lbl_PN_TAPE.Text = var_SER_RX
                        End Select
                        Return True

                    Case "ROHM"
                        If Len(var_SER_RX) > 50 Then
                            var_STRING = Split(var_SER_RX, ChrW(32))
                            .lbl_PN_TAPE.Text = var_STRING(0)
                            .lbl_LOT_TAPE.Text = Strings.Mid(var_STRING(7), 7, Len(var_STRING(7)))
                            .lbl_QTY_TAPE.Text = CInt(Strings.Left(var_STRING(7), 6))
                        End If

                        If Strings.Left(var_SER_RX, 2) = "1P" Then .lbl_PN_TAPE.Text = Mid(var_SER_RX, 3)
                        If Strings.Left(var_SER_RX, 2) = "1T" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        If Strings.Left(var_SER_RX, 1) = "Q" Then .lbl_QTY_TAPE.Text = CInt(Mid(var_SER_RX, 2))

                        If Strings.Left(var_SER_RX, 2) = "9D" Then .lbl_DATA_TAPE.Text = Mid(var_SER_RX, 3)
                        If .lbl_DATA_TAPE.Text = "" Then .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        Return True

                    Case "ROYALOHM"
                        .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                        If Strings.Left(var_SER_RX, 2) = "1T" Then .lbl_LOT_TAPE.Text = Mid(var_SER_RX, 3)
                        If Strings.Left(var_SER_RX, 1) = "Q" Then .lbl_QTY_TAPE.Text = CInt(Mid(var_SER_RX, 2))
                        If Len(var_SER_RX) > 12 And Len(var_SER_RX) < 20 Then
                            .lbl_PN_TAPE.Text = var_SER_RX
                        End If
                        Return True

                    Case "OSRAM"
                        var_STRING = Split(var_SER_RX, "@")
                        If var_STRING.Length > 1 Then
                            .lbl_PN_TAPE.Text = Mid(var_STRING(4), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(6), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(8), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(7), 3)
                            .lbl_BIN_TAPE.Text = Mid(var_STRING(9), 3) & "-" & Mid(var_STRING(10), 3) & "-" & Mid(var_STRING(11), 3) & "-" & Mid(var_STRING(12), 3)
                        End If
                        Return True

                    Case "UBLOX"
                        var_STRING = Split(var_SER_RX, ",")
                        If var_STRING.Length > 1 Then
                            .lbl_PN_TAPE.Text = var_STRING(1)
                            .lbl_QTY_TAPE.Text = var_STRING(3)
                            .lbl_DATA_TAPE.Text = var_STRING(4)
                            .lbl_LOT_TAPE.Text = var_STRING(5)
                        End If
                        Return True

                    Case "OMRON", "ST MICRO"
                        If Len(var_SER_RX) <> 8 Then
                            .lbl_DATA_TAPE.Text = "* " & Format(Date.Today, "yyyy/MM/dd")
                            .lbl_QTY_TAPE.Text = 0
                            .lbl_PN_TAPE.Text = var_SER_RX
                            .lbl_LOT_TAPE.Text = var_SER_RX
                        End If
                        Return True

                    Case "STACKPOLE"
                        If Len(var_SER_RX) > 50 And Len(var_SER_RX) < 100 Then
                            var_STRING = Split(var_SER_RX, ChrW(29))
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(3), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(4), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(5), 3)
                        End If
                        Return True

                    Case "TEXAS/NATIONAL"
                        var_STRING = Split(var_SER_RX, ChrW(29))
                        If var_STRING.Length > 1 Then
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(5), 2)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(7), 3)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(9), 2)
                        End If
                        Return True

                    Case "XILINX"
                        If Len(var_SER_RX) > 40 Then
                            var_STRING = Split(var_SER_RX, "\")
                            .lbl_PN_TAPE.Text = var_STRING(1)
                            .lbl_QTY_TAPE.Text = var_STRING(2)
                            .lbl_LOT_TAPE.Text = var_STRING(4)
                            .lbl_DATA_TAPE.Text = var_STRING(3)
                        End If
                        Return True

                    Case "VIKING"
                        If Len(var_SER_RX) > 50 Then
                            var_STRING = Split(var_SER_RX, ";")
                            .lbl_PN_TAPE.Text = Mid(var_STRING(2), 3)
                            .lbl_LOT_TAPE.Text = Mid(var_STRING(4), 3)
                            .lbl_QTY_TAPE.Text = Mid(var_STRING(5), 2)
                            .lbl_DATA_TAPE.Text = Mid(var_STRING(6), 3)
                        End If
                        Return True

                    Case "VISHAY"
                        If Len(var_SER_RX) > 50 Then
                            'PART NUMBER
                            .lbl_PN_TAPE.Text = LTrim(Mid(var_SER_RX, 1, 18))

                            ''GENERA STRINGA FORMATTATA
                            var_SER_RX = LTrim(var_SER_RX)
                            For i = 1 To Len(var_SER_RX)
                                If Mid(var_SER_RX, i, 1) = ChrW(32) And Mid(var_SER_RX, i + 1, 1) = ChrW(32) Then
                                    Mid(var_SER_RX, i, 1) = "@"
                                End If
                            Next
                            var_SER_RX = Replace(var_SER_RX, "@", "")
                            var_SER_RX = Replace(var_SER_RX, " ", "#")
                            var_STRING = Split(var_SER_RX, "#")
                            '=========================================='

                            'DATA
                            .lbl_DATA_TAPE.Text = Right(var_STRING(0), 8)

                            'QTY/LOTTO
                            Dim var_QTY
                            If IsNumeric(var_STRING(1)) Then
                                var_QTY = Split(var_STRING(3), ".")
                                .lbl_LOT_TAPE.Text = var_STRING(2)
                            Else
                                var_QTY = Split(var_STRING(2), ".")
                                .lbl_LOT_TAPE.Text = var_STRING(1)
                            End If
                            .lbl_QTY_TAPE.Text = var_QTY(0)
                        End If
                        Return True
                End Select
            Catch ex As Exception
                MessageBox.Show("ATTENZIONE: DECODIFICA LABEL NOK" & vbCr & ex.Message & vbCr & vbCr & "DATI NON COMPATIBILI, LA LETTURA VERRA' ANNULLATA", "sub_MARCHE_SEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
            Return False
        End With
    End Function
End Module
