namespace search_engine_12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.search_box = new System.Windows.Forms.TextBox();
            this.search_pic_box = new System.Windows.Forms.PictureBox();
            this.search_man = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_no_match_found = new System.Windows.Forms.Label();
            this.open_directory = new System.Windows.Forms.FolderBrowserDialog();
            this.change_dir = new System.Windows.Forms.Button();
            this.checkbox_substring_search = new System.Windows.Forms.CheckBox();
            this.label_num_of_files_matched = new System.Windows.Forms.Label();
            this.progressBar_searching_words = new System.Windows.Forms.ProgressBar();
            this.progressbar_loading_files = new System.Windows.Forms.ProgressBar();
            this.background_loading_files = new System.ComponentModel.BackgroundWorker();
            this.backgound_searching_words = new System.ComponentModel.BackgroundWorker();
            this.image_loading_files = new System.Windows.Forms.PictureBox();
            this.label_for_filepath = new System.Windows.Forms.Label();
            this.button_stop_searching = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.search_pic_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_man)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_loading_files)).BeginInit();
            this.SuspendLayout();
            // 
            // search_box
            // 
            this.search_box.Location = new System.Drawing.Point(637, 39);
            this.search_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(595, 26);
            this.search_box.TabIndex = 0;
            this.search_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_box_KeyDown);
            // 
            // search_pic_box
            // 
            this.search_pic_box.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("search_pic_box.BackgroundImage")));
            this.search_pic_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.search_pic_box.Enabled = false;
            this.search_pic_box.Location = new System.Drawing.Point(459, 28);
            this.search_pic_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_pic_box.Name = "search_pic_box";
            this.search_pic_box.Size = new System.Drawing.Size(800, 55);
            this.search_pic_box.TabIndex = 6;
            this.search_pic_box.TabStop = false;
            // 
            // search_man
            // 
            this.search_man.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("search_man.BackgroundImage")));
            this.search_man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.search_man.Location = new System.Drawing.Point(2, 131);
            this.search_man.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_man.Name = "search_man";
            this.search_man.Size = new System.Drawing.Size(324, 524);
            this.search_man.TabIndex = 7;
            this.search_man.TabStop = false;
            this.search_man.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(332, 203);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1033, 452);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // label_no_match_found
            // 
            this.label_no_match_found.AutoSize = true;
            this.label_no_match_found.BackColor = System.Drawing.Color.Transparent;
            this.label_no_match_found.Font = new System.Drawing.Font("Freestyle Script", 80F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_no_match_found.ForeColor = System.Drawing.Color.LightSalmon;
            this.label_no_match_found.Location = new System.Drawing.Point(370, 252);
            this.label_no_match_found.Name = "label_no_match_found";
            this.label_no_match_found.Size = new System.Drawing.Size(975, 189);
            this.label_no_match_found.TabIndex = 17;
            this.label_no_match_found.Text = "No match found...!!! ";
            this.label_no_match_found.Visible = false;
            // 
            // change_dir
            // 
            this.change_dir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("change_dir.BackgroundImage")));
            this.change_dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_dir.ForeColor = System.Drawing.Color.Black;
            this.change_dir.Location = new System.Drawing.Point(12, 28);
            this.change_dir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.change_dir.Name = "change_dir";
            this.change_dir.Size = new System.Drawing.Size(151, 42);
            this.change_dir.TabIndex = 9;
            this.change_dir.Text = "change directory";
            this.change_dir.UseVisualStyleBackColor = true;
            this.change_dir.Click += new System.EventHandler(this.change_dir_Click);
            // 
            // checkbox_substring_search
            // 
            this.checkbox_substring_search.AutoSize = true;
            this.checkbox_substring_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkbox_substring_search.BackgroundImage")));
            this.checkbox_substring_search.Enabled = false;
            this.checkbox_substring_search.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkbox_substring_search.Location = new System.Drawing.Point(518, 87);
            this.checkbox_substring_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkbox_substring_search.Name = "checkbox_substring_search";
            this.checkbox_substring_search.Size = new System.Drawing.Size(183, 24);
            this.checkbox_substring_search.TabIndex = 11;
            this.checkbox_substring_search.Text = "search for substrings";
            this.checkbox_substring_search.UseVisualStyleBackColor = true;
            this.checkbox_substring_search.CheckedChanged += new System.EventHandler(this.substring_search_CheckedChanged);
            // 
            // label_num_of_files_matched
            // 
            this.label_num_of_files_matched.AutoSize = true;
            this.label_num_of_files_matched.ForeColor = System.Drawing.SystemColors.Control;
            this.label_num_of_files_matched.Image = ((System.Drawing.Image)(resources.GetObject("label_num_of_files_matched.Image")));
            this.label_num_of_files_matched.Location = new System.Drawing.Point(862, 85);
            this.label_num_of_files_matched.Name = "label_num_of_files_matched";
            this.label_num_of_files_matched.Size = new System.Drawing.Size(0, 20);
            this.label_num_of_files_matched.TabIndex = 12;
            this.label_num_of_files_matched.Visible = false;
            // 
            // progressBar_searching_words
            // 
            this.progressBar_searching_words.Location = new System.Drawing.Point(12, 7);
            this.progressBar_searching_words.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar_searching_words.Name = "progressBar_searching_words";
            this.progressBar_searching_words.Size = new System.Drawing.Size(1341, 10);
            this.progressBar_searching_words.TabIndex = 13;
            this.progressBar_searching_words.Visible = false;
            // 
            // progressbar_loading_files
            // 
            this.progressbar_loading_files.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressbar_loading_files.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.progressbar_loading_files.ForeColor = System.Drawing.Color.Navy;
            this.progressbar_loading_files.Location = new System.Drawing.Point(445, 413);
            this.progressbar_loading_files.MarqueeAnimationSpeed = 20;
            this.progressbar_loading_files.Name = "progressbar_loading_files";
            this.progressbar_loading_files.Size = new System.Drawing.Size(825, 28);
            this.progressbar_loading_files.Step = 20;
            this.progressbar_loading_files.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressbar_loading_files.TabIndex = 0;
            // 
            // background_loading_files
            // 
            this.background_loading_files.WorkerSupportsCancellation = true;
            this.background_loading_files.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.background_loading_files.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.background_loading_files.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgound_searching_words
            // 
            this.backgound_searching_words.WorkerSupportsCancellation = true;
            this.backgound_searching_words.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgound_searching_words_DoWork_1);
            this.backgound_searching_words.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgound_searching_words_ProgressChanged_1);
            this.backgound_searching_words.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgound_searching_words_RunWorkerCompleted_1);
            // 
            // image_loading_files
            // 
            this.image_loading_files.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image_loading_files.BackgroundImage")));
            this.image_loading_files.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image_loading_files.Location = new System.Drawing.Point(445, 272);
            this.image_loading_files.Name = "image_loading_files";
            this.image_loading_files.Size = new System.Drawing.Size(825, 150);
            this.image_loading_files.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_loading_files.TabIndex = 14;
            this.image_loading_files.TabStop = false;
            // 
            // label_for_filepath
            // 
            this.label_for_filepath.AutoSize = true;
            this.label_for_filepath.BackColor = System.Drawing.Color.Transparent;
            this.label_for_filepath.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_for_filepath.Location = new System.Drawing.Point(332, 131);
            this.label_for_filepath.Name = "label_for_filepath";
            this.label_for_filepath.Size = new System.Drawing.Size(0, 20);
            this.label_for_filepath.TabIndex = 15;
            this.label_for_filepath.Visible = false;
            // 
            // button_stop_searching
            // 
            this.button_stop_searching.BackColor = System.Drawing.Color.Transparent;
            this.button_stop_searching.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_stop_searching.BackgroundImage")));
            this.button_stop_searching.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_stop_searching.Enabled = false;
            this.button_stop_searching.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_stop_searching.ForeColor = System.Drawing.Color.Black;
            this.button_stop_searching.Location = new System.Drawing.Point(1256, 30);
            this.button_stop_searching.Name = "button_stop_searching";
            this.button_stop_searching.Size = new System.Drawing.Size(97, 45);
            this.button_stop_searching.TabIndex = 16;
            this.button_stop_searching.UseVisualStyleBackColor = false;
            this.button_stop_searching.Visible = false;
            this.button_stop_searching.Click += new System.EventHandler(this.stop_searching_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1365, 674);
            this.Controls.Add(this.label_no_match_found);
            this.Controls.Add(this.button_stop_searching);
            this.Controls.Add(this.label_for_filepath);
            this.Controls.Add(this.progressbar_loading_files);
            this.Controls.Add(this.image_loading_files);
            this.Controls.Add(this.progressBar_searching_words);
            this.Controls.Add(this.label_num_of_files_matched);
            this.Controls.Add(this.checkbox_substring_search);
            this.Controls.Add(this.change_dir);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.search_man);
            this.Controls.Add(this.search_pic_box);
            this.Controls.Add(this.search_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.search_pic_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_man)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_loading_files)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search_box;
        private System.Windows.Forms.PictureBox search_pic_box;
        private System.Windows.Forms.PictureBox search_man;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FolderBrowserDialog open_directory;
        private System.Windows.Forms.Button change_dir;
        private System.Windows.Forms.CheckBox checkbox_substring_search;
        private System.Windows.Forms.Label label_num_of_files_matched;
        private System.Windows.Forms.ProgressBar progressBar_searching_words;
        private System.Windows.Forms.ProgressBar progressbar_loading_files;
        private System.ComponentModel.BackgroundWorker background_loading_files;
        public System.ComponentModel.BackgroundWorker backgound_searching_words;
        private System.Windows.Forms.PictureBox image_loading_files;
        private System.Windows.Forms.Label label_for_filepath;
        private System.Windows.Forms.Button button_stop_searching;
        private System.Windows.Forms.Label label_no_match_found;
    }
}

