using System;
using System.IO;

/**
* @author Sami Jenedi
* Class Student represents a college student. User can pay tuition.
*/

namespace SISProject
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set; }
        public decimal TuitionBalance { get; set; }
        public double Gpa { get; set; }

        public Student(string FName,string LName,string SId
          ,decimal TBalance,double Gp)
        {
            FirstName = FName;
            LastName = LName;
            StudentId = SId;
            TuitionBalance = TBalance;
            Gpa = Gp;
        }

     /**
     * MakePayment deducts the tuition balance by that amount.
     * @param Payment receives a payment. */
    public void MakePayment(decimal Payment)
        {
            TuitionBalance = TuitionBalance - Payment;
        }

    public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4:F}",FirstName,LastName
              ,StudentId,TuitionBalance,Gpa);
        }

    /**
    * Store writes the student’s property values to the output file stream.
    * @param outFile stores an opened output file stream. */
    public void Store(string outFile)
        {
            FileStream fSteram = new FileStream(outFile, FileMode.Append);
            StreamWriter OutFile = new StreamWriter(fSteram);
            OutFile.WriteLine(ToString());
            OutFile.Close();
            fSteram.Close();
        }
    }
}
