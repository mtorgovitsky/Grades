using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTarcker : IGradeTracker
    {
        public event NameChangedDelegate NameChanged; //<-- EVENT Declaration
        //public delegate NameChangedDelegate NameChanged; //<-- DELEGATE Declaration

        protected string _name;
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

        public abstract IEnumerator GetEnumerator();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs() { ExistingName = _name, NewName = value };

                    NameChanged(this, args);
                }

                _name = value;
            }
        }
    }
}
