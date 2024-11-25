namespace WinFS_DZ_10
{
    public partial class Form1 : Form
    {
        private Panel panel1;
        private Button btnAddText;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem LoadToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem ChangeToolStripMenuItem;
        private ToolStripMenuItem Add�����ToolStripMenuItem;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // ��������� MenuStrip
            menuStrip1 = new MenuStrip();

            FileToolStripMenuItem = new ToolStripMenuItem("����");
            LoadToolStripMenuItem = new ToolStripMenuItem("�����������");
            SaveToolStripMenuItem = new ToolStripMenuItem("��������");

            ChangeToolStripMenuItem = new ToolStripMenuItem("����������");
            Add�����ToolStripMenuItem = new ToolStripMenuItem("������ �����");

            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                LoadToolStripMenuItem,
                SaveToolStripMenuItem
            });

            ChangeToolStripMenuItem.DropDownItems.Add(Add�����ToolStripMenuItem);

            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                FileToolStripMenuItem,
                ChangeToolStripMenuItem
            });

            panel1 = new Panel
            {
                BackColor = Color.LightGray,
                Location = new Point(10, 40),
                Size = new Size(760, 400),
                BorderStyle = BorderStyle.Fixed3D
            };

            btnAddText = new Button
            {
                Text = "������ �����",
                Location = new Point(10, 450),
                Size = new Size(120, 30)
            };

            LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            Add�����ToolStripMenuItem.Click += Add�����ToolStripMenuItem_Click;
            btnAddText.Click += btnAddText_Click;

            this.Controls.Add(menuStrip1);
            this.Controls.Add(panel1);
            this.Controls.Add(btnAddText);

            this.MainMenuStrip = menuStrip1;
            this.Text = "��������� ��������";
            this.Size = new Size(800, 550);
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    panel1.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
                    panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        private void Add�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTextToPanel();
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            AddTextToPanel();
        }

        private void AddTextToPanel()
        {
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.DrawString(form2.EnteredText,
                            new Font("Arial", 12),
                            Brushes.Black,
                            form2.TextLocation);
                    }
                }
            }
        }
    }
}
