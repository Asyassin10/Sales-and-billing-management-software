﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace ADV1.PL
{
    public partial class FOUR : Form
    {
        public int id;
        ADVEntities db = new ADVEntities();
        BL.metod metod = new BL.metod();
        fournisseur tb_four = new fournisseur();
    
        public FOUR()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            ADV1.ADVEntities dbContext = new ADV1.ADVEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.fournisseurs.Load();
            // This line of code is generated by Data Source Configuration Wizard
            gridControl1.DataSource = dbContext.fournisseurs.Local.ToBindingList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PL.FOUR_ADD four_add = new FOUR_ADD();
            four_add.id = 0;
            four_add.btn_add.Text = "Ajoute";
            four_add.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PL.FOUR_ADD frm_add = new FOUR_ADD();
            id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("id"));
            tb_four = db.fournisseurs.Where(x => x.id == id).FirstOrDefault();
            frm_add.name_txt.Text = tb_four.four_name.ToString();
            frm_add.phone_txt.Text = tb_four.four_phone.ToString();
            frm_add.email_txt.Text = tb_four.four_email.ToString();
            metod.by = tb_four.four_cover;
            frm_add.pictureEdit1.Image = System.Drawing.Image.FromStream(metod.convert_image());
            frm_add.id = id;
            frm_add.btn_add.Text = "Modifier";
            frm_add.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var rs = MessageBox.Show("Processus de suppression", "Voulez-vous supprimer?", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    EBL.toast toast = new EBL.toast();
                    id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("id"));
                    tb_four = db.fournisseurs.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_four).State = EntityState.Deleted;
                    db.SaveChanges();
                    updte_data();
                    toast.txt_caption.Text = "Supprimer";
                    toast.ShowDialog();
                }
                else { }
            }
            catch { }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void updte_data()
        {
            db = new ADVEntities();
            gridControl1.DataSource = db.fournisseurs.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var search = textBox1.Text;
            gridControl1.DataSource = db.fournisseurs.Where(x => x.four_name.Contains(search)).ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            db = new ADVEntities();
            gridControl1.DataSource = db.fournisseurs.ToList();
        }

        private void FOUR_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDVDataSet1.fournisseurs' table. You can move, or remove it, as needed.
            this.fournisseursTableAdapter.Fill(this.aDVDataSet1.fournisseurs);

        }
    }
}
