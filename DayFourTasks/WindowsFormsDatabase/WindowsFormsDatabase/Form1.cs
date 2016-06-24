﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDatabase
{
    public partial class Form1 : Form
    {
        List<Customer> listCustomers = new List<Customer>();
        int customerListIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void buttonDisplayAll_Click(object sender, EventArgs e)
        {
            using (TestDBEntities myEntities = new TestDBEntities())
            {
                var customers = from customer in myEntities.Customers
                                select customer;
                listCustomers = customers.ToList();
            }
            DisplayCustomer(customerListIndex);
        }
        private void buttonDisplayNext_Click(object sender, EventArgs e)
        {
            customerListIndex++;
            if (customerListIndex >= listCustomers.Count)
            {
                customerListIndex = 0;
            }
            DisplayCustomer(customerListIndex);
        }
        private void buttonDisplayPrevious_Click(object sender, EventArgs e)
        {
            customerListIndex--;
            if (customerListIndex < 0)
            {
                customerListIndex = listCustomers.Count - 1;
            }
            DisplayCustomer(customerListIndex);
        }
        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            using (var myEntities = new TestDBEntities())
            {
                Customer addedCustomer = new Customer();
                addedCustomer.Name = textBoxName.Text;
                addedCustomer.Address = textBoxAddress.Text;
                addedCustomer.City = textBoxCity.Text;
                addedCustomer.Postcode = textBoxPostcode.Text;
                addedCustomer.Phone = textBoxPhoneNumber.Text;
                //var lastRecord = (from myRecord in myEntities.Customers
                //                  orderby myRecord.Id descending
                //                  select myRecord).First();
                //addedCustomer.Id = (int)lastRecord.Id + 1;
                //myEntities.Configuration.AutoDetectChangesEnabled = true;
                myEntities.Customers.Add(addedCustomer);
                myEntities.SaveChanges();
            }
        }
        private void buttonChangeRecord_Click(object sender, EventArgs e)
        {
        }
        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
        }
        private void DisplayCustomer(int customerId)
        {
            if (listCustomers[customerId] != null)
            {
                textBoxName.Text = listCustomers[customerId].Name;
                textBoxAddress.Text = listCustomers[customerId].Address;
                textBoxCity.Text = listCustomers[customerId].City;
                textBoxPostcode.Text = listCustomers[customerId].Postcode;
                textBoxPhoneNumber.Text = listCustomers[customerId].Phone;
            }
        }
    }
}