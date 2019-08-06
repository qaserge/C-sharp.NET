﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Day09CustomDialog
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        Friend currentlyEditedFriends;

        public AddEditDialog(Window owner, Friend friend = null)
        {
            Owner = owner;
            currentlyEditedFriends = friend;            
            InitializeComponent();
            btAddUpdate.Content = friend == null ? "Add friend" : "Update friend";
            if (friend!=null)
            {
                tbName.Text = friend.Name;
                tbAge.Text = friend.Age + "";
            }

        }

        private void AddUpdate_ButtonClick(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);

            if (currentlyEditedFriends != null)
            {
                // update
                currentlyEditedFriends.Name = name;
                currentlyEditedFriends.Age = age;
            }
            else
            {
                //add
                Friend friend = new Friend() { Name = name, Age = age }; // todo try parse
                Globals.friendsList.Add(friend);
            }            
            DialogResult = true; // close dialog with sucsess
        }
    }
}
