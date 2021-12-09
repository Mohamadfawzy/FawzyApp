using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.AudioRecorder;
using Xamarin.Essentials;
using System.IO;

namespace FawzyApp.Views.GalleryPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormView3 : StackLayout
    {
        AudioRecorderService recorder;
        AudioPlayer player;
        string localPath = "";

        public List<string> ListVoice { get; set; } = new List<string>();
        public FormView3()
        {
            InitializeComponent();

            localPath = FileSystem.AppDataDirectory;
            recorder = new AudioRecorderService
            {
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(30),
                AudioSilenceTimeout = TimeSpan.FromSeconds(10)
            };

            player = new AudioPlayer();
            player.FinishedPlaying += Player_FinishedPlaying;

            GetAllFilseName();


        }


        async void Record_Clicked(object sender, EventArgs e)
        {

            var status = await Permissions.RequestAsync<Permissions.Microphone>();
            if (status != PermissionStatus.Granted) return;


            await RecordAudio();
        }

        async Task RecordAudio()
        {
            try
            {
                if (!recorder.IsRecording) //Record button clicked
                {
                    recorder.StopRecordingOnSilence = TimeoutSwitch.IsToggled;

                    RecordButton.IsEnabled = false;
                    PlayButton.IsEnabled = false;

                    //start recording audio
                    var audioRecordTask = await recorder.StartRecording();

                    RecordButton.Text = "Stop Recording";
                    RecordButton.IsEnabled = true;

                    await audioRecordTask;

                    RecordButton.Text = "Record";
                    PlayButton.IsEnabled = true;
                }
                else //Stop button clicked
                {
                    RecordButton.IsEnabled = false;

                    //stop the recording...
                    await recorder.StopRecording();

                    RecordButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                //blow up the app!
                throw ex;
            }
        }

        void Play_Clicked(object sender, EventArgs e)
        {
            PlayAudio();
        }

        void PlayAudio()
        {
            try
            {
                var filePath = recorder.GetAudioFilePath();

                //cachedStream = new MemoryStream(File.ReadAllBytes(filePath));
                //FileStream file = new FileStream(localPath, FileMode.Create, FileAccess.Write);
                //cachedStream.WriteTo(file);
                //file.Close();
                //cachedStream.Close();

                //var filePath = localPath;
                if (filePath != null)
                {
                    PlayButton.IsEnabled = false;
                    RecordButton.IsEnabled = false;

                    player.Play(filePath);
                }

            }
            catch (Exception ex)
            {
                //blow up the app!
                throw ex;
            }
        }

        void Player_FinishedPlaying(object sender, EventArgs e)
        {
            PlayButton.IsEnabled = true;
            RecordButton.IsEnabled = true;
        }

        // moved
        private MemoryStream cachedStream;
        private void SaveVoice_Clicked(object sender, EventArgs e)
        {
            var fullPath = Path.Combine(localPath, "FawzyVoices");
            var filePath = recorder.GetAudioFilePath();
            var fileName = "voice" + Guid.NewGuid();

            DirectoryInfo dir = new DirectoryInfo(fullPath);
            dir.Create();

            cachedStream = new MemoryStream(File.ReadAllBytes(filePath));
            FileStream file = new FileStream(Path.Combine(fullPath, fileName), FileMode.Create, FileAccess.Write);
            cachedStream.WriteTo(file);
            file.Close();
            cachedStream.Close();

            OnPropertyChanged("collectionVoice");

        }
        string CurrentVoice = "";
        private void PlayVoice_Clicked(object s, EventArgs e)
        {
            var fullPath = Path.Combine(localPath, "FawzyVoices");
            DirectoryInfo dir = new DirectoryInfo(fullPath);

            if (!string.IsNullOrEmpty(CurrentVoice))
            {
                // var files = dir.GetFiles();
                var voice = Path.Combine(fullPath, CurrentVoice);
                player.Play(voice);
            }
            //
            //voiceFullName = file.FullName;
        }

        private void collectionVoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentVoice = e.CurrentSelection.FirstOrDefault().ToString();
        }


        private Task<bool> GetAllFilseName()
        {
            try
            {
                var fullPath = Path.Combine(localPath, "FawzyVoices");
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                var listFiles = dir.GetFiles();

                foreach (var voiceName in listFiles)
                {
                    ListVoice.Add(voiceName.Name);
                }
                collectionVoice.ItemsSource = ListVoice;
                OnPropertyChanged("collectionVoice");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Task.FromResult(true);
        }
    }
}