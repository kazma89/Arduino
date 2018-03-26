<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class previewFrm
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
        Me.previaPb = New AForge.Controls.PictureBox()
        Me.cerrarBtn = New System.Windows.Forms.Button()
        Me.guardarBtn = New System.Windows.Forms.Button()
        CType(Me.previaPb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'previaPb
        '
        Me.previaPb.Image = Nothing
        Me.previaPb.Location = New System.Drawing.Point(12, 12)
        Me.previaPb.Name = "previaPb"
        Me.previaPb.Size = New System.Drawing.Size(663, 448)
        Me.previaPb.TabIndex = 0
        Me.previaPb.TabStop = False
        '
        'cerrarBtn
        '
        Me.cerrarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cerrarBtn.Location = New System.Drawing.Point(537, 466)
        Me.cerrarBtn.Name = "cerrarBtn"
        Me.cerrarBtn.Size = New System.Drawing.Size(138, 50)
        Me.cerrarBtn.TabIndex = 1
        Me.cerrarBtn.Text = "Cerrar Vista Previa"
        Me.cerrarBtn.UseVisualStyleBackColor = True
        '
        'guardarBtn
        '
        Me.guardarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardarBtn.Location = New System.Drawing.Point(393, 466)
        Me.guardarBtn.Name = "guardarBtn"
        Me.guardarBtn.Size = New System.Drawing.Size(138, 50)
        Me.guardarBtn.TabIndex = 2
        Me.guardarBtn.Text = "Guardar Imagen"
        Me.guardarBtn.UseVisualStyleBackColor = True
        '
        'previewFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 521)
        Me.Controls.Add(Me.guardarBtn)
        Me.Controls.Add(Me.cerrarBtn)
        Me.Controls.Add(Me.previaPb)
        Me.Name = "previewFrm"
        Me.Text = "Vista Previa"
        CType(Me.previaPb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents previaPb As AForge.Controls.PictureBox
    Friend WithEvents cerrarBtn As Button
    Friend WithEvents guardarBtn As Button
End Class
