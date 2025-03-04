namespace BuildSrt;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void buttonBuildWav_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        _ = BuildWav.BuildWavFromMovieAsync(openFileDialog.FileName);
    }
}