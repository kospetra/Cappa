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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newReservation_Click(object sender, EventArgs e)
        {
            FrmNewReservation frmNewReservation = new FrmNewReservation();
            frmNewReservation.ShowDialog();
        }

        private void allReservation_clicked(object sender, EventArgs e)
        {
            FrmReservationList frmReservationList = new FrmReservationList();
            frmReservationList.ShowDialog();
        }

        private void addNewFood_Click(object sender, EventArgs e)
        {
            FrmAddNewFood frmAddNewFood = new FrmAddNewFood();
            frmAddNewFood.ShowDialog();
        }

        private void allFoods_Click(object sender, EventArgs e)
        {
            List allFoodForm = new List();
            allFoodForm.ShowDialog();
        }

        private void addNewToy_Click(object sender, EventArgs e)
        {
            FrmAddNewToy frameAddNewToy = new FrmAddNewToy();
            frameAddNewToy.ShowDialog();
        }

        private void listOfAllToys_Click(object sender, EventArgs e)
        {
            FrmToysList frmToysList = new FrmToysList();
            frmToysList.ShowDialog();
        }

        private void newRoom_Click(object sender, EventArgs e)
        {
            FrmAddNewRoom frmAddNewRoom = new FrmAddNewRoom();
            frmAddNewRoom.ShowDialog();
        }
    }
}
