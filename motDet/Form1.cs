using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;

namespace motDet
{
    public partial class Form1 : Form
    {
        private VideoCaptureDevice videoSource = null;
        private Bitmap lastFrame = null;
        private Bitmap lastFrameNormal = null;
        private Bitmap noMovementFrame = null;
        private string nMovementFrameTaken = null;
        private string lastMovementTaken = "";

        private int framesPerSecondTick = 0;
        private int framesPerSecondActual = 0;
        
        private Rectangle[] blobs = new Rectangle[1];

        private int noMovementTick = 0;
        private int movementTick = 0;
        private int movementTickSeconds = 0;

        private bool recordMovement = false;

        private bool movementOnCamera = false;
        private List<Bitmap[]> movementPics = new List<Bitmap[]>();
        private List<Bitmap[]> movementPicsBackup = new List<Bitmap[]>(); //Backup list of pictures to process
        private string bupinfo = "No backup images";
        private int framesSaved = 0;

        private bool workingPics = false;
        private bool openingFilter = true;
        private bool edgesFilter = true;

        public Form1()
        {
            
            InitializeComponent();
            var pos = this.PointToScreen(fpsLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            fpsLabel.Parent = pictureBox1;
            fpsLabel.Location = pos;
            fpsLabel.BackColor = Color.Transparent;
           // AForge.Imaging.Filters.Threshold filter = new AForge.Imaging.Filters.Threshold(100);
            setUpCamera();
            loadSavedData();

        }
        private void loadSavedData()
        {
            try
            {
            string[] data = System.IO.File.ReadAllText("saveData.txt").Split(' ');
            if (data[0] == "1")
                programSettings.useOpeningFilter = true;
            else
                programSettings.useOpeningFilter = false;

            if (data[1] == "1")
                programSettings.useEdgesFilter = true;
            else
                programSettings.useEdgesFilter = false;

            programSettings.minRequiredBlobSize = new System.Drawing.Point(Convert.ToInt32(data[2]), Convert.ToInt32(data[3]));

            }
            catch (FileLoadException)
            {

            }
        }
        private void saveData()
        {
            string content = "";
            if (programSettings.useOpeningFilter)
                content += "1 ";
            else
                content += "0 ";

            if (programSettings.useEdgesFilter)
                content += "1 ";
            else
                content += "0 ";

            content += programSettings.minRequiredBlobSize.X + " " + programSettings.minRequiredBlobSize.Y;

            System.IO.File.WriteAllText("saveData.txt",content);
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            Bitmap frameOriginal = (Bitmap)frame.Clone();



            AForge.Imaging.Filters.Grayscale filter = new AForge.Imaging.Filters.Grayscale(0.55,0.55,0.55);
            frame = filter.Apply(frame);
          //  AForge.Imaging.Filters.Threshold thresh = new AForge.Imaging.Filters.Threshold(250);
        

            Bitmap savedLastFrame = null;
            Bitmap savedLastFrameNormal = null;
            if (lastFrame != null)
                savedLastFrame = lastFrame;
            if (lastFrameNormal != null)
                savedLastFrameNormal = lastFrameNormal;
            lastFrame = frame;
            lastFrameNormal = frameOriginal;
            //Done converting image

            if (savedLastFrame != null)
            {

                //AForge.Imaging.Filters.Difference difFilter = new AForge.Imaging.Filters.Difference(savedLastFrame);
                //AForge.Imaging.Filters.Threshold thresh = new AForge.Imaging.Filters.Threshold(15);
                //AForge.Imaging.Filters.Erosion3x3 erosion = new AForge.Imaging.Filters.Erosion3x3();



                //frame = difFilter.Apply(frame);
                //frame = thresh.Apply(frame);
                //frame = erosion.Apply(frame);


                //AForge.Imaging.Filters.ExtractChannel exChannel = new AForge.Imaging.Filters.ExtractChannel(RGB.R);
                //Bitmap redChannel = exChannel.Apply(frameOriginal);
                //AForge.Imaging.Filters.Merge mergeFilter = new AForge.Imaging.Filters.Merge();
                //mergeFilter.OverlayImage = frame;
                //frame = mergeFilter.Apply(redChannel);
                //AForge.Imaging.Filters.ReplaceChannel repChannel = new AForge.Imaging.Filters.ReplaceChannel(RGB.R, frame);
                //frame = repChannel.Apply(frameOriginal);
                AForge.Imaging.BlobCounter blobCounter = new AForge.Imaging.BlobCounter();

                blobCounter.BackgroundThreshold = Color.Black;

                AForge.Imaging.Filters.MoveTowards mTowardsFilter = new AForge.Imaging.Filters.MoveTowards();
                mTowardsFilter.OverlayImage = frame;
                Bitmap tmp = null;
                try
                {
                 tmp = mTowardsFilter.Apply(savedLastFrame);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Multiple threads using bitmap resource, may cause problems.");
                    extraThread1.CancelAsync();
                  
                   // throw;  
                }
                savedLastFrameNormal.Dispose();
                savedLastFrameNormal = tmp;
             
                AForge.Imaging.Filters.FiltersSequence processingFilter = new AForge.Imaging.Filters.FiltersSequence();
                processingFilter.Add(new AForge.Imaging.Filters.Difference(savedLastFrame));
                processingFilter.Add(new AForge.Imaging.Filters.Threshold(15));
                if(programSettings.useOpeningFilter)
                processingFilter.Add(new AForge.Imaging.Filters.Opening());
                processingFilter.Add(new AForge.Imaging.Filters.Erosion());
                if(programSettings.useEdgesFilter)
                processingFilter.Add(new AForge.Imaging.Filters.Edges());
                Bitmap tmp1 = processingFilter.Apply(frame);
                savedLastFrame.Dispose();
                blobCounter.ProcessImage(tmp1);
                
                AForge.Imaging.Filters.ExtractChannel exChannel = new AForge.Imaging.Filters.ExtractChannel(RGB.R);
                Bitmap redChannel = exChannel.Apply(frameOriginal);

                AForge.Imaging.Filters.Merge mergeFilter = new AForge.Imaging.Filters.Merge();
                mergeFilter.OverlayImage = tmp1;
                
                Bitmap tmp2 = mergeFilter.Apply(redChannel);

                
                AForge.Imaging.Filters.ReplaceChannel repChannel = new AForge.Imaging.Filters.ReplaceChannel(RGB.R, frame);
                repChannel.ChannelImage = tmp2;
                frame = repChannel.Apply(frameOriginal);

                movementOnCamera = false;
          

                Rectangle[] rects = blobCounter.GetObjectsRectangles();
                Graphics g = Graphics.FromImage(frame);
                bool largeMovement = false;
                    using (Pen pen = new Pen(Color.Red, 2))
                    {
                        int largestWidth = -1;
                        int largestHeight = -1;
                        Rectangle largestRec = new Rectangle(0, 0, 0, 0);
                        foreach (Rectangle rc in rects)
                        {
                            
                            if ((rc.Width > programSettings.minRequiredBlobSize.X) || (rc.Height > programSettings.minRequiredBlobSize.Y))
                            {
                                if (rc.Width > largestWidth && rc.Height > largestHeight)
                                {
                                    largestWidth = rc.Width;
                                    largestHeight = rc.Height;
                                    largestRec = rc;
                                }
                               // g.DrawRectangle(pen, rc);
                                movementOnCamera = true;
                                largeMovement = true;
                                
                            }
                        }
                        g.DrawRectangle(pen, largestRec);
                    }
                    if (recordMovement)
                    {
                        if (largeMovement)
                        {
                            movementTick++;
                            noMovementTick = 0;
                            
                            // ControlPicLabel.Text = "TRUE";
                        }
                        else
                        {
                            if (movementTick > 0)
                                lastMovementTaken = DateTime.Now.ToShortTimeString();
                            noMovementTick++;
                            movementTick = 0;
                            if (noMovementTick >= 50 && !extraThread1.IsBusy)
                            {
                                noMovementFrame = (Bitmap)tmp1.Clone();
                                nMovementFrameTaken = DateTime.Now.ToShortTimeString();
                                noMovementTick = 0;
                            }

                        }

                        if (largeMovement)
                        {
                            if (!extraThread1.IsBusy)
                            {
                                //  (Bitmap)frameOriginal.Clone();
                                Bitmap[] element = new Bitmap[2];
                                element[0] = (Bitmap)frameOriginal.Clone();
                                element[1] = tmp1;
                                movementPics.Add(element);
                            }
                            else
                            {
                                Bitmap[] element = new Bitmap[2];
                                element[0] = (Bitmap)frameOriginal.Clone();
                                element[1] = tmp1;
                                movementPicsBackup.Add(element);
                            }
                        }
                        else
                        {
                            if (!largeMovement && !extraThread1.IsBusy && (movementPics.Count() >= 1 || movementPicsBackup.Count >= 1) && noMovementTick >= 30)
                            {
                                if (movementPicsBackup.Count() > 0)
                                {
                                    movementPics.AddRange(movementPicsBackup);
                                    movementPicsBackup.Clear();                   
                                }

                                workingPics = true;
                                extraThread1.RunWorkerAsync();
                            }
                        }
                    }

                g.Dispose();

            
            }
            
            pictureBox1.Image = frame;
            framesPerSecondTick++;
        }

        private void setUpCamera()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
      
           // videoSource.DesiredFrameSize = new Size(160, 120);
            //videoSource.DesiredFrameRate = 10;
            videoSource.SimulateTrigger();
            videoSource.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSource.Stop();
            saveData();
            extraThread1.CancelAsync();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         //   pictureBox1.Refresh();
            if (movementPicsBackup.Count() > 0)
            {
                bupinfo = "Backup images stored!\n" + movementPicsBackup.Count() + " images waiting to process";
            }
            else
                bupinfo = "Backup array ready.";
            backupInfo.Text = bupinfo;

            if (!recordMotionBox.Checked)
                ControlPicLabel.Visible = false;
            else
                ControlPicLabel.Visible = true;

            if (noMovementFrame != null)
                ControlPicLabel.Text = "Control Image Set!\n" + nMovementFrameTaken;
            else if (movementOnCamera)
                ControlPicLabel.Text = "No Control Image!\nToo much movement!";
            else
                ControlPicLabel.Text = "No Control Image!\nRecent movement!";

            if (workingPics)
            {
                infoLabel.Text = "Processing Movement Frames...";
                infoLabel2.Text = "Remaining: " + movementPics.Count().ToString();
                infoLabel2.Text += "\nSaved: " + framesSaved.ToString();
            }
            else
            {
                infoLabel.Text = "Not Processing Frames";
                infoLabel2.Text = "";
            }

            infoLabel3.Text = "Last recorded movement:\n" + lastMovementTaken;
        }

        private void recordMotionBox_CheckStateChanged(object sender, EventArgs e)
        {
            recordMovement = recordMotionBox.Checked;
        }

        private void camSettings_Click(object sender, EventArgs e)
        {
            videoSource.DisplayPropertyPage(Handle);
        }

        private void extraThread1_DoWork(object sender, DoWorkEventArgs e)
        {
            int processBatchSize = 5;
            if (framesPerSecondActual > 5)
                processBatchSize = framesPerSecondActual;
            if (movementPics.Count() == 1)
            {
                string title = DateTime.Now.ToString().Replace(' ', '_').Replace(':', '.').Replace('/', '.') + ".bmp";
                movementPics[0][0].Save(title);
                movementPics.Clear();
            }
            else if(noMovementFrame == null)
            {
                //int picNum = 0;
                //foreach (Bitmap[] pic in movementPics)
                //{
                //    string title = DateTime.Now.ToString().Replace(' ', '_').Replace(':', '.').Replace('/', '.') + picNum.ToString() + ".bmp";
                //    Bitmap picture = (Bitmap)pic[0].Clone();
                //    picture.Save(title);
                //    picNum++;
                //}
                movementPics.Clear();
            }
            else
            {
            
             
                int count = 0;
                Start:
                int highestDif = -1;
                Bitmap highestDifPic = movementPics[0][0];
                foreach (Bitmap[] pic in movementPics)
                {
                    int difPixels = 0;
                    count++;
                    for (int x = 0; x < pic[1].Width; x++)
                    {
                        for (int y = 0; y < pic[1].Height; y++)
                        {
                            if (Math.Abs(pic[1].GetPixel(x, y).GetBrightness() - noMovementFrame.GetPixel(x, y).GetBrightness()) >= 1)
                            {
                                difPixels++;
                            }
                        }
                    }
                    if (difPixels > highestDif)
                    {
                        highestDif = difPixels;
                        highestDifPic = pic[0];                       
                    }
                    if (count >= processBatchSize)
                    {
                        break;
                    }
                }
                string title = DateTime.Now.ToString().Replace(' ', '_').Replace(':', '.').Replace('/', '.') + ".bmp";
                highestDifPic.Save(title);
                framesSaved++;
                if (count >= processBatchSize)
                {

                    movementPics.RemoveRange(0, processBatchSize);
                    count = 0;
                    if(movementPics.Count() > 0)
                    goto Start;
                }
                else
                {
                  
                    movementPics.Clear();
                }
                framesSaved = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void extraThread1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            workingPics = false;
        }

        private void gridBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            framesPerSecondActual = framesPerSecondTick;
            framesPerSecondTick = 0;

            if (movementOnCamera)
                movementTickSeconds++;
            else
                movementTickSeconds = 0;


            fpsLabel.Text = framesPerSecondActual.ToString() + " FPS";
            if (movementTickSeconds > 0)
                fpsLabel.Text += "\nMovement detected!\n" + movementTickSeconds.ToString() + " seconds";
        }

        private void programSettingsButton_Click(object sender, EventArgs e)
        {
            programSettings settingsWindow = new programSettings(lastFrameNormal);
            settingsWindow.Show();
        }


     
    }
}
