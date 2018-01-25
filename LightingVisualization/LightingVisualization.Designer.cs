namespace LightingVisualization
{
    partial class LightingVisualization
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
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.Wood = new System.Windows.Forms.RadioButton();
            this.Intermediate = new System.Windows.Forms.RadioButton();
            this.Mirror = new System.Windows.Forms.RadioButton();
            this.GraphicIcon = new System.Windows.Forms.Label();
            this.DrawingPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.Controls.Add(this.GraphicIcon);
            this.DrawingPanel.Location = new System.Drawing.Point(12, 12);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(500, 500);
            this.DrawingPanel.TabIndex = 0;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.Wood);
            this.OptionsPanel.Controls.Add(this.Intermediate);
            this.OptionsPanel.Controls.Add(this.Mirror);
            this.OptionsPanel.Location = new System.Drawing.Point(12, 518);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(500, 68);
            this.OptionsPanel.TabIndex = 1;
            // 
            // Wood
            // 
            this.Wood.AutoSize = true;
            this.Wood.Location = new System.Drawing.Point(352, 17);
            this.Wood.Name = "Wood";
            this.Wood.Size = new System.Drawing.Size(128, 17);
            this.Wood.TabIndex = 2;
            this.Wood.TabStop = true;
            this.Wood.Text = "Powierzchnia matowa";
            this.Wood.UseVisualStyleBackColor = true;
            this.Wood.CheckedChanged += new System.EventHandler(this.Wood_CheckedChanged);
            // 
            // Intermediate
            // 
            this.Intermediate.AutoSize = true;
            this.Intermediate.Location = new System.Drawing.Point(170, 17);
            this.Intermediate.Name = "Intermediate";
            this.Intermediate.Size = new System.Drawing.Size(135, 17);
            this.Intermediate.TabIndex = 1;
            this.Intermediate.TabStop = true;
            this.Intermediate.Text = "Powierzchnia mieszana";
            this.Intermediate.UseVisualStyleBackColor = true;
            this.Intermediate.CheckedChanged += new System.EventHandler(this.Intermediate_CheckedChanged);
            // 
            // Mirror
            // 
            this.Mirror.AutoSize = true;
            this.Mirror.Location = new System.Drawing.Point(3, 17);
            this.Mirror.Name = "Mirror";
            this.Mirror.Size = new System.Drawing.Size(141, 17);
            this.Mirror.TabIndex = 0;
            this.Mirror.TabStop = true;
            this.Mirror.Text = "Powierzchnia metaliczna";
            this.Mirror.UseVisualStyleBackColor = true;
            this.Mirror.CheckedChanged += new System.EventHandler(this.Mirror_CheckedChanged);
            // 
            // GraphicIcon
            // 
            this.GraphicIcon.Location = new System.Drawing.Point(3, 0);
            this.GraphicIcon.Name = "GraphicIcon";
            this.GraphicIcon.Size = new System.Drawing.Size(500, 500);
            this.GraphicIcon.TabIndex = 0;
            // 
            // LightingVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 600);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.DrawingPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LightingVisualization";
            this.Text = "Lighting Visualization";
            this.Load += new System.EventHandler(this.LightingVisualization_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LightingVisualization_KeyDown);
            this.DrawingPanel.ResumeLayout(false);
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.RadioButton Mirror;
        private System.Windows.Forms.RadioButton Wood;
        private System.Windows.Forms.RadioButton Intermediate;
        private System.Windows.Forms.Label GraphicIcon;
    }
}

