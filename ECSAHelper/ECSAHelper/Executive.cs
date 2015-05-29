using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSAHelper
{
    /// <summary>
    /// A class representing an ECSA Executive, and all the contact info displayed on the website.
    /// </summary>
    public class Executive
    {
        /// <summary>
        /// Default constructor sets position to New Position
        /// </summary>
        public Executive()
        {
            this.position = "New Position";
            this.SetImageUrl();
        }

        /// <summary>
        /// Constructor with a given position
        /// </summary>
        /// <param name="position">
        /// The name of the position for this Executive
        /// </param>
        public Executive(string position)
        {
            this.position = position;
            this.SetImageUrl();
        }

        /// <summary>
        /// The name for this Executive's position. ex: President, Vice President Finance, etc.
        /// </summary>
        [DisplayName("Position")]
        [Category("Executive Info")]
        public string position { get; set; }

        /// <summary>
        /// The full name of the person elected as this Executive
        /// </summary>
        [DisplayName("Full Name")]
        [Category("Executive Info")]
        public string fullName { get; set; }

        /// <summary>
        /// The contact email of this Executive. ex: presidentofecsa@gmail.com
        /// </summary>
        [DisplayName("Email")]
        [Category("Executive Info")]
        public string email { get; set; }

        /// <summary>
        /// A biography of this Executive
        /// </summary>
        [DisplayName("Biography")]
        [Category("Executive Info")]
        public string bio { get; set; }

        /// <summary>
        /// The URL for the picture of this Executive
        /// </summary>
        /// <remarks>
        /// This should usually be 'img/PICTURE.jpg' where PICTURE
        /// is the position of this executive. This is where the AngularJS of the website expects to find the pictures
        /// to display.
        /// </remarks>
        [Browsable(false)]
        public string imageUrl { get; set; }

        /// <summary>
        /// Will set the image URL property for this Executive.
        /// </summary>
        /// <remarks>
        /// The filename for this Executive is just its Position without whitespace.
        /// </remarks>
        public void SetImageUrl()
        {
            this.imageUrl = "img/" + this.GetImageFileName() + ".jpg";
        }

        /// <summary>
        /// Gets the image file name for this Executive, which is just its Position without whitespace
        /// </summary>
        /// <returns>
        /// The image file name for this Executive
        /// </returns>
        public string GetImageFileName()
        {
            return position.Replace(" ", string.Empty);
        }

        /// <summary>
        /// Returns a string representation of this Executive, which is just its Position
        /// </summary>
        /// <returns>
        /// This Executive's Position.
        /// </returns>
        public override string ToString()
        {
            return this.position.ToString();
        }
    }
}
