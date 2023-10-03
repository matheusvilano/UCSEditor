using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using UCSEditor;
using UCSEditor.Extensions;
using System.IO;

namespace UCSEditor.Core
{
    /// <summary>
    /// The UCS View.
    /// </summary>
    public partial class UCSView : ContentPage
    {
        /// <summary>
        /// The default UCS view model.
        /// </summary>
        private readonly UCSViewModel ucsViewModel;

        /// <summary>
        /// Default constructor for UCSView.
        /// </summary>
        public UCSView()
        {
            // TODO: Highlight incorrect items in RED.

            Xamarin.Forms.DataGrid.DataGridComponent.Init();
            InitializeComponent();

            ucsViewModel = (UCSViewModel)BindingContext;
        }

        /// <summary>
        /// Called whenever the browse button is clicked.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private async void ButtonBrowse_Clicked(System.Object sender, System.EventArgs e)
        {
            if (ucsViewModel != null)
            {
                ucsViewModel.TempLog = "Browsing for files...";
                var files = await FilePicker.PickMultipleAsync();

                var fullPaths = new List<string>();
                foreach (var file in files)
                {
                    fullPaths.Add(file.FullPath);
                }

                if (fullPaths.Count > 0)
                {
                    ucsViewModel.GetUCSEntries(fullPaths.ToArray());
                    ucsViewModel.TempLog = "Done reading files.";
                }
                else
                {
                    ucsViewModel.TempLog = "No files selected.";
                }
            }
        }

        /// <summary>
        /// Called whenever the commit button is clicked.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private void ButtonCommit_Clicked(System.Object sender, System.EventArgs e)
        {
            if (ucsViewModel != null)
            {
                ucsViewModel.TempLog = "Commiting changes...";
                uint count = ucsViewModel.RenameUCSEntries();
                ucsViewModel.TempLog = $"Renamed {count} entries.";
            }
        }

        /// <summary>
        /// Called whenever the autofix button is clicked.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private void ButtonAutofix_Clicked(System.Object sender, System.EventArgs e)
        {
            if (ucsViewModel != null)
            {
                // TODO: Apply auto-fixex.
                ucsViewModel.TempLog = "Autofixing entries...";

                bool replaceAll = entrySearch.Text == "*" || entrySearch.Text == "" || entrySearch.Text == null;
                string selectedToken = pickerToken.SelectedItem as string;

                switch (selectedToken)
                {
                    case "CAT ID":
                        foreach(var ucsEntry in ucsViewModel.UCSEntries)
                        {
                            ucsEntry.Category = replaceAll ? entryReplacement.Text : ucsEntry.Category.Replace(entrySearch.Text, entryReplacement.Text);
                        }
                        break;

                    case "FX Name":
                        foreach (var ucsEntry in ucsViewModel.UCSEntries)
                        {
                            ucsEntry.Name = replaceAll ? entryReplacement.Text : ucsEntry.Name.Replace(entrySearch.Text, entryReplacement.Text);
                        }
                        break;

                    case "Creator ID":
                        foreach (var ucsEntry in ucsViewModel.UCSEntries)
                        {
                            ucsEntry.Creator = replaceAll ? entryReplacement.Text : ucsEntry.Creator.Replace(entrySearch.Text, entryReplacement.Text);
                        }
                        break;

                    case "Source ID":
                        foreach (var ucsEntry in ucsViewModel.UCSEntries)
                        {
                            ucsEntry.Source = replaceAll ? entryReplacement.Text : ucsEntry.Source.Replace(entrySearch.Text, entryReplacement.Text);
                        }
                        break;

                    case "User Data":
                        foreach (var ucsEntry in ucsViewModel.UCSEntries)
                        {
                            ucsEntry.UserData = replaceAll ? entryReplacement.Text : ucsEntry.UserData.Replace(entrySearch.Text, entryReplacement.Text);
                        }
                        break;

                    default:
                        ucsViewModel.TempLog = "Failed to run the autofix. Token seems to be invalid.";
                        break;
                }

                ucsViewModel.TempLog = $"Finished running the autofix tool on token \'{selectedToken}\'.";

                entrySearch.Text = "";
                entryReplacement.Text = "";
            }
        }

        /// <summary>
        /// Called whenever the play button is clicked.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private void ButtonPlaySound_Clicked(System.Object sender, System.EventArgs e)
        {
            if (ucsViewModel != null)
            {
                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(ucsViewModel.SelectedUCSEntry.OriginalPath);
                player.Play();
                ucsViewModel.TempLog = $"Playing sound \'{ucsViewModel.SelectedUCSEntry}\'.";
            }
        }

        /// <summary>
        /// Called whenever the stop button is clicked.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private void ButtonStopSound_Clicked(System.Object sender, System.EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Stop();
            ucsViewModel.TempLog = "Stopped all sounds.";
        }

        /// <summary>
        /// Called whenever a new item is selected in the data grid.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private void DataGrid_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (ucsViewModel != null)
            {
                if (ucsViewModel.SelectedUCSEntry != null)
                {
                    ucsViewModel.TempLog = $"Selected: {ucsViewModel.SelectedUCSEntry.OriginalPath}";
                }
            }
        }

        /// <summary>
        /// Called whenever the data grid is refreshing itself.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="e">The event arguments.</param>
        private void DataGrid_Refreshing(System.Object sender, System.EventArgs e)
        {
            if (ucsViewModel != null)
            {
                // TODO: log refresh command information.
            }
        }
    }
}
