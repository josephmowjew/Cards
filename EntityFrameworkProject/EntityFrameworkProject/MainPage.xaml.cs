
using ContactModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EntityFrameworkProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void findByNameClick(object sender, RoutedEventArgs e)
        {
            // check if the name field isnt blank and then search for the name in the database
            if(!String.IsNullOrEmpty(name.Text))
            {
                using (var db = new ContactContext())
                {
                    //search for the name in the contact table

                    var contact = db.Contact.FirstOrDefault(c => c.Name == name.Text);

                    if(contact != null)
                    {
                        //get the corresponding phoneNumber and place it in the phoneNumber field

                        phoneNumber.Text = contact.Phone.ToString();
                    }
                }
            }

        }

        private void findByPhoneNumberClick(object sender, RoutedEventArgs e)
        {
            // check if the name field isnt blank and then search for the name in the database
            if (!String.IsNullOrEmpty(phoneNumber.Text))
            {
                using (var db = new ContactContext())
                {
                    //search for the name in the contact table

                    var contact = db.Contact.FirstOrDefault(c => c.Phone == phoneNumber.Text);

                    if (contact != null)
                    {
                        //get the corresponding phoneNumber and place it in the phoneNumber field

                        name.Text = contact.Name.ToString();
                    }
                }
            }
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(phoneNumber.Text))
            {
                //create a new contact

                using (var db = new ContactContext())
                {
                    ContactModel.Contact newContact = new ContactModel.Contact() { Name= name.Text, Phone= phoneNumber.Text };

                    //check if the contatct is already in the database

                    var searchContact = db.Contact.FirstOrDefault(c => c.Phone == phoneNumber.Text.ToLower());

                    //only add the new contact if an existing contact having the same number isn't avaiable 
                    if(searchContact == null)
                    {
                        db.Contact.Add(newContact);
                        db.SaveChanges();
                       
                    }
                    else
                    {
                        var message = new MessageDialog("The contact you are trying to add is already in the phonebook").ShowAsync();
                    }
                   

                }
            }
        }
    }
}
