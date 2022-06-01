using AnimalHotelSystem.Application.Services;
using AnimalHotelSystem.Model;
using AnimalHotelSystem.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AnimalHotelSystem.Application
{
    public partial class FrmNewReservation : Form
    {
        private ReservationService reservationService = new ReservationService();
        private ToyService toyService = new ToyService();
        private RoomService roomService = new RoomService();
        public FormNewReservation reservationData = new FormNewReservation();
        public FormAnimal animalData = new FormAnimal();
        private List<Animal> allAnimals = new List<Animal>();
        private List<Toy> allToys = new List<Toy>();
        private List<Room> allFreeRooms = new List<Room>();

        public FrmNewReservation()
        {
            InitializeComponent();
            listBox1.DataSource = Enum.GetValues(typeof(TypeOfAnimal));
            allAnimals = reservationService.GetAllAnimals();
            listBox2.DataSource = allAnimals.Select(x => x.Name + "    Owners: " + x.OwnerName + " " + x.OwnerSurname)
                .ToList();
            allToys = toyService.GetAllToys();
        }

        private void addNewAnimal_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;
            groupBox1.Enabled = false;
        }

        private void findAnimalInData_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox1.Enabled = false;
        }

        private void SaveNewAnimal_Click(object sender, EventArgs e)
        {
            animalData.Name = textBox3.Text;
            animalData.Height = (int)numericUpDown3.Value;
            animalData.Length = (int)numericUpDown2.Value;
            animalData.Weight = (int)numericUpDown4.Value;
            animalData.Age = (int)numericUpDown1.Value;
            animalData.OwnerName = textBox1.Text;
            animalData.OwnerSurname = textBox2.Text;
            animalData.Alergies = textBox9.Text;
            animalData.Type = (TypeOfAnimal)listBox1.SelectedItem;
            

            bool excHappend = false;
            try
            {
                var animalId = reservationService.AddNewAnimal(animalData);
                reservationData.AnimalId = animalId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se graška prilikom dodavanja nove životinje: \n" + ex.Message, "", MessageBoxButtons.OK);
                excHappend = true;
            }

            if (!excHappend)
            {
                groupBox2.Enabled = false;
                listBox3.DataSource = allToys
                    .FindAll(x => x.TypeOfAnimal == (TypeOfAnimal)listBox1.SelectedItem)
                    .Select(x => x.Name).ToList();

                allFreeRooms = roomService.GetAllRoomsThatAreFree(dateTimePicker1.Value, dateTimePicker2.Value);
                listBox4.DataSource = allFreeRooms.FindAll(r => r.AnimalType == animalData.Type)
                    .Select(r => r.RoomNumber)
                    .ToList();

                groupBox4.Visible = true;
                button3.Visible = true;
            
                groupBox6.Visible = true;
            }
     
        }



        private void pickedAnimalFromBase_Click(object sender, EventArgs e)
        {
            var animal = allAnimals[listBox2.SelectedIndex];
            reservationData.AnimalId = animal.Id;

            listBox3.DataSource = allToys
                .FindAll(x => x.TypeOfAnimal == animal.Type)
                .Select(x => x.Name).ToList();

            allFreeRooms = roomService.GetAllRoomsThatAreFree(dateTimePicker1.Value, dateTimePicker2.Value);
            listBox4.DataSource = allFreeRooms.FindAll(r => r.AnimalType == animal.Type)
                .Select(r => r.RoomNumber)
                .ToList();

            groupBox4.Visible = true;
            button3.Visible = true;
            groupBox3.Enabled = false;
            groupBox6.Visible = true;
        }

        private void saveNewReservation_click(object sender, EventArgs e)
        {
            reservationData.FromDate = dateTimePicker1.Value;
            reservationData.ToDate = dateTimePicker2.Value;
            foreach (var i in listBox3.SelectedItems)
            {
                var selectedToy = allToys.FindLast(x => x.Name == (string)i);
                reservationData.ToyIds.Add(selectedToy.Id);
            }
            reservationData.RoomId = allFreeRooms[listBox4.SelectedIndex].Id;

            bool excHappend = false;
            try
            {
                reservationService.CreateRoomReservation(reservationData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se graška prilikom dodavanja nove rezervacije: \n" + ex.Message, "", MessageBoxButtons.OK);
                excHappend = true;
            }

            if (!excHappend)
            {
                Close();
            }
            

            
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class FormNewReservation
    {
        public int RoomId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int AnimalId { get; set; }

        public List<int> ToyIds { get; set; } = new List<int>();
    }

    public class FormAnimal
    {
        public TypeOfAnimal Type { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Alergies { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
    }

}
