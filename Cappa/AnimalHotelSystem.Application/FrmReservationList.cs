using AnimalHotelSystem.Application.Services;
using AnimalHotelSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AnimalHotelSystem.Application
{
    public partial class FrmReservationList : Form
    {
        ReservationService reservationService = new ReservationService();
        public FrmReservationList()
        {
            InitializeComponent();

            List<Reservation> allReservationsList = reservationService.GetAllReservations();
            List<string> reservationInputData = new List<string>(); 
            foreach (var reservation in allReservationsList)
            {
                var toysFromReservationString = string.Join(", ", reservation.Toys.Select(t => t.Name));
                reservationInputData.Add(reservation.Animal.Name
                    + "                 "
                    + reservation.FromDate.ToString("dd/MM/yyyy")
                    + "         "
                    + reservation.ToDate.ToString("dd/MM/yyyy")
                    + "          "
                    + toysFromReservationString);
            }

            listBox1.DataSource = reservationInputData;
        }

        private void close_click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class FormListReservations
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Animal Animal { get; set; }
        public List<Toy> Toys { get; set; } = new List<Toy>();
    }
}
