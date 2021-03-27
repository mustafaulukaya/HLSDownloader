using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLSDownloader
{
    public partial class Form1 : Form
    {
        private List<Segment> segments = new List<Segment>();
        private static List<Thread> threads = new List<Thread>();
        private WebClient client;
        private string baseUrl;


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            client = new WebClient();
        }


        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusLabel("STARTED");
                var mediaUrl = mediaUrlTextBox.Text;
                var splittedMediUrl = mediaUrl.Split('/');

                for (var i = 0; i < splittedMediUrl.Length - 1; i++)
                {
                    var s = splittedMediUrl[i];
                    baseUrl += s + "/";
                }

                var manifest = client.DownloadString(mediaUrl);

                var regex = new Regex("#EXTINF:.*");

                var tempSegments = regex.Split(manifest).ToList();
                tempSegments.RemoveAt(0);

                var index = 0;
                foreach (var tempSegment in tempSegments)
                {
                    var segment = tempSegment.Replace("\n", "");
                    segments.Add(new Segment()
                    {
                        Index = index,
                        Url = segment
                    });

                    index++;
                }


                progressBar.Minimum = 0;
                progressBar.Maximum = segments.Count;
                progressBar.Step = 1;

                if (threadCountNumericUpDown.Value <= 0)
                {
                    MessageBox.Show("Thread Sayısı 0 dan az veya 10 dan fazla olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (threadCountNumericUpDown.Value > segments.Count)
                        threadCountNumericUpDown.Value = segments.Count;

                    for (var i = 0; i < threadCountNumericUpDown.Value; i++)
                    {
                        DownloadData();
                    }
                }

            }
            catch (Exception)
            {
                SetStatusLabel("ERROR");
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void SetStatusLabel(string status)
        {
            statusLabel.Text = status;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void SetPercentLabel(double percent)
        {
            downloadPercent.Text = "%" + percent.ToString();
        }

        private void UpdateSegments()
        {
            var segment = segments.First(op => !op.IsDownloadStarted && !op.IsFinished);

            while (segment != null && IsChunkDownloaded(segment.Index))
            {
                segments.Remove(segment);
                PerformStep();
                CalculatePercent();
                segment = segments.First(op => !op.IsDownloadStarted && !op.IsFinished);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private Segment GetSegment()
        {
            var segment = segments.First(op => !op.IsDownloadStarted && !op.IsFinished);
            segments.Remove(segment);
            segment.IsDownloadStarted = true;
            segments.Add(segment);
            return segment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void SetSegmentCompleted(Segment segment)
        {
            var _segment = segments.First(op => op.Index == segment.Index);
            segments.Remove(_segment);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void PerformStep()
        {
            progressBar.PerformStep();
        }

        private void DownloadData()
        {
            UpdateSegments();


            Thread bgThread = new Thread(() =>
            {
                try
                {
                    var segment = GetSegment();
                    do
                    {
                        if (segment != null)
                        {
                            using (WebClient client = new WebClient())
                            {
                                var segmentFileUrl = baseUrl + segment.Url;
                                var tempData = client.DownloadData(segmentFileUrl);
                                SaveChunk(tempData, segment.Index);
                                PerformStep();
                                CalculatePercent();
                                SetSegmentCompleted(segment);
                            }

                            segment = GetSegment();
                        }

                    } while (segment != null);
                }
                catch (Exception ex)
                {
                    SetStatusLabel("ERROR (" + ex.Message + ")");
                }
            });
            threads.Add(bgThread);
            bgThread.Start();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void CalculatePercent(bool isFileUnion = false)
        {
            threadCountNumericUpDown.Value = threads.Count;
            double value = (100 * progressBar.Value) / progressBar.Maximum;
            SetPercentLabel(value);
            if (progressBar.Value == progressBar.Maximum && !isFileUnion)
                DownloadCompleted();
        }

        private bool IsDownloadStarted()
        {
            var directory = Directory.GetCurrentDirectory() + "/chunks/" + baseUrl.ComputeSha256Hash();
            return Directory.Exists(directory);
        }

        private bool IsChunkDownloaded(int index)
        {
            var directory = Directory.GetCurrentDirectory() + "/chunks/" + baseUrl.ComputeSha256Hash();

            if (!Directory.Exists(directory))
                return false;

            var path = directory + "/" + index + ".ts";

            return File.Exists(path);
        }

        private void SaveChunk(byte[] data, int index)
        {
            var directory = Directory.GetCurrentDirectory() + "/chunks/" + baseUrl.ComputeSha256Hash();

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var path = directory + "/" + index + ".ts";
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        private void DownloadCompleted()
        {
            progressBar.Value = 0;
            var path = Directory.GetCurrentDirectory() + "/" + baseUrl.ComputeSha256Hash() + ".ts";

            FileStream fs = new FileStream(path, FileMode.Create);

            var directory = Directory.GetCurrentDirectory() + "/chunks/" + baseUrl.ComputeSha256Hash();

            for (var index = 0; index < Directory.GetFiles(directory).Length; index++)
            {
                byte[] buffer = File.ReadAllBytes(directory + "/" + index + ".ts");
                fs.Write(buffer, 0, buffer.Length);
                PerformStep();
                CalculatePercent(true);
            }

            Directory.Delete(directory,true);

            try
            {
                fs.Close();
                SetStatusLabel("FINISHED & SAVED");
                MessageBox.Show($"Dosya {path} yoluna kaydedildi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya diske kaydedilirken hata oluştu.", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            finally
            {
                progressBar.Value = 0;
                segments.Clear();
                foreach (var thread in threads)
                {
                    thread.Abort();
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            threadCountNumericUpDown.Value = 1;
            mediaUrlTextBox.Text = "";
            progressBar.Value = 0;
            segments.Clear();
            foreach (var thread in threads)
            {
                thread.Abort();
            }
        }

        private void button_union_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            var chunkName = textBox_chunkName.Text;
            var path = Directory.GetCurrentDirectory() + "/" + chunkName + ".ts";

            FileStream fs = new FileStream(path, FileMode.Create);

            var directory = Directory.GetCurrentDirectory() + "/chunks/" + chunkName;

            var fileCount = Directory.GetFiles(directory).Length;
            progressBar.Maximum = fileCount;
            for (var index = 0; index < fileCount; index++)
            {
                byte[] buffer = File.ReadAllBytes(directory + "/" + index + ".ts");
                fs.Write(buffer, 0, buffer.Length);
                PerformStep();
                CalculatePercent(true);
            }

            Directory.Delete(directory, true);

            try
            {
                fs.Close();
                SetStatusLabel("FINISHED & SAVED");
                MessageBox.Show($"Dosya {path} yoluna kaydedildi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya diske kaydedilirken hata oluştu.", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            finally
            {
                progressBar.Value = 0;
            }
        }
    }

    public class Segment
    {
        public string Url { get; set; }
        public int Index { get; set; }
        public bool IsDownloadStarted { get; set; } = false;
        public bool IsFinished { get; set; } = false;
    }

    public static class StringExtensions
    {
        public static string ComputeSha256Hash(this string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
