namespace Ksu.Cis300.HuffmanTrees
{
    partial class UserInterface
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
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxSelectFile
            // 
            this.uxSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectFile.Location = new System.Drawing.Point(24, 23);
            this.uxSelectFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.uxSelectFile.Name = "uxSelectFile";
            this.uxSelectFile.Size = new System.Drawing.Size(486, 71);
            this.uxSelectFile.TabIndex = 1;
            this.uxSelectFile.Text = "Select a File";
            this.uxSelectFile.UseVisualStyleBackColor = true;
            this.uxSelectFile.Click += new System.EventHandler(this.uxSelectFile_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 117);
            this.Controls.Add(this.uxSelectFile);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "UserInterface";
            this.Text = "Huffman Trees";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.Button uxSelectFile;
    }
}

