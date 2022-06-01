using AnimalHotelSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalHotelSystem.Application
{
    public partial class FrmAddPortionsToFood : Form
    {
        private AnimalFoodService foodService = new AnimalFoodService();
        public AnimalFood AnimalFood { get; private set; }
        public FrmAddPortionsToFood(Model.AnimalFood foodForChange)
        {
            InitializeComponent();
            AnimalFood = foodForChange;
        }

        private void FrmAddPortionsToFood_Load(object sender, EventArgs e)
        {

        }

        private void addPortions_Click(object sender, EventArgs e)
        {
            bool excHappend = false;
            try
            {
                 foodService.ReplenishFood(AnimalFood.Name, (int) numericUpDown1.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se graška prilikom dodavanja porcija u postojeću hranu: \n" + ex.Message, "", MessageBoxButtons.OK);
                excHappend = true;
            }

            if (!excHappend)
            {
                Close();
            }
        }

        private void close(object sender, EventArgs e)
        {
            Close();
        }
    }
}
