using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLite;

namespace GuessWho.Models
{
	public class Person : INotifyPropertyChanged
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		private string name, sex, hairColor, eyeColor;
		private bool wearsGlasses;
		public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public string Sex
        {
            get { return sex; }
            set
            {
                if (sex != value)
                {
                    sex = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Sex"));
                }
            }
        }

        public string HairColor
        {
            get { return hairColor; }
            set
            {
                if (hairColor != value)
                {
                    hairColor = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("HairColor"));
                }
            }
        }

        public string EyeColor
        {
            get { return eyeColor; }
            set
            {
                if (eyeColor != value)
                {
                    eyeColor = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("EyeColor"));
                }
            }
        }

        public bool WearsGlasses
        {
            get { return wearsGlasses; }
            set
            {
                if (wearsGlasses != value)
                {
                    wearsGlasses = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("WearsGlasses"));
                }
            }
        }

        public string ImageUrl { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

