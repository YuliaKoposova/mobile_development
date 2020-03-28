using System;
using System.IO;
using System.Globalization;

namespace Mobile_device_managment {
    class Program {
        static void Main() {
            Parsing parsing = new Parsing();
            double sumCallOut = 0;
            double sumCallIn = 0;
            int sumSms = 0;
            parsing.CreateArray();
            parsing.GetValues(ref sumCallOut, ref sumCallIn, ref sumSms);
            Tariff tariff = new Tariff();
            tariff.Charging(sumCallOut, sumCallIn, sumSms);
        }
    }

    class Parsing {
        string[] CDR = File.ReadAllLines("data.csv");
        string abonent = "933156729";
        string[] row;
        string[,] abonentRecords = new string[10, 10];
        int recordsCounter = 0;

        public void CreateArray() {
            for (int i = 0; i < CDR.Length; i++) {
                if (CDR[i].Contains(abonent)) {
                    row = CDR[i].Split(',');
                    for (int j = 0; j < row.Length; j++) {
                        abonentRecords[recordsCounter, j] = row[j];
                    }
                    recordsCounter++;
                }
            }
        }

        public void GetValues(ref double sumCallOut, ref double sumCallIn, ref int sumSms) {
            CultureInfo _invert = CultureInfo.InvariantCulture;

            for (int i = 0; i < recordsCounter; i++) {
                if (abonentRecords[i, 1] == abonent) {
                    sumCallOut += Convert.ToDouble(abonentRecords[i, 3], _invert);
                    sumSms += Convert.ToInt32(abonentRecords[i, 4]);
                }
                if (abonentRecords[i, 2] == abonent) {
                    sumCallIn += Convert.ToDouble(abonentRecords[i, 3], _invert);
                }
            }
        }
    }

    class Tariff {
        public void Charging(double sumCallOut, double sumCallIn, int sumSms) {
            double kOut = 2;
            double freeOut = 20;
            double kIn = 0;
            double kSms = 2;
            double X = sumCallIn * kIn + (sumCallOut - freeOut) * kOut;
            double Y = sumSms * kSms;
            double all = X + Y;
            Console.WriteLine($"всего:{all}/ телефон: {X}/ смс: {Y}");
        }
    }
}
