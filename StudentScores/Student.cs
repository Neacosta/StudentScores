using System;
using System.Collections.Generic;
namespace StudentScores
{
    public class Student
    {
        private char sep = '|';

        public string Name
        {
            get;
            set;
            
        }
        public IList<double> Scores
        {
            get;
            set;
        } = new List<double>();

        public Student(string studentAndScores)
        {
            var columns = studentAndScores.Split(sep);
            Name = columns[0];

            for (int i = 1; i < columns.Length; ++i)
            {
                if (columns[i] != string.Empty)
                {
                    Scores.Add(Convert.ToDouble(columns[i]));
                }

            }
            
        }

        public Student Clone()
        {
            var student = new Student("");
            student.Name = Name;
            foreach(double score in Scores)
            {
                student.Scores.Add(score);  
            }
            return student;
        }

        public int ScoreCount => Scores.Count;
        public double ScoreTotal
        {
            get
            {
                var total = 0.0;
                foreach(double score in Scores)
                {
                    total += score;
                }
                return total;
            }
        }

        public double ScoreAverage
        {
            get
            {
                var average = 0.0;
                if (ScoreTotal > 0)
                {
                    average = ScoreTotal / ScoreCount;
                }
                return average;
            }

        }
        public string GetScoresString()
        {
            var scoresString = string.Empty;
            foreach (double score in Scores)
            {
                scoresString += sep.ToString() + score;
            }
            return scoresString;
        }
        public override string ToString() => Name + GetScoresString();
      
            
        



    }
}