using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox lbox;
        DataGridView dgv;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;

            //label
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);

            tn.Nodes.Add(new TreeNode("Silt-Label"));
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Teksttask-Textbox"));
            tn.Nodes.Add(new TreeNode("Piltikast-Picturebox"));
            //tn.Nodes.Add(new TreeNode("Picturebox"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);

            }
            else if (e.Node.Text == "Silt-Label")
            {
                this.Controls.Add(lbl);

            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(310, 30);
                r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(310, 70);
                r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                this.Controls.Add(r1);
                this.Controls.Add(r2);
            }
            else if (e.Node.Text == "Teksttask-Textbox")
            {
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "Failist";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 100;
                txt_box.Height = 100;
            }
            else if (e.Node.Text == "Piltikast-Picturebox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("img.jpg");
                picture.Location = new Point(400, 400);
                picture.Size = new Size(90, 90);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(300, 300);
                tabControl.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");
                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                page1.BackColor = Color.Blue;
                page2.BackColor = Color.Red;
                page3.BackColor = Color.Yellow;
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                this.Controls.Add(tabControl);
                tabControl.SelectedIndex = 2;//0, 1, 2
            }
            else if(e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige ilusam aken");
                var answer=MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi teksti", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }
            }
            else if (e.Node.Text == "ListBox")
            {
                string[] Colors_nimetused = new string[] {"Sinine", "Kollane", "Roheline", "Punane"};
                lbox = new ListBox();
                foreach(var item in Colors_nimetused)
                {
                    lbox.Items.Add(item);
                }
                lbox.Location = new Point(350, 50);
                lbox.Width=50;
                lbox.Height=Colors_nimetused.Length*15;
                this.Controls.Add(lbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml!("..//..//Files//example.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(200, 200);
                dgv.Width = 250;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "food";
                dgv.DataSource = dataSet;
                Controls.Add(dgv);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuItem1 = new MenuItem("File");
                menuItem1.MenuItems.Add("Exit", new EventHandler(menuitem1_Exit));
                menu.MenuItems.Add(menuItem1);
                this.Menu = menu;
            }
        }

        private void menuitem1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas oled kindel?","Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose()
            }
        }

        private void Radiobuttons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }

        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}
