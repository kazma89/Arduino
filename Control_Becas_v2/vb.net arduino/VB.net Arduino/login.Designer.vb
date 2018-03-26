<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.loginLbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.loginTxt = New System.Windows.Forms.TextBox()
        Me.passTxt = New System.Windows.Forms.TextBox()
        Me.accesarBtn = New System.Windows.Forms.Button()
        Me.salirBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'loginLbl
        '
        Me.loginLbl.AutoSize = True
        Me.loginLbl.Location = New System.Drawing.Point(12, 43)
        Me.loginLbl.Name = "loginLbl"
        Me.loginLbl.Size = New System.Drawing.Size(56, 13)
        Me.loginLbl.TabIndex = 0
        Me.loginLbl.Text = "USUARIO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CONTRASEÑA"
        '
        'loginTxt
        '
        Me.loginTxt.Location = New System.Drawing.Point(102, 40)
        Me.loginTxt.Name = "loginTxt"
        Me.loginTxt.Size = New System.Drawing.Size(100, 20)
        Me.loginTxt.TabIndex = 2
        '
        'passTxt
        '
        Me.passTxt.Location = New System.Drawing.Point(100, 78)
        Me.passTxt.Name = "passTxt"
        Me.passTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passTxt.Size = New System.Drawing.Size(100, 20)
        Me.passTxt.TabIndex = 3
        Me.passTxt.UseSystemPasswordChar = True
        '
        'accesarBtn
        '
        Me.accesarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.accesarBtn.Location = New System.Drawing.Point(116, 140)
        Me.accesarBtn.Name = "accesarBtn"
        Me.accesarBtn.Size = New System.Drawing.Size(75, 23)
        Me.accesarBtn.TabIndex = 4
        Me.accesarBtn.Text = "ACCESAR"
        Me.accesarBtn.UseVisualStyleBackColor = True
        '
        'salirBtn
        '
        Me.salirBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salirBtn.Location = New System.Drawing.Point(197, 140)
        Me.salirBtn.Name = "salirBtn"
        Me.salirBtn.Size = New System.Drawing.Size(75, 23)
        Me.salirBtn.TabIndex = 5
        Me.salirBtn.Text = "SALIR"
        Me.salirBtn.UseVisualStyleBackColor = True
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 204)
        Me.Controls.Add(Me.salirBtn)
        Me.Controls.Add(Me.accesarBtn)
        Me.Controls.Add(Me.passTxt)
        Me.Controls.Add(Me.loginTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.loginLbl)
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents loginLbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents loginTxt As System.Windows.Forms.TextBox
    Friend WithEvents passTxt As System.Windows.Forms.TextBox
    Friend WithEvents accesarBtn As System.Windows.Forms.Button
    Friend WithEvents salirBtn As System.Windows.Forms.Button
End Class
