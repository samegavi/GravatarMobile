﻿using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GravatarMobile.Core;
using System.Diagnostics;

namespace GravatarMobile_iOS.ViewControllers
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController() : base("MainViewController", null)
        {
            this.Title = "Gravatar Sample";
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            edtEmail.Text = @"newky2k@mac.com";

            edtEmail.EditingDidEndOnExit += (object sender, EventArgs e) =>
            {

            };

			
            btnGo.TouchUpInside += (object sender, EventArgs e) =>
            {
				try
				{
					this.View.EndEditing(true);

					imgGravatar.Avatar = new Gravatar(edtEmail.Text);
				}
				catch (Exception ex)
				{
					var alt = new UIAlertView("Error", ex.Message, null,"OK");
					alt.Show();
				}
                

            };

            btnCircle.TouchUpInside += (object sender, EventArgs e) =>
            {
				this.View.EndEditing(true);
                imgGravatar.ViewStyle = GravatarMobile.Core.Data.Enums.GravatarViewStyle.Round;
            };

            btnSquare.TouchUpInside += (object sender, EventArgs e) =>
            {
				this.View.EndEditing(true);
                imgGravatar.ViewStyle = GravatarMobile.Core.Data.Enums.GravatarViewStyle.Square;
            };

                
        }
    }
}
