
Imports System.Net.Mail
Imports System.IO.File

Module module_MAIL
    Public var_MAIL_DEST = ""
    Public var_MAIL_CC = ""

    'Queste sono le variabili            
    Dim smtpServer As New SmtpClient()
    Dim mail As New MailMessage()
    '_destinatario = + DESTINATARI DIVISI DA VIRGOLA

    Sub sub_SEND_MAIL(_oggetto, _contenuto, _destinatario, _Cc, _allegato)
        Try
            'Qui inserisci le credenziali per accedere al nostro servizio di posta
            smtpServer.Credentials = New Net.NetworkCredential("Database@famag.it", "DA2017SE")

            'Metti la porta del tuo HOST di posta (es. per GMAIL &#232; 587)
            smtpServer.Port = 25

            'SMTP del tuo HOST di posta (es. per GMAIL &#232; quello che vedi qua sotto)
            smtpServer.Host = "email.famag.it"

            'Attiviamo l'SSL
            smtpServer.EnableSsl = False

            'Creiamo la mail da spedire
            mail = New MailMessage()

            'Inserisci l'indirizzo di posta che verr&#224; visualizzato dal destinatario
            mail.From = New MailAddress("database@famag.it")

            'Inserisci l'email del destinatario
            mail.To.Add(_destinatario)

            'Inserisci l'email in CC
            If _Cc <> "" Then
                mail.CC.Add(_Cc)
            End If

            'Inserisci l'oggetto
            mail.Subject = _oggetto

            'Qui metti il testo dell'email (es. Textbox1.text + ControlChars.CrLf, ovvero il contenuto della textbox + andare a capo)
            mail.Body = _contenuto

            If Exists(_allegato) Then mail.Attachments.Add(New System.Net.Mail.Attachment(_allegato))

            smtpServer.Send(mail)
            mail.Dispose()

        Catch ex As Exception
            'NO CODE
        End Try
    End Sub
End Module
