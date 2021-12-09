using FawzyApp.ViewModels;
using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.ObjectModel;
namespace FawzyApp.Views.GalleryPages.ViewModels
{
    public class FormView3VM : BaseViewModel
    {
        AudioRecorderService recorder;
        AudioPlayer player;
        string localPath = "";
        //
        public bool RecordButtonIsEnabled = false;
        public bool PlayButtonIsEnabled = false;
        public string RecordButtonText = "";
        //
        public ObservableCollection<string> ListVoice { get; set; } 
        public ICommand SaveVoice_ClickedCommand => new Command(ExcuteSaveVoice_Clicked);
        public ICommand PlayVoice_ClickedCommand => new Command(ExcutePlayVoice_Clicked);
        public ICommand collectionVoice_SelectionChangedCommand => new Command<string>(collectionVoice_SelectionChanged);
        public FormView3VM()
        {
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
                    recorder.StopRecordingOnSilence = true;

                    RecordButtonIsEnabled = false;
                    PlayButtonIsEnabled = false;

                    //start recording audio
                    var audioRecordTask = await recorder.StartRecording();

                    RecordButtonText = "Stop Recording";
                    RecordButtonIsEnabled = true;

                    await audioRecordTask;

                    RecordButtonText = "Record";
                    PlayButtonIsEnabled = true;
                }
                else //Stop button clicked
                {
                    RecordButtonIsEnabled = false;

                    //stop the recording...
                    await recorder.StopRecording();

                    RecordButtonIsEnabled = true;
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
                    PlayButtonIsEnabled = false;
                    RecordButtonIsEnabled = false;

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
            PlayButtonIsEnabled = true;
            RecordButtonIsEnabled = true;
        }

        // moved
        private MemoryStream cachedStream;

        private void ExcuteSaveVoice_Clicked()
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

            GetAllFilseName();

        }
        string CurrentVoice = "";
        private void ExcutePlayVoice_Clicked()
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

        private void collectionVoice_SelectionChanged(string item)
        {
            //CurrentVoice = e.CurrentSelection.FirstOrDefault().ToString();
        }


        private Task<bool> GetAllFilseName()
        {
            ListVoice = new ObservableCollection<string>();
            ListVoice.Clear();
            try
            {
                var fullPath = Path.Combine(localPath, "FawzyVoices");
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                var listFiles = dir.GetFiles();

                foreach (var voiceName in listFiles)
                {
                    ListVoice.Add(voiceName.Name);
                }
                OnPropertyChanged("ListVoice");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Task.FromResult(true);
        }


    }
}
