using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Dropify
{
	public partial class MainForm : Form
	{

		private WaveOutEvent outputDevice;
		private AudioFileReader audioFile;
		private string songItem;
		private YouTubeService youtubeService;

		public MainForm()
		{
			InitializeComponent();
			//InitializeForm();

			// Set your Google API key here
			var apiKey = ConfigurationManager.AppSettings.Get("YoutubeAPI");

			// Create the YouTubeService using the API key
			youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = apiKey
			});
		}

		public async void StartDownloading()
		{
			// Loop through the items in the ListBox and add them to the DataGridView
			foreach (DataGridViewRow row in dataGridViewProgress.Rows)
			{
				if (row.IsNewRow) continue;

				try
				{
					Console.WriteLine("In Progress of downloading");
					// Access the data in each cell of the row using the Cells property
					string artist = row.Cells["ColumnArtist"].Value.ToString();
					string songName = row.Cells["ColumnSong"].Value.ToString();

					// Define the search query
					SearchResource.ListRequest searchRequest = youtubeService.Search.List("snippet");

					string videoTitle = artist + " - " + songName;
					searchRequest.Q = videoTitle;
					searchRequest.MaxResults = 1; // Get only the first result

					// Execute the search and get the results
					SearchListResponse searchResponse = searchRequest.Execute();

					// Check if there are any search results
					if (searchResponse.Items.Count > 0)
					{
						// Extract the URL of the first video
						string videoId = searchResponse.Items[0].Id.VideoId;
						string videoUrl = "https://www.youtube.com/watch?v=" + videoId;

						//Console.WriteLine("YouTube URL of the first result: " + videoUrl);
						await DownloadSong(videoUrl, videoTitle);

						row.Cells["ColumnProgress"].Value = "Done";
					}
					else
					{
						row.Cells["ColumnProgress"].Value = "Not Found";
						//Console.WriteLine("No videos found with the given title.");
					}
				}
				catch (Exception ex)
				{
					row.Cells["ColumnProgress"].Value = "Error";
					//Console.WriteLine("An error occurred: " + ex.Message);
				}
			}
		}

		public async Task DownloadSong(string videoUrl, string name)
		{

			var youtube = new YoutubeClient();

			var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);

			var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

			await using var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

			// Save the audio to a file (adjust the file name and extension as needed)
			var fileName = $"music/{name}.mp3";
			using (var fileStream = File.Create(fileName))
			{
				await stream.CopyToAsync(fileStream);
			}

			Console.WriteLine("Audio downloaded successfully!");
		}


		private void InitializeForm()
		{
			var flowPanel = new FlowLayoutPanel();
			flowPanel.FlowDirection = FlowDirection.LeftToRight;
			flowPanel.Margin = new Padding(5);

			var buttonPlay = new Button();
			buttonPlay.Text = "Play";
			buttonPlay.Click += OnButtonPlayClick;
			flowPanel.Controls.Add(buttonPlay);

			var buttonStop = new Button();
			buttonStop.Text = "Stop";
			buttonStop.Click += OnButtonStopClick;
			flowPanel.Controls.Add(buttonStop);

			var buttonRewind = new Button();
			buttonRewind.Text = "Rewind";
			buttonRewind.Click += OnButtonRewind;
			flowPanel.Controls.Add(buttonRewind);

			this.Controls.Add(flowPanel);

			this.FormClosing += OnButtonStopClick;

			//outputDevice = new WaveOutEvent();
			//audioFile = new AudioFileReader(@"music/Gasolina.mp4");
			//outputDevice.Init(audioFile);
		}

		private void OnButtonPlayClick(object sender, EventArgs args)
		{
			if (outputDevice == null)
			{
				outputDevice = new WaveOutEvent();
				outputDevice.PlaybackStopped += OnPlaybackStopped;
			}
			if (audioFile == null)
			{
				audioFile = new AudioFileReader(@"music/Gasolina.mp4");
				outputDevice.Init(audioFile);
			}

			outputDevice.Play();
		}

		private void OnButtonStopClick(object sender, EventArgs args)
		{
			outputDevice?.Stop();
		}

		private void OnButtonRewind(object sender, EventArgs args)
		{
			audioFile.Position = 11520008;
		}

		private void OnPlaybackStopped(object sender, StoppedEventArgs args)
		{
			outputDevice.Dispose();
			//outputDevice = null;
			audioFile.Dispose();
			//audioFile = null;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			// Check if both fields are filled
			if (string.IsNullOrWhiteSpace(artistInput.Text) || string.IsNullOrWhiteSpace(songInput.Text))
			{
				MessageBox.Show("Please fill in both Artist and Song Name fields.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return; // Stop execution if any field is empty
			}

			songItem = artistInput.Text.Trim() + " - " + songInput.Text.Trim();
			songsList.Items.Add(songItem);

			artistInput.Text = "";
			songInput.Text = "";
			songItem = "";

		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			// Check if an item is selected in the listbox
			if (songsList.SelectedIndex != -1)
			{
				// Remove the selected item from the listbox
				songsList.Items.RemoveAt(songsList.SelectedIndex);
			}
			else
			{
				MessageBox.Show("Please select an item to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void buttonDownload_Click(object sender, EventArgs e)
		{
			// Clear any previous rows in the DataGridView
			dataGridViewProgress.Rows.Clear();
			dataGridViewProgress.Columns.Clear();

			// Add columns to the DataGridView
			dataGridViewProgress.Columns.Add("ColumnArtist", "Artist");
			dataGridViewProgress.Columns.Add("ColumnSong", "Song");
			dataGridViewProgress.Columns.Add("ColumnProgress", "Progress");

			// Loop through the items in the ListBox and add them to the DataGridView
			foreach (var item in songsList.Items)
			{
				// Assuming the items in the ListBox are strings in the format "Artist - Song"
				string[] songData = item.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
				string artist = songData[0];
				string songName = songData[1];

				// Add the data to the DataGridView
				dataGridViewProgress.Rows.Add(artist, songName, "Downloading");
			}

			StartDownloading();
		}
	}
}
