using System;
using System.IO;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YoutubeExplode;
using System.Configuration;
using YoutubeExplode.Videos.Streams;

class Program
{

	public static async Task DownloadSong(string videoUrl, string name)
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

	static async Task Main(string[] args)
	{
		// Set your Google API key here
		var apiKey = ConfigurationManager.AppSettings.Get("YoutubeAPI");

		// Set the title of the video you want to search for
		string videoTitle = "Gasolina";

		// Create the YouTubeService using the API key
		YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
		{
			ApiKey = apiKey
		});

		try
		{
			// Define the search query
			SearchResource.ListRequest searchRequest = youtubeService.Search.List("snippet");
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

			}
			else
			{
				Console.WriteLine("No videos found with the given title.");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("An error occurred: " + ex.Message);
		}
	}
}
