<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tomarFotoFrm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.iniciarBtn = New System.Windows.Forms.Button()
        Me.capturarBtn = New System.Windows.Forms.Button()
        Me.terminarBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.previewVsp = New AForge.Controls.VideoSourcePlayer()
        Me.dispositivosCb = New System.Windows.Forms.ComboBox()
        Me.cerrarBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'iniciarBtn
        '
        Me.iniciarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iniciarBtn.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.iniciarBtn.Location = New System.Drawing.Point(10, 50)
        Me.iniciarBtn.Name = "iniciarBtn"
        Me.iniciarBtn.Size = New System.Drawing.Size(138, 78)
        Me.iniciarBtn.TabIndex = 0
        Me.iniciarBtn.Text = "Iniciar"
        Me.iniciarBtn.UseVisualStyleBackColor = True
        '
        'capturarBtn
        '
        Me.capturarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capturarBtn.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.capturarBtn.Location = New System.Drawing.Point(10, 259)
        Me.capturarBtn.Name = "capturarBtn"
        Me.capturarBtn.Size = New System.Drawing.Size(138, 78)
        Me.capturarBtn.TabIndex = 4
        Me.capturarBtn.Text = "Capturar"
        Me.capturarBtn.UseVisualStyleBackColor = True
        '
        'terminarBtn
        '
        Me.terminarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.terminarBtn.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.terminarBtn.Location = New System.Drawing.Point(10, 156)
        Me.terminarBtn.Name = "terminarBtn"
        Me.terminarBtn.Size = New System.Drawing.Size(138, 78)
        Me.terminarBtn.TabIndex = 5
        Me.terminarBtn.Text = "Terminar"
        Me.terminarBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(160, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 29)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Vista previa"
        '
        'previewVsp
        '
        Me.previewVsp.Location = New System.Drawing.Point(165, 50)
        Me.previewVsp.Name = "previewVsp"
        Me.previewVsp.Size = New System.Drawing.Size(598, 441)
        Me.previewVsp.TabIndex = 7
        Me.previewVsp.Text = "VideoSourcePlayer1"
        Me.previewVsp.VideoSource = Nothing
        '
        'dispositivosCb
        '
        Me.dispositivosCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dispositivosCb.FormattingEnabled = True
        Me.dispositivosCb.Location = New System.Drawing.Point(13, 14)
        Me.dispositivosCb.Name = "dispositivosCb"
        Me.dispositivosCb.Size = New System.Drawing.Size(135, 21)
        Me.dispositivosCb.TabIndex = 8
        '
        'cerrarBtn
        '
        Me.cerrarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cerrarBtn.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cerrarBtn.Location = New System.Drawing.Point(10, 352)
        Me.cerrarBtn.Name = "cerrarBtn"
        Me.cerrarBtn.Size = New System.Drawing.Size(138, 78)
        Me.cerrarBtn.TabIndex = 9
        Me.cerrarBtn.Text = "Cerrar"
        Me.cerrarBtn.UseVisualStyleBackColor = True
        '
        'tomarFotoFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 503)
        Me.Controls.Add(Me.cerrarBtn)
        Me.Controls.Add(Me.dispositivosCb)
        Me.Controls.Add(Me.previewVsp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.terminarBtn)
        Me.Controls.Add(Me.capturarBtn)
        Me.Controls.Add(Me.iniciarBtn)
        Me.Name = "tomarFotoFrm"
        Me.Text = "Camara fotografica"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents iniciarBtn As Button
    Friend WithEvents capturarBtn As Button
    Friend WithEvents terminarBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents previewVsp As AForge.Controls.VideoSourcePlayer
    Friend WithEvents dispositivosCb As ComboBox
    Friend WithEvents cerrarBtn As Button
End Class
