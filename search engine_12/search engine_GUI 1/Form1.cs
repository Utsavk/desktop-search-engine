using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;// for "Directory call up"
//using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using System.Threading;

namespace search_engine_12
{
    public partial class Form1 : Form
    {
        //VARIABLES
        start_process spobj;
        Bitmap image;
        DialogResult result;
        string[] temp;
        int total_files_discovered;
        string[] subdirectoryEntries;
        string dir;
        bool files_loaded_atleast_once = false;
        bool prev_key_was_enter = false;
        bool display_no_match_found_image = true;
        List<string> prevfilePaths=null;
        string prev_selected_path=null;
        List<string> dir_list = new List<string>();
        Dictionary<string, int> points_per_file = new Dictionary<string, int>();
        Dictionary<string, string> displaylist = new Dictionary<string, string>();
        public static bool go_for_substring_match = false;
        String project_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        void GetSubDirectories(string root)
        {
            total_files_discovered = 0;
            dir_list.Add(root);
            background_loading_files = new BackgroundWorker();
            background_loading_files.WorkerSupportsCancellation = true;
            background_loading_files.WorkerReportsProgress = true;
            background_loading_files.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            background_loading_files.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            // This event will be raised when we call ReportProgress
            background_loading_files.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            background_loading_files.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            
            progressbar_loading_files.Visible = true;
            image_loading_files.Visible = true;
            search_box.Enabled = false;
            checkbox_substring_search.Enabled = false;
            image = new Bitmap(project_path+ @"\search_engine_pics\image_loading_files.bmp");
            search_man.BackgroundImage = (Image)image;
            search_man.BackgroundImageLayout = ImageLayout.Stretch;
            search_man.Visible = true;
            image_loading_files.BackgroundImage = ((Image)new Bitmap(project_path+@"\search_engine_pics\loading....bmp"));
            
            using (Graphics graphics = Graphics.FromImage(image_loading_files.BackgroundImage))
            {
                System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 15);
                graphics.DrawString(open_directory.SelectedPath, font, Brushes.Wheat, 5, 120);
            }
            background_loading_files.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;
            do
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                if (dir_list.Count <= 0)
                    break;
                dir = dir_list[0];
                dir_list.RemoveAt(0);
                try
                {
                    temp = Directory.GetFiles(dir);
                    foreach (var v in temp)
                    {
                        try
                        {
                            if ((v.EndsWith(".txt")) || (v.EndsWith(".docx")) || (v.EndsWith(".doc")) || (v.EndsWith(".rtf")))
                            {
                                total_files_discovered++;
                                spobj.filePaths.Add(v);
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
                try
                {
                    subdirectoryEntries = Directory.GetDirectories(dir);

                    if (subdirectoryEntries.Length > 0)
                        foreach (string subdirectory in subdirectoryEntries)
                        {
                            dir_list.Add(subdirectory);
                        }
                }
                catch (UnauthorizedAccessException)
                {
                }
                Thread.Sleep(1);
            } while (dir_list.Count > 1);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressbar_loading_files.Visible = false;
            image_loading_files.Visible = false;
            image = new Bitmap(project_path+ @"\search_engine_pics\search man2.bmp");
            search_man.BackgroundImage = (Image)image;
            search_man.BackgroundImageLayout = ImageLayout.Stretch;
            search_box.Enabled = true;
            checkbox_substring_search.Enabled = true;
            if ((e.Cancelled == true))
            {
                //if (files_loaded_atleast_once == false)
                    //prev_selected_path = null;
                return;
            }
            prevfilePaths = spobj.filePaths;
            files_loaded_atleast_once = true;
            prev_selected_path = open_directory.SelectedPath;
            //change_dir.Enabled = true;
            label_num_of_files_matched.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_num_of_files_matched.Visible = true;
            label_num_of_files_matched.Text = total_files_discovered.ToString() + " file(s) are found in the directory";
            if (total_files_discovered == 0)
            {
                search_box.Enabled = false;
                checkbox_substring_search.Enabled = false;
                MessageBox.Show("No file found in this directory!\n" + open_directory.SelectedPath);
            }
        }
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.BackColor = Color.Transparent;
            this.Width += 60;
            spobj = new start_process();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            search_box.BringToFront();
            checkbox_substring_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            result = open_directory.ShowDialog();
            {
                if (result == DialogResult.Cancel || result == DialogResult.Abort)
                {
                    this.Dispose();
                    this.Close();
                    System.Windows.Forms.Application.Exit();
                }
                else if (result == DialogResult.OK)
                {
                    prev_selected_path = open_directory.SelectedPath;
                    GetSubDirectories(open_directory.SelectedPath);
                }
            }

            label_for_filepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
        }
        public void display_file_details(string file_name, string display_data, string file_path)
        {

            //PictureBox pic_box_matched_files = new PictureBox();
            Button img_button_matched_files = new Button();
            img_button_matched_files.Width = flowLayoutPanel1.Width - 28;
            img_button_matched_files.Height = 80;

            //label_num_of_files.
            image = new Bitmap(project_path+ @"\search_engine_pics\text_file_image_icon2.bmp");
            using (Graphics graphics = Graphics.FromImage(image))
            {
                //file_name.Remove(0, 6);
                System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 20);
                graphics.DrawString(file_name, font, Brushes.White, 130, 0);
            }
            img_button_matched_files.BackgroundImage = (Image)image;
            img_button_matched_files.ImageAlign = ContentAlignment.TopCenter;
            img_button_matched_files.BackgroundImageLayout = ImageLayout.Stretch;
            img_button_matched_files.ForeColor = Color.Wheat;
            img_button_matched_files.TextAlign = ContentAlignment.MiddleLeft;
            img_button_matched_files.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            display_data = Regex.Replace(display_data, @"\s+", " ");
            display_data = "                             " + display_data;
            img_button_matched_files.Text = display_data;

            Controls.Add(img_button_matched_files);
            flowLayoutPanel1.Controls.Add(img_button_matched_files);
            img_button_matched_files.Click += delegate(object sender, EventArgs e)
            {
                pic_box_Click(sender, e, file_name);
            };

        }
        void pic_box_Click(object sender, EventArgs e, string file_name)
        {
            Process.Start(file_name);
        }
        private void search_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (search_box.Text.Trim().Length == 0)
                return;
            if (prev_key_was_enter == true)
            {
                refresh();
            }
            if (e.KeyCode == Keys.Enter)
            {
                //label_no_match_found.Visible = false;
                button_stop_searching.Enabled = true;
                button_stop_searching.Visible = true;
                afterEnter();
                search_man.Visible = true;
                flowLayoutPanel1.Visible = true;
                prev_key_was_enter = true;
                progressBar_searching_words.Visible = true;
            }
        }
        private void refresh()
        {
            flowLayoutPanel1.Visible = false;
            progressBar_searching_words.Minimum = 0;
            progressBar_searching_words.Value = progressBar_searching_words.Minimum;
            progressBar_searching_words.Visible = true;
            dir_list = new List<string>();
            int lim = flowLayoutPanel1.Controls.Count;
            while (lim > 0)
            {
                Control c = flowLayoutPanel1.Controls[lim - 1];
                flowLayoutPanel1.Controls.RemoveAt(lim - 1);
                c.Dispose();
                lim--;
            }
            prev_key_was_enter = false;
            //search_man.Visible = false;
            image = new Bitmap(project_path+ @"\search_engine_pics\search man2.bmp");
            search_man.BackgroundImage = (Image)image;
            search_man.BackgroundImageLayout = ImageLayout.Stretch;

            label_num_of_files_matched.ResetText();
            label_num_of_files_matched.Visible = false;
            //total_files_discovered = 0;
            spobj.total_files = 0;
            spobj.progress_bar_temp_variable = 0;
            progressBar_searching_words.Visible = false;
            progressbar_loading_files.Visible = false;
            label_no_match_found.Visible = false; 
            progressBar_searching_words.Visible = false;
            progressBar_searching_words.Minimum = 0;
            progressBar_searching_words.Value = progressBar_searching_words.Minimum;
            label_for_filepath.Visible = false;
        }
        private void change_dir_Click(object sender, EventArgs e)
        {
            search_box.Enabled = true;
            checkbox_substring_search.Enabled = true;
            if (progressbar_loading_files.Visible == true)
            {
                if (background_loading_files.WorkerSupportsCancellation == true)
                {
                    background_loading_files.CancelAsync();
                }
                MessageBox.Show("Loading cancelled!!\nNo files loaded");
                //spobj.filePaths = new List<string>();
            }
            /*else if(files_loaded_atleast_once==true)
            {
                prevfilePaths = spobj.filePaths;
            }*/
            spobj = new start_process();
            refresh();
            dir_list = new List<string>();
            result = open_directory.ShowDialog();
            if (result == DialogResult.OK)
            {
                GetSubDirectories(open_directory.SelectedPath);
            }
            else
            {
                if(files_loaded_atleast_once==true)
                {
                    string str = prev_selected_path;
                    if (str.Length > 25)
                    {
                        str.Substring(0, 22);
                        str += "...";
                    }
                    MessageBox.Show("Searching will be done in the same directory\n"+str);
                    spobj.filePaths = prevfilePaths;
                }
                else
                {
                    MessageBox.Show("No file selected to be searched");
                    search_box.Enabled = false;
                    checkbox_substring_search.Enabled = false;
                    
                }
            }
        }
        private void substring_search_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
            if (checkbox_substring_search.Checked == true)
                go_for_substring_match = true;
            else
                go_for_substring_match = false;//search a complete word

        }
        private void afterEnter()
        {
            spobj.querry = search_box.Text;
            spobj.querry = spobj.querry.ToLower();
            spobj.parts = spobj.querry.Split(' ');

            progressBar_searching_words.Minimum = 0;
            progressBar_searching_words.Value = progressBar_searching_words.Minimum;
            progressBar_searching_words.Maximum = total_files_discovered;
            label_for_filepath.Visible = true;
            change_dir.Enabled = false;
            search_box.Enabled = false;
            checkbox_substring_search.Enabled = false;

            backgound_searching_words = new BackgroundWorker();
            backgound_searching_words.WorkerSupportsCancellation = true;
            backgound_searching_words.WorkerReportsProgress = true;
            backgound_searching_words.DoWork += new DoWorkEventHandler(backgound_searching_words_DoWork_1);
            backgound_searching_words.ProgressChanged += new ProgressChangedEventHandler(backgound_searching_words_ProgressChanged_1);
            backgound_searching_words.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgound_searching_words_RunWorkerCompleted_1);
            
            backgound_searching_words.RunWorkerAsync();

        }
        private void backgound_searching_words_DoWork_1(object sender, DoWorkEventArgs e)
        {

            display_no_match_found_image=spobj.begin_searching_in_each_file(ref points_per_file, ref displaylist, total_files_discovered, ref backgound_searching_words,sender,  e);
            
        }
        private void backgound_searching_words_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            search_box.Enabled = true;
            change_dir.Enabled = true;
            checkbox_substring_search.Enabled = true;
            //progressBar_searching_words.Minimum = 0;
            //progressBar_searching_words.Value = progressBar_searching_words.Minimum;
            spobj.progress_bar_temp_variable = 0;
            
            //progressBar_searching_words.Visible = false;
            button_stop_searching.Enabled = false;
            button_stop_searching.Visible = false;
            if (e.Cancelled == true)
            {
                //image_user_interrupted.Visible = true;
                image = new Bitmap(project_path+ @"\search_engine_pics\no_match_found.bmp");
                search_man.BackgroundImage = (Image)image;
                search_man.BackgroundImageLayout = ImageLayout.Stretch;
                MessageBox.Show("Searching interrupted by the user!!");
                image = new Bitmap(project_path+ @"\search_engine_pics\search man2.bmp");
                search_man.BackgroundImage = (Image)image;
                search_man.BackgroundImageLayout = ImageLayout.Stretch;
                //image_user_interrupted.Visible = true;
                refresh();
                spobj.total_files = 0;
                return;
            }
            foreach (var v in points_per_file)
            {
                display_file_details(v.Key, displaylist[v.Key], "                             ");

            }
            label_num_of_files_matched.Visible = true;
            label_num_of_files_matched.Text = spobj.total_files.ToString() + " file(s) matched your querry ";// +total_files_discovered.ToString();
            spobj.total_files = 0;
            if (display_no_match_found_image == false)
            {
                label_no_match_found.Visible = true;
                //label_no_match_found.BringToFront();
                image = new Bitmap(project_path+ @"\search_engine_pics\image_search_stopped_by_the_user2.bmp");
                search_man.BackgroundImage = (Image)image;
                search_man.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void backgound_searching_words_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar_searching_words.Value = spobj.progress_bar_temp_variable;
            try
            {
                if (spobj.filePaths[spobj.progress_bar_temp_variable].Length > 70)
                    label_for_filepath.Text = spobj.filePaths[spobj.progress_bar_temp_variable].Substring(0, 70) + ".....";
                else
                    label_for_filepath.Text = spobj.filePaths[spobj.progress_bar_temp_variable];
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Null refrence exception");
            }

            catch (Exception)
            {
            }

        }
        private void stop_searching_Click(object sender, EventArgs e)
        {
            if (progressBar_searching_words.Visible == true)
            {
                if (backgound_searching_words.WorkerSupportsCancellation == true)
                {
                    backgound_searching_words.CancelAsync();
                }
            }
        }
     }
    class start_process
    {
        public List<string> filePaths = new List<string>();
        public string querry;
        public string[] parts;
        public int total_files = 0;
        private int num_of_word_in_querry(string[] parts)
        {
            int i = 0;
            foreach (var v in parts)
                i++;
            return i;
        }
        public int progress_bar_temp_variable = 0;
        public bool begin_searching_in_each_file(ref Dictionary<string, int> points_per_file, ref Dictionary<string, string> displaylist, int tot_files_discovered, ref BackgroundWorker bobj, object sender, DoWorkEventArgs e)
        {
            int num_of_words = num_of_word_in_querry(parts);
            displaylist = new Dictionary<string, string>();
            searching sobj = new searching();
            int matches = 0;
            List<List<int>> container_of_indices_list;
            List<int> points_list = new List<int>();
            List<string> files_acc_to_their_rankings = new List<string>();
            bool match_found = false;
            bool no_file_found = true;
            total_files = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                foreach (var filepath in filePaths)
                {
                    
            
                    if ((worker.CancellationPending == true))
                    {
                        e.Cancel = true;
                        worker.ReportProgress(0);
                        
                        return false;

                    }
                    progress_bar_temp_variable++;
                    if (((filepath.EndsWith("txt")) || (filepath.EndsWith(".rtf"))))
                    //if ((filepath.EndsWith(".txt")) || (filepath.EndsWith(".docx")) || (filepath.EndsWith(".doc")) || (filepath.EndsWith(".rtf")))
                    {

                        closest_words cw = new closest_words();
                        int points = 0;
                        container_of_indices_list = new List<List<int>>();
                        int d_eff = 0;
                        sobj.tot_words_matched = 0;
                        matches = 0;
                        string[] data;
                        StringBuilder text = new StringBuilder();//set of keywords of a file

                        if ((filepath.EndsWith("txt"))|| (filepath.EndsWith(".rtf")))
                        {
                            try
                            {
                                data = File.ReadAllLines(filepath);

                                foreach (var word in data)
                                {
                                    word.ToLower();
                                    text.Append(word + " ");
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        

                        text.Append(".");
                        sobj.m = text.Length;
                        foreach (var q in parts)
                        {
                            q.Trim();
                            if (q == "")
                                continue;
                            List<int> list_of_indices = new List<int>();
                            sobj.i = 0;
                            sobj.table = new int[q.Length];
                            sobj.n = q.Length;
                            if (sobj.n > 1)
                            {
                                sobj.kmptable(q);
                                sobj.kmp(q, text.ToString().ToLower(), ref list_of_indices);
                            }
                            else
                            {
                                sobj.brute_force_search(q, text.ToString().ToLower(), ref list_of_indices);
                            }
                            if (sobj.atleast_one_copy_found == true)
                            {
                                matches++;
                                sobj.atleast_one_copy_found = false;
                                match_found = true;
                                no_file_found = false;

                            }
                            if (list_of_indices.Count > 0)
                            {
                                container_of_indices_list.Add(list_of_indices);
                                points = points + (list_of_indices.Count * 10);
                            }
                        }
                        cw.num_of_lists = container_of_indices_list.Count;
                        if (cw.num_of_lists != 0)
                        {
                            int left_ind, right_ind;
                            cw.find_rank(container_of_indices_list, ref d_eff, out left_ind, out right_ind,ref num_of_words);
                            points = points + (matches * 10) - d_eff;
                            points_list.Add(points);
                            matches = 0;
                            if (right_ind - left_ind < 110)
                            {
                                int diff = (110 - (right_ind - left_ind)) / 2;
                                if (left_ind - diff > 0)
                                    left_ind = left_ind - diff;
                                else
                                {
                                    int diff2 = diff - left_ind;
                                    diff = diff + diff2;
                                    left_ind = 1;
                                }
                                if (right_ind + diff < text.ToString().Length)
                                    right_ind = right_ind + diff;
                                else
                                {
                                    right_ind = text.ToString().Length + 1;
                                }
                            }
                            else if (right_ind - left_ind > 110)
                            {
                                right_ind = left_ind + 110;
                            }
                            string display_line = text.ToString().Substring(left_ind - 1, right_ind - left_ind);
                            displaylist.Add(filepath, display_line);
                            files_acc_to_their_rankings.Add(filepath);

                        }//end of txt,docx if
                        if (match_found == true)
                        {
                            total_files++;
                            match_found = false;
                        }
                    }
                    bobj.ReportProgress(progress_bar_temp_variable);
                    Thread.Sleep(1);
                }//end of files' foreach
                
            }//end of try block
            catch (NullReferenceException)
            {
                MessageBox.Show("No file selected to be searched");
            }
            /*Dictionary<string, int>*/
            progress_bar_temp_variable = 0;
            points_per_file = new Dictionary<string, int>();
            int count = points_list.Count;//, i = 0;

            while ((points_list.Count > 0))
            {
                int maxmatch = points_list.Max();
                string file_name = files_acc_to_their_rankings[points_list.IndexOf(maxmatch)];
                points_list.Remove(maxmatch);
                files_acc_to_their_rankings.Remove(file_name);
                points_per_file.Add(file_name, maxmatch);//50 points for each word
                
            }
            bobj.WorkerSupportsCancellation = true;
            bobj.CancelAsync();
            //MessageBox.Show("over ");
            return (!no_file_found);
        }
    }
    class searching
    {
        public int[] table;
        public int m, n;
        public int i = 0;
        public bool atleast_one_copy_found = false;
        public int tot_words_matched;
        public void kmptable(string pattern)
        {
            //i = 0;
            table = new int[n];
            int k = -1;

            table[0] = k;
            for (int j = 1; j < n; j++)
            {
                while (k > -1 && pattern[k + 1] != pattern[j])
                {
                    k = table[k];
                }
                if (pattern[j] == pattern[k + 1])
                {
                    k++;
                }
                table[j] = k;
            }
        }
        public void kmp(string pattern, string text, ref List<int> list_of_indices)
        {

            int k = -1;

            for (; i < m; i++)
            {

                while (k > -1 && pattern[k + 1] != text[i])
                {
                    k = table[k];
                }
                if (text[i] == pattern[k + 1])
                {
                    k++;
                }
                if (k == n - 1)// that is k reached at the end of the pattern
                {
                    if ((Form1.go_for_substring_match == true) || (((i - n == -1) || (text[i - n] == ' ')) &&
                        ((i + 1 == m) || (text[i + 1] == '\n') || (text[i + 1] == ' ') || (text[i + 1] == '.') || (text[i + 1] == ',') )))//|| ((/*text[i + 1] == 's'*/true) && ((text[i + 2] == ' ') || (text[i + 2] == '.') || (text[i + 2] == ','))))))
                    {
                        list_of_indices.Add(i - k + 1);
                        atleast_one_copy_found = true;
                        tot_words_matched++;
                        if (i < m)
                        {
                            kmp(pattern, text, ref list_of_indices);
                        }
                        else
                        {
                            return;
                        }
                    }
                    return;
                }
            }
            return;
        }
        public void brute_force_search(string pattern, string text, ref List<int> list_of_indices)
        {
            for (; i < m; i++)
            {
                if (text[i] == pattern[0])
                {
                    if ((i - n == -1) || (text[i - n] == ' '))//any complete word predecessed by a space
                        if ((i + 1 == m) || (text[i + 1] == ' ') || (text[i + 1] == '.') || (text[i + 1] == ',') )
                        {
                            list_of_indices.Add(i);
                            atleast_one_copy_found = true;
                            tot_words_matched++;
                        }
                }
            }
        }
    }
    class heap
    {
        public int last;
        public void heapify(int[] h, int index, int item)//creating a min heap
        {
            while ((index > 1) && (item < h[index / 2]))
            {

                h[index] = h[index / 2];//traversing up the tree
                index /= 2;

            }
            h[index] = item;
            h[0] = h[1];//used for finding range via max and min methods
        }
        public void deleteitem(int[] h)
        {
            int item = h[last];
            h[last] = int.MaxValue;
            last--;
            int parent = 1, child = 2;
            while (child <= last)//parent nodes' data will be removed
            {
                if ((child < last) && (h[child] > h[child + 1]))
                    child = child + 1;//getting the smaller of the two children
                if (h[child] < item)//
                {
                    h[parent] = h[child];//shifting up
                    parent = child;
                    child = parent * 2;

                }
                else
                    break;
            }
            h[parent] = item;
            last++;
        }
    }
    class closest_words
    {
        heap hobj = new heap();
        public Dictionary<int, int> dict_listnum_isto_wordsindex = new Dictionary<int, int>();
        public int num_of_lists;//count words using regex
        private int[] range, indices;

        private int findmin(List<List<int>> container, ref int[] heap_elements)
        {
            int return_value = int.MaxValue;//min_range;
            int deleted_root;
            int result;
            //heap_elements = range;
            for (int h = 0; h < range.Length; h++)
            {
                heap_elements[h] = range[h];
            }
            while (true)
            {
                result = range.Max() - range.Min();
                if (return_value > result)
                {
                    for (int h = 0; h < range.Length; h++)
                    {
                        heap_elements[h] = range[h];
                    }
                    return_value = result;
                }
                deleted_root = range[1];
                hobj.deleteitem(range);
                int list_num = dict_listnum_isto_wordsindex[deleted_root];
                indices[list_num]++;
                if (indices[list_num] < container[list_num].Count)
                {
                    hobj.heapify(range, hobj.last, container[list_num][indices[list_num]]);
                }
                else
                {
                    break;
                }

            }
            return (return_value);
        }
        public void find_rank(List<List<int>> container, ref int d_eff, out int left_ind, out int right_ind, ref int num_of_words)
        {
            int shortest_cont_range;
            int[] heap_elements;
            int num_of_dis_to_be_stored = container.Count;
            for (int i = 0; i < num_of_dis_to_be_stored; i++)
            {
                foreach (var k in container[i])
                {
                    try
                    {
                        dict_listnum_isto_wordsindex.Add(k, i);
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }

            float dis_sum = 0;
            bool findmin_never_called = true;
            left_ind = 0; right_ind = 0;
            if (num_of_lists == 0)
            {
                left_ind = 0; right_ind = 0;
                //return;
            }
            else if (num_of_lists == 1)
            {
                left_ind = right_ind = container[0][0];
                //return;
            }
            else
            {
                while (num_of_lists > num_of_words / 2)
                {
                    heap_elements = new int[num_of_lists + 1];
                    indices = new int[num_of_dis_to_be_stored];
                    range = new int[num_of_lists + 1];
                    hobj.last = num_of_lists;
                    for (int i = 0, y = 0; i < num_of_dis_to_be_stored; i++, y++)
                    //i is the index of the list which is being accesed from container_list
                    {//y will behave as the index of range array which is being sent to heapify
                        if (container[i].Count == 0)
                        {
                            y--;
                            continue;
                        }
                        hobj.heapify(range, y + 1, container[i][0]);
                    }
                    shortest_cont_range = findmin(container, ref heap_elements);
                    if (findmin_never_called == true)
                    {
                        findmin_never_called = false;
                        left_ind = heap_elements.Min();
                        right_ind = heap_elements.Max();
                    }
                    dis_sum = dis_sum + (shortest_cont_range / num_of_lists);
                    int lim = heap_elements.Length;
                    for (int j = 1; j < lim; j++)
                    {
                        int list_number = dict_listnum_isto_wordsindex[heap_elements[j]];
                        container[list_number].Remove(heap_elements[j]);
                        if (container[list_number].Count <= 0)
                        {
                            num_of_lists--;
                        }

                    }
                }
            }
            d_eff = Convert.ToInt32(dis_sum / 4);
        }
    }
}

