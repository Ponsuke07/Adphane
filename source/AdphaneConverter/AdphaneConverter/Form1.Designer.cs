namespace Cvsharp_test
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.file_select = new System.Windows.Forms.Button();
            this.Convert_buttom = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gamma_bar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamma_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(15, 22);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(200, 300);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // file_select
            // 
            this.file_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_select.Location = new System.Drawing.Point(15, 362);
            this.file_select.Name = "file_select";
            this.file_select.Size = new System.Drawing.Size(98, 34);
            this.file_select.TabIndex = 1;
            this.file_select.Text = "ファイルの選択";
            this.file_select.UseVisualStyleBackColor = true;
            this.file_select.Click += new System.EventHandler(this.file_select_Click);
            // 
            // Convert_buttom
            // 
            this.Convert_buttom.Enabled = false;
            this.Convert_buttom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Convert_buttom.Location = new System.Drawing.Point(119, 362);
            this.Convert_buttom.Name = "Convert_buttom";
            this.Convert_buttom.Size = new System.Drawing.Size(96, 34);
            this.Convert_buttom.TabIndex = 4;
            this.Convert_buttom.Text = "コンバート";
            this.Convert_buttom.UseVisualStyleBackColor = true;
            this.Convert_buttom.Click += new System.EventHandler(this.Comvert_buttom_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "|(.stl)|*.stl";
            this.saveFileDialog.Filter = "\"(.stl)|*.stl|すべてのファイル|*.*\"";
            // 
            // gamma_bar
            // 
            this.gamma_bar.AutoSize = false;
            this.gamma_bar.BackColor = System.Drawing.Color.White;
            this.gamma_bar.Enabled = false;
            this.gamma_bar.LargeChange = 1;
            this.gamma_bar.Location = new System.Drawing.Point(15, 328);
            this.gamma_bar.Maximum = 150;
            this.gamma_bar.Name = "gamma_bar";
            this.gamma_bar.Size = new System.Drawing.Size(200, 28);
            this.gamma_bar.TabIndex = 20;
            this.gamma_bar.TickFrequency = 10;
            this.gamma_bar.Value = 9;
            this.gamma_bar.Scroll += new System.EventHandler(this.gamma_bar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(232, 410);
            this.Controls.Add(this.gamma_bar);
            this.Controls.Add(this.Convert_buttom);
            this.Controls.Add(this.file_select);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamma_bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button file_select;
        private System.Windows.Forms.Button Convert_buttom;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TrackBar gamma_bar;
    }
}

