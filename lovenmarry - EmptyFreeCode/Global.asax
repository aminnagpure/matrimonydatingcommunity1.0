<%@ Application Language="VB" %>
 
<script runat="server">
    Dim Gf As New comonfunctions
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Try
            Application("noofusers") = 1
            Dim Logins As IList(Of LoginIds) = New List(Of LoginIds)
            Application("Ids") = Logins
            
        Catch ex As Exception
            '    Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        End Try
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        Try
            
        Catch ex As Exception

        End Try
        
    
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        ' Dim ex As Exception = Server.GetLastError.GetBaseException
        
        '    Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
         Dim ip As String = ""
        ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If Not String.IsNullOrEmpty(ip) Then
            Dim ipRange As String() = ip.Split(","c)
            Dim le As Integer = ipRange.Length - 1
            Dim trueIP As String = ipRange(le)
        Else
            ip = Request.ServerVariables("REMOTE_ADDR")
        End If
        Dim cf As New comonfunctions
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        
        
        Dim err As String = "Error in: " & Request.Url.ToString() & ". Error Message:" & objErr.Message.ToString() & " " & ip
        If Session("pid") IsNot Nothing Then
            err  = err & vbCrLf & " PID:" & Session("pid")
        End If
        '   Session("errmsg") = err & e.ToString
        'Response.Redirect("errmsg.aspx")
        'cf.send25("err", "err occured yoursite.com", "tiwariamitkumar70@gmail.com", err.ToString) 'aminnagpure@gmail.com
        
        'Server.ClearError()
        
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Try
            
            Application.Lock()
            Application("noofusers") = CInt(Application("noofusers")) + 1
            Application.UnLock()
            
        Catch ex As Exception
            ' cf.send25("err", "err occured", "aminnagpure@gmail.com", ex.Message)
            '  Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        End Try

    End Sub
    'Public Sub Session_OnEnd()
        'Try
        '    Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
        '    Dim L As New LoginIds
        '    L.Fname = Session("fname")
        '    L.PID = Session("pid")
        '    Logins = Application("Ids")
        '    Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
        '    If b Then
        '        Logins.Remove(Logins.Find(Function(x) x.PID.Contains(L.PID)))
        '    End If
        '    Application("Ids") = Logins
        'Catch ex As Exception

        'End Try
        'End Sub
    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Try
            Dim strpid As String = CType(Session("pid"), String)
            
            If strpid <> "" Then
                Gf.logoffuser(strpid)
            End If
            
            Application.Lock()
            Application("noofusers") = CInt(Application("noofusers") - 1)
            Application.UnLock()
            
        Catch ex As Exception
            '   CF.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
            'logof.send25("err", "err occured", "aminnagpure@gmail.com", ex.Message)
            ' Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        End Try
        Application.Lock()
        Try
            
            Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
            Dim L As New LoginIds
            L.Fname = Session("fname")
            L.PID = Session("pid")
            Logins = Application("Ids")
            Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
            If b Then
                Logins.Remove(Logins.Find(Function(x) x.PID.Contains(L.PID)))
            End If
            Application("Ids") = Logins
             
        Catch ex As Exception

        End Try
        Application.UnLock()
    End Sub
       
</script>