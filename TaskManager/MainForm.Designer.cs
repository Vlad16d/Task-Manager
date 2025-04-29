namespace TaskManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.TextBox textBoxTask;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonComplete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSortAlpha;
        private System.Windows.Forms.Button buttonSortStatus;
        private System.Windows.Forms.Button buttonToggleTheme;
        private System.Windows.Forms.Label labelStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.textBoxTask = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSortAlpha = new System.Windows.Forms.Button();
            this.buttonSortStatus = new System.Windows.Forms.Button();
            this.buttonToggleTheme = new System.Windows.Forms.Button();
            this.labelStats = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // MainForm
            this.Text = "Task Manager";
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.MinimumSize = new System.Drawing.Size(600, 450);

            // listBoxTasks
            this.listBoxTasks.Location = new System.Drawing.Point(10, 10);
            this.listBoxTasks.Size = new System.Drawing.Size(570, 250);
            this.listBoxTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.listBoxTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxTasks.DrawItem += listBoxTasks_DrawItem;
            this.listBoxTasks.DragDrop += listBoxTasks_DragDrop;
            this.listBoxTasks.DragOver += listBoxTasks_DragOver;
            this.listBoxTasks.MouseDown += listBoxTasks_MouseDown;
            this.listBoxTasks.MouseMove += listBoxTasks_MouseMove;
            this.listBoxTasks.AllowDrop = true;

            // textBoxTask
            this.textBoxTask.Location = new System.Drawing.Point(10, 270);
            this.textBoxTask.Size = new System.Drawing.Size(450, 20);
            this.textBoxTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // buttonAdd
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Location = new System.Drawing.Point(470, 268);
            this.buttonAdd.Size = new System.Drawing.Size(110, 23);
            this.buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonAdd.Click += buttonAdd_Click;

            // buttonEdit
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Location = new System.Drawing.Point(10, 300);
            this.buttonEdit.Size = new System.Drawing.Size(90, 23);
            this.buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.buttonEdit.Click += buttonEdit_Click;

            // buttonComplete
            this.buttonComplete.Text = "Finish";
            this.buttonComplete.Location = new System.Drawing.Point(110, 300);
            this.buttonComplete.Size = new System.Drawing.Size(90, 23);
            this.buttonComplete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.buttonComplete.Click += buttonComplete_Click;

            // buttonDelete
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Location = new System.Drawing.Point(210, 300);
            this.buttonDelete.Size = new System.Drawing.Size(90, 23);
            this.buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.buttonDelete.Click += buttonDelete_Click;

            // buttonSortAlpha
            this.buttonSortAlpha.Text = "Sort A-Z";
            this.buttonSortAlpha.Location = new System.Drawing.Point(310, 300);
            this.buttonSortAlpha.Size = new System.Drawing.Size(90, 23);
            this.buttonSortAlpha.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.buttonSortAlpha.Click += buttonSortAlpha_Click;

            // buttonSortStatus
            this.buttonSortStatus.Text = "Sort by Status";
            this.buttonSortStatus.Location = new System.Drawing.Point(410, 300);
            this.buttonSortStatus.Size = new System.Drawing.Size(90, 23);
            this.buttonSortStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.buttonSortStatus.Click += buttonSortStatus_Click;

            // buttonToggleTheme
            this.buttonToggleTheme.Text = "Toggle Theme";
            this.buttonToggleTheme.Location = new System.Drawing.Point(510, 300);
            this.buttonToggleTheme.Size = new System.Drawing.Size(90, 23);
            this.buttonToggleTheme.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonToggleTheme.Click += buttonToggleTheme_Click;

            // labelStats
            this.labelStats.Text = "Stats: 0 tasks (0 done)";
            this.labelStats.Location = new System.Drawing.Point(10, 330);
            this.labelStats.Size = new System.Drawing.Size(580, 23);
            this.labelStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Controls
            this.Controls.Add(this.listBoxTasks);
            this.Controls.Add(this.textBoxTask);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonComplete);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSortAlpha);
            this.Controls.Add(this.buttonSortStatus);
            this.Controls.Add(this.buttonToggleTheme);
            this.Controls.Add(this.labelStats);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
