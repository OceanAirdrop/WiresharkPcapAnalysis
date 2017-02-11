namespace OceanAirdrop
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPCapDotNet = new System.Windows.Forms.Button();
            this.buttonTShark = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "This Winform App is just a stub to demonstrate the ability to read in a WireSahrk" +
    " .pacp file";
            // 
            // buttonPCapDotNet
            // 
            this.buttonPCapDotNet.Location = new System.Drawing.Point(98, 146);
            this.buttonPCapDotNet.Name = "buttonPCapDotNet";
            this.buttonPCapDotNet.Size = new System.Drawing.Size(130, 67);
            this.buttonPCapDotNet.TabIndex = 1;
            this.buttonPCapDotNet.Text = "pcapdotnet";
            this.buttonPCapDotNet.UseVisualStyleBackColor = true;
            this.buttonPCapDotNet.Click += new System.EventHandler(this.buttonPCapDotNet_Click);
            // 
            // buttonTShark
            // 
            this.buttonTShark.Location = new System.Drawing.Point(414, 146);
            this.buttonTShark.Name = "buttonTShark";
            this.buttonTShark.Size = new System.Drawing.Size(130, 67);
            this.buttonTShark.TabIndex = 2;
            this.buttonTShark.Text = "tshark";
            this.buttonTShark.UseVisualStyleBackColor = true;
            this.buttonTShark.Click += new System.EventHandler(this.buttonTShark_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Option 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Option 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 290);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonTShark);
            this.Controls.Add(this.buttonPCapDotNet);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Programmatic Analysis of Wireshark.pcap files using C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPCapDotNet;
        private System.Windows.Forms.Button buttonTShark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

