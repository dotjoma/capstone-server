<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.console = New System.Windows.Forms.RichTextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnShutdown = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'console
        '
        Me.console.Location = New System.Drawing.Point(14, 70)
        Me.console.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.console.Name = "console"
        Me.console.ReadOnly = True
        Me.console.Size = New System.Drawing.Size(539, 440)
        Me.console.TabIndex = 0
        Me.console.Text = ""
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(14, 30)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(182, 32)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start Server"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnShutdown
        '
        Me.btnShutdown.Location = New System.Drawing.Point(206, 30)
        Me.btnShutdown.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(182, 32)
        Me.btnShutdown.TabIndex = 2
        Me.btnShutdown.Text = "Shutdown Server"
        Me.btnShutdown.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 540)
        Me.Controls.Add(Me.btnShutdown)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.console)
        Me.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents console As System.Windows.Forms.RichTextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnShutdown As System.Windows.Forms.Button

End Class
