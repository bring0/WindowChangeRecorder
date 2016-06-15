namespace Gma.UserActivityMonitorDemo
{
    partial class TestFormComponent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.counter = 0;

            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelWheel = new System.Windows.Forms.Label();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.globalEventProvider1 = new Gma.UserActivityMonitor.GlobalEventProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(459, 616);
            this.textBoxLog.TabIndex = 8;
            this.textBoxLog.WordWrap = false;
            // 
            // labelWheel
            // 
            this.labelWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWheel.AutoSize = true;
            this.labelWheel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWheel.Location = new System.Drawing.Point(280, 31);
            this.labelWheel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWheel.Name = "labelWheel";
            this.labelWheel.Size = new System.Drawing.Size(134, 17);
            this.labelWheel.TabIndex = 9;
            this.labelWheel.Text = "Wheel={0:####}";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMousePosition.Location = new System.Drawing.Point(205, 11);
            this.labelMousePosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(206, 17);
            this.labelMousePosition.TabIndex = 7;
            this.labelMousePosition.Text = "x={0:####}; y={1:####}";
            // 
            // globalEventProvider1
            // 
            this.globalEventProvider1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseMove);
            this.globalEventProvider1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseClick);
            this.globalEventProvider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseDown);
            this.globalEventProvider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseUp);
            this.globalEventProvider1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseDoubleClick);
            this.globalEventProvider1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HookManager_KeyPress);
            this.globalEventProvider1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HookManager_KeyUp);
            this.globalEventProvider1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HookManager_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // TestFormComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 616);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWheel);
            this.Controls.Add(this.labelMousePosition);
            this.Controls.Add(this.textBoxLog);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TestFormComponent";
            this.Text = "Test for the component GlobelEventProvider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelWheel;
        private System.Windows.Forms.Label labelMousePosition;
        private Gma.UserActivityMonitor.GlobalEventProvider globalEventProvider1;
        private System.Windows.Forms.Label label1;
    }
}