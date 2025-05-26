using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

public class SeleniumDownloader
{
    private readonly string _downloadFolder;

    public SeleniumDownloader(string downloadFolder)
    {
        _downloadFolder = downloadFolder;
    }

    public void DescargarExcel(string url)
    {
        var options = new EdgeOptions();
        options.AddUserProfilePreference("download.default_directory", _downloadFolder);
        options.AddUserProfilePreference("download.prompt_for_download", false);
        options.AddUserProfilePreference("disable-popup-blocking", true);

        using var driver = new EdgeDriver(options);
        driver.Navigate().GoToUrl(url);

        // Ajusta el XPath al enlace del archivo Excel que necesites descargar
        var link = driver.FindElement(By.XPath("//a[contains(@href, '.xlsx')]"));
        link.Click();

        // Espera para que la descarga termine (mejor implementa una espera explícita o chequeo de archivo)
        Thread.Sleep(15000);
    }
}
