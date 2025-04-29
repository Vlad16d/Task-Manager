using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using TaskManager;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        //private string filePath = "tasks.json";
        private int dragIndex = -1;
        private bool isDarkTheme = false;  // Флаг для определения текущей темы

        public MainForm()
        {
            InitializeComponent();
            LoadTasks();
            ApplyTheme();
        }

        private void LoadTasks()
        {
            try
            {
                tasks = DatabaseHelper.LoadTasks();
                UpdateTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки задач из базы данных: {ex.Message}");
            }
        }


        private void SaveTasks()
        {
            try
            {
                DatabaseHelper.SaveTasks(tasks); // Вам нужно реализовать этот метод в DatabaseHelper
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения задач в БД: {ex.Message}");
            }
        }


        private void UpdateTaskList()
        {
            listBoxTasks.Items.Clear();
            foreach (var task in tasks)
            {
                listBoxTasks.Items.Add(task);
            }

            labelStats.Text = $"Tasks: {tasks.Count} | Completed: {tasks.FindAll(t => t.IsCompleted).Count}";
        }

        private void ApplyTheme()
        {
            if (isDarkTheme)
            {
                this.BackColor = Color.FromArgb(34, 34, 34); // Темный фон
                this.ForeColor = Color.White;
                listBoxTasks.BackColor = Color.FromArgb(45, 45, 48);
                listBoxTasks.ForeColor = Color.White;
                buttonAdd.BackColor = Color.FromArgb(60, 60, 60);
                buttonAdd.ForeColor = Color.White;
                buttonToggleTheme.BackColor = Color.FromArgb(60, 60, 60);
                buttonToggleTheme.ForeColor = Color.White;
                labelStats.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                listBoxTasks.BackColor = Color.White;
                listBoxTasks.ForeColor = Color.Black;
                buttonAdd.BackColor = Color.LightGray;
                buttonAdd.ForeColor = Color.Black;
                buttonToggleTheme.BackColor = Color.LightGray;
                buttonToggleTheme.ForeColor = Color.Black;
                labelStats.ForeColor = Color.Black;
            }
        }

        private void buttonToggleTheme_Click(object sender, EventArgs e)
        {
            isDarkTheme = !isDarkTheme;  // Переключаем флаг темы
            ApplyTheme();  // Применяем новую тему
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxTask.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                var newTask = new TaskItem { Name = name, IsCompleted = false };

                try
                {
                    DatabaseHelper.AddTask(newTask);  // Сохраняем сразу в БД
                    LoadTasks();                      // Перезагружаем список с актуальными ID
                    textBoxTask.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении задачи в БД: {ex.Message}");
                }
            }
        }


        //private void buttonComplete_Click(object sender, EventArgs e)
        //{
          //  if (listBoxTasks.SelectedIndex >= 0)
            //{
              //  tasks[listBoxTasks.SelectedIndex].IsCompleted = !tasks[listBoxTasks.SelectedIndex].IsCompleted;
                //UpdateTaskList();
                //SaveTasks();
            //}
        //}

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                // Получаем задачу, на которую кликнули
                var selectedTask = tasks[listBoxTasks.SelectedIndex];

                // Меняем статус задачи
                selectedTask.IsCompleted = !selectedTask.IsCompleted;

                // Обновляем задачу в базе данных
                try
                {
                    DatabaseHelper.UpdateTask(selectedTask); // Обновляем в базе
                    UpdateTaskList(); // Обновляем список задач на форме
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении статуса задачи в БД: {ex.Message}");
                }
            }
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex >= 0)
            {
                // Получаем выбранную задачу
                var selectedTask = tasks[listBoxTasks.SelectedIndex];

                // Удаляем задачу из базы данных
                try
                {
                    DatabaseHelper.DeleteTask(selectedTask.Id); // Удаляем из базы
                    tasks.RemoveAt(listBoxTasks.SelectedIndex); // Удаляем из списка задач
                    UpdateTaskList(); // Обновляем список задач на форме
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении задачи из базы данных: {ex.Message}");
                }
            }
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = listBoxTasks.SelectedIndex;
            if (index >= 0)
            {
                // Получаем задачу, которую редактируем
                var taskToEdit = tasks[index];

                // Запрашиваем новое название задачи
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Редактировать задачу:", "Редактирование", taskToEdit.Name);

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    // Обновляем имя задачи
                    taskToEdit.Name = newName;

                    // Сначала обновляем задачу в базе данных
                    try
                    {
                        DatabaseHelper.UpdateTask(taskToEdit); // Обновляем в базе данных
                        UpdateTaskList(); // Обновляем отображение задач на форме
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обновлении задачи в базе данных: {ex.Message}");
                    }
                }
            }
        }


        private void buttonSortAlpha_Click(object sender, EventArgs e)
        {
            tasks.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            UpdateTaskList();
            SaveTasks();
        }

        private void buttonSortStatus_Click(object sender, EventArgs e)
        {
            tasks.Sort((a, b) => a.IsCompleted.CompareTo(b.IsCompleted));
            UpdateTaskList();
            SaveTasks();
        }

        private void listBoxTasks_MouseDown(object sender, MouseEventArgs e)
        {
            dragIndex = listBoxTasks.IndexFromPoint(e.X, e.Y);
        }

        private void listBoxTasks_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragIndex >= 0)
            {
                listBoxTasks.DoDragDrop(listBoxTasks.Items[dragIndex], DragDropEffects.Move);
            }
        }

        private void listBoxTasks_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBoxTasks_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxTasks.PointToClient(new Point(e.X, e.Y));
            int dropIndex = listBoxTasks.IndexFromPoint(point);
            if (dropIndex >= 0 && dragIndex >= 0 && dropIndex != dragIndex)
            {
                TaskItem draggedTask = tasks[dragIndex];
                tasks.RemoveAt(dragIndex);
                tasks.Insert(dropIndex, draggedTask);
                UpdateTaskList();
                SaveTasks();
            }
        }

        private void listBoxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var task = (TaskItem)listBoxTasks.Items[e.Index];
            e.DrawBackground();
            Brush brush = task.IsCompleted ? Brushes.Gray : (isDarkTheme ? Brushes.White : Brushes.Black);
            e.Graphics.DrawString(task.ToString(), e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                buttonAdd.PerformClick();
                return true; // предотвращает "звон"
            }
            else if (keyData == Keys.Delete)
            {
                buttonDelete.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
